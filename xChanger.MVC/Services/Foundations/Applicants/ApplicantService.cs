//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Brokers.DateTimes;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Brokers.Storages;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public ApplicantService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }
        public ValueTask<ExternalApplicantModel> AddApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
        TryCatch(async () =>
        {
            ValidateApplicanAdd(externalApplicantModel);
            return await storageBroker.InsertExternalApplicantModelAsync(externalApplicantModel);

        });

        public IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels() =>
              TryCatch(() => storageBroker.RetrieveAllExternalApplicantModels());

        public ValueTask<ExternalApplicantModel> UpdateApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
        TryCatch(async () =>
        {
            ValidateApplicantOnModify(externalApplicantModel);
            return await storageBroker.UpdateExternalApplicantModelAsync(externalApplicantModel);

        });
        public async Task DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel)
        {
            ValidateApplicanId(externalApplicantModel);
            await storageBroker.DeleteExternalApplicantModelAsync(externalApplicantModel);

        }

        public async ValueTask<ExternalApplicantModel> GetApplicantByIdAsync(Guid id) =>
            await this.storageBroker.SelectExternalApplicantModelIdAsync(id);
    }
}
