//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;
using Xeptions;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet
{
    public partial class SpreadsheetProccesingService
    {
        private delegate List<ExternalApplicantModel> ReturningExternalApplicantFunction();
        
        private List<ExternalApplicantModel> TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                return returningExternalApplicantFunction();
            }
            catch (SpreadSheetValidationException spreadSheetValidationException)
            {
                throw CreateAndLogValidationException(spreadSheetValidationException.InnerException as Xeption);
            }

            catch(SpreadSheetServiceException spreadSheetServiceException)
            {
                throw CreateAndLogServiceException(spreadSheetServiceException.InnerException as Xeption);
            }

            catch(EmptyExternalApplicantException emptyExternalApplicantException)
            {
                throw CreateAndLogValidationException(emptyExternalApplicantException);
            }
        }

        private SpreadSheetProccesingServiceException CreateAndLogServiceException(Xeption xeption)
        {
            var spreadSheetProccesingServiceException =
                new SpreadSheetProccesingServiceException(xeption);

            this.loggingBroker.LogError(spreadSheetProccesingServiceException);

            return spreadSheetProccesingServiceException;
        }

        private SpreadSheetProccesingValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var spreadSheetProccesingValidationException = 
                new SpreadSheetProccesingValidationException(xeption);

            this.loggingBroker.LogError(spreadSheetProccesingValidationException);

            return spreadSheetProccesingValidationException;
        }
    }
}
