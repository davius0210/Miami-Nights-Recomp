# Miami Nights – Widescreen Enhancement Task

> **INSTRUKSI UNTUK ChatGPT (wajib dibaca):**
> Untuk bagian art (Bagian 5.A), **gunakan fitur image generation / image editing (imagegen)** milik ChatGPT
> untuk benar-benar menghasilkan file gambar PNG. Jangan hanya menjelaskan, menulis kode, atau memberi
> deskripsi teks. Untuk setiap gambar yang saya unggah: edit/perluas gambar tersebut dengan imagegen,
> kembalikan hasilnya sebagai gambar yang bisa diunduh, satu gambar per hasil, dengan nama file yang sama
> seperti aslinya. Pertahankan bagian tengah gambar persis seperti aslinya dan hanya perluas sisi
> kiri/kanan. Tanpa anti-aliasing, tanpa blur, gaya pixel art isometrik yang sama.
> Bagian kode (5.B) tidak perlu dikerjakan di ChatGPT; itu dilanjutkan di Claude Code.

Dokumen serah-terima untuk melanjutkan pekerjaan di ChatGPT (atau tool lain).
Proyek: rekonstruksi C#/MonoGame (DesktopGL, net8.0) dari game J2ME
"Miami Nights - Singles in The City" (480x800, Samsung S8000).
Folder proyek: `D:\Development\REA-Project\MiamiNight\rebuild`

## 1. Tujuan

Game aslinya portrait 480x800. Target: tampilan **benar-benar wide (16:9)** seperti game modern,
dengan asset yang di-enhance (outpaint latar ke 16:9, upscale sprite/UI tetap bergaya pixel art).

## 2. Arsitektur render (hasil analisis)

- Game menggambar ke kanvas logis **240x400** (offscreen `aM`, graphics `aN`), lalu di-upscale 2x
  (`h.cs` `m_a(Graphics, Image)` / `m_b(Graphics,int,int)`) ke buffer layar 480x800 (`Game1.screenImage`, ARGB int[]).
- `Game1.Present()` menukar ARGB -> ABGR dan meng-upload ke `presentTex`, lalu menggambar ke window.
- Layout vertikal kanvas logis: status bar `y 0..75`, **area dunia `y 75..315` (240x240)**, HUD/dialog `y 315..400`.
- Konstanta 240/400 dikodekan langsung di ~200 tempat (`h.cs`, `f.cs`, `g.cs`, `c.cs`), mis.
  `SetClip(0,75,240,240)`, `FillRect(0,0,240,400)`.
- Peta kota: kamera `f.C`, `f.D`; layer tile digambar lewat `f.m_a(g, 3, C, D, 240, 240, 0, 75)` (`f.cs` ~2616).
  Posisi entitas memakai `worldY - D + 75` (`f.cs` ~2352, 2658, 2873, 2996, 3076, 3106, 4953, 5310).
- Interior (kamar tidur, state 34, `f.m_c(Graphics,int)` `f.cs` ~4061) adalah komposisi sprite statis
  selebar 240; **tidak ada piksel di luar kamar** (sisi hanya warna cokelat polos).
- Resource: `res/0 … res/21` (arsip sprite berisi PNG tertanam), `res/dataIGP`, `res/sfx_shower.wav`.
- Loader PNG: `Engine/Midp.cs` `Image.CreateImage(byte[])`.

## 3. Yang SUDAH selesai

1. **Warna serba biru** – diperbaiki. Penyebab: `Texture2D.GetData` menghasilkan ABGR, engine memakai ARGB.
   Perbaikan di `Engine/Midp.cs` (konversi + un-premultiply) dan `Game1.cs` `Present()` (ARGB->ABGR sekali).
2. **Sprite menghadap kiri berantakan** – diperbaiki. Penyebab: konstanta transform MIDP salah.
   Benar: 0 NONE, 1 MIRROR_ROT180 (flip V), 2 MIRROR (flip H), 3 ROT180, 4 MIRROR_ROT270,
   5 ROT90, 6 ROT270, 7 MIRROR_ROT90. Diperbaiki di `Graphics.DrawRegion` (`Engine/Midp.cs`).
3. **Window landscape**: resizable (default 1280x720), F11 fullscreen, letterbox dengan latar blur.
4. **Compositor wide (tahap 1, procedural)** di `Game1.cs` (`DrawWide`, `Layout`, `WideToLegacy`):
   - Aktif hanya saat gameplay (terdeteksi lewat `Graphics.WorldClipSeen`, di-set oleh `SetClip(0,75,240,240)`).
   - Area dunia (device px `0,150,480,480`) diperbesar mengisi tinggi layar, sisi kiri/kanan diisi
     mirror dunia yang digelapkan.
   - HUD dipindah ke tepi: jam kiri atas, ikon `$` + uang kanan atas, bar aksi bawah tengah.
   - Klik mouse dipetakan balik ke koordinat game. F10 = toggle mode wide.
   - **Belum diverifikasi visual saat gameplay** (koordinat potongan jam/uang adalah perkiraan:
     `SrcClock`, `SrcMoneyIcon`, `SrcMoney`, `SrcHud` di `Game1.cs`).

## 4. Batasan saat ini

Compositor hanya memperbesar dan memperluas secara procedural. **Dunia tidak menampilkan area lebih luas.**
Untuk benar-benar lebih lebar perlu (a) kamera/viewport peta kota dilebarkan, dan (b) art baru untuk interior.

## 5. Sisa pekerjaan

### A. Art (bagian yang akan dikerjakan di ChatGPT)
1. Ekstrak semua PNG dari `res/0..21` (arsip: header kecil lalu PNG tertanam, lihat `xxd res/0`;
   PNG dimulai pada signature `89 50 4E 47`). Pisahkan: latar kamar/kota, sprite karakter, UI.
2. Outpaint tiap **latar interior** ke 16:9 (lantai, dinding, furnitur diperluas, gaya pixel art isometrik sama).
3. Outpaint/extend **tile peta kota** bila diperlukan, upscale sprite/UI dengan filter pixel-art
   (nearest / xBR), jangan blur.
4. Kunci hasil ke palet asli dan grid piksel asli (kuantisasi) supaya gaya konsisten.
5. Simpan hasil dengan nama sama di folder `enhanced/` untuk diintegrasikan.

### B. Kode
1. Melebarkan kanvas logis (240 -> lebar 16:9) dan viewport dunia; ganti konstanta `240`/`400`/`75`
   yang menyangkut area dunia dengan konstanta global (`VIEW_W`, `VIEW_H`, `VIEW_Y`).
2. Pusatkan kamera `f.C/f.D` pada pemain dengan clamp ke tepi peta; sesuaikan culling entitas.
3. Interior: tempatkan komposisi kamar di tengah dan pakai latar hasil outpaint di sisi.
4. Layout HUD final di tepi layar (tanpa hitungan perkiraan).
5. Uji tiap scene: kamar tidur, kota, dialog, menu. Gunakan F12 (`shot_f12.png`) untuk screenshot
   frame legacy.

## 6. Prompt contoh untuk ChatGPT (outpaint kamar)

> Gunakan image generation (imagegen) untuk membuat gambar hasilnya, jangan jawab dengan teks saja.
> Ini adalah screenshot interior game pixel art isometrik (resolusi 240x240). Perluas gambar ke kiri dan
> kanan menjadi rasio 16:9 (misal 427x240) dengan gaya pixel art identik: palet terbatas, tanpa
> anti-aliasing, tanpa blur, garis dan sudut isometrik yang sama. Pertahankan bagian tengah persis
> seperti aslinya (jangan diubah). Perluas lantai, dinding, dan tambahkan furnitur sejenis secara wajar.
> Output PNG, latar tidak transparan.

Tips: minta gambar kecil (native 240px) lalu upscale integer dengan nearest-neighbor sendiri;
hasil AI sering tidak tepat per piksel, jadi tahap kuantisasi ke palet asli tetap diperlukan.

## 7. Build & run

```
cd D:\Development\REA-Project\MiamiNight\rebuild
dotnet build
dotnet run
```
Tutup game yang sedang berjalan sebelum build (file `MiamiNight.exe` terkunci). Alternatif:
`dotnet build -o D:\dev-cache\tmp\mn_out` lalu salin folder `res` ke sana.

## 8. Catatan lingkungan

- Server MCP `fal` gagal konek (401): `FAL_KEY` tidak terset di environment. Tidak dibutuhkan bila memakai ChatGPT.
- Tombol: F10 toggle mode wide, F11 fullscreen, F12 screenshot.
