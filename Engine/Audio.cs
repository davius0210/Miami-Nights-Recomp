// javax.microedition.media (MMAPI) surface: Manager.createPlayer + Player.
// WAV -> SoundEffect; MIDI -> built-in SMF parser + soft-synth (MonoGame has no MIDI device access).
// Fidelity note: original used the phone's MMAPI synth; ours approximates timbre,
// preserves song structure, tempo, sequencing and loop counts.
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace MiamiNights
{
    public static class Manager
    {
        public static Player CreatePlayer(Stream stream, string contentType)
        {
            byte[] data;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                data = ms.ToArray();
            }
            return new Player(data, contentType);
        }
    }

    public sealed class Player
    {
        private SoundEffect effect;
        private SoundEffectInstance inst;
        private readonly int totalLoops; // set via SetLoopCount before Start
        private int loopCount;
        private int playedLoops;
        public bool IsRunning { get; private set; }

        public Player(byte[] data, string mime)
        {
            try
            {
                if (mime == "audio/midi")
                {
                    short[] st = SoundFontSynth.Render(data, 300.0);   // SGM-V2.01 SoundFont (stereo 44.1k) if present
                    if (st != null)
                    {
                        using (var wav = Wav.WrapStereo44(st))
                            effect = SoundEffect.FromStream(wav);
                    }
                    else
                    {
                        short[] pcm = MidiSynth.Render(data, 300.0);  // fallback: built-in soft-synth
                        using (var wav = Wav.Wrap(pcm))
                            effect = SoundEffect.FromStream(wav);
                    }
                }
                else // audio/x-wav
                {
                    using (var ms = new MemoryStream(data))
                        effect = SoundEffect.FromStream(ms);
                }
                inst = effect.CreateInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[audio] create failed: " + ex.Message);
            }
        }

        public void Realize() { }
        public void Prefetch() { }

        public void SetLoopCount(int n) { loopCount = n; }

        public void Start()
        {
            if (inst == null) return;
            try
            {
                playedLoops = 0;
                inst.IsLooped = loopCount == -1;
                inst.Play();
                IsRunning = true;
            }
            catch { IsRunning = false; }
        }

        public void Stop()
        {
            if (inst == null) return;
            try { inst.Stop(); } catch { }
            IsRunning = false;
        }

        // finite loop accounting: polled from the per-frame audio pump
        internal void TickLoop()
        {
            if (inst == null || !IsRunning || loopCount == -1 || loopCount == 0) return;
            if (inst.State == SoundState.Stopped)
            {
                playedLoops++;
                if (playedLoops <= loopCount)
                {
                    try { inst.Play(); } catch { IsRunning = false; }
                }
                else
                {
                    IsRunning = false;
                }
            }
        }

        public bool IsPlaying()
        {
            return inst != null && inst.State == SoundState.Playing;
        }

        public void Close()
        {
            Stop();
            try { inst?.Dispose(); effect?.Dispose(); } catch { }
            inst = null; effect = null;
        }

        public void Deallocate() { }
    }

    // ------------------------------------------------------------------
    // SoundFont MIDI rendering (MeltySynth). Default font: res/soundfont/SGM-V2.01.sf2
    // (Shan's GM SoundFont). Override with env MN_SOUNDFONT=<path to .sf2>.
    // ------------------------------------------------------------------
    public static class SoundFontSynth
    {
        public const int SR = 44100;
        private static MeltySynth.SoundFont font;
        private static bool tried;
        private static readonly object gate = new object();

        public static string FontPath()
        {
            string env = Environment.GetEnvironmentVariable("MN_SOUNDFONT");
            if (!string.IsNullOrEmpty(env)) return env;
            return Path.Combine(AppContext.BaseDirectory, "res", "soundfont", "SGM-V2.01.sf2");
        }

        // load in the background at startup so the first song does not stall the game
        public static void Preload() { System.Threading.ThreadPool.QueueUserWorkItem(_ => Font()); }

        private static MeltySynth.SoundFont Font()
        {
            lock (gate)
            {
                if (tried) return font;
                tried = true;
                string p = FontPath();
                if (!File.Exists(p)) { Console.WriteLine("[sf2] not found: " + p + " (using built-in synth)"); return null; }
                try
                {
                    var t0 = DateTime.Now;
                    font = new MeltySynth.SoundFont(p);
                    Console.WriteLine("[sf2] loaded " + Path.GetFileName(p) + " in " + (int)(DateTime.Now - t0).TotalMilliseconds + " ms");
                }
                catch (Exception e) { Console.WriteLine("[sf2] load failed: " + e.Message); font = null; }
                return font;
            }
        }

        // interleaved stereo 16-bit @44.1k, or null when no SoundFont is available
        public static short[] Render(byte[] smf, double maxSeconds)
        {
            var f = Font();
            if (f == null) return null;
            try
            {
                var midi = new MeltySynth.MidiFile(new MemoryStream(smf));
                var synth = new MeltySynth.Synthesizer(f, SR);
                var seq = new MeltySynth.MidiFileSequencer(synth);
                seq.Play(midi, false);
                double secs = Math.Min(midi.Length.TotalSeconds + 1.0, maxSeconds);   // +1s release tail
                int n = Math.Max(1, (int)(SR * secs));
                var l = new float[n]; var r = new float[n];
                seq.Render(l, r);
                var o = new short[n * 2];
                for (int i = 0; i < n; i++)
                {
                    o[2 * i] = (short)Math.Max(-32768, Math.Min(32767, (int)(l[i] * 32767f)));
                    o[2 * i + 1] = (short)Math.Max(-32768, Math.Min(32767, (int)(r[i] * 32767f)));
                }
                return o;
            }
            catch (Exception e) { Console.WriteLine("[sf2] render failed: " + e.Message); return null; }
        }
    }

    internal static class Wav
    {
        // 16-bit stereo PCM WAV @44.1k (interleaved L,R)
        public static MemoryStream WrapStereo44(short[] lr)
        {
            var ms = new MemoryStream();
            var w = new BinaryWriter(ms);
            int dataLen = lr.Length * 2;
            w.Write(new[] { 'R', 'I', 'F', 'F' }); w.Write(36 + dataLen);
            w.Write(new[] { 'W', 'A', 'V', 'E' }); w.Write(new[] { 'f', 'm', 't', ' ' });
            w.Write(16); w.Write((short)1); w.Write((short)2);
            w.Write(SoundFontSynth.SR); w.Write(SoundFontSynth.SR * 4);
            w.Write((short)4); w.Write((short)16);
            w.Write(new[] { 'd', 'a', 't', 'a' }); w.Write(dataLen);
            foreach (short v in lr) w.Write(v);
            ms.Position = 0;
            return ms;
        }

        // 16-bit mono PCM WAV container around sample data
        public static MemoryStream Wrap(short[] samples)
        {
            var ms = new MemoryStream();
            var w = new BinaryWriter(ms);
            int dataLen = samples.Length * 2;
            w.Write(new[] { 'R', 'I', 'F', 'F' });
            w.Write(36 + dataLen);
            w.Write(new[] { 'W', 'A', 'V', 'E' });
            w.Write(new[] { 'f', 'm', 't', ' ' });
            w.Write(16);
            w.Write((short)1);          // PCM
            w.Write((short)1);          // mono
            w.Write(22050);             // sample rate
            w.Write(22050 * 2);         // byte rate
            w.Write((short)2);          // block align
            w.Write((short)16);         // bits
            w.Write(new[] { 'd', 'a', 't', 'a' });
            w.Write(dataLen);
            foreach (short s in samples) w.Write(s);
            ms.Position = 0;
            return ms;
        }
    }

    // ------------------------------------------------------------------
    // Minimal SMF (Standard MIDI File) parser + subtractive soft-synth.
    // Supports: format 0/1, note on/off, program change, tempo meta, sustain-lite,
    // channel 10 percussion, running status. Tempo map honored; 22050 Hz mono out.
    // ------------------------------------------------------------------
    public static class MidiSynth
    {
        private sealed class Ev
        {
            public double Time;     // seconds
            public bool On;
            public int Ch, Note, Vel, Prog;
        }

        public static short[] Render(byte[] smf, double maxSeconds)
        {
            const int SR = 22050;
            var events = new List<Ev>();
            double endTickTime = 0;

            try
            {
                int pos = 0;
                if (ReadU32(smf, ref pos) != 0x4D546864) return new short[0];
                int hdrLen = (int)ReadU32(smf, ref pos);
                int fmt = ReadU16(smf, ref pos);
                int ntrks = ReadU16(smf, ref pos);
                int division = ReadU16(smf, ref pos);
                pos += hdrLen - 6;
                if (fmt > 1) return new short[0];

                bool smpte = (division & 0x8000) != 0;
                double secPerTick = 0; // computed after tempo events; use tick→sec via tempo map

                // gather raw events with tick stamps + tempo changes
                var raw = new List<(long tick, int type, int a, int b)>();
                var tempos = new List<(long tick, int usPerQn)>();
                long tpq = smpte ? 480 : (division & 0x7FFF);
                tempos.Add((0, 500000));

                for (int t = 0; t < ntrks && pos + 8 <= smf.Length; t++)
                {
                    if (ReadU32(smf, ref pos) != 0x4D54726B) break;
                    int len = (int)ReadU32(smf, ref pos);
                    int end = pos + len;
                    long tick = 0;
                    int status = 0;
                    while (pos < end && pos < smf.Length)
                    {
                        tick += ReadVlq(smf, ref pos);
                        if (pos >= smf.Length || pos >= end + 8) break;   // bounds guard (fuzzed/packed tracks)
                        int b0 = smf[pos++] & 0xFF;
                        if (b0 >= 0xF0)
                        {
                            if (b0 == 0xFF)
                        {
                                if (pos >= smf.Length) break;
                                int meta = smf[pos++] & 0xFF;
                                int mlen = (int)ReadVlq(smf, ref pos);
                                if (pos + mlen > smf.Length) break;
                                if (meta == 0x51 && mlen == 3)
                                {
                                    int us = ((smf[pos] & 0xFF) << 16) | ((smf[pos + 1] & 0xFF) << 8) | (smf[pos + 2] & 0xFF);
                                    tempos.Add((tick, us));
                                }
                                pos += mlen;
                            }
                            else if (b0 == 0xF0 || b0 == 0xF7)
                            {
                                int slen = (int)ReadVlq(smf, ref pos);
                                pos += slen;
                            }
                        }
                        else
                        {
                            if ((b0 & 0x80) != 0) { status = b0; }   // b0 already consumed by pos++
                            int hi = status & 0xF0;
                            int ch = status & 0x0F;
                            if (hi == 0xC0 || hi == 0xD0)
                            {
                                // running status: b0 IS the data byte
                                int d1 = (b0 & 0x80) != 0 ? (pos < smf.Length ? smf[pos++] & 0xFF : 0) : b0;
                                raw.Add((tick, hi | ch, d1, 0));
                            }
                            else
                            {
                                int d1, d2;
                                if ((b0 & 0x80) != 0)
                                {
                                    if (pos + 1 >= smf.Length) break;
                                    d1 = smf[pos++] & 0xFF;
                                    d2 = smf[pos++] & 0xFF;
                                }
                                else
                                {
                                    if (pos >= smf.Length) break;
                                    d1 = b0;   // running status: b0 = first data byte
                                    d2 = smf[pos++] & 0xFF;
                                }
                                raw.Add((tick, hi | ch, d1, d2));
                            }
                        }
                    }
                    pos = end;
                }

                // tempo map: tick -> seconds
                tempos.Sort((x, y) => x.tick.CompareTo(y.tick));
                double TickToSec(long tick)
                {
                    double sec = 0;
                    long lastTick = 0;
                    int us = 500000;
                    foreach (var tp in tempos)
                    {
                        if (tp.tick >= tick) break;
                        long span = tp.tick - lastTick;
                        sec += span * (us / 1e6) / tpq;
                        lastTick = tp.tick;
                        us = tp.usPerQn;
                    }
                    sec += (tick - lastTick) * (us / 1e6) / tpq;
                    return sec;
                }

                // Note: program-change data is parsed for structural completeness only;
                // timbre selection is driven by percussion flag (ch 10) + envelope shape.
                foreach (var (tick, type, a, b) in raw)
                {
                    int hi = type & 0xF0, ch = type & 0x0F;
                    double time = TickToSec(tick);
                    endTickTime = Math.Max(endTickTime, time);
                    switch (hi)
                    {
                        case 0x90 when b > 0:
                            events.Add(new Ev { Time = time, On = true, Ch = ch, Note = a & 0x7F, Vel = b });
                            break;
                        case 0x90 when b == 0:
                        case 0x80:
                            events.Add(new Ev { Time = time, On = false, Ch = ch, Note = a & 0x7F, Vel = 0 });
                            break;
                        case 0xC0:
                            break; // program change: acknowledged, no timbre model
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[midi] parse failed: " + ex.Message);
                return new short[0];
            }

            // ---- render ----
            double duration = Math.Min(maxSeconds, endTickTime + 2.0);
            if (duration <= 0) return new short[0];
            int total = (int)(duration * SR);
            var outPcm = new short[total];

            // voices
            var voice = new Voice[16];
            for (int i = 0; i < 16; i++) voice[i] = new Voice();

            events.Sort((x, y) =>
            {
                int c = x.Time.CompareTo(y.Time);
                if (c != 0) return c;
                return (x.On ? 1 : 0).CompareTo(y.On ? 1 : 0); // offs before ons at same time
            });

            int ei = 0;
            for (int n = 0; n < total; n++)
            {
                double t = n / (double)SR;
                while (ei < events.Count && events[ei].Time <= t)
                {
                    Ev e = events[ei++];
                    Voice v = voice[e.Ch];
                    if (e.On) v.NoteOn(e.Note, e.Vel, e.Ch == 9);
                    else v.NoteOff(e.Note);
                }
                float sample = 0f;
                for (int c = 0; c < 16; c++) sample += voice[c].Tick(1.0 / SR);
                sample = Math.Min(1f, Math.Max(-1f, sample * 0.25f));
                outPcm[n] = (short)(sample * short.MaxValue);
            }
            return outPcm;
        }

        private sealed class Voice
        {
            private int note = -1;
            private double phase;
            private double env, release = 1;
            private bool on, perc;
            private int vel;
            private Random rnd = new Random(1234);

            public void NoteOn(int n, int v, bool isPerc)
            {
                note = n; vel = v; on = true; perc = isPerc; env = 0; release = 1;
                phase = 0;
            }

            public void NoteOff(int n)
            {
                if (on && note == n) on = false;
            }

            public float Tick(double dt)
            {
                if (note < 0) return 0f;
                if (on)
                {
                    env += dt * 8.0;         // ~125ms attack
                    if (env > 1) env = 1;
                }
                else
                {
                    release -= dt * 6.0;     // ~166ms release
                    if (release <= 0) { note = -1; return 0f; }
                }

                double freq = 440.0 * Math.Pow(2.0, (note - 69) / 12.0);
                double amp = env * release * (vel / 127.0) * (perc ? 0.9 : 0.7);
                double s;
                if (perc)
                {
                    // noise-ish percussion
                    s = (rnd.NextDouble() * 2 - 1) * Math.Exp(-phase * (note < 50 ? 8 : 20));
                }
                else
                {
                    phase += freq * dt;
                    if (phase > 1) phase -= Math.Floor(phase);
                    // program-shaped: default square; piano-ish decay via env handled above
                    s = phase < 0.5 ? 1 : -1;
                    // light lowpass blend with sine to tame harshness
                    s = 0.65 * s + 0.35 * Math.Sin(2 * Math.PI * phase);
                }
                phase += perc ? dt : 0;
                return (float)(s * amp);
            }
        }

        private static uint ReadU32(byte[] b, ref int pos)
        {
            uint v = (uint)((b[pos] << 24) | (b[pos + 1] << 16) | (b[pos + 2] << 8) | b[pos + 3]);
            pos += 4;
            return v;
        }

        private static int ReadU16(byte[] b, ref int pos)
        {
            int v = (b[pos] << 8) | b[pos + 1];
            pos += 2;
            return v;
        }

        private static long ReadVlq(byte[] b, ref int pos)
        {
            long v = 0;
            byte c;
            do { c = b[pos++]; v = (v << 7) | (c & 0x7F); } while ((c & 0x80) != 0 && pos < b.Length);
            return v;
        }
    }
}
