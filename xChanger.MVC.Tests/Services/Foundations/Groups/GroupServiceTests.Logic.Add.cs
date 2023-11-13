//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using ApplicantGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldAddGroupAsync()
        {
            //given
            ApplicantGroup randomGroup = CreateRandomGroup();
            ApplicantGroup inputGroup = randomGroup;
            ApplicantGroup persistedGroup = inputGroup;
            ApplicantGroup expectedGroup = inputGroup.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGroupAsync(inputGroup)).
                ReturnsAsync(persistedGroup);
            //when

            ApplicantGroup actualGroup = await this.groupService.AddGroupAsync(inputGroup);

            //then

            actualGroup.Should().BeEquivalentTo(expectedGroup);

            this.storageBrokerMock.Verify(broker =>
                 broker.InsertGroupAsync(inputGroup), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
