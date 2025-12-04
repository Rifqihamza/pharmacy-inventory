using pharmacyInventory.Models;

namespace pharmacyInventory.Service
{
    class MedicineService
    {

        /* ===== Initiate Models Medicine Data to Array List ===== */
        private readonly List<MedicineModels> MedicineList = [];

        /* ===== Initiate Type Data for Add +1 ID (Auto Increment) ===== */
        int AddIdMedicine = 1;

        /* ===== Get Data by ID ===== */
        public MedicineModels? GetById(int id)
        {
            return MedicineList.FirstOrDefault(medicine => medicine.IdMedicine == id);
        }

        /* ===== Read Medicine Data Service ===== */
        public List<MedicineModels> ReadService()
        {
            return MedicineList;
        }

        /* ===== Create Medicine Data Service ===== */
        public bool CreateService(
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {

            if (nameMedic == "" || nameMedic.Length < 2)
            {
                Console.WriteLine("Nama obat harus lebih dari 1 karakter");
                return false;
            }

            if (descMedic == "" || descMedic.Length < 2)
            {
                Console.WriteLine("Deskripsi obat harus lebih dari 2 karakter");
                return false;
            }

            if (catMedic == "" || catMedic.Length < 2)
            {
                Console.WriteLine("Kategori obat harus lebih dari 2 karakter");
                return false;
            }

            if (priceMedic == 0)
            {
                Console.WriteLine("Harga obat harus lebih dari 0");
                return false;
            }

            if (stockMedic == 0)
            {
                Console.WriteLine("Stok obat harus lebih dari 0");
                return false;
            }

            MedicineModels medic = new()
            {
                IdMedicine = AddIdMedicine++,
                NameMedicine = nameMedic,
                DescMedicine = descMedic,
                CatMedicine = catMedic,
                PriceMedicine = priceMedic,
                StockMedicine = stockMedic,
            };

            MedicineList.Add(medic);
            return true;
        }

        /* ===== Update Medicine Data Service ===== */
        public bool UpdateService(
            int idMedic,
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {
            var medicine = MedicineList.FirstOrDefault(medicine => medicine.IdMedicine == idMedic);
            if (medicine != null)
            {
                medicine.NameMedicine = nameMedic;
                medicine.DescMedicine = descMedic;
                medicine.CatMedicine = catMedic;
                medicine.PriceMedicine = priceMedic;
                medicine.StockMedicine = stockMedic;
                return true;
            }
            else
            {
                return false;
            }

        }

        /* ===== Delete Medicine Data Service ===== */
        public bool DeleteService(int id)
        {
            var medicine = MedicineList.FirstOrDefault(medicine => medicine.IdMedicine == id);
            if (medicine != null)
            {
                MedicineList.Remove(medicine);
                return true;
            }
            else
            {
                return false;
            }
        }

        /* ===== Search Medicine Data Service ===== */
        public List<MedicineModels> SearchService(string keyword)
        {
            keyword = keyword.ToLower();

            return MedicineList
                .Where(medicine => medicine.NameMedicine.ToLower().Contains(keyword))
                .ToList();
        }

        /* ===== Filter Medicine Data Service ===== */
        public List<MedicineModels> FilterService(string category)
        {
            return MedicineList.Where(medicine => medicine.CatMedicine.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
