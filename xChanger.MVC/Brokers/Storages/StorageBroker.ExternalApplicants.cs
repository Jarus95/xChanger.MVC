//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ExternalApplicantModel> ExternalApplicantModel { get; set; }
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "wwwroot", "data");
        public string ApplicantGetDownloadedFileName()
        {
            var applicants = RetrieveAllExternalApplicantModels();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();


            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells["A1"].Value = "Firstname";
            worksheet.Cells["B1"].Value = "Lastname";
            worksheet.Cells["C1"].Value = "Email";
            worksheet.Cells["D1"].Value = "PhoneNumber";
            worksheet.Cells["E1"].Value = "GroupName";

            int row = 2;
            foreach (var student in applicants)
            {
                int column = 1;

                worksheet.Cells[row, column].Value = student.FirstName;
                column++;
                worksheet.Cells[row, column].Value = student.LastName;
                column++;
                worksheet.Cells[row, column].Value = student.Email;
                column++;
                worksheet.Cells[row, column].Value = student.PhoneNumber;
                column++;
                worksheet.Cells[row, column].Value = student.GroupName;
                row++;
            }
            string fileName = "applicants.xlsx";
            string filePath = Path.Combine(rootPath, fileName);
            package.SaveAs(new FileInfo(filePath));
            return fileName;

        }
        public async ValueTask<ExternalApplicantModel> InsertExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await InsertAsync(externalApplicantModel);

        public IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels() =>
            SelectAll<ExternalApplicantModel>();

        public async ValueTask<ExternalApplicantModel> SelectExternalApplicantModelIdAsync(Guid id) =>
            await SelectAsync<ExternalApplicantModel>();

        public async ValueTask<ExternalApplicantModel> UpdateExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await UpdateAsync(externalApplicantModel);

        public async Task DeleteExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await DeleteAsync(externalApplicantModel);
    }
}
