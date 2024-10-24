using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Wbx.Sample.Domain.Repository;
using Domain.Models;

public class StopProcessTaskCommand : IRequest<Result>
{
    public StopProcessParams StopProcessParams { get; set; }

    public class StopProcessTaskCommandValidator : AbstractValidator<StopProcessTaskCommand>
    {
        public StopProcessTaskCommandValidator()
        {
            RuleFor(command => command.StopProcessParams).NotNull().WithMessage("Нет параметров остановки");
        }
    }

    public class StopProcessTaskCommandHandler : IRequestHandler<StopProcessTaskCommand, Result>
    {
        private readonly IValidator<StopProcessTaskCommand> _validator;

        public StopProcessTaskCommandHandler(IValidator<StopProcessTaskCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Result> Handle(StopProcessTaskCommand command, CancellationToken cancellationToken )
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
