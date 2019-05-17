using Domain.Sharings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sharings.Queries
{
    public class GetAllSharingsHandler : IQueryHandler<GetAllSharings, IList<Sharing>>
    {
        private readonly ISharingRepository _sharingRepository;

        public GetAllSharingsHandler(ISharingRepository sharingRepository)
        {
            _sharingRepository = sharingRepository;
        }

        public IList<Sharing> Handle(GetAllSharings query)
        {
            return _sharingRepository.GetAll()
                                    .Where(x => x.IsActive)
                                    .ToList();
        }
    }
}
