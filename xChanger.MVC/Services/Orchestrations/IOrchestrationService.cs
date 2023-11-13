//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Groups;

namespace xChanger.MVC.Services.Orchestrations;

public interface IOrchestrationService
{
    Task ProccesingImportRequest(IFormFile file);
    ValueTask<ExternalApplicantModel> GetApplicantById(Guid id);
    IQueryable<ExternalApplicantModel> RetrieveAllApplicants();
    IQueryable<Group> RetrieveAllGroups();
    ValueTask<Group> UpdateGroupAsync(Group group);
    Task DeleteGroupAsync(Group group);
    ValueTask<ExternalApplicantModel> UpdateApplicant(ExternalApplicantModel externalApplicantModel);
    Task DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel);
    string ApplicantGetDownloadedFileName();
    string GroupGetDownloadedFileName();
}
