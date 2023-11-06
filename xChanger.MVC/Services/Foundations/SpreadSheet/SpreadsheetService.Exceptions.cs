//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using System.Linq;
using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions;
using xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;
using xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions.Categories;
using Xeptions;

namespace xChanger.MVC.Services.Foundations.SpreadSheet
{
    public partial class SpreadsheetService
    {
        private delegate List<ExternalApplicantModel> ReturningExternalApplicantFunction();

        private List<ExternalApplicantModel> TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                return returningExternalApplicantFunction();
            }
            catch (NullSpreadSheetException nullSpreadSheetException)
            {
                throw CreateAndLogValidationException(nullSpreadSheetException);
            }
            catch (InvalidSpreadSheetException invalidSpreadSheetException)
            {
                throw CreateAndLogValidationException(invalidSpreadSheetException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsSpreadSheetException =
                    new AlreadyExistsSpreadSheetException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsSpreadSheetException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedSpreadSheetException =
                    new LockedSpreadSheetException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedSpreadSheetException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedStorageSpreadSheetException =
                    new FailedStorageSpreadSheetException(dbUpdateException);

                throw CreateAndLogDependencyException(failedStorageSpreadSheetException);
            }
            catch (Exception exception)
            {
                var failedServiceSpreadSheetException = new FailedServiceSpreadSheetException(exception);

                throw CreateServiceException(failedServiceSpreadSheetException);
            }
        }

        private SpreadSheetServiceException CreateServiceException(Xeption exception)
        {
            var spreadSheetServiceException = new SpreadSheetServiceException(exception);
            this.loggingBroker.LogError(spreadSheetServiceException);

            return spreadSheetServiceException;
        }

        private SpreadSheetDependecyException CreateAndLogDependencyException(Xeption exception)
        {
            var spreadSheetDependecyException = new SpreadSheetDependecyException(exception);
            this.loggingBroker.LogError(spreadSheetDependecyException);

            return spreadSheetDependecyException;
        }

        private SpreadSheetDependecyValidationException CreateAndLogDependencyValidationException(
            Xeption exception)
        {
            var spreadSheetDependecyValidationException =
                new SpreadSheetDependecyValidationException(exception);

            this.loggingBroker.LogError(spreadSheetDependecyValidationException);

            return spreadSheetDependecyValidationException;
        }

        private SpreadSheetValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var spreadSheetValidationException = 
                new SpreadSheetValidationException(xeption);

            this.loggingBroker.LogError(spreadSheetValidationException);
            
            return spreadSheetValidationException;
        }
    }
}
