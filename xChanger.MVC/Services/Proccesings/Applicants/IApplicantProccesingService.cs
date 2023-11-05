//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Services.Proccesings.Applicants
{
    public interface IApplicantProccesingService
    {
        ValueTask<ExternalApplicantModel> InsertApplicantAsync(ExternalApplicantModel externalApplicantModel);
    }
}
