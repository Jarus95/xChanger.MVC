//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Services.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Proccesings.Applicants
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
