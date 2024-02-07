using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HopePharmacy.Controllers
{
    public class InvoiceController : Controller
    {
        Entities.HopeDecemberPharmacyContext context=new Entities.HopeDecemberPharmacyContext();
        public IActionResult AddNewInvoice(Models.InvoiceModel invoiceModel)
        {
            Entities.Invoice invoice = new Entities.Invoice();
           
            var medicine= context.MedicineSuppliers.Where(x => x.MedicineId == invoiceModel.MedicineId).FirstOrDefault();
            
            invoice.PatientId= invoiceModel.PatientId;
            invoice.MedicineId= invoiceModel.MedicineId;

            decimal sellingPrice = medicine.SellingPrice-(medicine.SellingPrice * (medicine.DiscountValue/100))
                +(medicine.SellingPrice* (medicine.TaxValue/100))*invoiceModel.QTY;

            decimal profit = sellingPrice - (medicine.CostPrice* invoiceModel.QTY);
            invoice.ProfitPrice = profit;
            invoice.SellingPrice = sellingPrice;
            invoice.TransactionDate = DateTime.Now;

            invoice.EmployeeId = 1;
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            ViewBag.Patient = context.Patients.ToList();
            ViewBag.Medicine = (from obj in context.MedicineSuppliers.Include(x => x.Medicine).Include(x => x.Supplier)
                                select new
                                {
                                    Id=obj.MedicineId,
                                    Name=obj.Medicine.MedicineName+" - "+obj.Supplier.SupplierName,

                                }).ToList();
            return View();
        }

    }
}
