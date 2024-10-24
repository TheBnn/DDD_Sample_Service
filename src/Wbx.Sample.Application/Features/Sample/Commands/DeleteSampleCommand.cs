using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Domain.Repository;
using Domain.Models;

public class DeleteSampleCommand : IRequest<EditResult<Guid>>
{
    public Guid Id { get; set; }

    public class DeleteSampleCommandValidator : AbstractValidator<DeleteSampleCommand>
    {
        public DeleteSampleCommandValidator()
        {
            RuleFor(command => command.Id).NotNull();
        }
    }

    public class DeleteSampleCommandHandler : IRequestHandler<DeleteSampleCommand, EditResult<Guid>>
    {
        private readonly IValidator<DeleteSampleCommand> _validator;
        private readonly IRepository<Sample, GetSamplesParams> _repository;

        public DeleteSampleCommandHandler(IValidator<DeleteSampleCommand> validator, IRepository<Sample, GetSamplesParams> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<EditResult<Guid>> Handle(DeleteSampleCommand command, CancellationToken cancellationToken)
        {
            var validateResult = _validator.Validate(command);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return new EditResult<Guid>();
            }

           var sample = _repository.Delete(command.Id);

            return new EditResult<Guid> { IsSuccess = true };
        }
    }
}
