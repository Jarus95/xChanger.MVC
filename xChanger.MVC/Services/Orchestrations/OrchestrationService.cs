//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Groups;
using xChanger.MVC.Services.Proccesings.Applicants;
using xChanger.MVC.Services.Proccesings.Group;
using xChanger.MVC.Services.Proccesings.SpreadSheet;

namespace xChanger.MVC.Services.Orchestrations;

public partial class OrchestrationService : IOrchestrationService
{
    List<ExternalApplicantModel> validExternalApplicants;
    private readonly ISpreadsheetProccesingService spreadsheetProccesingService;
    private readonly IGroupProccesingService groupProccesingService;
    private readonly IApplicantProccesingService applicantProccesingService;
    private readonly ILoggingBroker loggingBroker;

    public OrchestrationService(
        ISpreadsheetProccesingService spreadsheetProccesingService,
        IGroupProccesingService groupProccesingService,
        IApplicantProccesingService applicantProccesingService,
        ILoggingBroker loggingBroker)
    {
        this.validExternalApplicants = new List<ExternalApplicantModel>();
        this.spreadsheetProccesingService = spreadsheetProccesingService;
        this.groupProccesingService = groupProccesingService;
        this.applicantProccesingService = applicantProccesingService;
        this.loggingBroker = loggingBroker;
    }

    public Task ProccesingImportRequest(IFormFile formFile) =>
    TryCatch(async () =>
    {
        this.validExternalApplicants = spreadsheetProccesingService.GetExternalApplicants(formFile);

        foreach (var externalApplicant in validExternalApplicants)
        {
            Group ensureGroup = await GetGroup(externalApplicant);
            ExternalApplicantModel applicant = MapToApplicant(externalApplicant, ensureGroup);
            await applicantProccesingService.InsertApplicantAsync(applicant);

        }
    });

    private ValueTask<Group> GetGroup(ExternalApplicantModel externalApplicant)
    {
        return groupProccesingService.EnsureGroupExistsByName(externalApplicant.GroupName);
    }

    private ExternalApplicantModel MapToApplicant(ExternalApplicantModel externalApplicant, Group ensureGroup)
    {
        return new ExternalApplicantModel
        {
            Id = Guid.NewGuid(),
            FirstName = externalApplicant.FirstName,
            LastName = externalApplicant.LastName,
            Email = externalApplicant.Email,
            GroupName = ensureGroup.GroupName,
            GroupId = ensureGroup.Id,
            PhoneNumber = externalApplicant.PhoneNumber
        };
    }
    public async ValueTask<ExternalApplicantModel> GetApplicantById(Guid id) =>
        await this.applicantProccesingService.GetApplicantByIdAsync(id);

    public IQueryable<ExternalApplicantModel> RetrieveAllApplicants() =>
             this.applicantProccesingService.RetrieveAllApplicants();

    public async ValueTask<ExternalApplicantModel> UpdateApplicant(ExternalApplicantModel externalApplicantModel) =>
         await this.applicantProccesingService.UpdateApplicantModelAsync(externalApplicantModel);
         

    public IQueryable<Group> RetrieveAllGroups()=>
        this.groupProccesingService.RetrieveAllGroups();

    public async Task DeleteApplicantModelAsync(ExternalApplicantModel externalApplicantModel) =>
        await this.applicantProccesingService.DeleteApplicantModelAsync(externalApplicantModel);
}
