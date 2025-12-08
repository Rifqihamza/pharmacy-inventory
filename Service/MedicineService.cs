using pharmacyInventory.Models;

namespace pharmacyInventory.Service
{
    class MedicineService
    {
        /* ===== Initiate Models Medicine Data to Array List ===== */
        private readonly List<MedicineModels> MedicineList = [];

        /* ===== Initiate Type Data for Add +1 ID (Auto Increment) ===== */
        int AddIdMedicine_0502 = 1;

        /* ===== Get Data by ID ===== */
        public MedicineModels? GetById(int id)
        {
            return MedicineList.FirstOrDefault(medicine => medicine.IdMedicine_0502 == id);
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
            MedicineModels medic_0502 = new()
            {
                IdMedicine_0502 = AddIdMedicine_0502++,
                NameMedicine_0502 = nameMedic,
                DescMedicine_0502 = descMedic,
                CatMedicine_0502 = catMedic,
                PriceMedicine_0502 = priceMedic,
                StockMedicine_0502 = stockMedic,
            };

            MedicineList.Add(medic_0502);
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
            var medicine_0502 = GetById(idMedic);
            if (medicine_0502 != null)
            {
                medicine_0502.NameMedicine_0502 = nameMedic;
                medicine_0502.DescMedicine_0502 = descMedic;
                medicine_0502.CatMedicine_0502 = catMedic;
                medicine_0502.PriceMedicine_0502 = priceMedic;
                medicine_0502.StockMedicine_0502 = stockMedic;
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
            var medicine_0502 = GetById(id);
            if (medicine_0502 != null)
            {
                MedicineList.Remove(medicine_0502);
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
                .Where(medicine =>
                    medicine
                        .NameMedicine_0502.ToLower()
                        .Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
                )
                .ToList();
        }

        /* ===== Filter Medicine Data Service ===== */
        public List<MedicineModels> FilterService(string category)
        {
            return MedicineList
                .Where(medicine =>
                    medicine.CatMedicine_0502.Equals(category, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
        }
    }
}
