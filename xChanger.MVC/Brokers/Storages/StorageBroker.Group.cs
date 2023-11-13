//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using xChanger.MVC.Models.Foundations.Groups;

namespace xChanger.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Group> Group { get; set; }


        public string GroupGetDownloadedFileName()
        {
            var groups = RetrieveAllGroups();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();


            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells["A1"].Value = "GroupName";

            int row = 2;
            foreach (var group in groups)
            {
                int column = 1;

                worksheet.Cells[row, column].Value = group.GroupName;
                column++;
                row++;
            }
            string fileName = "groups.xlsx";
            string filePath = Path.Combine(rootPath, fileName);
            package.SaveAs(new FileInfo(filePath));
            return fileName;

        }
        public async ValueTask<Group> InsertGroupAsync(Group group) =>
            await InsertAsync(group);

        public IQueryable<Group> RetrieveAllGroups() =>
            SelectAll<Group>();

        public async ValueTask<Group> SelectGroupIdAsync(Guid id) => 
            await SelectAsync<Group>(id);

        public async ValueTask<Group> UpdateGroupAsync(Group group) =>
            await UpdateAsync(group);

        public async Task DeleteGroupAsync(Group group) =>
            await DeleteAsync(group);
    }
}
