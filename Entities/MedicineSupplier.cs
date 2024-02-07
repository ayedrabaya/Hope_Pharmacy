using System;
using System.Collections.Generic;

#nullable disable

namespace HopePharmacy.Entities
{
    public partial class MedicineSupplier
    {
        public int MedicineSupplierId { get; set; }
        public int SupplierId { get; set; }
        public int MedicineId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime ExpiaryDate { get; set; }
        public int OriginalQuantity { get; set; }
        public int LeftQuantity { get; set; }
        public string Description { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TaxValue { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
