using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class BusinessExceptions : Exception
    {
        private readonly IEnumerable<BusinessException> _exceptionPositions;

        public BusinessExceptions(IEnumerable<IBusinessException> exceptions, Exception innerException) : base("Business exceptions", innerException)
        {
            _exceptionPositions = exceptions.Select(s => new BusinessException(s.Code, (Exception)s)).ToList();
        }

        public IEnumerable<BusinessException> Exceptions => _exceptionPositions;

        public class BusinessException
        {
            public string Code { get; }
            public string Message => Exception.Message;

            public Exception Exception { get; }

            public BusinessException(string code, Exception exception)
            {
                Code = code;
                Exception = exception;
            }
        }
    }
}
