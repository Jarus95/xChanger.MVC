//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using xChanger.MVC.Models.Foundations.SpreadSheets.Exceptions;

namespace xChanger.MVC.Services.Foundations.SpreadSheet;

public partial class SpreadsheetService
{
    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidSpreadSheetException = new InvalidSpreadSheetException();

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
            {
                invalidSpreadSheetException.UpsertDataList(
                    key: parameter,
                    value: rule.Message);
            }
        }

        invalidSpreadSheetException.ThrowIfContainsErrors();
    }
}
