using Domain.Recipients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Recipients.Queries
{
    public class GetRecipientByEmailHandler : IQueryHandler<GetRecipientByEmail, Recipient>
    {
        private readonly IRecipientRepository _recipientRepository;

        public GetRecipientByEmailHandler(IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;
        }

        public Recipient Handle(GetRecipientByEmail query)
        {
            return _recipientRepository.GetAll()
                                    .Where(x => x.Email == query.Email)
                                    .FirstOrDefault();
        }
    }
}
