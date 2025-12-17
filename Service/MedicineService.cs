using pharmacyInventory.Models;

namespace pharmacyInventory.Service
{
    class MedicineService
    {
        /* ===== Inisiasi Data dari Models ke Array List ===== */
        private readonly List<MedicineModels> MedicineList = [];

        /* ===== Inisiasi tipe data untuk id agar mengawali dari 1 hingga seterusnya (Auto Increment) ===== */
        int AddIdMedicine_0502 = 1;

        /* ===== Service Untuk Ambil Data dari Models Berdasarkan ID ===== */
        public MedicineModels? GetById(int id)
        {
            return MedicineList.FirstOrDefault(medicine => medicine.IdMedicine_0502 == id);
        }

        /* ===== Service untuk Membaca Data Obat dari List Obat ===== */
        public List<MedicineModels> ReadService()
        {
            return MedicineList;
        }

        /* ===== Service untuk Membuat Data Obat Baru ===== */
        public void CreateService(
            // Parameter sesuai data dari Models
            string nameMedic,
            string descMedic,
            string catMedic,
            int priceMedic,
            int stockMedic
        )
        {
            // Validasi Service Apakah OK untuk di Insert ke Database atau Memory System
            if (
                MedicineList.Any(m =>
                    m.NameMedicine_0502.Equals(nameMedic, StringComparison.OrdinalIgnoreCase)
                )
            )
                throw new Exception("Data Obat Sudah Tersedia!");

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
