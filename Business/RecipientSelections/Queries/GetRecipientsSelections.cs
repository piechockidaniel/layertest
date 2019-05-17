using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RecipientSelections.Queries
{
    public class GetRecipientsSelections : IQuery
    {
        public int[] RecipientID { get; }
        public GetRecipientsSelections(int[] recipientID)
        {
            RecipientID = recipientID;
        }
    }
}
