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
        public void CreateService(
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {
            if (string.IsNullOrWhiteSpace(nameMedic))
                throw new ArgumentException("Nama obat tidak boleh kosong");

            if (nameMedic.Length < 2)
                throw new ArgumentException("Nama obat minimal 2 karakter");

            if (string.IsNullOrWhiteSpace(catMedic))
                throw new ArgumentException("Kategori tidak boleh kosong");

            string[] validCategories = { "OB", "OBT", "OK", "PS", "NA" };
            if (!validCategories.Contains(catMedic.ToUpper()))
                throw new ArgumentException("Kategori obat tidak valid");

            if (priceMedic <= 0)
                throw new ArgumentException("Harga harus lebih dari 0");

            if (stockMedic <= 0)
                throw new ArgumentException("Stok harus lebih dari 0");

            MedicineModels medicine = new()
            {
                IdMedicine_0502 = AddIdMedicine_0502++,
                NameMedicine_0502 = nameMedic,
                DescMedicine_0502 = descMedic,
                CatMedicine_0502 = catMedic.ToUpper(),
                PriceMedicine_0502 = priceMedic,
                StockMedicine_0502 = stockMedic,
            };

            MedicineList.Add(medicine);
        }

        /* ===== Update Medicine Data Service ===== */
        public void UpdateService(
            int idMedic,
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {
            var medicine = GetById(idMedic) ?? throw new Exception("Data obat tidak ditemukan");

            if (string.IsNullOrWhiteSpace(nameMedic))
                throw new ArgumentException("Nama obat tidak boleh kosong");

            if (priceMedic <= 0)
                throw new ArgumentException("Harga harus lebih dari 0");

            if (stockMedic <= 0)
                throw new ArgumentException("Stok harus lebih dari 0");

            medicine.NameMedicine_0502 = nameMedic;
            medicine.DescMedicine_0502 = descMedic;
            medicine.CatMedicine_0502 = catMedic;
            medicine.PriceMedicine_0502 = priceMedic;
            medicine.StockMedicine_0502 = stockMedic;
        }

        /* ===== Delete Medicine Data Service ===== */
        public void DeleteService(int id)
        {
            var medicine = GetById(id) ?? throw new Exception("Data obat tidak ditemukan");

            MedicineList.Remove(medicine);
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
