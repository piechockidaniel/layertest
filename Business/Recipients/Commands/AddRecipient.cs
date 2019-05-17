using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Recipients.Commands
{
    public class AddRecipient : ICommand
    {
        private Guid _uniqueID;
        public Guid UniqueID => _uniqueID;
        public string Email { get; }
        public AddRecipient(string email)
        {
            _uniqueID = Guid.NewGuid();
            Email = email;
        }
    }
}
