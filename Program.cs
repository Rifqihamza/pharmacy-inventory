using pharmacyInventory.Controllers;
using pharmacyInventory.Service;

namespace pharmacyInventory
{
    class Program
    {
        public static void Main()
        {
            MedicineService medicineService = new();
            bool systemRunning = true;

            while (systemRunning)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========== Selamat Datang di Sistem ==========");
                Console.WriteLine("============= Pharmacy Inventory =============");
                Console.WriteLine("==============================================");
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Tambah Data Obat");
                Console.WriteLine("2. Lihat Data Obat");
                Console.WriteLine("3. Update Data Obat");
                Console.WriteLine("4. Delete Data Obat");
                Console.WriteLine("5. Cari Data Obat");
                Console.WriteLine("6. Filter Data Obat");
                Console.WriteLine("7. Akhiri Sistem");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.Write("Pilih Menu (1/2/3/4/5/6/7): ");
                string inputChoose = Console.ReadLine() ?? "";

                switch (inputChoose)
                {
                    case "1":
                        MedicineControllers.CreateMedicineCode(medicineService);
                        break;
                    case "2":
                        MedicineControllers.ReadAllMedicineCode(medicineService);
                        break;
                    case "3":
                        MedicineControllers.UpdateMedicineCode(medicineService);
                        break;
                    case "4":
                        MedicineControllers.DeleteMedicineCode(medicineService);
                        break;
                    case "5":
                        MedicineControllers.SearchMedicineCode(medicineService);
                        break;
                    case "6":
                        MedicineControllers.FilterByCategory(medicineService);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("==========================================");
                        Console.WriteLine("========== Pilihan tidak valid! ==========");
                        Console.WriteLine("==========================================");
                        break;
                }
            }
        }
    }
}
