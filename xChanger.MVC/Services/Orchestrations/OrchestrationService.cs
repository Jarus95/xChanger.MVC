//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.Groups;
using Tarteeb.XChanger.Services.Proccesings.Applicants;
using Tarteeb.XChanger.Services.Proccesings.Group;
using Tarteeb.XChanger.Services.Proccesings.SpreadSheet;

namespace Tarteeb.XChanger.Services.Orchestrations;

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
            Group ensureGroup = await groupProccesingService.EnsureGroupExistsByName(externalApplicant.GroupName);
            ExternalApplicantModel applicant = MapToApplicant(externalApplicant, ensureGroup);
            await applicantProccesingService.InsertApplicantAsync(applicant);

        }
    });

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
}
