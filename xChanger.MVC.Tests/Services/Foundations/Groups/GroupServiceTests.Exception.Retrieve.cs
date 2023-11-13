//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using FluentAssertions;
using Moq;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;

namespace xChanger.MVC.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        private async Task ShouldThrowGroupServiceExceptionOnRetrieveAllServiceErrorOccursAndLogIt()
        {
            //given
            string randomMessage = GetRandomString();

            Exception exception = new Exception(randomMessage);

            var failedServiceGroupException =
                new FailedServiceGroupException(exception);

            var expectedGroupServiceException =
                new GroupServiceException(failedServiceGroupException);

            this.storageBrokerMock.Setup(broker =>
            broker.RetrieveAllGroups()).Throws(failedServiceGroupException);
            //when
            Action retrieveAllStudentAction = () =>
                this.groupService.RetrieveAllGroups();

            GroupServiceException actualGroupServiceException =
                Assert.Throws<GroupServiceException>(retrieveAllStudentAction);
            //then

            actualGroupServiceException.Should().BeEquivalentTo(expectedGroupServiceException);

            this.storageBrokerMock.Verify(broker =>
            broker.RetrieveAllGroups(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(
                    expectedGroupServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
