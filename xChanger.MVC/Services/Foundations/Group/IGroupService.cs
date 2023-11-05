//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using System.Threading.Tasks;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Services.Foundations.Group
{
    public interface IGroupService
    {
        ValueTask<ApplicantsGroup> AddGroupAsyc(ApplicantsGroup group);
        IQueryable<ApplicantsGroup> RetrieveAllGroups();
    }
}
