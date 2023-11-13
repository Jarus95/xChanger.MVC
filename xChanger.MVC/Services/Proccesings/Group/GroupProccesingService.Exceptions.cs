//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using xChanger.MVC.Models.Proccesings.Group;
using Xeptions;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Proccesings.Group
{
    public partial class GroupProccesingService
    {
        private delegate ValueTask<ApplicantsGroup> ReturningGroupFunctions();
        private delegate IQueryable<ApplicantsGroup> ReturningGroupsFunctions();

        private IQueryable<ApplicantsGroup> TryCatch(ReturningGroupsFunctions returningGroupsFunctions)
        {
            try
            {
                return returningGroupsFunctions();
            }
            catch (FailedServiceGroupException FailedServiceGroupException)
            {
                throw CreateAndLogGroupProccesingServiceException(FailedServiceGroupException.InnerException as Xeption);
            }
        }
        private async ValueTask<ApplicantsGroup> TryCatch(ReturningGroupFunctions returningGroupsFunctions)
        {
            try
            {
                return await returningGroupsFunctions();
            }
            catch (GroupValidationException groupValidationException)
            {
                throw CreateAndLogGroupProccesingValidationException(groupValidationException.InnerException as Xeption);
            }
            catch (GroupDependencyException groupDependencyException)
            {
                throw CreateAndLogGroupProccesingDependencException(groupDependencyException.InnerException as Xeption);
            }
            catch (GroupDependencyValidationException groupDependencyValidationException)
            {
                throw CreateAndLogGroupProccesingDependencValidationException(groupDependencyValidationException.InnerException as Xeption);
            }
            catch (GroupServiceException groupServiceException)
            {
                throw CreateAndLogGroupProccesingServiceException(groupServiceException.InnerException as Xeption);
            }
        }

        private GroupProccesingServiceException CreateAndLogGroupProccesingServiceException(Xeption xeption)
        {
            var groupProccesingServiceException =
                new GroupProccesingServiceException(xeption);

            this.loggingBroker.LogError(groupProccesingServiceException);

            return groupProccesingServiceException;
        }

        private GroupProccesingDependencyException CreateAndLogGroupProccesingDependencException(Xeption xeption)
        {
            var groupProccesingDependencyException =
                new GroupProccesingDependencyException(xeption);

            this.loggingBroker.LogError(groupProccesingDependencyException);

            return groupProccesingDependencyException;
        }

        private GroupProccesingDependencValidationException CreateAndLogGroupProccesingDependencValidationException(Xeption xeption)
        {
            var groupProccesingDependencValidationException =
                new GroupProccesingDependencValidationException(xeption);

            this.loggingBroker.LogError(groupProccesingDependencValidationException);

            return groupProccesingDependencValidationException;
        }

        private GroupProccesingValidationException CreateAndLogGroupProccesingValidationException(Xeption xeption)
        {
            var groupProccesingValidationException =
                new GroupProccesingValidationException(xeption);

            this.loggingBroker.LogError(xeption);

            return groupProccesingValidationException;
        }
    }
}
