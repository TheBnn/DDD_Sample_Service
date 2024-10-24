using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Wbx.Sample.Domain.Repository;
using Domain.Models;

public class ProcessTaskItemCommand : IRequest<Result>
{
    public ProcessTaskItemParams ProcessItemParams { get; set; }

    public class ProcessTaskItemCommandValidator : AbstractValidator<ProcessTaskItemCommand>
    {
        public ProcessTaskItemCommandValidator()
        {
            RuleFor(command => command.ProcessItemParams).NotNull().WithMessage("Нет параметров ручного запуска итерации");
        }
    }

    public class ProcessTaskItemCommandHandler : IRequestHandler<ProcessTaskItemCommand, Result>
    {
        private readonly IValidator<ProcessTaskItemCommand> _validator;

        public ProcessTaskItemCommandHandler(IValidator<ProcessTaskItemCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Result> Handle(ProcessTaskItemCommand command, CancellationToken cancellationToken )
        {
            var validateResult = _validator.Validate(command);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return new Result();
            }

            //запускаем процесс периодического выполнения

            return new Result { IsSuccess = true};
        }
    }
}
