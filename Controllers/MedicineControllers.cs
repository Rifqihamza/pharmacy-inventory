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

            string input_0502 = Console.ReadLine() ?? "";

            if (input_0502 == "1")
                return 1;
            if (input_0502 == "2")
                return 2;

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

            var list_0502 = medicineService.ReadService();

            if (list_0502.Count == 0)
            {
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

            Console.WriteLine();
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
            string name_0502 = Console.ReadLine() ?? "";
            if (name_0502 == "" || name_0502.Length < 1)
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Stock Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            Console.Write("Deskripsi     : ");
            string desc_0502 = Console.ReadLine() ?? "";

            Console.Write("Kategori (OB/OBT/OK/PS/NA): ");
            string cat_0502 = Console.ReadLine() ?? "";
            if (cat_0502 == "")
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
            string priceInput_0502 = Console.ReadLine() ?? "";
            if (priceInput_0502 == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Harga Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }
            int price_0502 = int.Parse(priceInput_0502);

            Console.Write("Stok          : ");
            string stockInput_0502 = Console.ReadLine() ?? "";
            if (stockInput_0502 == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("============ Stock Tidak Boleh Kosong! ============");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }
            int stock_0502 = int.Parse(stockInput_0502);

            medicineService.CreateService(name_0502, desc_0502, cat_0502, price_0502, stock_0502);

            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("== Data obat baru berhasil ditambahkan! ==");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine($" Nama Obat      : {name_0502}");
            Console.WriteLine($" Deskripsi Obat : {desc_0502}");
            Console.WriteLine($" Kategori Obat  : {cat_0502}");
            Console.WriteLine($" Harga Obat     : {price_0502}");
            Console.WriteLine($" Stok Obat      : {stock_0502}");
            Console.WriteLine();
            Console.WriteLine("==========================================");

            PauseController();
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

            var list_0502 = medicineService.ReadService();

            if (list_0502.Count == 0)
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
            string idInput_0502 = Console.ReadLine() ?? "";

            if (idInput_0502 == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            int id_0502 = int.Parse(idInput_0502);
            var medicine_0502 = medicineService.GetById(id_0502);

            if (medicine_0502 == null)
            {
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("=========== Data Obat Tidak Ditemukan! ===========");
                Console.WriteLine("==================================================");
                Console.WriteLine();
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
            string priceUpdate_0502 = Console.ReadLine() ?? "";
            if (int.TryParse(priceUpdate_0502, out int p) && p > 0)
                medicine_0502.PriceMedicine_0502 = p;

            Console.Write($"Stok Baru ({medicine_0502.StockMedicine_0502}) : ");
            string stockUpdate_0502 = Console.ReadLine() ?? "";
            if (int.TryParse(stockUpdate_0502, out int s) && s > 0)
                medicine_0502.StockMedicine_0502 = s;

            bool success_0502 = medicineService.UpdateService(
                id_0502,
                medicine_0502.NameMedicine_0502,
                medicine_0502.DescMedicine_0502,
                medicine_0502.CatMedicine_0502,
                medicine_0502.PriceMedicine_0502,
                medicine_0502.StockMedicine_0502
            );

            if (!success_0502)
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
            Console.WriteLine($" ID Obat        : {medicine_0502.IdMedicine_0502}");
            Console.WriteLine($" Nama Obat      : {medicine_0502.NameMedicine_0502}");
            Console.WriteLine($" Deskripsi Obat : {medicine_0502.DescMedicine_0502}");
            Console.WriteLine($" Kategori Obat  : {medicine_0502.CatMedicine_0502}");
            Console.WriteLine($" Harga Obat     : {medicine_0502.PriceMedicine_0502}");
            Console.WriteLine($" Stok Obat      : {medicine_0502.StockMedicine_0502}");
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
            string idInput_0502 = Console.ReadLine() ?? "";

            if (idInput_0502 == "")
            {
                Console.WriteLine();
                Console.WriteLine("===================================================");
                Console.WriteLine("=========== ID Obat Tidak Boleh Kosong! ===========");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                PauseController();
                return;
            }

            int id_0502 = int.Parse(idInput_0502);

            if (medicineService.DeleteService(id_0502))
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
            string name_0502 = Console.ReadLine() ?? "";

            var results_0502 = medicineService.SearchService(name_0502);

            Console.Clear();

            if (results_0502.Count == 0)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("======= Data obat tidak ditemukan! =======");
                Console.WriteLine("==========================================");
            }
            else
            {
                foreach (var m_0502 in results_0502)
                {
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
            string category_0502 = Console.ReadLine() ?? "";

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
                Console.WriteLine();
                Console.WriteLine("====================================================");
                Console.WriteLine("====== Tidak ada obat dalam kategori tersebut ======");
                Console.WriteLine("====================================================");
                Console.WriteLine();
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
