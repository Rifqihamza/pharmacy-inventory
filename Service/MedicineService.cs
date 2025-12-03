using pharmacyInventory.Models;

namespace pharmacyInventory.Service
{
    class MedicineService
    {
        private readonly List<MedicineModels> MedicineList = [];

        int AddIdMedicine = 1;

        public MedicineModels? GetById(int id)
        {
            return MedicineList.FirstOrDefault(medicine => medicine.IdMedicine == id);
        }

        /* ===== Create Medicine ===== */
        public bool CreateMedicine(
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

        /* ===== Read Medicine ===== */
        public List<MedicineModels> ReadAllMedicine()
        {
            return MedicineList;
        }

        /* ===== Update Medicine ===== */
        public bool UpdateMedicine(
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

        /* ===== Delete Medicine ===== */
        public bool DeleteMedicine(int id)
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

        /* ===== Search Medicine ===== */
        public List<MedicineModels> SearchMedicine(string keyword)
        {
            keyword = keyword.ToLower();

            return MedicineList
                .Where(medicine => medicine.NameMedicine.ToLower().Contains(keyword))
                .ToList();
        }

        /* ===== Filter Medicine ===== */
        public List<MedicineModels> FilterMedicine(string category)
        {
            return MedicineList.Where(medicine => medicine.CatMedicine.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
