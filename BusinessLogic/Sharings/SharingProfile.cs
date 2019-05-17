using AutoMapper;
using Domain.Sharings;
using System.Linq;

namespace BusinessLogic.Sharings
{
    public class SharingProfile : Profile
    {
        public SharingProfile()
        {
            CreateMap<Sharing, SharingDTO>()
                .ForMember(memb => memb.Recipient, act => act.MapFrom(mf => mf.Recipient.Email))
                .ForMember(memb => memb.Selection, act => act.MapFrom(mf => string.Format("{0}{1}", mf.Selection.SheetName.ToString().Contains(" ") ? string.Format("'{0}'", mf.Selection.SheetName) : mf.Selection.SheetName.ToString(), !string.IsNullOrEmpty(mf.Selection.RangeName) ? string.Format("{0}", mf.Selection.RangeName) : string.Empty)));
        }
    }
}
