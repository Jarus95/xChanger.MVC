using System.Linq;
using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using xChanger.MVC.Models.Proccesings.Applicant;
using xChanger.MVC.Models.Proccesings.Group;
using Xeptions;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public partial class ApplicantProccesingService
    {
        private delegate ValueTask<ExternalApplicantModel> ReturningApplicantFunctions();
        private delegate IQueryable<ExternalApplicantModel> ReturningApplicantsFunctions();

        private async ValueTask<ExternalApplicantModel> TryCatch(ReturningApplicantFunctions returningApplicantsFunctions)
        {
            try
            {
                return await returningApplicantsFunctions();
            }
            catch (ApplicantValidationException applicantValidationException)
            {
                throw CreateAndLogApplicantProccesingValidationException(applicantValidationException.InnerException as Xeption);
            }
            catch (ApplicantDependencyException applicantDependencyException)
            {
                throw CreateAndLogApplicantProccesingDependencException(applicantDependencyException.InnerException as Xeption);
            }
            catch (ApplicantDependencyValidationException applicantDependencyValidationException)
            {      
                throw CreateAndLogApplicantProccesingDependencValidationException(applicantDependencyValidationException.InnerException as Xeption);
            }
            catch (ApplicantServiceException applicantServiceException)
            {
                throw CreateAndLogApplicantProccesingServiceException(applicantServiceException.InnerException as Xeption);
            }
        }

        private IQueryable<ExternalApplicantModel> TryCatch(ReturningApplicantsFunctions returningApplicantsFunctions)
        {
            try
            {
                return returningApplicantsFunctions();
            }
            catch(ApplicantServiceException applicantServiceException)
            {
                throw CreateAndLogApplicantProccesingServiceException(applicantServiceException.InnerException as Xeption);
            }
        }

        private ApplicantProccesingServiceException CreateAndLogApplicantProccesingServiceException(Xeption xeption)
        {
            var applicantProccesingServiceException =
                new ApplicantProccesingServiceException(xeption);

            this.loggingBroker.LogError(applicantProccesingServiceException);

            return applicantProccesingServiceException;
        }

        private ApplicantProccesingDependencyException CreateAndLogApplicantProccesingDependencException(Xeption xeption)
        {
            var applicantProccesingDependencyException =
                new ApplicantProccesingDependencyException(xeption);

            this.loggingBroker.LogError(applicantProccesingDependencyException);

            return applicantProccesingDependencyException;
        }

        private ApplicantProccesingDependencyValidationException CreateAndLogApplicantProccesingDependencValidationException(Xeption xeption)
        {
            var applicantProccesingDependencyValidationException =
                new ApplicantProccesingDependencyValidationException(xeption);

            this.loggingBroker.LogError(applicantProccesingDependencyValidationException);

            return applicantProccesingDependencyValidationException;
        }

        private ApplicantProccesingValidationException CreateAndLogApplicantProccesingValidationException(Xeption xeption)
        {
            var applicantProccesingValidationException =
                new ApplicantProccesingValidationException(xeption);

            this.loggingBroker.LogError(xeption);

            return applicantProccesingValidationException;

        }
    }
}
