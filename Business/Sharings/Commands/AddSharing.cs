using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sharings.Commands
{
    public class AddSharing : ICommand
    {
        private Guid _uniqueID;
        public Guid UniqueID => _uniqueID;

        public int SelectionID { get; }
        public int RecipientID { get; }

        public AddSharing(int recipientID, int selectionID)
        {
            RecipientID = recipientID;
            SelectionID = selectionID;
            _uniqueID = Guid.NewGuid();
        }
    }
}
