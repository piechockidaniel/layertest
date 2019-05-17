using Domain;
using Domain.Sharings;
using Domain.Recipients;
using Domain.Selections;

namespace Business.Sharings.Commands
{
    public class AddSharingHandler : ICommandHandler<AddSharing>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISharingFactory _sharingFactory;
        private readonly ISelectionRepository _selectionRepository;
        private readonly IRecipientRepository _recipientRepository;

        public AddSharingHandler(IUnitOfWork unitOfWork, ISharingFactory sharingFactory, ISelectionRepository selectionRepository, IRecipientRepository recipientRepository)
        {
            _unitOfWork = unitOfWork;
            _sharingFactory = sharingFactory;
            _selectionRepository = selectionRepository;
            _recipientRepository = recipientRepository;
        }

        public void Handle(AddSharing command)
        {
            var sharing = _sharingFactory.Create();
            sharing.Recipient = _recipientRepository.Get(command.RecipientID);
            sharing.Selection = _selectionRepository.Get(command.SelectionID);
            sharing.UniqueID = command.UniqueID;
            _unitOfWork.CommitChanges();
        }
    }
}
