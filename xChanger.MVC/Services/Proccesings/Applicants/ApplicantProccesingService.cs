//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public partial class ApplicantProccesingService : IApplicantProccesingService
    {
        private readonly IApplicantService applicantService;
        private readonly ILoggingBroker loggingBroker;
        public ApplicantProccesingService(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        public async ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
            await applicantService.AddApplicantAsync(externalApplicantModel);

        public IQueryable<ExternalApplicantModel> RetrieveAllApplicants() =>
            this.applicantService.RetrieveAllExternalApplicantModels();
    }
}
