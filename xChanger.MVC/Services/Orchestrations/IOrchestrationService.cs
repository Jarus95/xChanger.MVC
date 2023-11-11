//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Orchestrations;

public interface IOrchestrationService
{
    Task ProccesingImportRequest(IFormFile file);
    IQueryable<ExternalApplicantModel> RetrieveAllApplicants();
    ValueTask<ExternalApplicantModel> UpdateApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
    ValueTask<ExternalApplicantModel> DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel);

}
