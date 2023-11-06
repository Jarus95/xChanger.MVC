//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Foundations.SpreadSheet;

public interface ISpreadsheetService
{
    List<ExternalApplicantModel> GetApplicants(IFormFile file);
}
