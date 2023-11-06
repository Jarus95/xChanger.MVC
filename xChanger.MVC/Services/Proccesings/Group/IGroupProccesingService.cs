//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using ApplicantsGroup = xChanger.MVC.Models.Foundations.Groups.Group;
namespace xChanger.MVC.Services.Proccesings.Group
{
    public interface IGroupProccesingService
    {
        ValueTask<ApplicantsGroup> EnsureGroupExistsByName(string name);
        ApplicantsGroup RetrieveGroupByName(string name);
    }
}
