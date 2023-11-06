//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions
{
    public class NullSpreadSheetException : Xeption
    {
        public NullSpreadSheetException()
            : base("SpreadSheet is null")
        { }
    }
}
