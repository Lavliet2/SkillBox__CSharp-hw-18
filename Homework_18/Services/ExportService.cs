using ClosedXML.Excel;
using Homework_18.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Homework_18.Services
{
    public class ExportService : IExportService
    {
        public async Task ExportToExcelAsync(ObservableCollection<IAnimal> animals, string path)
        {            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Animals");
                worksheet.Cell("A1").Value = "ID";
                worksheet.Cell("B1").Value = "Type";
                worksheet.Cell("C1").Value = "Habitat";

                int row = 2;
                foreach (var animal in animals)
                {
                    worksheet.Cell(row, 1).Value = animal.ID;
                    worksheet.Cell(row, 2).Value = animal.Name;
                    worksheet.Cell(row, 3).Value = animal.Habitat;
                    row++;
                }

                workbook.SaveAs(path);
            }
        }

        public async Task ExportToTextAsync(ObservableCollection<IAnimal> animals, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                await writer.WriteLineAsync("ID\tType\tHabitat");

                foreach (var animal in animals)
                {
                    await writer.WriteLineAsync($"{animal.ID}\t{animal.Name}\t{animal.Habitat}");
                }
            }
        }

        public async Task ExportToPdfAsync(ObservableCollection<IAnimal> animals, string path)
        {
            using (var writer = new PdfWriter(path))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    Table table = new Table(new float[] { 1, 3, 3 });
                    table.AddHeaderCell("ID");
                    table.AddHeaderCell("Type");
                    table.AddHeaderCell("Habitat");

                    foreach (var animal in animals)
                    {
                        table.AddCell(animal.ID.ToString());
                        table.AddCell(animal.Name);
                        table.AddCell(animal.Habitat);
                    }

                    document.Add(table);
                    document.Close();
                }
            }
        }
    }
}
