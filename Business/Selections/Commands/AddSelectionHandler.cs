using Domain;
using Domain.Selections;
using System;

namespace Business.Selections.Commands
{
    public class AddSelectionHandler : ICommandHandler<AddSelection>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISelectionFactory _selectionFactory;
        private readonly IValidator _validator;

        public AddSelectionHandler(IUnitOfWork unitOfWork, ISelectionFactory selectionFactory, IValidator validator)
        {
            _unitOfWork = unitOfWork;
            _selectionFactory = selectionFactory;
            _validator = validator;
        }

        public void Handle(AddSelection command)
        {
            _validator.Validate(command);
            var selection = _selectionFactory.Create();
            selection.UniqueID = command.UniqueID;
            selection.RangeName = command.RangeName;
            selection.SheetName = (Enum.Parse(typeof(SheetNameEnum), command.SheetName) as SheetNameEnum?).Value;
            _unitOfWork.CommitChanges();
        }
    }
}
