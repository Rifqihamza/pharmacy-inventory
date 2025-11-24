using pharmacyInventory.Controllers;
using pharmacyInventory.Service;

namespace pharmacyInventory
{
    class Program
    {
        public static void Main()
        {
            MedicineService medicineService = new MedicineService();
            bool systemRunning = true;

            while (systemRunning)
            {
                Console.WriteLine("================================");
                Console.WriteLine("===== Welcome To Di Sistem =====");
                Console.WriteLine("====== Pharmacy Inventory ======");
                Console.WriteLine("================================");
                Console.WriteLine("1. Tambah Obat");
                Console.WriteLine("2. Lihat Obat");
                Console.WriteLine("3. Update Obat");
                Console.WriteLine("4. Delete Obat");
                Console.WriteLine("5. Cari Obat");
                Console.WriteLine("6. Filter Obat");
                Console.WriteLine("7. Keluar");
                Console.WriteLine("--------------------------------");
                Console.Write("Pilih Menu (1/2/3/4/5/6/7): ");
                string inputChoose = Console.ReadLine() ?? "";
                Console.WriteLine("================================");

                switch (inputChoose)
                {
                    case "1":
                        MedicineControllers.AddMedicineCode(medicineService);
                        break;
                    case "2":
                        MedicineControllers.ShowAllMedicineCode(medicineService);
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
                        MedicineControllers.FilterMedicineCode(medicineService);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
            }
        }
    }
}
