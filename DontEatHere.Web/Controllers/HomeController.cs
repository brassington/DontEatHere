using DontEatHere.Web.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DontEatHere.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InspectionRecords()
        {
            string excelFile = "violations-all-fy12.xlsx";
            string sheetName = "Violations FY12";
            var excel = new ExcelQueryFactory(excelFile);
            excel.AddMapping<InspectionRecord>(x => x.FacilityName, "FACILITY NAME");
            excel.AddMapping<InspectionRecord>(x => x.InspectionDate, "INSPECTION DATE");
            excel.AddMapping<InspectionRecord>(x => x.Address, "ADDRESS");
            excel.AddMapping<InspectionRecord>(x => x.Comment, "VIOLATION COMMENTS");

            var model = from item in excel.Worksheet<InspectionRecord>(sheetName)
                       where item.FacilityName.Contains ("WINGSTOP")
                       select item;

            return View(model);
        }

        [HttpPost]
        public ActionResult InspectionRecords(string zip)
        {
            string ZipCode = zip.ToString();
            string excelFile = "violations-all-fy12.xlsx";
            string sheetName = "Violations FY12";
            var excel = new ExcelQueryFactory(excelFile);
            excel.AddMapping<InspectionRecord>(x => x.FacilityName, "FACILITY NAME");
            excel.AddMapping<InspectionRecord>(x => x.InspectionDate, "INSPECTION DATE");
            excel.AddMapping<InspectionRecord>(x => x.Address, "ADDRESS");
            excel.AddMapping<InspectionRecord>(x => x.Comment, "VIOLATION COMMENTS");

            var model = from item in excel.Worksheet<InspectionRecord>(sheetName)
                        where item.Address.Contains(ZipCode)
                        select item;

            return View(model);
        }

    }
}
