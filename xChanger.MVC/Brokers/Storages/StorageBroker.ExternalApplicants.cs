//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ExternalApplicantModel> ExternalApplicantModel { get; set; }

        public async ValueTask<ExternalApplicantModel> InsertExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await InsertAsync(externalApplicantModel);

        public IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels() =>
            SelectAll<ExternalApplicantModel>();

        public async ValueTask<ExternalApplicantModel> SelectExternalApplicantModelIdAsync(Guid id) =>
            await SelectAsync<ExternalApplicantModel>();

        public async ValueTask<ExternalApplicantModel> UpdateExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await UpdateAsync(externalApplicantModel);

        public async ValueTask<ExternalApplicantModel> DeleteExternalApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            await DeleteAsync(externalApplicantModel);
    }
}
