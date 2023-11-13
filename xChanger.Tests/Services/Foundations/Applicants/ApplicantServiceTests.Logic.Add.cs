//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldAddApplicantAsync()
        {
            //given
            ExternalApplicantModel randomApplicant = CreateRandomApplicant();
            ExternalApplicantModel incomingExternalApplicantModel = randomApplicant;
            ExternalApplicantModel persistedApplicant = incomingExternalApplicantModel;
            ExternalApplicantModel expectedApplicant = incomingExternalApplicantModel.DeepClone();
            this.storageBrokerMock.Setup(broker => broker.InsertExternalApplicantModelAsync(incomingExternalApplicantModel))
                .ReturnsAsync(persistedApplicant);

            //when
            ExternalApplicantModel actualApplicant = await this.applicantService
                .AddApplicantAsync(incomingExternalApplicantModel);

            //then
            actualApplicant.Should().BeEquivalentTo(expectedApplicant);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertExternalApplicantModelAsync(incomingExternalApplicantModel), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
