using Business.RecipientSelections.Commands;
using Business.RecipientSelections.Exceptions;
using Domain.Selections;
using System;
using System.Text.RegularExpressions;

namespace Business.RecipientSelections.Validators
{
    public class SheetNameRule : IValidationRule<AddRecipientsSelections>
    {

        public SheetNameRule()
        {
            
        }

        public void Validate(AddRecipientsSelections command)
        {
            Regex regex = new Regex(@"^('[\w\s]+'|[\w\s]+)(![A-Z]+[0-9]+)?(:[A-Z]+[0-9]+)?", RegexOptions.Compiled);
            foreach (var selection in command.SheetSelections)
            {
                if (!regex.IsMatch(selection))
                {
                    throw new SelectionWrongFormatException();
                }
            }
        }
    }
}
