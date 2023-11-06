//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Services.Proccesings.Applicants
{
    public interface IApplicantProccesingService
    {
        ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel);
    }
}
