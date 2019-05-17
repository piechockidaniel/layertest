using AutoMapper;
using Business;
using Business.RecipientSelections.Commands;
using Business.Sharings.Queries;
using BusinessLogic.RecipientsSelections;
using BusinessLogic.Sharings;
using SpreadsheetAPI.Queries;
using System.Collections.Generic;
using System.Web.Http;

namespace SpreadsheetAPI.Controllers
{
    [RoutePrefix("api/sharings")]
    public class SharingsController : ApiController
    {

        private readonly IQueriesMediator _queriesMediator;
        private readonly IRuntimeMapper _mapper;
        private readonly ICommandHandlerDispatcher _commandHandlerDispatcher;

        public SharingsController(IQueriesMediator queriesMediator, IRuntimeMapper mapper, ICommandHandlerDispatcher commandHandlerDispatcher)
        {
            _queriesMediator = queriesMediator;
            _mapper = mapper;
            _commandHandlerDispatcher = commandHandlerDispatcher;
        }

        [HttpGet()]
        [Route("list/all")]
        public IEnumerable<SharingDTO> GetAll()
        {
            return _queriesMediator.GetResultFrom<IEnumerable<SharingDTO>, GetAllSharings>(new GetAllSharings());
        }

        [HttpPost()]
        [Route("add")]
        public string AddSharing(RecipientsSelectionsDTO recipientsSelectionsDTO)
        {
            var command = _mapper.Map<AddRecipientsSelections>(recipientsSelectionsDTO);
            _commandHandlerDispatcher.Execute(command);
            var result = "Operation successful";
            return result;
        }
    }
}