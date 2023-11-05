//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Brokers;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

namespace xChanger.MVC.Services.Foundations.SpreadSheet;

public partial class SpreadsheetService : ISpreadsheetService
{
    private readonly ISpreadSheetBroker spreadSheetBroker;
    private readonly ILoggingBroker loggingBroker;

    public SpreadsheetService(ISpreadSheetBroker spreadSheetBroker, ILoggingBroker loggingBroker)
    {
        this.spreadSheetBroker = spreadSheetBroker;
        this.loggingBroker = loggingBroker;
    }
    public List<ExternalApplicantModel> GetApplicants(IFormFile file) =>
    TryCatch(() =>
    {
        MemoryStream stream = ValidateSpreadSheetNotNull(file);

        return spreadSheetBroker.ReadExternalApplicants(stream);
    });

    private static MemoryStream ValidateSpreadSheetNotNull(IFormFile file)
    {
        if (file is null)
        {
            throw new NullSpreadSheetException();
        }

        MemoryStream memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        memoryStream.Position = 1;

        return memoryStream;
    }
}
