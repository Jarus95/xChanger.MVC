//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet
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
