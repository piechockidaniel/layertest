using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RecipientSelections.Commands
{
    public class AddRecipientsSelections : ICommand
    {
        public string[] RecipientEmails { get; set; }
        public string[] SheetSelections { get; set; }

        public AddRecipientsSelections()
        {
            
        }
    }
}
