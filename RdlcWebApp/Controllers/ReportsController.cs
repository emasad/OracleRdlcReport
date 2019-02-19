using Microsoft.Reporting.WebForms;
using RdlcWebApp.DAL;
using RdlcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RdlcWebApp.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult RPTTestReport(string id)
        {
            List<Student> list = new StudentDAL().GetStudent();

            //-----------Report Body----------------                

            if (list.Count >= 0)
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Views/Reports/RPTTestReport.rdlc");

                ReportDataSource reportDataSourceData = new ReportDataSource("DataSet1", list);
                localReport.DataSources.Add(reportDataSourceData);

                ReportParameter pInstName = new ReportParameter();
                pInstName.Name = "P_InstName";
                pInstName.Values.Add("Sonali Bank limited");
                localReport.SetParameters(pInstName);
                ReportParameter pInstAddress = new ReportParameter();
                pInstAddress.Name = "P_InstAddress";
                pInstAddress.Values.Add("Head Office");


                localReport.SetParameters(pInstAddress);

                ReportParameter pReportName = new ReportParameter();
                pReportName.Name = "P_ReportName";
                pReportName.Values.Add("Test Report");
                localReport.SetParameters(pReportName);

                string reportType = "pdf";
                string mimeType;
                string encoding;
                string fileNameExtension;

                string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>11in</PageWidth>" +
                    "  <PageHeight>8.23in</PageHeight>" +
                    "  <MarginTop>0in</MarginTop>" +
                    "  <MarginLeft>0.5in</MarginLeft>" +
                    "  <MarginRight>0in</MarginRight>" +
                    "  <MarginBottom>0in</MarginBottom>" +
                    "</DeviceInfo>";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = localReport.Render(
                    reportType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings);

                return File(renderedBytes, mimeType);
            }
            return View();
        }
    }
}