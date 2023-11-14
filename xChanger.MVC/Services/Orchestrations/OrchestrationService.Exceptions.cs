//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Globalization;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;
using xChanger.MVC.Models.Foundations.Groups;
using xChanger.MVC.Models.Orchestrations.ExternalApplicants;
using xChanger.MVC.Models.Orchestrations.Groups;
using xChanger.MVC.Models.Orchestrations.SpreadSheet;
using xChanger.MVC.Models.Proccesings.Applicant;
using xChanger.MVC.Models.Proccesings.Group;
using xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions;
using xChanger.MVC.Services.Proccesings.Applicants;
using Xeptions;

namespace xChanger.MVC.Services.Orchestrations
{
    public partial class OrchestrationService
    {
        public delegate Task ProccesingImportFunction();
        public delegate ValueTask<Group> ReturningGroupFunctions();

        public async ValueTask<Group> TryCatch(ReturningGroupFunctions returningGroupFunctions)
        {
            try
            {
                return await returningGroupFunctions();
            }
            catch (GroupProccesingValidationException groupProccesingValidationException)
            {
                throw CreateAndLogGroupOrchestrationValidationException(groupProccesingValidationException.InnerException as Xeption);
            }
            catch (GroupProccesingDependencyException groupProccesingDependencyException)
            {
                throw CreateAndLogGroupOrchestrationDependencyException(groupProccesingDependencyException.InnerException as Xeption);
            }
            catch (GroupProccesingDependencValidationException groupProccesingDependencValidationException)
            {
                throw CreateAndLogGroupOrchestrationDependencyValidationException(groupProccesingDependencValidationException.InnerException as Xeption);
            }
            catch (GroupProccesingServiceException groupProccesingServiceException)
            {
                throw CreateAndLogGroupOrchestrationServiceException(groupProccesingServiceException.InnerException as Xeption);
            }
        }
        public async Task TryCatch(ProccesingImportFunction proccesingImportFunction)
        {
            try
            {
                await proccesingImportFunction();
            }
            catch (SpreadSheetProccesingValidationException spreadSheetProccesingValidationException)
            {
                throw CreateAndLogSpreadSheetOrchestrationValidationException(spreadSheetProccesingValidationException.InnerException as Xeption);
            }
            catch (GroupProccesingValidationException groupProccesingValidationException)
            {
                throw CreateAndLogGroupOrchestrationValidationException(groupProccesingValidationException.InnerException as Xeption);
            }
            catch(GroupProccesingDependencyException groupProccesingDependencyException)
            {
                throw CreateAndLogGroupOrchestrationDependencyException(groupProccesingDependencyException.InnerException as Xeption);
            }
            catch(GroupProccesingDependencValidationException groupProccesingDependencValidationException)
            {
                throw CreateAndLogGroupOrchestrationDependencyValidationException(groupProccesingDependencValidationException.InnerException as Xeption);
            }
            catch(GroupProccesingServiceException groupProccesingServiceException)
            {
                throw CreateAndLogGroupOrchestrationServiceException(groupProccesingServiceException.InnerException as Xeption);
            }
            catch(ApplicantProccesingValidationException applicantProccesingValidationException)
            {
                throw CreateAndLogApplicantOrchestrationValidationException(applicantProccesingValidationException.InnerException as Xeption);
            }
            catch(ApplicantProccesingDependencyException applicantProccesingDependencyException)
            {
                throw CreateAndLogApplicantOrchestrationDependencyException(applicantProccesingDependencyException.InnerException as Xeption);
            }
            catch(ApplicantProccesingDependencyValidationException applicantProccesingDependencyValidationException)
            {
                throw CreateAndLogApplicantOrchestrationDependencyValidationException(applicantProccesingDependencyValidationException.InnerException as Xeption);
            }
            catch(ApplicantProccesingServiceException applicantProccesingServiceException)
            {
                throw CreateAndLogApplicantOrchestrationServiceException(applicantProccesingServiceException.InnerException as Xeption);
            }
        }

        private ApplicantOrchestrationServiceException CreateAndLogApplicantOrchestrationServiceException(Xeption xeption)
        {
            ApplicantOrchestrationServiceException applicantOrchestrationServiceException =
                new ApplicantOrchestrationServiceException(xeption);

            this.loggingBroker.LogError(applicantOrchestrationServiceException);

            return applicantOrchestrationServiceException;
        }

        private ApplicantDependencyValidationException CreateAndLogApplicantOrchestrationDependencyValidationException(Xeption xeption)
        {
            var applicantDependencyValidationException = 
                new ApplicantDependencyValidationException(xeption);

            this.loggingBroker.LogError(applicantDependencyValidationException);

            return applicantDependencyValidationException;
        }

        private SpreadSheetOrchestrationValidationException CreateAndLogSpreadSheetOrchestrationValidationException(Xeption xeption)
        {
            SpreadSheetOrchestrationValidationException spreadSheetOrchestrationValidationException =
                new SpreadSheetOrchestrationValidationException(xeption);

            this.loggingBroker.LogError(spreadSheetOrchestrationValidationException);

            return spreadSheetOrchestrationValidationException;
        }

        private ApplicantOrchestrationDependencyException CreateAndLogApplicantOrchestrationDependencyException(Xeption xeption)
        {
            var applicantOrchestrationDependencyException = 
                new ApplicantOrchestrationDependencyException(xeption);

            this.loggingBroker.LogError(applicantOrchestrationDependencyException);

            return applicantOrchestrationDependencyException;
        }

        private GroupOrchestartionDependencyValidationException CreateAndLogGroupOrchestrationDependencyValidationException(Xeption xeption)
        {
            var groupOrchestartionDependencyValidationException =
                new GroupOrchestartionDependencyValidationException(xeption);

            this.loggingBroker.LogError(groupOrchestartionDependencyValidationException);

            return groupOrchestartionDependencyValidationException;
        }

        private GroupOrchestartionDependencyException CreateAndLogGroupOrchestrationDependencyException(Xeption xeption)
        {
            var groupOrchestartionDependencyException = 
                new GroupOrchestartionDependencyException(xeption);

            this.loggingBroker.LogError(groupOrchestartionDependencyException);

            return groupOrchestartionDependencyException;
        }

        private GroupOrchestrationServiceException CreateAndLogGroupOrchestrationServiceException(Xeption xeption)
        {
            GroupOrchestrationServiceException groupOrchestrationServiceException =
                new GroupOrchestrationServiceException(xeption);

            this.loggingBroker.LogError(xeption);

            return groupOrchestrationServiceException;
        }

        private ExternalApplicantOrchestrationValidationException CreateAndLogApplicantOrchestrationValidationException(Xeption xeption)
        {
            var externalApplicantOrchestrationValidationException =
                new ExternalApplicantOrchestrationValidationException(xeption);
            
            this.loggingBroker.LogError(externalApplicantOrchestrationValidationException);

            return externalApplicantOrchestrationValidationException;
        }

        private GroupOrchestartionValidationException CreateAndLogGroupOrchestrationValidationException(Xeption xeption)
        {
            var groupOchrestartionValidationException =
                new GroupOrchestartionValidationException(xeption);

            this.loggingBroker.LogError(groupOchrestartionValidationException);

            return groupOchrestartionValidationException;
        }
    }
}
