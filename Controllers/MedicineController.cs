using HopePharmacy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HopePharmacy.Controllers
{
    public class MedicineController : Controller
    {
        Entities.HopeDecemberPharmacyContext context = new Entities.HopeDecemberPharmacyContext();
        public IActionResult AddNewMedicine(Models.MedicineModel medicineModel)
        {
            Entities.Medicine medicine = new Entities.Medicine();
            //medicineModel.MedicineId = medicine.MedicineId;
            medicine.MedicineName = medicineModel.MedicineName;
            context.Add(medicine);
            context.SaveChanges();

            return RedirectToAction("GetAllMedicines");
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult GetAllMedicines()
        {
            List<Models.MedicineModel> lst = new List<Models.MedicineModel>();
            lst = (from obj in context.Medicines
                   select new Models.MedicineModel
                   {
                       MedicineId = obj.MedicineId,
                       MedicineName = obj.MedicineName,
                   }).ToList();
            return View(lst);
        }

        public IActionResult Details(int Id)
        {
            ViewBag.supplier = context.Suppliers.ToList();
            ViewBag.MedicineId = Id;
            return View();
        }
        public IActionResult AddMedicineDetails(Models.MedicineDetailsModel medicineDetailsmodel)
        {
            Entities.MedicineSupplier medicineSupplier = new Entities.MedicineSupplier();

            medicineSupplier.SupplierId = medicineDetailsmodel.SupplierId;
            medicineSupplier.MedicineId = medicineDetailsmodel.MedicineId;
            medicineSupplier.SellingPrice = medicineDetailsmodel.SellingPrice;
            medicineSupplier.LeftQuantity = medicineDetailsmodel.LeftQuantity;
            medicineSupplier.OriginalQuantity = medicineDetailsmodel.OriginalQuantity;
            medicineSupplier.DiscountValue = medicineDetailsmodel.DiscountValue;
            medicineSupplier.TaxValue = medicineDetailsmodel.TaxValue;
            medicineSupplier.CostPrice = medicineDetailsmodel.CostPrice;
            medicineSupplier.ExpiaryDate = medicineDetailsmodel.ExpiaryDate;
            medicineSupplier.Description = medicineDetailsmodel.Description;
            context.MedicineSuppliers.Add(medicineSupplier);
            context.SaveChanges();
            return RedirectToAction("GetAllMedicines");
        }
        public IActionResult GetAllMedicineDetails()
        {
            List<Models.MedicineDetailsModel> lst = new List<Models.MedicineDetailsModel>();
            lst = (from obj in context.MedicineSuppliers.Include(x => x.Medicine).Include(y => y.Supplier)
                   select new Models.MedicineDetailsModel
                   {
                       SupplierName = obj.Supplier.SupplierName,
                       MedicineName = obj.Medicine.MedicineName,
                       TaxValue = obj.TaxValue,
                       SellingPrice = obj.SellingPrice,
                       OriginalQuantity = obj.OriginalQuantity,
                       DiscountValue = obj.DiscountValue,
                       Description = obj.Description,
                       ExpiaryDate = obj.ExpiaryDate,
                       CostPrice = obj.CostPrice,
                       LeftQuantity = obj.LeftQuantity,
                   }).ToList();
            return View(lst);
        }
    }
}
