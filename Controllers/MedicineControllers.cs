using pharmacyInventory.Models;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        // Show Header Title Each Section Controller
        public static void HeaderController(string title)
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine($"------ {title} ------");
            Console.WriteLine("===============================");
        }

        // Pause Controller Before Continue
        public static void PauseController()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Press any key to continue....");
            Console.WriteLine("-----------------------------");
            Console.ReadKey();
            Console.Clear();
        }

        // Sub Menu Back or Continue for Each Section Controller
        private static int SubMenuController(string message)
        {
            Console.WriteLine();
            Console.WriteLine($"1. {message}");
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.Write("Pilih Menu: ");

            string input = Console.ReadLine() ?? "";

            if (input == "1") return 1;
            if (input == "2") return 2;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("=============== Pilihan Tidak Valid! ===============");
            Console.WriteLine("====================================================");
            Console.WriteLine();
            PauseController();
            return 2;
        }

        // Controller for Show All Medicine Data Inside Controller (For Update, Delete, Search, Filter)
        // Help User Know What Data Want to Update, Delete, Search, or Filter
        private static void ReadInlineController(MedicineService medicineService)
        {
            HeaderController("Data Semua Obat");

            var list = medicineService.ReadService();

            if (list.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("============== Tidak Ada Data Obat! ==============");
                Console.WriteLine("==================================================");
                Console.WriteLine();
            }
            else
            {
                foreach (var m in list)
                {
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine();
                    Console.WriteLine($" ID Obat        : {m.IdMedicine}");
                    Console.WriteLine($" Nama Obat      : {m.NameMedicine}");
                    Console.WriteLine($" Deskripsi Obat : {m.DescMedicine}");
                    Console.WriteLine($" Kategori Obat  : {m.CatMedicine}");
                    Console.WriteLine($" Harga Obat     : {m.PriceMedicine}");
                    Console.WriteLine($" Stok Obat      : {m.StockMedicine}");
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                }
            }

            Console.WriteLine();
        }

        // Controller for Read and Show All Medicine Data
        public static void ReadController(MedicineService medicineService)
        {
            HeaderController("Lihat Data Semua Obat");
            if (SubMenuController("Lihat Data Semua Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            Console.WriteLine();

            var list = medicineService.ReadService();

            if (list.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("========== Tidak Ada Data Obat! ==========");
                Console.WriteLine("==========================================");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("===== Data Semua Obat di Inventory! =====");
                Console.WriteLine("=========================================");
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

            PauseController();
        }

        // Controller Create New Medicine Data
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
            string name = Console.ReadLine() ?? "";

            Console.Write("Deskripsi     : ");
            string desc = Console.ReadLine() ?? "";

            Console.Write("Kategori (OB/OBT/OK/PS/NA): ");
            string cat = Console.ReadLine() ?? "";
            if (cat == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Stock Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            Console.Write("Harga         : ");
            string priceInput = Console.ReadLine() ?? "";
            if (priceInput == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Harga Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }
            int price = int.Parse(priceInput);

            Console.Write("Stok          : ");
            string stockInput = Console.ReadLine() ?? "";
            if (stockInput == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Stock Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }
            int stock = int.Parse(stockInput);

            medicineService.CreateService(name, desc, cat, price, stock);

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
            Console.WriteLine();
            Console.WriteLine("==========================================");

            PauseController();
        }

        // Controller Update Medicine Data (Select by ID)
        public static void UpdateController(MedicineService medicineService)
        {
            HeaderController("Ubah Data Obat");

            if (SubMenuController("Ubah Data Obat") == 2)
            {
                return;
            }
            else
            {
                Console.Clear();
            }

            ReadInlineController(medicineService);

            Console.Write("Masukkan ID Obat yang ingin diubah: ");
            string idInput = Console.ReadLine() ?? "";

            if (idInput == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            int id = int.Parse(idInput);
            var medicine = medicineService.GetById(id);

            if (medicine == null)
            {
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("=========== Data Obat Tidak Ditemukan! ===========");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                PauseController();
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

            bool success = medicineService.UpdateService(
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
                PauseController();
                return;
            }

            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("===== Data obat berhasil diperbarui! =====");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine($" ID Obat        : {medicine.IdMedicine}");
            Console.WriteLine($" Nama Obat      : {medicine.NameMedicine}");
            Console.WriteLine($" Deskripsi Obat : {medicine.DescMedicine}");
            Console.WriteLine($" Kategori Obat  : {medicine.CatMedicine}");
            Console.WriteLine($" Harga Obat     : {medicine.PriceMedicine}");
            Console.WriteLine($" Stok Obat      : {medicine.StockMedicine}");
            Console.WriteLine();
            Console.WriteLine("==========================================");
            PauseController();
        }

        // Controller Delete Medicine Data (Select by ID)
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
            string idInput = Console.ReadLine() ?? "";

            if (idInput == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            int id = int.Parse(idInput);

            if (medicineService.DeleteService(id))
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("=========================================");
                Console.WriteLine("====== Data obat berhasil dihapus! ======");
                Console.WriteLine("=========================================");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("======= Data obat tidak ditemukan! =======");
                Console.WriteLine("==========================================");
                Console.WriteLine();
            }

            PauseController();
        }

        // Controller Search Medicine Data (Select by Name Medicine)
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
            string name = Console.ReadLine() ?? "";

            var results = medicineService.SearchService(name);

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

            PauseController();
        }

        // Controller Filter Medicine Data (Select by Category)
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
            string category = Console.ReadLine() ?? "";

            var allMedicine = medicineService.ReadService();
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
                Console.WriteLine();
                Console.WriteLine("====================================================");
                Console.WriteLine("====== Tidak ada obat dalam kategori tersebut ======");
                Console.WriteLine("====================================================");
                Console.WriteLine();
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
            PauseController();
        }
    }
}
