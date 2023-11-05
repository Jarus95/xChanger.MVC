//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using ApplicantsGroup = Tarteeb.XChanger.Models.Foundations.Groups.Group;
namespace Tarteeb.XChanger.Services.Proccesings.Group
{
    public interface IGroupProccesingService
    {
        ValueTask<ApplicantsGroup> EnsureGroupExistsByName(string name);
        ApplicantsGroup RetrieveGroupByName(string name);
    }
}
