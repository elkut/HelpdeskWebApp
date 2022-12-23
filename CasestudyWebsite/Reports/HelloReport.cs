﻿using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CasestudyWebsite.Reports
{
    public class HelloReport
    {
        public void GenerateReport(string rootpath)
        {
            PageSize pg = PageSize.A4;
            var helvetica = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);
            Image img = new Image(ImageDataFactory.Create(rootpath + "/img/look-up.png"))
                .ScaleAbsolute(200, 100)
                .SetFixedPosition(((pg.GetWidth() - 200) / 2), 710);
            PdfWriter writer = new(rootpath + "/pdfs/hellow.pdf",
                new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0));
            PdfDocument pdf = new(writer);
            Document document = new(pdf); // PageSize(595, 842)
            document.Add(img);
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("Hello World from PDF LAND!")
                .SetFont(helvetica)
                .SetFontSize(24)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph(""));
            Table table = new Table(3);
            table
                .SetWidth(298) // roughly 50%
                .SetTextAlignment(TextAlignment.CENTER)
                .SetRelativePosition(0, 0, 0, 0)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            Cell cell1 = new Cell()
                .Add(new Paragraph("some data"))
                .SetBorder(Border.NO_BORDER)
                .SetFontSize(10);
            table.AddCell(cell1);
            Cell cell2 = new Cell()
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph("more data"))
                .SetFontSize(10);
            table.AddCell(cell2);
            Cell cell3 = new Cell()
                .Add(new Paragraph("even more data"))
                .SetBorder(Border.NO_BORDER)
                .SetFontSize(10);
            table.AddCell(cell3);
            document.Add(table);
            document.Close();
        }
    }
}
