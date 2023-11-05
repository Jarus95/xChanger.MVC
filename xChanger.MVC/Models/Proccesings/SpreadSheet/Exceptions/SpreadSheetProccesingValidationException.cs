//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Xeptions;

namespace Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions
{
    public class SpreadSheetProccesingValidationException : Xeption
    {
        public SpreadSheetProccesingValidationException(Xeption innerException)
           : base("Spreadsheet validation error occured. Fix the errors and try again", innerException)
        {}
    }
}
