using AutoMapper;
using Castle.Windsor;
using System.Reflection;

namespace SpreadsheetAPI.Queries
{
    public class QueriesMediator : IQueriesMediator
    {
        private readonly IRuntimeMapper _mapper;
        private readonly IWindsorContainer _container;

        public QueriesMediator(IRuntimeMapper mapper, IWindsorContainer container)
        {
            _mapper = mapper;
            _container = container;
        }

        public TResult GetResultFrom<TResult, TQuery>(TQuery query)
        {
            var handler = _container.Resolve<object>(query.GetType().Name, new { });
            var handlerMethod = handler.GetType().GetMethod("Handle");
            try
            {
                var result = handlerMethod.Invoke(handler, new object[] { query });
                return (TResult)_mapper.Map(result, handlerMethod.ReturnType, typeof(TResult));
            }
            catch (TargetInvocationException exc)
            {
                throw exc.InnerException;
            }
        }
    }
}
