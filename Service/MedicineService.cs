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
        public void AddMedicine(
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {
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
        }

        /* ===== Read Medicine ===== */
        public List<MedicineModels> GetAllMedicine()
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
            return MedicineList
                .Where(medicine =>
                    medicine.CatMedicine.Equals(category, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }
    }
}
