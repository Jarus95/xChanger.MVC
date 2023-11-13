//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using Xunit;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;

namespace xChanger.MVC.Tests.Services.Foundations.Groups
{

    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            ApplicantsGroup nullGroup = null;
            var nullGroupEexception = new NullGroupEexception();
            var ExpectedgroupValidationException = new GroupValidationException(nullGroupEexception);
            //when
            ValueTask<ApplicantsGroup> AddGroupTask = this.groupService.AddGroupAsync(nullGroup);

            GroupValidationException inputGroupValidationException =
                await Assert.ThrowsAsync<GroupValidationException>(AddGroupTask.AsTask);
            //then
            inputGroupValidationException.Should().BeEquivalentTo(ExpectedgroupValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAss(ExpectedgroupValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGroupAsync(It.IsAny<ApplicantsGroup>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfApplicantIsInvalidLogItAsync(string invalidText)
        {
            //given
            ApplicantsGroup group = new ApplicantsGroup
            {
                GroupName = invalidText,
                Id = default
            };

            var invalidGroupException = new InvalidGroupException();

            invalidGroupException.AddData(
                key: nameof(ApplicantsGroup.Id),
                values: "Id is required");

            invalidGroupException.AddData(
                key: nameof(ApplicantsGroup.GroupName),
                values: "Text is required");

            var expectedGroupValidationException = 
                new GroupValidationException(invalidGroupException);

            //when
            ValueTask<ApplicantsGroup> addGroupTask =
                   this.groupService.AddGroupAsync(group);

            GroupValidationException actualGroupValidationException =
               await Assert.ThrowsAsync<GroupValidationException>(addGroupTask.AsTask);

            //then
            actualGroupValidationException.Should().BeEquivalentTo(expectedGroupValidationException);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAss(
                actualGroupValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGroupAsync(It.IsAny<ApplicantsGroup>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
