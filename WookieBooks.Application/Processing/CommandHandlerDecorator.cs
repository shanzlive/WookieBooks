using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WookieBooks.Application.Processing
{
  /*  public class CommandHandlerDecorator<T> : IRequestHandler<T, Unit>
        where T : IRequest
    {
        private readonly IRequestHandler<T, Unit> _decorated;
        private readonly IEnumerable<IValidator<T>> _validators;

        public CommandHandlerDecorator(IRequestHandler<T, Unit> decorated, IEnumerable<IValidator<T>> validators)
        {
            _decorated = decorated;
            _validators = validators;
        }

        public Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
            var validationFailures = _validators
                .Select(validator = > ValidatorConfiguration.Validate)
        }
    }
  */
}
