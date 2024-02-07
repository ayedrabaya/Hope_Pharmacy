using System;
using System.Collections.Generic;

#nullable disable

namespace HopePharmacy.Entities
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public int MedicineId { get; set; }
        public decimal ProfitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
