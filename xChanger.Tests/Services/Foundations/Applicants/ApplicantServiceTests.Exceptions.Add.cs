//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using EFxceptions.Models.Exceptions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;

namespace xChanger.MVC.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDuplicateKeyErrorOccursAndLogItAsync()
        {
            //given 
            string someMessage = GetRandomString();
            ExternalApplicantModel randomApplicant = CreateRandomApplicant();

            var duplicateKeyException =
                new DuplicateKeyException(someMessage);

            var ApplicantAlreadyExistsException =
                new ApplicantAlreadyExistsException(duplicateKeyException);

            var excpectedApplicantDependencyValidationException =
                new ApplicantDependencyValidationException(ApplicantAlreadyExistsException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertExternalApplicantModelAsync(randomApplicant)).ThrowsAsync(duplicateKeyException);
            //when
            ValueTask<ExternalApplicantModel> addApplicantTask =
                   this.applicantService.AddApplicantAsync(randomApplicant);

            var actualApplicantDependencyValidationException =
                await Assert.ThrowsAnyAsync<ApplicantDependencyValidationException>(addApplicantTask.AsTask);
            //then

            actualApplicantDependencyValidationException.
                Should().
                BeEquivalentTo(excpectedApplicantDependencyValidationException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertExternalApplicantModelAsync(randomApplicant), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    excpectedApplicantDependencyValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateConcurrencyErrorOccursAndLogItAsync()
        {
            //given 
            ExternalApplicantModel randomApplicant = CreateRandomApplicant();

            DbUpdateConcurrencyException dbUpdateConcurrencyException =
                new DbUpdateConcurrencyException();

            LockedApplicantException lockedApplicantException =
                new LockedApplicantException(dbUpdateConcurrencyException);

            ApplicantDependencyException expectedApplicantDependencyException =
                 new ApplicantDependencyException(lockedApplicantException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertExternalApplicantModelAsync(randomApplicant)).ThrowsAsync(dbUpdateConcurrencyException);
            //when
            ValueTask<ExternalApplicantModel> addApplicantTask =
                   this.applicantService.AddApplicantAsync(randomApplicant);

            var actualApplicantDependencyException =
                await Assert.ThrowsAnyAsync<ApplicantDependencyException>(addApplicantTask.AsTask);
            //then

            actualApplicantDependencyException.
                Should().
                BeEquivalentTo(expectedApplicantDependencyException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertExternalApplicantModelAsync(randomApplicant), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedApplicantDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateErrorOccursAndLogItAsync()
        {
            //given 
            ExternalApplicantModel randomApplicant = CreateRandomApplicant();

            DbUpdateException dbUpdateException =
                new DbUpdateException();

            var failedApplicantStorageException =
                new FailedApplicantStorageException(dbUpdateException);

            ApplicantDependencyException expectedApplicantDependencyException =
                 new ApplicantDependencyException(failedApplicantStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertExternalApplicantModelAsync(randomApplicant)).ThrowsAsync(dbUpdateException);
            //when
            ValueTask<ExternalApplicantModel> addApplicantTask =
                   this.applicantService.AddApplicantAsync(randomApplicant);

            var actualApplicantDependencyException =
                await Assert.ThrowsAnyAsync<ApplicantDependencyException>(addApplicantTask.AsTask);
            //then

            actualApplicantDependencyException.
                Should().
                BeEquivalentTo(expectedApplicantDependencyException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertExternalApplicantModelAsync(randomApplicant), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedApplicantDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
        {
            //given
            ExternalApplicantModel applicant = CreateRandomApplicant();

            var exception = new Exception();

            var failedApplicantServiceException =
                new FailedApplicantServiceException(exception);

            var expectedApplicantServiceException =
                new ApplicantServiceException(failedApplicantServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.InsertExternalApplicantModelAsync(applicant)).ThrowsAsync(failedApplicantServiceException);
            //when

            ValueTask<ExternalApplicantModel> addApplicantTask =
                this.applicantService.AddApplicantAsync(applicant);


            var actualApplicantServiceException =
                await Assert.ThrowsAnyAsync<ApplicantServiceException>(addApplicantTask.AsTask);

            //then

            actualApplicantServiceException.Should().BeEquivalentTo(expectedApplicantServiceException);

            this.storageBrokerMock.Verify(broker =>
                 broker.InsertExternalApplicantModelAsync(applicant), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(expectedApplicantServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
