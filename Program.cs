/* ========================================

    Kelas: SI-25-05
    Kelompok: 02
    Anggota Kelompok:
    1. MUHAMMAD RIFQI HAMZA (102042500206)
    2. MUHAMMAD NABIL RAMADHAN (102042500158)
    4. YUKA INTAN SAHARA (102042500059)
    3. RASYAFANI RAMADHINE (102042500191)

======================================== */

using pharmacyInventory.Controllers;
using pharmacyInventory.Service;

namespace pharmacyInventory
{
    class Program
    {
        public static void Main()
        {
            // Initiate Object from Service to Manage Data
            MedicineService medicineService_0502 = new();

            // Initiate for Looping Always run
            bool systemRunning_0502 = true;

            // Use Looping Avoid Crash or End System After Use Function Create Read Update Delete Until Stop the System
            while (systemRunning_0502)
            {
                try
                {
                    // Show Title and Main Menu
                    Console.Clear();
                    Console.WriteLine("==============================================");
                    Console.WriteLine("========== Selamat Datang di Sistem ==========");
                    Console.WriteLine("============= Pharmacy Inventory =============");
                    Console.WriteLine("==============================================");
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(" 1. Tambah Data Obat");
                    Console.WriteLine(" 2. Lihat Data Obat");
                    Console.WriteLine(" 3. Update Data Obat");
                    Console.WriteLine(" 4. Delete Data Obat");
                    Console.WriteLine(" 5. Cari Data Obat");
                    Console.WriteLine(" 6. Filter Data Obat");
                    Console.WriteLine(" 7. Akhiri Sistem");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine();

                    // Input Option Menu
                    Console.Write("Pilih Menu (1/2/3/4/5/6/7): ");
                    string inputChoose_0502 = Console.ReadLine() ?? "";

                    // Switch Case for Input Option
                    switch (inputChoose_0502)
                    {
                        case "1":
                            MedicineControllers.CreateController(medicineService_0502);
                            break;
                        case "2":
                            MedicineControllers.ReadController(medicineService_0502);
                            break;
                        case "3":
                            MedicineControllers.UpdateController(medicineService_0502);
                            break;
                        case "4":
                            MedicineControllers.DeleteController(medicineService_0502);
                            break;
                        case "5":
                            MedicineControllers.SearchController(medicineService_0502);
                            break;
                        case "6":
                            MedicineControllers.FilterController(medicineService_0502);
                            break;
                        case "7":
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("==========================================");
                            Console.WriteLine("========== Pilihan tidak valid! ==========");
                            Console.WriteLine("======= Press any key to continue! =======");
                            Console.WriteLine("==========================================");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
        }
    }
}
