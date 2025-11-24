using System.Runtime.CompilerServices;
using pharmacyInventory.Service;

namespace pharmacyInventory.Controllers
{
    class MedicineControllers
    {
        /* ===== Function Untuk Kembali ke Menu Utama ===== */

        public static void ShowAllMedicineCode(MedicineService medicineService)
        {
            var MedicineList = medicineService.GetAllMedicine();

            Console.WriteLine("=========================");
            Console.WriteLine("======= Data Obat =======");
            Console.WriteLine("=========================");

            if (MedicineList.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat.");
            }
            else
            {
                foreach (var medic in MedicineList)
                {
                    Console.Write(
                        $"{medic.IdMedicine} || {medic.NameMedicine} || {medic.DescMedicine} || {medic.CatMedicine} || {medic.PriceMedicine} || {medic.StockMedicine}"
                    );
                }
            }
        }

        public static void PauseSystem()
        {
            Console.WriteLine("Tekan tombol apa saja untuk kembali ke menu utama...");
            Console.ReadKey();
        }

        public static void AddMedicineCode(MedicineService medicineService)
        {
            Console.WriteLine("===== Tambah Data Obat =====");

            Console.Write("Nama Obat: ");
            string nameMedic = Console.ReadLine() ?? "";

            Console.Write("Deskripsi Obat: ");
            string descMedic = Console.ReadLine() ?? "";

            Console.Write("Kategori Obat: ");
            string catMedic = Console.ReadLine() ?? "";

            Console.Write("Harga Obat: ");
            int priceMedic = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Stok Obat: ");
            int stockMedic = int.Parse(Console.ReadLine() ?? "0");

            medicineService.AddMedicine(nameMedic, descMedic, catMedic, priceMedic, stockMedic);

            Console.WriteLine("Obat berhasil ditambahkan!");
            PauseSystem();
        }

        public static void UpdateMedicineCode(MedicineService medicineService)
        {
            Console.WriteLine("===== Ubah Data Obat =====");

            Console.Write("Id Obat yang ingin diubah: ");
            int idMedic = int.Parse(Console.ReadLine() ?? "");

            var medicine = medicineService.GetById(idMedic);

            if (medicine == null)
            {
                Console.WriteLine("Obat tidak ditemukan!");
                PauseSystem();
                return;
            }

            Console.Write("Nama Obat Baru: ");
            string nameMedic = Console.ReadLine() ?? "";

            Console.Write("Deskripsi Obat Baru: ");
            string descMedic = Console.ReadLine() ?? "";

            Console.Write("Category Obat Baru: ");
            string catMedic = Console.ReadLine() ?? "";

            Console.Write("Harga Obat Baru: ");
            string priceMedic = Console.ReadLine() ?? "";

            Console.Write("Stok Obat Baru: ");
            string stockMedic = Console.ReadLine() ?? "";

            medicineService.UpdateMedicine(
                idMedic,
                nameMedic,
                descMedic,
                catMedic,
                int.Parse(priceMedic),
                int.Parse(stockMedic)
            );

            Console.WriteLine("Data obat berhasil diubah!");
            PauseSystem();
        }

        public static void DeleteMedicineCode(MedicineService medicineService)
        {
            Console.WriteLine("===== Hapus Data Obat =====");

            ShowAllMedicineCode(medicineService);

            Console.Write("Id Obat yang ingin dihapus: ");
            int idMedic = int.Parse(Console.ReadLine() ?? "");

            if (medicineService.DeleteMedicine(idMedic))
            {
                Console.WriteLine("Obat berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("Obat tidak ditemukan!");
            }

            PauseSystem();
        }
    }
}
