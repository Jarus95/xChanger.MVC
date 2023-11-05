//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions;
using xChanger.MVC.Services.Foundations.SpreadSheet;

namespace xChanger.MVC.Services.Proccesings.SpreadSheet;
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

