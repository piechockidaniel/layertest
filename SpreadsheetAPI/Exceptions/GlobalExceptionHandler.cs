using Business;
using SpreadsheetAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SpreadsheetAPI.Exceptions
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        

        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = GetErrorMessage(context.Exception, context.Request);
        }

        public class ErrorMessageResult : IHttpActionResult
        {
            private readonly HttpRequestMessage _request;
            private readonly HttpResponseMessage _httpResponseMessage;

            public ErrorMessageResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }

        public IHttpActionResult GetErrorMessage(System.Exception exc, HttpRequestMessage request)
        {
            List<ErrorModel> model = new List<ErrorModel>();

            if (exc is AggregateException aggregateException)
            {
                foreach (var inner in aggregateException.InnerExceptions)
                {
                    ReadException(inner, model);
                }
            }
            else
            {
                ReadException(exc, model);
            }
            var response = CreateResponseMessage(request, HttpStatusCode.BadRequest, model);
            return new ErrorMessageResult(request, response);
        }

        protected HttpResponseMessage CreateResponseMessage(HttpRequestMessage request, HttpStatusCode code, IEnumerable<ErrorModel> result)
        {
            return request.CreateResponse(code, result);
        }

        private void ReadException(Exception exc, IList<ErrorModel> errorModels)
        {
            Exception exception = exc;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                if (exception is IBusinessException)
                {
                    break;
                }
            }
            string code;
            if (exception is IBusinessException business)
            {
                code = business.Code;
            }
            else
            {
                code = exception.GetType().Name;
            }
            errorModels.Add(new ErrorModel { Code = code, Message = exception.Message });
        }
    }
}