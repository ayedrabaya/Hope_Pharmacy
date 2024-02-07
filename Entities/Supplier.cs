using System;
using System.Collections.Generic;

#nullable disable

namespace HopePharmacy.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            MedicineSuppliers = new HashSet<MedicineSupplier>();
        }

        public int SuppliersId { get; set; }
        public string SupplierName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int ManufactureId { get; set; }

        public virtual Manufacture Manufacture { get; set; }
        public virtual ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
    }
}
