//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet;

public interface ISpreadsheetProccesingService
{
    List<ExternalApplicantModel> GetExternalApplicants(IFormFile file);
}
