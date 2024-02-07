
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HopePharmacy.Controllers
{
    public class SuppliersController : Controller
    {
        Entities.HopeDecemberPharmacyContext context = new Entities.HopeDecemberPharmacyContext();
        public IActionResult GetAllSuppliers()
        {
            List<Models.SuppliersModel> suppliers1 = new List<Models.SuppliersModel>();
            suppliers1 = (from x in context.Suppliers.Include(y => y.Manufacture)
                          select new Models.SuppliersModel
                          {
                              SupplierId = x.SuppliersId,
                              SupplierName = x.SupplierName,
                              Mobile = x.Mobile,
                              Address = x.Address,
                              ManufactureId = x.ManufactureId,
                              ManufactureName = x.Manufacture.ManufactureName,


                          }).ToList();
            return View(suppliers1);
        }
        public IActionResult Create()
        {
            ViewBag.Manufacture = context.Manufactures.ToList();
            return View();
        }
        public IActionResult AddNewSuppliers(Models.SuppliersModel suppliers)
        {

            Entities.Supplier supplier = new Entities.Supplier();

            supplier.SupplierName = suppliers.SupplierName;
            supplier.Address = suppliers.Address;
            supplier.Mobile = suppliers.Mobile;
            supplier.ManufactureId = suppliers.ManufactureId;
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("GetAllSuppliers");

        }
        public IActionResult Edit(int Id)
        {

            Entities.Supplier supplier = new Entities.Supplier();
            supplier = context.Suppliers.Where(x => x.SuppliersId == Id).FirstOrDefault();
            Models.SuppliersModel suppliersModel = new Models.SuppliersModel();
            suppliersModel.SupplierId = supplier.SuppliersId;
            suppliersModel.SupplierName = supplier.SupplierName;
            suppliersModel.Address = supplier.Address;
            suppliersModel.ManufactureId = supplier.ManufactureId;
            suppliersModel.Mobile = supplier.Mobile;
            ViewBag.Manufacture = context.Manufactures.ToList();
            return View(suppliersModel);
        }
        public IActionResult UpdateSupplier(Models.SuppliersModel suppliersModel)
        {
            Entities.Supplier supplier = new Entities.Supplier();

            supplier = context.Suppliers.Where(x => x.SuppliersId == suppliersModel.SupplierId).FirstOrDefault();


            supplier.Address = suppliersModel.Address;
            supplier.SupplierName = suppliersModel.SupplierName;
            supplier.Mobile = suppliersModel.Mobile;
            supplier.ManufactureId = suppliersModel.ManufactureId;

            context.SaveChanges();
            return RedirectToAction("GetAllSuppliers");
        }
        public IActionResult Delete(int Id)
        {
            Entities.Supplier supplier = new Entities.Supplier();


            supplier = context.Suppliers.Where(x => x.SuppliersId == Id).FirstOrDefault();
            context.Remove(supplier);
            context.SaveChanges();


            return RedirectToAction("GetAllSuppliers");
        }


    }
}
