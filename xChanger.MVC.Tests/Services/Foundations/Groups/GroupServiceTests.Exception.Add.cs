//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================
using EFxceptions.Models.Exceptions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDuplicateKeyErrorOccursAndLogItAsync()
        {
            //given 
            string someMessage = GetRandomString();
            ApplicantsGroup randomGroup = CreateRandomGroup();

            var duplicateKeyException =
                new DuplicateKeyException(someMessage);

            var alreadyExistsGroupException =
                new AlreadyExistsGroupException(duplicateKeyException);

            var excpectedGroupDependencyValidationException =
                new GroupDependencyValidationException(alreadyExistsGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(randomGroup)).ThrowsAsync(duplicateKeyException);
            //when
            ValueTask<ApplicantsGroup> addGroupTask =
                   this.groupService.AddGroupAsync(randomGroup);

            var actualGroupDependencyValidationException =
                await Assert.ThrowsAnyAsync<GroupDependencyValidationException>(addGroupTask.AsTask);
            //then

            actualGroupDependencyValidationException.
                Should().
                BeEquivalentTo(excpectedGroupDependencyValidationException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertGroupAsync(randomGroup), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    excpectedGroupDependencyValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateConcurrencyErrorOccursAndLogItAsync()
        {
            //given 
            ApplicantsGroup randomGroup = CreateRandomGroup();

            DbUpdateConcurrencyException dbUpdateConcurrencyException =
                new DbUpdateConcurrencyException();

            LockedGroupException lockedGroupException =
                new LockedGroupException(dbUpdateConcurrencyException);

            GroupDependencyException expectedGroupDependencyException =
                 new GroupDependencyException(lockedGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(randomGroup)).ThrowsAsync(dbUpdateConcurrencyException);
            //when
            ValueTask<ApplicantsGroup> addGroupTask =
                   this.groupService.AddGroupAsync(randomGroup);

            var actualGroupDependencyException =
                await Assert.ThrowsAnyAsync<GroupDependencyException>(addGroupTask.AsTask);
            //then

            actualGroupDependencyException.
                Should().
                BeEquivalentTo(expectedGroupDependencyException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertGroupAsync(randomGroup), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedGroupDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateErrorOccursAndLogItAsync()
        {
            //given 
            ApplicantsGroup randomGroup = CreateRandomGroup();

            DbUpdateException dbUpdateException =
                new DbUpdateException();

            var failedStorageGroupException =
                new FailedStorageGroupException(dbUpdateException);

            GroupDependencyException expectedGroupDependencyException =
                 new GroupDependencyException(failedStorageGroupException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(randomGroup)).ThrowsAsync(dbUpdateException);
            //when
            ValueTask<ApplicantsGroup> addGroupTask =
                   this.groupService.AddGroupAsync(randomGroup);

            var actualGroupDependencyException =
                await Assert.ThrowsAnyAsync<GroupDependencyException>(addGroupTask.AsTask);
            //then

            actualGroupDependencyException.
                Should().
                BeEquivalentTo(expectedGroupDependencyException);

            this.storageBrokerMock.Verify(broker =>
             broker.InsertGroupAsync(randomGroup), Times.Once);


            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedGroupDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogItAsync()
        {
            //given
            ApplicantsGroup group = CreateRandomGroup();

            var exception = new Exception();

            var failedServiceGroupException =
                new FailedServiceGroupException(exception);

            var expectedGroupServiceException =
                new GroupServiceException(failedServiceGroupException);

            this.storageBrokerMock.Setup(broker =>
               broker.InsertGroupAsync(group)).ThrowsAsync(failedServiceGroupException);
            //when

            ValueTask<ApplicantsGroup> addGroupTask =
                this.groupService.AddGroupAsync(group);


            var actualGroupServiceException =
                await Assert.ThrowsAnyAsync<GroupServiceException>(addGroupTask.AsTask);

            //then

            actualGroupServiceException.Should().BeEquivalentTo(expectedGroupServiceException);

            this.storageBrokerMock.Verify(broker =>
                 broker.InsertGroupAsync(group), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(expectedGroupServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
