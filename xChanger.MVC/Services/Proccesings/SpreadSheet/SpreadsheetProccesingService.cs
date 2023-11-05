//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;
using Tarteeb.XChanger.Services.Foundations.SpreadSheet;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet;
public partial class SpreadsheetProccesingService : ISpreadsheetProccesingService
{
    private readonly ISpreadsheetService spreadsheetService;
    private readonly ILoggingBroker loggingBroker;
    public SpreadsheetProccesingService(ISpreadsheetService spreadsheetService, ILoggingBroker loggingBroker)
    {
        this.spreadsheetService = spreadsheetService;
        this.loggingBroker = loggingBroker;
    }
    public List<ExternalApplicantModel> GetExternalApplicants(IFormFile file) =>
    TryCatch(() =>
    {
        List<ExternalApplicantModel> externalApplicantModels = spreadsheetService.GetApplicants(file);

        ValidateExternalApplicantNotEmpty(externalApplicantModels);

        externalApplicantModels.ForEach(externalAplicant =>
        {
            if (string.IsNullOrWhiteSpace(externalAplicant.FirstName)
                || string.IsNullOrWhiteSpace(externalAplicant.PhoneNumber)
                || string.IsNullOrWhiteSpace(externalAplicant.LastName)
                || string.IsNullOrWhiteSpace(externalAplicant.GroupName))
            {
                externalApplicantModels.Remove(externalAplicant);
            }
        });
        return externalApplicantModels;
    });
}

