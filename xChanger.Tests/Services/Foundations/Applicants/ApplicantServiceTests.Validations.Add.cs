//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using FluentAssertions;
using Moq;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;

namespace xChanger.MVC.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfApplicantIsNullAndLogItAsync()
        {
            //given
            ExternalApplicantModel noApplicant = null;
            var nullApplicantException = new NullApplicantException();

            var expectedApplicantValidationException = new ApplicantValidationException(nullApplicantException);

            //when
            ValueTask<ExternalApplicantModel> addApplicantTask =
                this.applicantService.AddApplicantAsync(noApplicant);

            ApplicantValidationException actualApplicantVAlidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            //then
            actualApplicantVAlidationException.Should().BeEquivalentTo(
                expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertExternalApplicantModelAsync(It.IsAny<ExternalApplicantModel>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnAddIfApplicantIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidApplicant = new ExternalApplicantModel
            {
                FirstName = invalidText
            };

            var invalidApplicantException = new InvalidApplicantException();

            invalidApplicantException.AddData(
            key: nameof(ExternalApplicantModel.Id),
            values: "Id is required");

            invalidApplicantException.AddData(
            key: nameof(ExternalApplicantModel.FirstName),
            values: "Text is required");

            invalidApplicantException.AddData(
            key: nameof(ExternalApplicantModel.LastName),
            values: "Text is required");

            invalidApplicantException.AddData(
            key: nameof(ExternalApplicantModel.PhoneNumber),
            values: "Text is required");

            invalidApplicantException.AddData(
            key: nameof(ExternalApplicantModel.Email),
            values: "Text is required");

            var expectedApplicantValidationException =
             new ApplicantValidationException(invalidApplicantException);

            //when
            ValueTask<ExternalApplicantModel> addApplicantTask =
                this.applicantService.AddApplicantAsync(invalidApplicant);

            ApplicantValidationException actualApplicantValidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            //then
            actualApplicantValidationException.Should().BeEquivalentTo(expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertExternalApplicantModelAsync(It.IsAny<ExternalApplicantModel>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
