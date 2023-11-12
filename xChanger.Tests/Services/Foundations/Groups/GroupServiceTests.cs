//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq.Expressions;
using Moq;
using xChanger.MVC.Brokers.DateTimes;
using xChanger.MVC.Brokers.Loggings;
using xChanger.MVC.Brokers.Storages;
using xChanger.MVC.Models.Foundations.Groups.Exceptions.Categories;
using xChanger.MVC.Services.Foundations.Group;
using Tynamix.ObjectFiller;
using Xeptions;
using ApplicantGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Tests.Services.Foundations.Groups
{
    public partial class GroupServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;


        private readonly GroupService groupService;

        public GroupServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            groupService = new GroupService(
                this.storageBrokerMock.Object,
                this.dateTimeBrokerMock.Object, 
                this.loggingBrokerMock.Object);
        }

        private ApplicantGroup CreateRandomGroup() =>
            CreateGroupFiller().Create();

        private Filler<ApplicantGroup> CreateGroupFiller()
        {
            var filler = new Filler<ApplicantGroup>();
            return filler;
        }


        private Expression<Func<Xeption, bool>> SameExceptionAss(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private string GetRandomString() =>
              new MnemonicString().GetValue();
    }
}
