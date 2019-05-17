using Business.RecipientSelections.Commands;
using Business.RecipientSelections.Exceptions;
using Domain.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.RecipientSelections.Validators
{
    public class SheetTypeRule : IValidationRule<AddRecipientsSelections>
    {

        public SheetTypeRule()
        {

        }

        public void Validate(AddRecipientsSelections command)
        {

            Regex regex = new Regex(@"^('[\w\s]+'|[\w\s]+)(![A-Z]+[0-9]+)?(:[A-Z]+[0-9]+)?", RegexOptions.Compiled);
            foreach (var selection in command.SheetSelections)
            {

                var matches = regex.Matches(selection);
                var sheetName = matches[0].Groups[1].Value;
                sheetName = sheetName.Replace("'", "");

                SheetNameEnum sheetNameEnum;
                if (!Enum.TryParse<SheetNameEnum>(sheetName, out sheetNameEnum))
                {
                    throw new SheetNameNotAllowedException();
                }
            }
        }
    }
}
