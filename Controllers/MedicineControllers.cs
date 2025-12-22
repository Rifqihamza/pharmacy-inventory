using System.Diagnostics.Contracts;
using pharmacyInventory.Models;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        // Menampilkan Tulisan Header Di Setiap Function CRUD, Search, Filter
        public static void HeaderController(string title)
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine($"------ {title} ------");
            Console.WriteLine("===============================");
        }

        // Memberhentikan Program Sementara dan Menunggu User Beri Aksi Untuk Lanjut
        public static void PauseController()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Press any key to continue....");
            Console.WriteLine("-----------------------------");
            Console.ReadKey();
            Console.Clear();
        }

        // Sub Menu Untuk User Memilih Lanjut ke Menu Yang Di Inginkan Atau Kembali Ke Menu Sebelumnya
        private static int SubMenuController(string message)
        {
            Console.WriteLine();
            Console.WriteLine($"1. {message}");
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.Write("Pilih Menu: ");

            string input_0502 = Console.ReadLine() ?? "";

            if (input_0502 == "1")
                return 1;
            if (input_0502 == "2")
                return 2;

            Console.Clear();
            Console.WriteLine("=============== Pilihan Tidak Valid! ===============");
            Console.WriteLine();
            PauseController();
            return 2;
        }

        /*
        Controller Yang Di Munculkan Di Menu Update, Delete, Search, Filter
        Agar Membantu User Untuk Melihat Data Sebelum Melakukan Aksi
       */
        private static void ReadInlineController(MedicineService medicineService)
        {
            /* Memunculkan Element Header pada setiap menu di console */
            HeaderController("Data Semua Obat");

            /*
            Membuat variabel baru dengan tipe data var
            agar tipe data di tentukan oleh compiler
            */

            var list_0502 = medicineService.ReadService();

            /*
            Pengecekan untuk list jika tidak ada data maka akan menampilkan pesan tidak ada obat
            Jika terdapat obat maka langsung merender data menggunakan foreach yang diambil dari
            variabel list_0502
            */

            if (list_0502.Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("============== Tidak Ada Data Obat! ==============");
                Console.WriteLine("==================================================");
                Console.WriteLine();
            }
            else
            {
                foreach (var m in list_0502)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine();
                    Console.WriteLine($" ID Obat        : {m.IdMedicine_0502}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine_0502}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine_0502}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine_0502}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine_0502}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine_0502}");
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                }
            }
        }

        // Function Controller Untuk Membuat atau Menambah Data Obat Baru
        public static void CreateController(MedicineService medicineService)
        {
            HeaderController("Tambah Data Obat");

            if (SubMenuController("Tambah Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            Console.Write("Nama Obat     : ");
            string name_0502 = Console.ReadLine() ?? "";
            if (name_0502 == "")
            {
                Console.Clear();
                Console.WriteLine("============ Nama Tidak Boleh Kosong! ============");
                PauseController();
                return;
            }

            if (name_0502.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("============ Nama Harus Lebih Dari 2 Huruf! ============");
                PauseController();
                return;
            }

            Console.Write("Deskripsi     : ");
            string desc_0502 = Console.ReadLine() ?? "";

            Console.Write("Kategori (OB/OBT/OK/PS/NA): ");
            string cat_0502 = Console.ReadLine() ?? "";

            string[] validCategories = ["OB", "OBT", "OK", "PS", "NA"];
            if (!validCategories.Contains(cat_0502.ToUpper()))
            {
                Console.Clear();
                Console.WriteLine("========== Kategori Harus Sesuai Pilihan! =========");
                PauseController();
                return;
            }

            if (cat_0502 == "")
            {
                Console.Clear();
                Console.WriteLine("========== Kategori Tidak Boleh Kosong! =========");
                PauseController();
                return;
            }

            Console.Write("Harga         : ");
            string priceInput = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(priceInput))
            {
                Console.Clear();
                Console.WriteLine("============ Harga Tidak Boleh Kosong! ============");
                PauseController();
                return;
            }

            if (!int.TryParse(priceInput, out int price))
            {
                Console.Clear();
                Console.WriteLine("============ Harga Harus Angka Valid! ============");
                PauseController();
                return;
            }

            if (price < 0)
            {
                Console.Clear();
                Console.WriteLine("============ Harga Harus Lebih Dari 0! ============");
                PauseController();
                return;
            }

            Console.Write("Stok          : ");
            string stockInput = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(stockInput))
            {
                Console.Clear();
                Console.WriteLine("============ Stok Tidak Boleh Kosong! ============");
                PauseController();
                return;
            }

            if (!int.TryParse(stockInput, out int stock))
            {
                Console.Clear();
                Console.WriteLine("============ Stok Harus Angka Valid! ============");
                PauseController();
                return;
            }

            if (stock < 0)
            {
                Console.Clear();
                Console.WriteLine("============ Stok Harus Lebih Dari 0! ============");
                PauseController();
                return;
            }

            try
            {
                medicineService.CreateService(name_0502, desc_0502, cat_0502, price, stock);

                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("== Data obat baru berhasil ditambahkan! ==");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                Console.WriteLine($" Nama Obat      : {name_0502}");
                Console.WriteLine($" Deskripsi Obat : {desc_0502}");
                Console.WriteLine($" Kategori Obat  : {cat_0502}");
                Console.WriteLine($" Harga Obat     : {price}");
                Console.WriteLine($" Stok Obat      : {stock}");
                Console.WriteLine();
                Console.WriteLine("==========================================");
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine($"Validasi gagal: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error: {ex.Message}");
            }

            PauseController();
        }

        // Function Controller Untuk Membaca atau Mengambil Data Obat Yang Tersedia
        public static void ReadController(MedicineService medicineService)
        {
            /* Memunculkan Element Header pada setiap menu di console */
            HeaderController("Lihat Data Semua Obat");

            /*
            Pengecekan pada saat Sub Menu Muncul
            Jika user menginput angka 2 maka akan kembali ke menu utama
            Tapi jika input selain 2 atau input angka 1, maka akan lanjut ke
            menu selanjutnya
             */

            if (SubMenuController("Lihat Data Semua Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            Console.WriteLine();

            /*
            Membuat variabel baru dengan tipe data var
            agar tipe data di tentukan oleh compiler
            */

            var list_0502 = medicineService.ReadService();

            /*
            Pengecekan untuk list jika tidak ada data maka akan menampilkan pesan tidak ada obat
            Jika terdapat obat maka langsung merender data menggunakan foreach yang diambil dari
            variabel list_0502
            */
            if (list_0502.Count == 0)
            {
                Console.WriteLine("========== Tidak Ada Data Obat! ==========");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("===== Data Semua Obat di Inventory! =====");
                Console.WriteLine("=========================================");

                foreach (var m in list_0502)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine($" ID Obat        : {m.IdMedicine_0502}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine_0502}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine_0502}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine_0502}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine_0502}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine_0502}");
                    Console.WriteLine("=========================================");
                }
            }
            // Memunculkan method pause untuk user melihat data terlebih dahulu sebelum lanjut
            PauseController();
        }

        // Function Controller Untuk Ubah Data Obat Berdasarkan ID
        public static void UpdateController(MedicineService medicineService)
        {
            /* Memunculkan Element Header pada setiap menu di console */
            HeaderController("Ubah Data Obat");

            /*
            Pengecekan pada saat Sub Menu Muncul
            Jika user menginput angka 2 maka akan kembali ke menu utama
            Tapi jika input selain 2 atau input angka 1, maka akan lanjut ke
            menu selanjutnya
             */
            if (SubMenuController("Ubah Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            /*
            Memanggil method ReadInlineController untuk memunculkan data obat
            Ini membantu user agar tidak kebingungan saat ingin update data
            */

            ReadInlineController(medicineService);

            // Input untuk memilih data obat berdasarkan ID
            Console.Write("Masukkan ID Obat yang ingin diubah: ");
            string idInput_0502 = Console.ReadLine() ?? "";

            // Kondisi untuk mencoba untuk parsing ID dari string ke integer

            // Jika data input tidak bisa di ubah atau di parsing maka akan muncul error,
            if (!int.TryParse(idInput_0502, out int id_0502))
            {
                Console.Clear();
                Console.WriteLine("=========== ID Obat Harus Angka Valid! ===========");
                PauseController();
                return;
            }
            // Pengecekan jika angka input ID kurang dari 0, maka error ID obat tidak boleh 0
            if (id_0502 < 0)
            {
                Console.Clear();
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                PauseController();
                return;
            }

            // Menginisiasi variabel medicine untuk mengambil data berdasarkan ID dari method service GetById
            var medicine_0502 = medicineService.GetById(id_0502);

            // Jika ID obat dari variabel tersebut tidak ada, maka data obat tidak ditemukan
            if (medicine_0502 == null)
            {
                Console.Clear();
                Console.WriteLine("=========== Data Obat Tidak Ditemukan! ===========");
                PauseController();
                return;
            }

            Console.Write($"Nama Obat Baru ({medicine_0502.NameMedicine_0502}) : ");
            string nameInput_0502 = Console.ReadLine() ?? "";
            if (nameInput_0502 != "")
                medicine_0502.NameMedicine_0502 = nameInput_0502;

            Console.Write($"Deskripsi Baru ({medicine_0502.DescMedicine_0502}) : ");
            string descInput_0502 = Console.ReadLine() ?? "";
            if (descInput_0502 != "")
                medicine_0502.DescMedicine_0502 = descInput_0502;

            Console.Write($"Kategori Baru ({medicine_0502.CatMedicine_0502}) : ");
            string catInput_0502 = Console.ReadLine() ?? "";
            if (catInput_0502 != "")
                medicine_0502.CatMedicine_0502 = catInput_0502;

            Console.Write($"Harga Baru ({medicine_0502.PriceMedicine_0502}) : ");
            string newPriceInput_0502 = Console.ReadLine() ?? "";

            // Pengecekan untuk input harga, jika harga yang di input tidak di isi, maka data tidak berubah dan tetap data sebelumnya
            if (!string.IsNullOrWhiteSpace(newPriceInput_0502))
            {
                // Setelah pengecekan input kosong, dilakukan pengecekan untuk coba di parsing dari string ke integer
                if (!int.TryParse(newPriceInput_0502, out int newPrice_0502))
                {
                    Console.Clear();
                    Console.WriteLine("=========== Harga Obat Harus Angka Valid! ===========");
                    PauseController();
                    return;
                }

                // Pengecekan untuk data harga yang di input kurang dari 0, maka akan menampilkan error
                if (newPrice_0502 < 0)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "=========== Harga Tidak Boleh Kurang Dari 0! =============="
                    );
                    PauseController();
                    return;
                }

                medicine_0502.PriceMedicine_0502 = newPrice_0502;
            }

            // Pengecekan untuk stok sama seperti harga
            Console.Write($"Stok Baru ({medicine_0502.StockMedicine_0502}) : ");
            string newStockInput_0502 = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(newStockInput_0502))
            {
                if (!int.TryParse(newStockInput_0502, out int newStock_0502))
                {
                    Console.Clear();
                    Console.WriteLine("=========== Stok Obat Harus Angka Valid! ===========");
                    PauseController();
                    return;
                }

                if (newStock_0502 < 0)
                {
                    Console.Clear();
                    Console.WriteLine("=========== Stok Harus Lebih Dari 0! ===============");
                    PauseController();
                    return;
                }

                medicine_0502.StockMedicine_0502 = newStock_0502;
            }

            /*
            Jika sudah selesai input, maka akan lanjut untuk mencoba memasukkan data
            disini memanggil service untuk melakukan validasi data dari input dan masuk ke
            memori sistem
            */
            try
            {
                medicineService.UpdateService(
                    id_0502,
                    medicine_0502.NameMedicine_0502,
                    medicine_0502.DescMedicine_0502,
                    medicine_0502.CatMedicine_0502.ToUpper(),
                    medicine_0502.PriceMedicine_0502,
                    medicine_0502.StockMedicine_0502
                );
                // Ketika pengecekan sudah berhasil maka akan memunculkan pesan berhasil dan terlihat list data obat baru
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("===== Data obat berhasil diperbarui! =====");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                Console.WriteLine($" ID Obat        : {medicine_0502.IdMedicine_0502}");
                Console.WriteLine($" Nama Obat      : {medicine_0502.NameMedicine_0502}");
                Console.WriteLine($" Deskripsi Obat : {medicine_0502.DescMedicine_0502}");
                Console.WriteLine($" Kategori Obat  : {medicine_0502.CatMedicine_0502}");
                Console.WriteLine($" Harga Obat     : {medicine_0502.PriceMedicine_0502}");
                Console.WriteLine($" Stok Obat      : {medicine_0502.StockMedicine_0502}");
                Console.WriteLine();
                Console.WriteLine("==========================================");
            }
            // Menangkap error ketika terdapat kegagalan validasi data ke memory
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine($"Validasi gagal: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Error: {ex.Message}");
            }

            PauseController();
        }

        // Function Controller untuk Menghapus Data Obat Berdasarkan ID
        public static void DeleteController(MedicineService medicineService)
        {
            HeaderController("Hapus Data Obat");

            if (SubMenuController("Hapus Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            ReadInlineController(medicineService);

            Console.Write("Masukkan ID Obat yang ingin dihapus: ");
            string idInput_0502 = Console.ReadLine() ?? "";

            if (!int.TryParse(idInput_0502, out int id_0502))
            {
                Console.Clear();
                Console.WriteLine("=========== ID Obat Harus Angka Valid! ===========");
                PauseController();
                return;
            }

            if (id_0502 <= 0)
            {
                Console.Clear();
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                PauseController();
                return;
            }

            try
            {
                medicineService.DeleteService(id_0502);
                Console.Clear();
                Console.WriteLine("========== Data obat berhasil dihapus! ==========");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }

            PauseController();
        }

        // Function Controller untuk Mencari Data Obat Berdasarkan Kata Kunci atau Nama Obat
        public static void SearchController(MedicineService medicineService)
        {
            HeaderController("Cari Data Obat");

            if (SubMenuController("Cari Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            ReadInlineController(medicineService);

            Console.Write("Masukkan Nama obat: ");
            string name_0502 = Console.ReadLine() ?? "";

            var results_0502 = medicineService.SearchService(name_0502);

            if (results_0502.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("======= Data obat tidak ditemukan! =======");
            }
            else
            {
                foreach (var m_0502 in results_0502)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("===== Berhasil menemukan data obat! =====");
                    Console.WriteLine("=========================================");
                    Console.WriteLine($" ID Obat        : {m_0502.IdMedicine_0502}");
                    Console.WriteLine($" Nama Obat      : {m_0502.NameMedicine_0502}");
                    Console.WriteLine($" Deskripsi Obat : {m_0502.DescMedicine_0502}");
                    Console.WriteLine($" Kategori Obat  : {m_0502.CatMedicine_0502}");
                    Console.WriteLine($" Harga Obat     : {m_0502.PriceMedicine_0502}");
                    Console.WriteLine($" Stok Obat      : {m_0502.StockMedicine_0502}");
                    Console.WriteLine("=========================================");
                }
            }

            PauseController();
        }

        // Function Controller untuk Filter Data Obat Berdasarkan Kategori Obat
        public static void FilterController(MedicineService medicineService)
        {
            HeaderController("Filter Data Obat");

            if (SubMenuController("Filter Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            ReadInlineController(medicineService);

            Console.Write("Masukkan kategori obat (OB/OBT/OK/PS/NA): ");
            string category_0502 = Console.ReadLine()?.ToUpper() ?? "";

            var allMedicine_0502 = medicineService.ReadService();
            List<MedicineModels> results_0502 = [];

            foreach (var m_0502 in allMedicine_0502)
            {
                if (
                    m_0502.CatMedicine_0502.Equals(
                        category_0502,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    results_0502.Add(m_0502);
                }
            }

            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("====== Hasil Filter Kategori ======");
            Console.WriteLine("===================================");

            if (results_0502.Count == 0)
            {
                Console.WriteLine("====== Tidak ada obat dalam kategori tersebut ======");
            }
            else
            {
                foreach (var m_0502 in results_0502)
                {
                    Console.WriteLine();
                    Console.WriteLine($" ID Obat        : {m_0502.IdMedicine_0502}");
                    Console.WriteLine($" Nama Obat      : {m_0502.NameMedicine_0502}");
                    Console.WriteLine($" Deskripsi Obat : {m_0502.DescMedicine_0502}");
                    Console.WriteLine($" Kategori Obat  : {m_0502.CatMedicine_0502}");
                    Console.WriteLine($" Harga Obat     : {m_0502.PriceMedicine_0502}");
                    Console.WriteLine($" Stok Obat      : {m_0502.StockMedicine_0502}");
                    Console.WriteLine("=========================================");
                }
            }
            PauseController();
        }
    }
}
