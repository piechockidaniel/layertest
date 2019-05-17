using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Selections.Commands
{
    public class AddSelection : ICommand
    {
        private Guid _uniqueID;
        public Guid UniqueID => _uniqueID;
        public string SheetName { get; }
        public string RangeName { get; }

        public AddSelection(string sheetName, string rangeName)
        {
            _uniqueID = Guid.NewGuid();
            SheetName = sheetName;
            RangeName = rangeName;
        }
    }
}
