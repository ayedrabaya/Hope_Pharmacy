using System.ComponentModel.DataAnnotations;

namespace HopePharmacy.Models
{
    public class SuppliersModel
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int SupplierId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public string SupplierName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public string Mobile { get; set; }
        public string Address { get; set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public int ManufactureId { get; set; }
        public string ManufactureName { get; set; }
    }
}
