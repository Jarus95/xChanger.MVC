//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.XChanger.Brokers.DateTimes;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Foundations.Applicants
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
            ValidateApplicantOnAdd(externalApplicantModel);
            return await storageBroker.InsertExternalApplicantModelAsync(externalApplicantModel);

        });

        public IQueryable<ExternalApplicantModel> RetrieveAllExternalApplicantModels() =>
              TryCatch(() => storageBroker.RetrieveAllExternalApplicantModels());
    }
}
