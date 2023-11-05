//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Orchestrations.ExternalApplicants.Exceptions;
using Tarteeb.XChanger.Models.Orchestrations.Groups;
using Tarteeb.XChanger.Models.Proccesings.Group;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;
using Xeptions;

namespace Tarteeb.XChanger.Services.Orchestrations
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

        private GroupOchrestartionDependencyException CreateAndLogGroupDependencyException(Xeption xeption)
        {
            var groupOchrestartionDependencyException = 
                new GroupOchrestartionDependencyException(xeption);

            this.loggingBroker.LogError(groupOchrestartionDependencyException);

            return groupOchrestartionDependencyException;
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

        private GroupOchrestartionValidationException CreateAndLogGroupValidationException(Xeption xeption)
        {
            var groupOchrestartionValidationException =
                new GroupOchrestartionValidationException(xeption);

            this.loggingBroker.LogError(groupOchrestartionValidationException);

            return groupOchrestartionValidationException;
        }
    }
}
