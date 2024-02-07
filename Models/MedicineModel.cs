using System.ComponentModel.DataAnnotations;

namespace HopePharmacy.Models
{
    public class MedicineModel
    {

        public int MedicineId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field Is Required")]
        public string MedicineName { get; set; }
    }
}
