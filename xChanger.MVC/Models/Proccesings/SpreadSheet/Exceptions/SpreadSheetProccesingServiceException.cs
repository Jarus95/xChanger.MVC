//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions
{
    public class SpreadSheetProccesingServiceException : Xeption
    {
        public SpreadSheetProccesingServiceException(Xeption innerException)
            : base("Spread sheet service error occured, contact support", innerException)
        { }
    }
}
