using pharmacyInventory.Models;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        /* ===== Header ===== */
        public static void HeaderMessage(string title = "Data Obat")
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine($"======= {title} =======");
            Console.WriteLine("==============================");
        }

        /* ===== Sub Menu (Lanjut / Kembali) ===== */
        private static int SubMenuOption(string message)
        {
            Console.WriteLine();
            Console.WriteLine("1. " + message);
            Console.WriteLine("2. Kembali ke Menu Utama");
            Console.Write("Pilih: ");

            int choice = int.Parse(Console.ReadLine() ?? "2");
            return choice;
        }

        /* ===== Tampilkan Semua Obat ===== */
        public static void ShowAllMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Daftar Obat");

            var list = medicineService.GetAllMedicine();

            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                foreach (var medic in list)
                {
                    Console.WriteLine(
                        $"{medic.IdMedicine} | {medic.NameMedicine} | {medic.DescMedicine} | {medic.CatMedicine} | Rp{medic.PriceMedicine} | Stok: {medic.StockMedicine}"
                    );
                }
            }

            PauseSystem();
        }

        /* ===== Pause ===== */
        public static void PauseSystem()
        {
            Console.WriteLine("\nTekan tombol apa saja untuk kembali...");
            Console.ReadKey();
            Console.Clear();
        }

        /* ===== Tambah Obat ===== */
        public static void AddMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Tambah Obat");

            if (SubMenuOption("Tambah Obat Baru") == 2)
                return;

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

            Console.WriteLine("\nObat berhasil ditambahkan!");
            PauseSystem();
        }

        /* ===== Update Obat ===== */
        public static void UpdateMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Ubah Data Obat");

            if (SubMenuOption("Ubah Data Obat") == 2)
                return;

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

            Console.WriteLine("\nData obat berhasil diperbarui!");
            PauseSystem();
        }

        /* ===== Hapus Obat ===== */
        public static void DeleteMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Hapus Obat");

            if (SubMenuOption("Hapus Obat") == 2)
                return;

            ShowAllMedicineCode(medicineService);

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
            HeaderMessage("Cari Obat");

            if (SubMenuOption("Cari Obat") == 2)
                return;

            Console.Write("Masukkan kategori obat: ");
            string category = Console.ReadLine() ?? "";

            var results = medicineService.SearchMedicine(category);

            Console.Clear();
            Console.WriteLine("===== Hasil Pencarian =====\n");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dalam kategori tersebut.");
            }
            else
            {
                foreach (var m in results)
                {
                    Console.WriteLine(
                        $"{m.IdMedicine} | {m.NameMedicine} | {m.CatMedicine} | Rp{m.PriceMedicine} | Stok {m.StockMedicine}"
                    );
                }
            }

            PauseSystem();
        }

        private static void FilterByPrice(MedicineService service)
        {
            HeaderMessage("Filter Harga");

            Console.Write("Tampilkan obat dengan harga kurang dari: Rp ");
            int maxPrice = int.Parse(Console.ReadLine() ?? "0");

            List<MedicineModels> data = service.GetAllMedicine();
            List<MedicineModels> results = new List<MedicineModels>();

            // Filter manual
            foreach (MedicineModels item in data)
            {
                if (item.PriceMedicine < maxPrice)
                {
                    results.Add(item);
                }
            }

            Console.Clear();
            Console.WriteLine("===== Hasil Filter Harga =====\n");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dengan harga di bawah itu.");
            }
            else
            {
                foreach (MedicineModels m in results)
                {
                    Console.WriteLine($"{m.IdMedicine} | {m.NameMedicine} | Rp{m.PriceMedicine}");
                }
            }

            PauseSystem();
        }

        private static void FilterByStock(MedicineService service)
        {
            HeaderMessage("Filter Stok");

            Console.Write("Tampilkan obat dengan stok kurang dari: ");
            int maxStock = int.Parse(Console.ReadLine() ?? "0");

            List<MedicineModels> data = service.GetAllMedicine();
            List<MedicineModels> results = new List<MedicineModels>();

            foreach (MedicineModels item in data)
            {
                if (item.StockMedicine < maxStock)
                {
                    results.Add(item);
                }
            }

            Console.Clear();
            Console.WriteLine("===== Hasil Filter Stok =====\n");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dengan stok serendah itu.");
            }
            else
            {
                foreach (MedicineModels m in results)
                {
                    Console.WriteLine(
                        $"{m.IdMedicine} | {m.NameMedicine} | Stok: {m.StockMedicine}"
                    );
                }
            }

            PauseSystem();
        }

        private static void FilterByCategory(MedicineService service)
        {
            HeaderMessage("Filter Kategori");

            Console.Write("Masukkan kategori: ");
            string category = Console.ReadLine() ?? "";

            List<MedicineModels> data = service.GetAllMedicine();
            List<MedicineModels> results = new List<MedicineModels>();

            foreach (MedicineModels item in data)
            {
                if (item.CatMedicine.ToLower() == category.ToLower())
                {
                    results.Add(item);
                }
            }

            Console.Clear();
            Console.WriteLine("===== Hasil Filter Kategori =====\n");

            if (results.Count == 0)
            {
                Console.WriteLine("Tidak ada obat dalam kategori itu.");
            }
            else
            {
                foreach (MedicineModels m in results)
                {
                    Console.WriteLine($"{m.IdMedicine} | {m.NameMedicine} | {m.CatMedicine}");
                }
            }

            PauseSystem();
        }

        public static void FilterMedicineCode(MedicineService medicineService)
        {
            HeaderMessage("Filter Obat");

            Console.WriteLine("Pilih filter yang ingin digunakan:");
            Console.WriteLine("1. Filter berdasarkan harga (lebih kecil dari)");
            Console.WriteLine("2. Filter berdasarkan stok (lebih kecil dari)");
            Console.WriteLine("3. Filter berdasarkan kategori");
            Console.WriteLine("4. Kembali ke menu utama");
            Console.Write("Pilih: ");

            int option = int.Parse(Console.ReadLine() ?? "4");
            Console.Clear();

            switch (option)
            {
                case 1:
                    FilterByPrice(medicineService);
                    break;

                case 2:
                    FilterByStock(medicineService);
                    break;

                case 3:
                    FilterByCategory(medicineService);
                    break;

                default:
                    return;
            }
        }
    }
}
