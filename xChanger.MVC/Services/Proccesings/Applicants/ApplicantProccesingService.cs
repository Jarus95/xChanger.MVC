//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Group;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public partial class ApplicantProccesingService : IApplicantProccesingService
    {
        private readonly IApplicantService applicantService;
        private readonly ILoggingBroker loggingBroker;
        public ApplicantProccesingService(IApplicantService applicantService, ILoggingBroker loggingBroker)
        {
            this.applicantService = applicantService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
            TryCatch(async () => await applicantService.AddApplicantAsync(externalApplicantModel));

        public IQueryable<ExternalApplicantModel> RetrieveAllApplicants() =>
          TryCatch(() => this.applicantService.RetrieveAllExternalApplicantModels());

        public ValueTask<ExternalApplicantModel> UpdateApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
            TryCatch(async () => await applicantService.UpdateApplicantModelAsync(externalApplicantModel));

        public async Task DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
                await applicantService.DeleteApplicantModelAsync(externalApplicantModel);

        public async ValueTask<ExternalApplicantModel> GetApplicantByIdAsync(Guid id) =>
            await this.applicantService.GetApplicantByIdAsync(id);

        public string GetDownloadedFileName() => this.applicantService.GetDownloadedFileName();
    }
}
