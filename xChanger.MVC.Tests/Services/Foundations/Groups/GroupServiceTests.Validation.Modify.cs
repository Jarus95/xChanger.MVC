using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using xChanger.MVC.Models.Foundations.Groups;
using xChanger.MVC.Models.Foundations.Groups.Exceptions;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;

namespace xChanger.MVC.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionIfInputsNullAndLogItAsync()
        {
            //given
            Group group = null;
            var nullGroupEexception = new NullGroupEexception();
            var expectedGroupValidationException = new GroupValidationException(nullGroupEexception);
            //when
            ValueTask<Group> AddGroupTask = this.groupService.UpdateGroupAsync(group);
            GroupValidationException inputGroupValidationException = 
                await Assert.ThrowsAsync<GroupValidationException>(AddGroupTask.AsTask);
            //then
            inputGroupValidationException.Should().BeEquivalentTo(expectedGroupValidationException);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAss(expectedGroupValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateGroupAsync(group), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
