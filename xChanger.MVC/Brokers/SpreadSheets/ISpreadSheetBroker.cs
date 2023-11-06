using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers
{
    public interface ISpreadSheetBroker
    {
        List<ExternalApplicantModel> ReadExternalApplicants(MemoryStream stream);
    }
}
