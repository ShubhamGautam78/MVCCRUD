using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCRUD.Data;
using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        //ApplicationDbContext context = new ApplicationDbContext(Context);

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
           List<SelectListItem> ObjItem = new List<SelectListItem>()  
            {  
          new SelectListItem {Text="Select",Value="0",Selected=true },  
          new SelectListItem {Text="ASP.NET",Value="1" },  
          new SelectListItem {Text="C#",Value="2"},  
          new SelectListItem {Text="MVC",Value="3"},  
          new SelectListItem {Text="SQL",Value="4" },  
            };  
            ViewBag.ListItem = ObjItem;  
            return View(); 
        }
        public IActionResult Upsert(int? DepartmentId)
        {

           var EmployeeList = _context.employee.Select(cl => new SelectListItem()
            {

                Text = cl.Name,
                Value = cl.EmployeeId.ToString()
            });

       
       // EmployeeVM productVM = new EmployeeVM()
            {
                IEnumerable<Employee> obj = _context.employee;
               // Employee employee = new Employee();
                ViewBag.Department = EmployeeList;
               //    IEnumerable <Employee> obj = _context.employee;
                return View(obj);

            };

            //var DepartmentList = _context.employee.Select(cl => new SelectListItem()
            //{

            //    Text = cl.Name,
            //    Value = cl.DepartmentId.ToString()
            //});

            //// EmployeeVM productVM = new EmployeeVM()
            //{
            //    IEnumerable<Department> obj = _context.department;
            //    // Employee employee = new Employee();
            //    ViewBag.Department = DepartmentList;
            //    //    IEnumerable <Employee> obj = _context.employee;
            //    return View(obj);

            //};


        }
    }
}