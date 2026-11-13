// javax.microedition.rms.RecordStore — same open/enumerate/get/set/add semantics,
// persisted as one file per store next to the executable (saves/).
using System;
using System.Collections.Generic;
using System.IO;

namespace MiamiNights
{
    public sealed class RecordStoreException : Exception { public RecordStoreException(string m) : base(m) { } }
    public sealed class InvalidRecordIDException : Exception { public InvalidRecordIDException(string m) : base(m) { } }

    public sealed class RecordEnumeration
    {
        private readonly RecordStore store;
        private readonly List<int> ids;
        private int cursor = -1;

        internal RecordEnumeration(RecordStore s)
        {
            store = s;
            ids = s.Ids();
            cursor = -1;
        }

        public bool HasNextElement() { return cursor + 1 < ids.Count; }

        public int NextRecordId()
        {
            if (cursor + 1 >= ids.Count) throw new InvalidRecordIDException("no record");
            cursor++;
            return ids[cursor];
        }

        public void Reset() { cursor = -1; }
        public void Destroy() { }
    }

    public sealed class RecordStore
    {
        private static readonly Dictionary<string, RecordStore> open = new Dictionary<string, RecordStore>();

        internal readonly Dictionary<int, byte[]> records = new Dictionary<int, byte[]>();
        internal readonly List<int> order = new List<int>();
        private int nextId = 1;
        private readonly string path;
        private int openCount;

        private RecordStore(string name)
        {
            string dir = Path.Combine(AppContext.BaseDirectory, "saves");
            Directory.CreateDirectory(dir);
            path = Path.Combine(dir, Sanitize(name) + ".rms");
            Load();
        }

        private static string Sanitize(string n)
        {
            foreach (char c in Path.GetInvalidFileNameChars()) n = n.Replace(c, '_');
            return n;
        }

        public static RecordStore OpenRecordStore(string name, bool autoCreate)
        {
            if (!open.TryGetValue(name, out var rs))
            {
                rs = new RecordStore(name);
                open[name] = rs;
            }
            rs.openCount++;
            return rs;
        }

        public RecordEnumeration EnumerateRecords(object filter, object comparator, bool keepUpdated)
        {
            return new RecordEnumeration(this);
        }

        internal List<int> Ids() { return new List<int>(order); }

        public byte[] GetRecord(int id)
        {
            if (!records.TryGetValue(id, out var b)) throw new InvalidRecordIDException("id " + id);
            var copy = new byte[b.Length];
            Array.Copy(b, copy, b.Length);
            return copy;
        }

        public int GetRecordSize(int id)
        {
            if (!records.TryGetValue(id, out var b)) throw new InvalidRecordIDException("id " + id);
            return b.Length;
        }

        public void SetRecord(int id, byte[] data, int offset, int numBytes)
        {
            if (!records.ContainsKey(id)) throw new InvalidRecordIDException("id " + id);
            var b = new byte[numBytes];
            Array.Copy(data, offset, b, 0, numBytes);
            records[id] = b;
            Save();
        }

        public int AddRecord(byte[] data, int offset, int numBytes)
        {
            var b = new byte[numBytes];
            Array.Copy(data, offset, b, 0, numBytes);
            int id = nextId++;
            records[id] = b;
            order.Add(id);
            Save();
            return id;
        }

        public void CloseRecordStore()
        {
            if (openCount > 0) openCount--;
        }

        public void DeleteRecord(int id)
        {
            if (!records.Remove(id)) throw new InvalidRecordIDException("id " + id);
            order.Remove(id);
            Save();
        }

        private void Load()
        {
            if (!File.Exists(path)) return;
            using (var fs = File.OpenRead(path))
            using (var br = new BinaryReader(fs))
            {
                nextId = br.ReadInt32();
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    int id = br.ReadInt32();
                    int len = br.ReadInt32();
                    records[id] = br.ReadBytes(len);
                    order.Add(id);
                }
            }
        }

        private void Save()
        {
            using (var fs = File.Create(path))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(nextId);
                bw.Write(order.Count);
                foreach (int id in order)
                {
                    byte[] b = records[id];
                    bw.Write(id);
                    bw.Write(b.Length);
                    bw.Write(b);
                }
            }
        }
    }
}
