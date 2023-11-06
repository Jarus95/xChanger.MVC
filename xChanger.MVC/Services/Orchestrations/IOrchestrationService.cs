//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace xChanger.MVC.Services.Orchestrations;

public interface IOrchestrationService
{
    Task ProccesingImportRequest(IFormFile file);
}
