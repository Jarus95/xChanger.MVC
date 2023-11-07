//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using Xeptions;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;

namespace xChanger.MVC.Services.Foundations.Group
{
    public partial class GroupService
    {
        private delegate ValueTask<ApplicantsGroup> ReturningGroupFunction();
        private delegate IQueryable<ApplicantsGroup> ReturningGroupsFunction();

        private async ValueTask<ApplicantsGroup> TryCatch(ReturningGroupFunction returningGroupFunction)
        {
            try
            {
                return await returningGroupFunction();
            }
            catch (NullGroupEexception nullGroupException)
            {
               throw CreateAndLogValidationException(nullGroupException);
            }
            catch(InvalidGroupException invalidGroupException)
            {
                throw CreateAndLogValidationException(invalidGroupException);
            }

            catch(DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsGroupException =
                     new AlreadyExistsGroupException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsGroupException);
            }

            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedGroupException = 
                    new LockedGroupException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedGroupException);
            }

            catch(DbUpdateException dbUpdateException)
            {
                var failedStorageGroupException = 
                    new FailedStorageGroupException(dbUpdateException);

                throw CreateAndLogDependencyException(failedStorageGroupException);
            }

            catch(Exception exception)
            {
                var failedServiceGroupException = 
                    new FailedServiceGroupException(exception);

                throw CreateServiceException(failedServiceGroupException);
            }
        }

        private IQueryable<ApplicantsGroup> TryCatch(ReturningGroupsFunction returningGroupsFunction)
        {
            try
            {
                return returningGroupsFunction();
            }
            catch (Exception exception)
            {
                var failedServiceGroupException =
                    new FailedServiceGroupException(exception);

                throw CreateServiceException(failedServiceGroupException);
            }
        }
        private GroupDependencyException CreateAndLogDependencyException(Xeption xeption)
        {
            GroupDependencyException groupDependencyException =
                new GroupDependencyException(xeption);

            this.loggingBroker.LogError(groupDependencyException);

            return groupDependencyException;
        }

        private GroupDependencyValidationException CreateAndLogDependencyValidationException(Xeption xeption)
        {
                     
            var groupDependencyValidationException =
                new GroupDependencyValidationException(xeption);

            this.loggingBroker.LogError(groupDependencyValidationException);

            return groupDependencyValidationException;
        }

        private GroupValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var groupValidationException =
                new GroupValidationException(xeption); 

            this.loggingBroker.LogError(groupValidationException);

            return groupValidationException;
        }
        private GroupServiceException CreateServiceException(Xeption xeption)
        {
            var groupServiceException =
                new GroupServiceException(xeption);

            this.loggingBroker.LogError(groupServiceException);

            return groupServiceException;
        }
    }
}
