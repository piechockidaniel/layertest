using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RecipientSelections.Exceptions
{
    public class SheetNameNotAllowedException : System.Exception, IBusinessException
    {
        public string Code => "SheetNameNotAllowed";
    }
}
