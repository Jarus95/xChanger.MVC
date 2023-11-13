//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.Data.SqlClient;
using Moq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using xChanger.MVC.Brokers.DateTimes;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Brokers.Storages;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Foundations.Applicants;
using Tynamix.ObjectFiller;
using Xeptions;

namespace xChanger.MVC.Tests.Services.Foundations.Applicants
{
    public partial class ApplicantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IApplicantService applicantService;

        public ApplicantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.applicantService = new ApplicantService(
               storageBroker: this.storageBrokerMock.Object,
               dateTimeBroker: this.dateTimeBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object);
        }

        private string GetRandomString() =>
           new MnemonicString().GetValue();
        private ExternalApplicantModel CreateRandomApplicant() =>
            CreateApplicantFiller().Create();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private Filler<ExternalApplicantModel> CreateApplicantFiller()
        {
            var filler = new Filler<ExternalApplicantModel>();
            return filler;
        }

        private Expression<Func<Xeption, bool>> SameExceptionAss(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);
        private static SqlException GetSqlError() =>
        (SqlException)FormatterServices.GetSafeUninitializedObject(typeof(SqlException));
    }
}
