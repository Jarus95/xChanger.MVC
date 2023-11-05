//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Proccesings.SpreadSheet.Exceptions
{
    public class EmptyExternalApplicantException : Xeption
    {
        public EmptyExternalApplicantException()
            : base("Spreadsheet is empty")
        { }
    }
}
