﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace NOEN.Common
{
    public static class ReportHelper
    {
        public static async Task GeneratePdf(string html, string filePath)
        {
            await Task.Run(() =>
            {
                using(FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                    pdf.Save(ms);
                }
            });
        }

        public static Task GenerateXls<T>(List<T> datasorce, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(nameof(T));
                    ws.Cells["A1"].LoadFromCollection<T>(datasorce, true, TableStyles.Light1);
                    ws.Cells.AutoFitColumns();
                    pck.Save();
                }
            });
        }
    }
}