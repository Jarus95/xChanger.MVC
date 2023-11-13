//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions.Categories;
using xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions;
using Xeptions;

namespace xChanger.MVC.Services.Proccesings.SpreadSheet
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
            catch(EmptyExternalApplicantException emptyExternalApplicantException)
            {
                throw CreateAndLogValidationException(emptyExternalApplicantException);
            }
            catch(SpreadSheetServiceException spreadSheetServiceException)
            {
                throw CreateAndLogServiceException(spreadSheetServiceException.InnerException as Xeption);
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
