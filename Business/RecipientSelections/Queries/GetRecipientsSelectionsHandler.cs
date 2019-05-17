using Domain.Sharings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RecipientSelections.Queries
{
    public class GetRecipientsSelectionsHandler : IQueryHandler<GetRecipientsSelections, IList<Sharing>>
    {
        private readonly ISharingRepository _sharingRepository;

        public GetRecipientsSelectionsHandler(ISharingRepository sharingRepository)
        {
            _sharingRepository = sharingRepository;
        }

        public IList<Sharing> Handle(GetRecipientsSelections query)
        {
            return _sharingRepository.GetAll()
                                    .Where(x => x.IsActive && 
                                                query.RecipientID.Contains(x.Recipient.ID))
                                    .ToList();
        }
    }
}
