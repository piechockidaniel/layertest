using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Recipients.Queries
{
    public class GetRecipientByEmail
    {
        public string Email { get; }
        public GetRecipientByEmail(string email)
        {
            Email = email;
        }
    }
}
