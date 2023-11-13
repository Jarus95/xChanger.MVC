//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public interface IApplicantProccesingService
    {
        ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel);
        ValueTask<ExternalApplicantModel> GetApplicantByIdAsync(Guid id);
        IQueryable<ExternalApplicantModel> RetrieveAllApplicants();
        ValueTask<ExternalApplicantModel> UpdateApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        Task DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        string GetDownloadedFileName();

    }
}
