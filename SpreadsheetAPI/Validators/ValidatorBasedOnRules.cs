using Business;
using BusinessLogic.Exceptions;
using Castle.Windsor;
using System;
using System.Linq;

namespace SpreadsheetAPI.Validators
{
    public class ValidatorBasedOnRules : IValidator
    {
        private readonly IWindsorContainer _windsorContainer;

        public ValidatorBasedOnRules(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        public void Validate<TCommand>(TCommand command)
        {
            var rules = _windsorContainer.ResolveAll<IValidationRule<TCommand>>();
            try
            {
                Array.ForEach(rules, rule => rule.Validate(command));
            }
            catch (AggregateException aggrExc)
            {
                aggrExc.Handle(ex => ex is IBusinessException);
                throw new BusinessExceptions(aggrExc.InnerExceptions.OfType<IBusinessException>(), aggrExc);
            }
        }
    }
}
