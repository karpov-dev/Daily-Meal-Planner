using Syncfusion.Drawing;
using Business_Layer;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace PresentationLayer.Service
{
    class PDFGenerator
    {
        public static bool CreatePDF(User user, DailyRation dailyRation)
        {
            if ( user == null || dailyRation == null ) return false;

            using( PdfDocument document = new PdfDocument() )
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                PdfFont titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont bigFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                PdfFont smallFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

                PdfBrush DarkRedBrush = PdfBrushes.DarkRed;
                PdfBrush BlackBrush = PdfBrushes.Black;
                PdfPen darkBluePen = new PdfPen(Color.DarkBlue, 2);
                PdfPen darkPenLine = new PdfPen(Color.Black, 2);

                graphics.DrawString("DAILY RATION", titleFont, DarkRedBrush, new PointF(0, 0));
                graphics.DrawLine(darkPenLine, new PointF(0, 25), new PointF(900, 25));

                graphics.DrawString("INFORMATION", bigFont, BlackBrush, new PointF(0, 60));
                graphics.DrawString("Age: " + user.Age, font, BlackBrush, new PointF(0, 90));
                graphics.DrawString("Height: " + user.Height, font, BlackBrush, new PointF(150, 90));
                graphics.DrawString("Weight: " + user.Weight, font, BlackBrush, new PointF(300, 90));
                graphics.DrawString("Activity: " + user.GetCurrentStringActivity(), font, BlackBrush, new PointF(0, 120));
                graphics.DrawString("ARM: " + user.GetARM(), font, BlackBrush, new PointF(150, 120));
                graphics.DrawString("BMR: " + user.GetBMR(), font, BlackBrush, new PointF(300, 120));
                graphics.DrawString("Need Calories: " + user.GetCalories(), font, DarkRedBrush, new PointF(0, 150));
                graphics.DrawLine(darkPenLine, new PointF(0, 180), new PointF(900, 180));

                graphics.DrawString("DAILY RATION", bigFont, BlackBrush, new PointF(0, 220));
                int line = 220, lineStep = 20;
                foreach(MealTime mealTime in user.DailyRation.MealTimes )
                {
                    if(mealTime.Products.Count == 0) continue;

                    line += 40;
                    graphics.DrawString("Meal Time: " + mealTime.Name, font, BlackBrush, new PointF(0, line));
                    DataTable dataTable = new DataTable();
                    PdfGrid pdfGrid = new PdfGrid();
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("Gramms");
                    dataTable.Columns.Add("Fats");
                    dataTable.Columns.Add("Carbs");
                    dataTable.Columns.Add("Protein");
                    dataTable.Columns.Add("Calories100");
                    foreach(Product product in mealTime.Products )
                    {
                        dataTable.Rows.Add(new object[]
                        {
                            product.Name,
                            product.Gramms,
                            product.Fats,
                            product.Carbs,
                            product.Protein,
                            product.Calories100
                        });
                    }
                    pdfGrid.DataSource = dataTable;
                    pdfGrid.Draw(page, new PointF(0, line + 20));
                    line += lineStep * mealTime.Products.Count;
                    line += 35;
                    graphics.DrawString("Meal Time TOTAL calories: " + mealTime.GetCalories(), font, DarkRedBrush, new PointF(0, line));
                }
                line += 20;
                graphics.DrawLine(darkPenLine, new PointF(0, line), new PointF(900, line));
                line += 20;
                graphics.DrawString("TOTAL CALORIES: " + dailyRation.GetCalories(), font, DarkRedBrush, new PointF(0, line));

                document.Save(File.Create("DailyRation.pdf"));
                document.Close(true);
                return false;
            }
        }
    }
}
