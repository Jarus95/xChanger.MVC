using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace Tarteeb.XChanger.Brokers
{
    public interface ISpreadSheetBroker
    {
        List<ExternalApplicantModel> ReadExternalApplicants(MemoryStream stream);
    }
}
