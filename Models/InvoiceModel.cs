namespace HopePharmacy.Models
{
    public class InvoiceModel
    {
        public int MedicineId { get; set; }
        public int PatientId{ get; set; }
        public int QTY { get; set; }
        public int SellingPrice { get; set; }
    }
}
