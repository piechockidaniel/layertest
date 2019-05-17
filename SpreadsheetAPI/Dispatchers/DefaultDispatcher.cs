using Business;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpreadsheetAPI.Dispatchers
{
    public class DefaultDispatcher : ICommandHandlerDispatcher
    {
        private readonly IWindsorContainer _windsorContainer;

        public DefaultDispatcher(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (typeof(TCommand) == typeof(ICommand))
            {
                var handler = _windsorContainer.Resolve(typeof(ICommandHandler<>).MakeGenericType(command.GetType()));
                handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });
            }
            else
            {
                var handler = _windsorContainer.Resolve<ICommandHandler<TCommand>>();
                handler.Handle(command);
            }
        }
    }
}