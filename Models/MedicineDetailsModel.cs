using System;
using System.ComponentModel.DataAnnotations;

namespace HopePharmacy.Models
{
    public class MedicineDetailsModel
    {
        
        public int MedicineSupplierId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int SupplierId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int MedicineId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public decimal CostPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public decimal SellingPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public DateTime ExpiaryDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int OriginalQuantity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int LeftQuantity { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public decimal DiscountValue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public decimal TaxValue { get; set; }

        public string MedicineName { get; set; }
        public string SupplierName { get; set; }










    }
}
