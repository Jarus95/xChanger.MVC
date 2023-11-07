using System.Collections.Generic;
using System.IO;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Brokers
{
    public interface ISpreadSheetBroker
    {
        List<ExternalApplicantModel> ReadExternalApplicants(MemoryStream stream);
    }
}
