//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Threading.Tasks;
using xChanger.MVC.Models.Orchestrations.ExternalApplicants.Exceptions;
using xChanger.MVC.Models.Orchestrations.Groups;
using xChanger.MVC.Models.Proccesings.Group;
using xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions;
using Xeptions;

namespace xChanger.MVC.Services.Orchestrations
{
    public partial class OrchestrationService
    {
        public delegate Task ReturningExternalApplicantFunction();

        public async Task TryCatch(ReturningExternalApplicantFunction returningExternalApplicantFunction)
        {
            try
            {
                await returningExternalApplicantFunction();
            }
            catch (SpreadSheetProccesingValidationException spreadSheetProccesingValidationException)
            {
                throw CreateAndLogApplicanValidationException(spreadSheetProccesingValidationException.InnerException as Xeption);
            }
            catch(GroupProccesingValidationException groupProccesingValidationException)
            {
                throw CreateAndLogGroupValidationException(groupProccesingValidationException.InnerException as Xeption);
            }
            catch(GroupProccesingDependencyException groupProccesingDependencyException)
            {
                throw CreateAndLogGroupDependencyException(groupProccesingDependencyException.InnerException as Xeption);
            }
            catch(GroupProccesingDependencValidationException groupProccesingDependencValidationException)
            {
                throw CreateAndLogGroupDependencyValidationException(groupProccesingDependencValidationException.InnerException as Xeption);
            }
            catch(GroupProccesingServiceException groupProccesingServiceException)
            {
                throw CreateAndLogGroupServiceException(groupProccesingServiceException.InnerException as Xeption);
            }
        }

        private GroupOrchestartionDependencyValidationException CreateAndLogGroupDependencyValidationException(Xeption xeption)
        {
            var groupOrchestartionDependencyValidationException =
                new GroupOrchestartionDependencyValidationException(xeption);

            this.loggingBroker.LogError(groupOrchestartionDependencyValidationException);

            return groupOrchestartionDependencyValidationException;
        }

        private GroupOrchestartionDependencyException CreateAndLogGroupDependencyException(Xeption xeption)
        {
            var groupOrchestartionDependencyException = 
                new GroupOrchestartionDependencyException(xeption);

            this.loggingBroker.LogError(groupOrchestartionDependencyException);

            return groupOrchestartionDependencyException;
        }

        private GroupOrchestrationServiceException CreateAndLogGroupServiceException(Xeption xeption)
        {
            GroupOrchestrationServiceException groupOrchestrationServiceException =
                new GroupOrchestrationServiceException(xeption);

            this.loggingBroker.LogError(xeption);

            return groupOrchestrationServiceException;
        }

        private ExternalApplicantOrchestrationValidationException CreateAndLogApplicanValidationException(Xeption xeption)
        {
            var externalApplicantOrchestrationValidationException =
                new ExternalApplicantOrchestrationValidationException(xeption);
            
            this.loggingBroker.LogError(externalApplicantOrchestrationValidationException);

            return externalApplicantOrchestrationValidationException;
        }

        private GroupOrchestartionValidationException CreateAndLogGroupValidationException(Xeption xeption)
        {
            var groupOchrestartionValidationException =
                new GroupOrchestartionValidationException(xeption);

            this.loggingBroker.LogError(groupOchrestartionValidationException);

            return groupOchrestartionValidationException;
        }
    }
}
