using System;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.Applicants.Exceptions;

namespace Tarteeb.XChanger.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private void ValidateApplicantOnAdd(ExternalApplicantModel externalApplicantModel)
        {
            ValidateApplicantNotNull(externalApplicantModel);

            Validate(
                (Rule: IsInvalid(externalApplicantModel.Id), Parameter: nameof(ExternalApplicantModel.Id)),
                (Rule: IsInvalid(externalApplicantModel.FirstName), Parameter: nameof(ExternalApplicantModel.FirstName)),
                (Rule: IsInvalid(externalApplicantModel.LastName), Parameter: nameof(ExternalApplicantModel.LastName)),
                (Rule: IsInvalid(externalApplicantModel.Email), Parameter: nameof(ExternalApplicantModel.Email)),
                (Rule: IsInvalid(externalApplicantModel.PhoneNumber), Parameter: nameof(ExternalApplicantModel.PhoneNumber)));

        }

        private void ValidateApplicantNotNull(ExternalApplicantModel externalApplicantModel)
        {
            if (externalApplicantModel is null)
            {
                throw new NullApplicantException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {

            Condition = System.String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };
        
        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidApplicantException = new InvalidApplicantException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidApplicantException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidApplicantException.ThrowIfContainsErrors();
        }
    }
}
