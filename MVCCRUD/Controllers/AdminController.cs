using Microsoft.AspNetCore.Mvc;
using MVCCRUD.Data;
using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddEmployee model)
        {
            try
            {
                if (ModelState.IsValid && model != null)
                {

                    AddEmployee employee = new AddEmployee();
                    _dbContext.Add(model);
                    _dbContext.SaveChanges();
                    return RedirectToAction("GetEmployees");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            List<AddEmployee> employees = _dbContext.AllEmployees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AddEmployee employee = _dbContext.AllEmployees.FirstOrDefault(m => m.EmployeeId == Id);
            return View("Create", employee);
        }
        [HttpPost]
        public ActionResult Edit(AddEmployee model)
        {
            var data = _dbContext.AllEmployees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (data != null)
            {
                data.Name = model.Name;
                data.Address = model.Address;
                data.Designation = model.Designation;
                _dbContext.SaveChanges();
            }
            ViewBag.Message = "Data Updated Successfully";
            return RedirectToAction("GetEmployees");
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var data = _dbContext.AllEmployees.Find(Id);
            return View(data);
        }
        public ActionResult Delete(int Id)
        {
            var data = _dbContext.AllEmployees.Where(m => m.EmployeeId == Id).FirstOrDefault();
            _dbContext.AllEmployees.Remove(data);
            _dbContext.SaveChanges();
            return RedirectToAction("GetEmployees");
        }


    }
}
