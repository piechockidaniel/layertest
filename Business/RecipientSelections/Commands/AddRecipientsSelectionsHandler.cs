using Business.Recipients.Commands;
using Business.Selections.Commands;
using Business.Sharings.Commands;
using Business.Utils;
using Domain;
using Domain.Recipients;
using Domain.Selections;
using Domain.Sharings;
using System.Linq;
using System.Collections.Generic;

namespace Business.RecipientSelections.Commands
{
    public class AddRecipientsSelectionsHandler : ICommandHandler<AddRecipientsSelections>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISelectionFactory _selectionFactory;
        private readonly IRecipientFactory _recipientFactory;
        private readonly IRecipientRepository _recipientRepository;
        private readonly ISelectionRepository _selectionRepository;
        private readonly ISharingRepository _sharingRepository;
        private readonly ISharingFactory _sharingFactory;
        private readonly IValidator[] _validator;
        private readonly ICommandHandlerDispatcher _commandHandlerDispatcher;

        public AddRecipientsSelectionsHandler(IUnitOfWork unitOfWork, ISelectionFactory selectionFactory, IRecipientFactory recipientFactory, IRecipientRepository recipientRepository, ISelectionRepository selectionRepository, ISharingRepository sharingRepository, ISharingFactory sharingFactory, IValidator[] validator, ICommandHandlerDispatcher commandHandlerDispatcher)
        {
            _unitOfWork = unitOfWork;
            _selectionFactory = selectionFactory;
            _recipientFactory = recipientFactory;
            _recipientRepository = recipientRepository;
            _selectionRepository = selectionRepository;
            _sharingFactory = sharingFactory;
            _sharingRepository = sharingRepository;
            _validator = validator;
            _commandHandlerDispatcher = commandHandlerDispatcher;
        }

        public void Handle(AddRecipientsSelections command)
        {
            List<Recipient> recipients = new List<Recipient>();
            List<Selection> selections = new List<Selection>();
            _validator.ToList().ForEach(x=>x.Validate(command));
            foreach (var recipient in command.RecipientEmails)
            {
                if (!_recipientRepository.Exists(recipient))
                {                
                    var newRecipient = new AddRecipient(recipient);
                    _commandHandlerDispatcher.Execute(newRecipient);
                    _unitOfWork.CommitChanges();
                }
                recipients.Add(_recipientRepository.Get(recipient));
            }

            foreach (var selection in command.SheetSelections)
            {
                var sheetName = RegexUtils.GetSheetNameFromSelectionString(selection);
                var selectionName = RegexUtils.GetSelectionNameFromSelectionString(selection);
                if (!_selectionRepository.Exists(sheetName, selectionName))
                {
                    var newSelection = new AddSelection(sheetName, selectionName);
                    _commandHandlerDispatcher.Execute(newSelection);
                    _unitOfWork.CommitChanges();
                }
                selections.Add(_selectionRepository.Get(sheetName, selectionName));
            }

            foreach (var recipientEntity in recipients)
            {
                foreach (var selectionEntity in selections)
                {
                    if (!_sharingRepository.Exists(recipientEntity.ID, selectionEntity.ID))
                    {
                        var newSharing = new AddSharing(recipientEntity.ID, selectionEntity.ID);
                        _commandHandlerDispatcher.Execute(newSharing);
                        _unitOfWork.CommitChanges();
                    }
                }
            }
        }
    }
}
