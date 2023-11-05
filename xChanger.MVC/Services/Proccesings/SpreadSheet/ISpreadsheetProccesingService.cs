//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.SpreadSheet;

public interface ISpreadsheetProccesingService
{
    List<ExternalApplicantModel> GetExternalApplicants(IFormFile file);
}
