# Pharmacy Inventory Management System

A simple **Pharmacy Inventory Management System** built using **C#
(Console Application)** with the **MVC pattern**.\
Project ini memiliki fitur CRUD untuk mengelola data obat seperti
menambah, melihat, mengubah, dan menghapus obat.

## 🚀 Fitur Utama

- Menambahkan obat baru
- Menampilkan daftar obat
- Mengupdate informasi obat
- Menghapus obat dari inventory
- Penyimpanan data berbasis JSON (local file)

## 🧱 Struktur Folder

    /Controllers
        ProductController.cs
    /Models
        Product.cs
        ProductModels.cs
    /Data
        products.json
    Program.cs

### Penjelasan Struktur

- **Product.cs** → berisi class POCO (model data obat).
- **ProductModels.cs** → berisi logika CRUD (Add, Update, Delete,
  GetAll).
- **ProductController.cs** → penghubung antara View dan Model,
  memanggil fungsi CRUD.
- **Program.cs** → menu utama aplikasi (View).

## 🧩 Teknologi yang Digunakan

- C#
- .NET Console App
- JSON Storage (System.Text.Json)

## 📦 Cara Menjalankan

1.  Clone repository:

    ```bash
    git clone https://github.com/Rifqihamza/pharmacy-inventory.git
    ```

2.  Masuk folder project:

    ```bash
    cd pharmacy-inventory
    ```

3.  Jalankan aplikasi:

    ```bash
    dotnet run
    ```

## 📘 Contoh Menu Program

    1. Tambah Obat
    2. Lihat Obat
    3. Update Obat
    4. Hapus Obat
    5. Keluar

## 📝 Catatan Pengembangan

- Ke depan bisa ditambahkan fitur login.
- Dapat diupgrade menjadi aplikasi WinForms atau WebApp.
- Dapat menambahkan database seperti MySQL/SQLServer.

## 📄 Lisensi

MIT License -- bebas digunakan dan dikembangkan kembali.
