using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LinqToExcel;
using DontEatHere.Web.Models;

namespace DontEatHere.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                        where item.FacilityName.Contains("WINGSTOP")
                        select item;

            return View(model);
        }



    }
}
