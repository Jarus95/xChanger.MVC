//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers
{
    public class SpreadSheetBroker : ISpreadSheetBroker
    {
        static bool IsTrailingFinalRow(int row, int column, ExcelWorksheet worksheet) =>
            String.IsNullOrEmpty(worksheet.Cells[row, column].Value?.ToString());
        public List<ExternalApplicantModel> ReadExternalApplicants(MemoryStream stream)
        {
            var externalApplicants = new List<ExternalApplicantModel>();
            int row = 2;
            int column = 1;
            using var excelPackage = new ExcelPackage(stream);
            ExcelWorksheet worksheet =
                excelPackage.Workbook.Worksheets[0];

            while (!IsTrailingFinalRow(row, column, worksheet))
            {
                var externalApplicant = new ExternalApplicantModel();

                externalApplicant.FirstName = worksheet.Cells[row, column].Value.ToString();
                externalApplicant.LastName = worksheet.Cells[row, column + 1].Value.ToString();
                externalApplicant.Email = worksheet.Cells[row, column + 2].Value.ToString();
                externalApplicant.PhoneNumber = worksheet.Cells[row, column + 3].Value.ToString();
                externalApplicant.GroupName = worksheet.Cells[row, column + 4].Value.ToString();

                externalApplicants.Add(externalApplicant);
                row++;
            }
            return externalApplicants;


        }
    }
}
