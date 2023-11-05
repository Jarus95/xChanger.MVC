//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions;

namespace xChanger.MVC.Services.Proccesings.SpreadSheet
{
    public partial class SpreadsheetProccesingService
    {
        private static void ValidateExternalApplicantNotEmpty(List<ExternalApplicantModel> externalApplicantModels)
        {
            if (externalApplicantModels.Count == 0)
            {
                throw new EmptyExternalApplicantException();
            }
        }
    }
}
