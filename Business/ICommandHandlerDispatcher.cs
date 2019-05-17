using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICommandHandlerDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
