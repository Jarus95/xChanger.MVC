//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public class ApplicantProccesingService : IApplicantProccesingService
    {
        private readonly IApplicantService applicantService;

        public ApplicantProccesingService(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        public async ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel) =>
            await applicantService.AddApplicantAsync(externalApplicantModel);
    }
}
