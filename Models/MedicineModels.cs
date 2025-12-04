namespace pharmacyInventory.Models
{
    class MedicineModels
    {
        // Initiate Models Medicine Data
        public int IdMedicine { get; set; }
        public string NameMedicine { get; set; } = "";
        public string DescMedicine { get; set; } = "";
        public string CatMedicine { get; set; } = "";
        public int PriceMedicine { get; set; }
        public int StockMedicine { get; set; }
    }
}
