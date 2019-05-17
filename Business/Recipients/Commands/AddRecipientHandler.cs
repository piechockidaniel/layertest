using Domain;
using Domain.Recipients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Recipients.Commands
{
    public class AddRecipientHandler : ICommandHandler<AddRecipient>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipientFactory _recipientFactory;

        public AddRecipientHandler(IUnitOfWork unitOfWork, IRecipientFactory recipientFactory)
        {
            _unitOfWork = unitOfWork;
            _recipientFactory = recipientFactory;
            
        }

        public void Handle(AddRecipient command)
        {
            var recipient = _recipientFactory.Create();
            recipient.Email = command.Email;
            recipient.UniqueID = command.UniqueID;
            _unitOfWork.CommitChanges();
        }
    }
}
