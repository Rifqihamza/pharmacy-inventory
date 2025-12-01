using pharmacyInventory.Models;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        // Tampilan Header setiap Function
        public static void HeaderMessage(string title)
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine($"------ {title} ------");
            Console.WriteLine("==============================");
        }

        // Sistem Pause atau Jeda sebelum lanjut
        public static void PauseSystem()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Sub Menu pada setiap function untuk Lanjut atau Kembali
        private static int SubMenuOption(string message)
        {
            Console.WriteLine();
            Console.WriteLine($"1. {message}");
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.Write("Pilih Menu: ");

            string input = Console.ReadLine() ?? "";

            if (input == "1") return 1;
            if (input == "2") return 2;

            Console.WriteLine("Pilihan tidak valid!");
            PauseSystem();
            return 2;
        }

        // Menampilkan Semua Data Obat Yang Di Panggil Setiap Function
        private static void ShowInlineFunctionCode(MedicineService medicineService)
        {
            HeaderMessage("Data Semua Obat");

            var list = medicineService.ReadAllMedicine();

            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                foreach (var m in list)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine($" ID Obat        : {m.IdMedicine}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine}");
                    Console.WriteLine("=========================================");
                }
            }

            Console.WriteLine();
        }

        // Membaca Semua Data Dan Menampilkan Semua Data Obat
        public static void ReadAllMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Data Semua Obat");

            var list = medicineService.ReadAllMedicine();

            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                foreach (var m in list)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine($" ID Obat        : {m.IdMedicine}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine}");
                    Console.WriteLine("=========================================");
                }
            }

            PauseSystem();
        }

        // Function Tambah Data Obat
        public static void CreateMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Tambah Data Obat");

            if (SubMenuOption("Tambah Data Obat") == 2)
                return;

            Console.Write("Nama Obat     : ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Deskripsi     : ");
            string desc = Console.ReadLine() ?? "";

            Console.Write("Kategori (OB/OBT/OK/PS/NA): ");
            string cat = Console.ReadLine() ?? "";

            Console.Write("Harga         : ");
            string priceInput = Console.ReadLine() ?? "";
            if (priceInput == "")
            {
                Console.WriteLine("Harga tidak boleh kosong!");
                PauseSystem();
                return;
            }
            int price = int.Parse(priceInput);

            Console.Write("Stok          : ");
            string stockInput = Console.ReadLine() ?? "";
            if (stockInput == "")
            {
                Console.WriteLine("Stok tidak boleh kosong!");
                PauseSystem();
                return;
            }
            int stock = int.Parse(stockInput);

            medicineService.CreateMedicine(name, desc, cat, price, stock);

            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("== Data obat baru berhasil ditambahkan! ==");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine($" Nama Obat      : {name}");
            Console.WriteLine($" Deskripsi Obat : {desc}");
            Console.WriteLine($" Kategori Obat  : {cat}");
            Console.WriteLine($" Harga Obat     : {price}");
            Console.WriteLine($" Stok Obat      : {stock}");
            Console.WriteLine("==========================================");

            PauseSystem();
        }

        // Function Update Data Obat
        public static void UpdateMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Ubah Data Obat");

            if (SubMenuOption("Ubah Data Obat") == 2)
                return;

            ShowInlineFunctionCode(medicineService);

            Console.Write("Masukkan ID Obat yang ingin diubah: ");
            string idInput = Console.ReadLine() ?? "";

            if (idInput == "")
            {
                Console.WriteLine("ID obat tidak boleh kosong!");
                PauseSystem();
                return;
            }

            int id = int.Parse(idInput);
            var medicine = medicineService.GetById(id);

            if (medicine == null)
            {
                Console.WriteLine("Data obat tidak ditemukan!");
                PauseSystem();
                return;
            }

            Console.Write($"Nama Obat Baru ({medicine.NameMedicine}) : ");
            string nameInput = Console.ReadLine() ?? "";
            if (nameInput != "") medicine.NameMedicine = nameInput;

            Console.Write($"Deskripsi Baru ({medicine.DescMedicine}) : ");
            string descInput = Console.ReadLine() ?? "";
            if (descInput != "") medicine.DescMedicine = descInput;

            Console.Write($"Kategori Baru ({medicine.CatMedicine}) : ");
            string catInput = Console.ReadLine() ?? "";
            if (catInput != "") medicine.CatMedicine = catInput;

            Console.Write($"Harga Baru ({medicine.PriceMedicine}) : ");
            string priceUpdate = Console.ReadLine() ?? "";
            if (int.TryParse(priceUpdate, out int p) && p > 0)
                medicine.PriceMedicine = p;

            Console.Write($"Stok Baru ({medicine.StockMedicine}) : ");
            string stockUpdate = Console.ReadLine() ?? "";
            if (int.TryParse(stockUpdate, out int s) && s > 0)
                medicine.StockMedicine = s;

            bool success = medicineService.UpdateMedicine(
                 id,
                 medicine.NameMedicine,
                 medicine.DescMedicine,
                 medicine.CatMedicine,
                 medicine.PriceMedicine,
                 medicine.StockMedicine
             );

            if (!success)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("====== Data obat gagal diperbarui! ======");
                Console.WriteLine("=========================================");
                PauseSystem();
                return;
            }

            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==== Data obat berhasil diperbarui! ====");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine($" ID Obat        : {medicine.IdMedicine}");
            Console.WriteLine($" Nama Obat      : {medicine.NameMedicine}");
            Console.WriteLine($" Deskripsi Obat : {medicine.DescMedicine}");
            Console.WriteLine($" Kategori Obat  : {medicine.CatMedicine}");
            Console.WriteLine($" Harga Obat     : {medicine.PriceMedicine}");
            Console.WriteLine($" Stok Obat      : {medicine.StockMedicine}");
            Console.WriteLine("=========================================");
            PauseSystem();
        }

        // Function Hapus Data Obat
        public static void DeleteMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Hapus Data Obat");

            if (SubMenuOption("Hapus Data Obat") == 2)
                return;

            ShowInlineFunctionCode(medicineService);

            Console.Write("Masukkan ID Obat yang ingin dihapus: ");
            string idInput = Console.ReadLine() ?? "";

            if (idInput == "")
            {
                Console.WriteLine("ID obat tidak boleh kosong!");
                PauseSystem();
                return;
            }

            int id = int.Parse(idInput);

            if (medicineService.DeleteMedicine(id))
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("====== Data obat berhasil dihapus! ======");
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("======= Data obat tidak ditemukan! =======");
                Console.WriteLine("==========================================");
            }

            PauseSystem();
        }

        // Function Cari Data Obat by Nama
        public static void SearchMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Cari Data Obat");

            if (SubMenuOption("Cari Data Obat") == 2)
                return;

            ShowInlineFunctionCode(medicineService);

            Console.Write("Masukkan Nama obat: ");
            string name = Console.ReadLine() ?? "";

            var results = medicineService.SearchMedicine(name);

            Console.Clear();

            if (results.Count == 0)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("======= Data obat tidak ditemukan! =======");
                Console.WriteLine("==========================================");
            }
            else
            {
                foreach (var m in results)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("===== Berhasil menemukan data obat! =====");
                    Console.WriteLine("=========================================");
                    Console.WriteLine($" ID Obat        : {m.IdMedicine}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine}");
                    Console.WriteLine("=========================================");
                }
            }

            PauseSystem();
        }

        // Function Filter Data Obat by Kategori
        public static void FilterByCategory(MedicineService medicineService)
        {
            HeaderMessage("Filter Data Obat");

            if (SubMenuOption("Filter Data Obat") == 2)
                return;

            ShowInlineFunctionCode(medicineService);

            Console.Write("Masukkan kategori obat (OB/OBT/OK/PS/NA): ");
            string category = Console.ReadLine() ?? "";

            var allMedicine = medicineService.ReadAllMedicine();
            List<MedicineModels> results = [];

            foreach (var m in allMedicine)
            {
                if (m.CatMedicine.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(m);
                }
            }

            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("====== Hasil Filter Kategori ======");
            Console.WriteLine("===================================");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dalam kategori tersebut.");
            }
            else
            {
                foreach (var m in results)
                {
                    Console.WriteLine();
                    Console.WriteLine($" ID Obat        : {m.IdMedicine}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine}");
                    Console.WriteLine("=========================================");
                }
            }

            PauseSystem();
        }
    }
}
