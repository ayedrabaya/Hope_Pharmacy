using System;
using System.Collections.Generic;

#nullable disable

namespace HopePharmacy.Entities
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int ManufactureId { get; set; }
        public string ManufactureName { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
