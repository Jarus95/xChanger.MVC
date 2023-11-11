//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public interface IApplicantProccesingService
    {
        ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel);
        IQueryable<ExternalApplicantModel> RetrieveAllApplicants();
        ValueTask<ExternalApplicantModel> UpdateApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
        ValueTask<ExternalApplicantModel> DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel);

    }
}
