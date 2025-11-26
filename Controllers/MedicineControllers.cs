using pharmacyInventory.Models;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        /* ===== Header ===== */
        public static void HeaderMessage(string title = "Daftar Data Obat")
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine($"======= {title} =======");
            Console.WriteLine("==============================");
        }

        /* ===== Pause ===== */
        public static void PauseSystem()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /* ===== Sub Menu (Lanjut / Kembali) ===== */
        private static int SubMenuOption(string message)
        {
            Console.WriteLine();
            Console.WriteLine("1. " + message);
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.Write("Pilih Menu: ");

            int choice = int.Parse(Console.ReadLine() ?? "2");
            return choice;
        }

        /* ===== Tampilkan Semua Obat ===== */
        public static void ShowAllMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Daftar Data Obat");

            var list = medicineService.GetAllMedicine();

            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"ID",-3} | {"Nama Obat",-20} | {"Deskripsi",-30} | {"Kategori",-15} | {"Harga",-10} | {"Stok",-5}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                foreach (var medic in list)
                {
                    Console.WriteLine(
                        $"{medic.IdMedicine,-3} | " +
                        $"{medic.NameMedicine,-20} | " +
                        $"{medic.DescMedicine,-30} | " +
                        $"{medic.CatMedicine,-15} | " +
                        $"{"Rp" + medic.PriceMedicine,-10} | " +
                        $"{medic.StockMedicine,-5}"
                    );
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }

            PauseSystem();
        }


        /* ===== Tampilkan Semua Obat di Dalam Function ===== */
        private static void ShowAllMedicineInline(MedicineService medicineService)
        {
            HeaderMessage("Daftar Data Obat");

            var list = medicineService.GetAllMedicine();

            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"ID",-3} | {"Nama Obat",-20} | {"Deskripsi",-30} | {"Kategori",-15} | {"Harga",-10} | {"Stok",-5}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                foreach (var medic in list)
                {
                    Console.WriteLine(
                        $"{medic.IdMedicine,-3} | " +
                        $"{medic.NameMedicine,-20} | " +
                        $"{medic.DescMedicine,-30} | " +
                        $"{medic.CatMedicine,-15} | " +
                        $"{"Rp" + medic.PriceMedicine,-10} | " +
                        $"{medic.StockMedicine,-5}"
                    );
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }

            Console.WriteLine();
        }

        /* ===== Tambah Obat ===== */
        public static void AddMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Tambah Data Obat Baru");

            if (SubMenuOption("Tambah Data Obat Baru") == 2)
                return;

            Console.WriteLine();
            Console.Write("Nama Obat     : ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Deskripsi     : ");
            string desc = Console.ReadLine() ?? "";

            Console.Write("Kategori      : ");
            string cat = Console.ReadLine() ?? "";

            Console.Write("Harga         : ");
            int price = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Stok          : ");
            int stock = int.Parse(Console.ReadLine() ?? "0");

            medicineService.AddMedicine(name, desc, cat, price, stock);

            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("== Data obat baru berhasil ditambahkan! ==");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.Write($" Nama Obat: {name} ||\n Deskripsi Obat: {desc} ||\n Kategori Obat: {cat} ||\n Harga Obat: {price} ||\n Stok Obat: {stock} ||\n");
            Console.WriteLine("==========================================");
            PauseSystem();
        }

        /* ===== Update Obat ===== */
        public static void UpdateMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Ubah Data Obat");

            if (SubMenuOption("Ubah Data Obat") == 2)
            {
                return;
            }
            ShowAllMedicineInline(medicineService);
            Console.Write("Masukkan ID Obat: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var medicine = medicineService.GetById(id);

            if (medicine == null)
            {
                Console.WriteLine("Obat tidak ditemukan!");
                PauseSystem();
                return;
            }

            Console.Write("Nama Obat Baru   : ");
            medicine.NameMedicine = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(medicine.NameMedicine))
            {
                medicine.NameMedicine = medicine.NameMedicine;
            }

            Console.Write("Deskripsi Baru   : ");
            medicine.DescMedicine = Console.ReadLine() ?? "";

            Console.Write("Kategori Baru    : ");
            medicine.CatMedicine = Console.ReadLine() ?? "";

            Console.Write("Harga Baru       : ");
            medicine.PriceMedicine = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Stok Baru        : ");
            medicine.StockMedicine = int.Parse(Console.ReadLine() ?? "0");

            medicineService.UpdateMedicine(
                id,
                medicine.NameMedicine,
                medicine.DescMedicine,
                medicine.CatMedicine,
                medicine.PriceMedicine,
                medicine.StockMedicine
            );
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("== Data obat berhasil diperbarui! ==");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write($" Nama Obat: {medicine.NameMedicine} ||\n Deskripsi Obat: {medicine.DescMedicine} ||\n Kategori Obat: {medicine.CatMedicine} ||\n Harga Obat: {medicine.PriceMedicine} ||\n Stok Obat: {medicine.StockMedicine} ||\n");
            Console.WriteLine("====================================");
            PauseSystem();
        }

        /* ===== Hapus Obat ===== */
        public static void DeleteMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Hapus Data Obat");

            if (SubMenuOption("Hapus Data Obat") == 2)
                return;

            ShowAllMedicineInline(medicineService);

            Console.Write("Masukkan ID Obat yang ingin dihapus: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            if (medicineService.DeleteMedicine(id))
                Console.WriteLine("Obat berhasil dihapus!");
            else
                Console.WriteLine("Obat tidak ditemukan!");

            PauseSystem();
        }

        /* ===== Cari Obat ===== */
        public static void SearchMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Cari Data Obat");

            if (SubMenuOption("Cari Data Obat") == 2)
                return;

            ShowAllMedicineInline(medicineService);
            Console.Write("Masukkan Nama obat: ");
            string name = Console.ReadLine() ?? "";

            var results = medicineService.SearchMedicine(name);

            Console.Clear();
            Console.WriteLine("===== Hasil Pencarian =====\n");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dengan nama tersebut.");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"ID",-3} | {"Nama Obat",-20} | {"Deskripsi",-30} | {"Kategori",-15} | {"Harga",-10} | {"Stok",-5}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                foreach (var m in results)
                {
                    Console.WriteLine(
                    $"{m.IdMedicine,-3} | " +
                    $"{m.NameMedicine,-20} | " +
                    $"{m.DescMedicine,-30} | " +
                    $"{m.CatMedicine,-15} | " +
                    $"{"Rp" + m.PriceMedicine,-10} | " +
                    $"{m.StockMedicine,-5}"
                    );
                }
            }
            PauseSystem();
        }

        /* ===== Filter Obat ===== */
        public static void FilterByCategory(MedicineService medicineService)
        {
            HeaderMessage("Filter Obat Berdasarkan Kategori");

            if (SubMenuOption("Filter Obat Berdasarkan Kategori") == 2)
                return;

            ShowAllMedicineInline(medicineService);

            Console.Write("Masukkan kategori obat: ");
            string category = Console.ReadLine() ?? "";

            List<MedicineModels> data = medicineService.GetAllMedicine();
            List<MedicineModels> results = [];

            foreach (MedicineModels item in data)
            {
                if (item.CatMedicine.ToLower() == category.ToLower())
                {
                    results.Add(item);
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
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"ID",-3} | {"Nama Obat",-20} | {"Deskripsi",-30} | {"Kategori",-15} | {"Harga",-10} | {"Stok",-5}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                foreach (var m in results)
                {
                    Console.WriteLine(
                    $"{m.IdMedicine,-3} | " +
                    $"{m.NameMedicine,-20} | " +
                    $"{m.DescMedicine,-30} | " +
                    $"{m.CatMedicine,-15} | " +
                    $"{"Rp" + m.PriceMedicine,-10} | " +
                    $"{m.StockMedicine,-5}"
                    );
                }
            }
            PauseSystem();
        }
    }
}
