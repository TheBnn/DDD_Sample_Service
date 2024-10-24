using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Wbx.Sample.Domain.Repository;
using Domain.Models;

public class StartProcessTaskCommand : IRequest<Result>
{
    public StartProcessParams StartProcessParams { get; set; }

    public class StartProcessTaskCommandValidator : AbstractValidator<StartProcessTaskCommand>
    {
        public StartProcessTaskCommandValidator()
        {
            RuleFor(command => command.StartProcessParams).NotNull().WithMessage("Нет параметров запуска");
        }
    }

    public class StartProcessTaskCommandHandler : IRequestHandler<StartProcessTaskCommand, Result>
    {
        private readonly IValidator<StartProcessTaskCommand> _validator;

        public StartProcessTaskCommandHandler(IValidator<StartProcessTaskCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Result> Handle(StartProcessTaskCommand command, CancellationToken cancellationToken )
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
