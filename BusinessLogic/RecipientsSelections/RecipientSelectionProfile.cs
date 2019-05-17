using AutoMapper;
using Business.RecipientSelections.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RecipientsSelections
{
    public class RecipientSelectionProfile : Profile
    {
        public RecipientSelectionProfile()
        {
            CreateMap<RecipientsSelectionsDTO, AddRecipientsSelections>();
        }
    }
}
