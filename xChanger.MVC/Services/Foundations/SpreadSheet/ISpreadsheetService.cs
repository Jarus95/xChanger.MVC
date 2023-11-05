//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Foundations.SpreadSheet;

public interface ISpreadsheetService
{
    List<ExternalApplicantModel> GetApplicants(IFormFile file);
}
