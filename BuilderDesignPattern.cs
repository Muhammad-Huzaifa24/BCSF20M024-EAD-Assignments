using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A6
{

    // ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 

    // Product classes
    public class PDFReport
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Data { get; set; }

        public void print()
        {
            Console.WriteLine("PDF");
        }

    }
    public class ExcelReport
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Data { get; set; }

    }

    // build the parts of product (report) as generic
    // return product (report) as generic
    public interface IReportBuilder
    {
        void BuildHeader();
        void BuildBody();
        void BuildTitle();
        void BuildData();
        object GetReport(); // Use 'object' as a common return type for both PDFReport and ExcelReport
    }

    // build the PDF report parts
    // concrete report builder
    public class PDFReportBuilder : IReportBuilder
    {
        private PDFReport _pdfReport = new PDFReport();

        public void BuildHeader()
        {
            _pdfReport.Header = "PDF Header";
        }

        public void BuildBody()
        {
            _pdfReport.Body = "PDF Body";
        }

        public void BuildTitle() 
        {
            _pdfReport.Title = "PDF title";
        }
        public void BuildData()
        {
            _pdfReport.Data = "PDF Data";
        }
        public object GetReport()
        {
            return _pdfReport;
        }
    }

    // build the Excel report parts
    // concrete report builder
    public class ExcelReportBuilder : IReportBuilder
    {
        private ExcelReport _excelReport = new ExcelReport();

        public void BuildHeader()
        {
            _excelReport.Header = "Excel Header";
        }

        public void BuildBody()
        {
            _excelReport.Body = "Excel Body";
        }
        public void BuildTitle()
        {
            _excelReport.Title = "Excel Title";
        }

        public void BuildData()
        {
            _excelReport.Data = "Excel Data";
        }

        public object GetReport()
        {
            return _excelReport;
        }
    }

    // hiding the construction process
    // separation the construction process from 
    // the client code
    // ensures the generated is correct
    public class ReportDirector
    {
        private IReportBuilder _builder;

        public ReportDirector(IReportBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildHeader();
            _builder.BuildBody();
            _builder.BuildTitle();
            _builder.BuildData();
        }
    }

    // ----------------------------------------- ( EXAMPLE 02 ) -------------------------

    // Product classes
    public class FluentPDFReport
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Data { get; set; }
    }
    public class FluentExcelReport
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Data { get; set; }

    }

    // chain method calling process
    // more readable for client
    // create a separate method 
    // for each fucntionaliti and
    // based on coming paramter and apply check
    // separate the resultant product
    public class FluentReportBuilder
    {
        private FluentPDFReport _pdfReport = new FluentPDFReport();
        private FluentExcelReport _excelReport = new FluentExcelReport();
        private string _reportType;

        public FluentReportBuilder ForPDFReport()
        {
            _reportType = "PDF";
            return this;
        }

        public FluentReportBuilder ForExcelReport()
        {
            _reportType = "Excel";
            return this;
        }

        public FluentReportBuilder SetHeader(string header)
        {
            if (_reportType == "PDF")
            {
                _pdfReport.Header = header;
            }
            else if (_reportType == "Excel")
            {
                _excelReport.Title = header;
            }
            return this;
        }
        public FluentReportBuilder SetTitle(string title)
        {
            if(_reportType == "PDF")
            {
                _pdfReport.Title = title;
            }
            else if (_reportType == "Excel")
            {
                _excelReport.Title = title;
            }
            return this;
        }

        public FluentReportBuilder SetData(string data)
        {
            if (_reportType == "PDF")
            {
                _pdfReport.Data = data;
            }
            else if (_reportType == "Excel")
            {
                _excelReport.Data = data;
            }
            return this;
        }

        public FluentReportBuilder SetBody(string body)
        {
            if (_reportType == "PDF")
            {
                _pdfReport.Body = body;
            }
            else if (_reportType == "Excel")
            {
                _excelReport.Data = body;
            }
            return this;
        }

        public object GetReport()
        {
            return _reportType == "PDF" ? (object)_pdfReport : _excelReport;
        }

        public void DisplayPDFReport()
        {
            if (_reportType == "PDF")
            {
                Console.WriteLine($"PDF Report Details:\nHeader: {_pdfReport.Header}\nBody: {_pdfReport.Body}\nTitle: {_pdfReport.Title}\nData: {_pdfReport.Data}");
            }
            else
            {
                Console.WriteLine("No PDF report data available.");
            }
        }

        public void DisplayExcelReport()
        {
            if (_reportType == "Excel")
            {
                Console.WriteLine($"Excel Report Details:\nHeader: {_excelReport.Header}\nBody: {_excelReport.Body}\nTitle: {_excelReport.Title}\nData: {_excelReport.Data}");
            }
            else
            {
                Console.WriteLine("No Excel report data available.");
            }
        }
    }




}
