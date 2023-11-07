//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================
using System;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;
using Xeptions;

namespace xChanger.MVC.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<ExternalApplicantModel> ReturningApplicantFunction();
        private delegate IQueryable<ExternalApplicantModel> ReturningApplicantsFunction();

        private async ValueTask<ExternalApplicantModel> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantException nullApplicantException)
            {
                throw CreateAndLogValidationException(nullApplicantException);
            }

            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }

            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsApplicantException =
                    new ApplicantAlreadyExistsException(duplicateKeyException);

                throw CreateAndALogDependencyValidationException(alreadyExistsApplicantException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedApplicantException =
                   new LockedApplicantException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedApplicantException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedApplicantStorageException =
                     new FailedApplicantStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedApplicantStorageException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantStorageException = new FailedApplicantStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
            catch (Exception exception)
            {
                var failedApplicantServiceException = new FailedApplicantServiceException(exception);

                throw CreateAndLogServiceException(failedApplicantServiceException);
            }
        }
        private IQueryable<ExternalApplicantModel> TryCatch(ReturningApplicantsFunction returningApplicantsFunction)
        {
            try
            {
                return returningApplicantsFunction();
            }
            catch (Exception exception)
            {
                var failedApplicantsServiceException =
                    new FailedApplicantServiceException(exception);

                throw CreateAndLogServiceException(failedApplicantsServiceException);
            }
        }
        private ApplicantDependencyException CreateAndLogDependencyException(Xeption xeption)
        {
            ApplicantDependencyException applicantDependencyException =
                new ApplicantDependencyException(xeption);

            this.loggingBroker.LogError(applicantDependencyException);

            return applicantDependencyException;
        }
        private ApplicantDependencyValidationException CreateAndALogDependencyValidationException(Xeption exception)
        {
            var applicantDependencyValidationException =
                new ApplicantDependencyValidationException(exception);
            this.loggingBroker.LogError(applicantDependencyValidationException);

            return applicantDependencyValidationException;
        }

        private ApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantValidationException =
                new ApplicantValidationException(exception);
            this.loggingBroker.LogError(applicantValidationException);

            return applicantValidationException;
        }

        private ApplicantDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantDependencyException(exception);

            return applicantDependencyException;
        }

        private ApplicantServiceException CreateAndLogServiceException(Xeption exception)
        {
            var applicantServiceException = new ApplicantServiceException(exception);
            this.loggingBroker.LogError(applicantServiceException);

            return applicantServiceException;
        }

    }
}
