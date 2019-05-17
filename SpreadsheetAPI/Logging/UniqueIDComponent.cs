using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SpreadsheetAPI.Logging
{
    public class UniqueIDComponent : OwinMiddleware
    {
        public UniqueIDComponent(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            string[] guid = new[] { Guid.NewGuid().ToString() };
            context.Request.Headers.Add("UNIQUE_ID", guid);
            context.Response.Headers.Add("UNIQUE_ID", guid);
            await Next.Invoke(context);
        }
    }
}