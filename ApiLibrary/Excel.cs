using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;

namespace ApiLibrary
{
    public class Excel
    {
        public static void NewExcelWoorkbook(string name)
        {

            using ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            IWorkbook workbook = application.Workbooks.Create(1);

            application.DefaultVersion = ExcelVersion.Excel2013;
            FileStream stream = new FileStream($"{name}.xlsx", FileMode.Create, FileAccess.ReadWrite);
            workbook.SaveAs(stream);
            stream.Dispose();
            workbook.Close();
            excelEngine.Dispose();

        }
        public static void SubscribersToExcel(List<Subscriber> subscribers, string name)
        {
            using ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            FileStream inputStream = new FileStream(name + ".xlsx", FileMode.Open);
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);

            inputStream.Dispose();

            application.DefaultVersion = ExcelVersion.Excel2013;

            IWorksheet namedSheet = workbook.Worksheets.Create("Subscribers");
            IWorksheet worksheet = workbook.Worksheets["Subscribers"];

            workbook.Worksheets[0].Remove();

            worksheet.Range["A1"].Text = "First Name";
            worksheet.Range["B1"].Text = "Last Name";
            worksheet.Range["C1"].Text = "Email";
            worksheet.Range["D1"].Text = "Mobile";

            IStyle style = workbook.Styles.Add("Header");
            style.Font.Bold = true;
            worksheet.Range["A1:D1"].CellStyle = style;

            int counter = 2;
            foreach (Subscriber Subscriber in subscribers)
            {
                worksheet.Range["A" + counter].Text = Subscriber.FirstName;
                worksheet.Range["B" + counter].Text = Subscriber.LastName;
                worksheet.Range["C" + counter].Text = Subscriber.Email;
                worksheet.Range["D" + counter].Text = Subscriber.Mobile;
                counter++;
            }

            FileStream stream = new FileStream($"{name}.xlsx", FileMode.Create, FileAccess.ReadWrite);
            workbook.SaveAs(stream);
            stream.Dispose();
            workbook.Close();
            excelEngine.Dispose();
        }
    }
}
