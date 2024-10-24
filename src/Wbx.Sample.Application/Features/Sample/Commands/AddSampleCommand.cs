using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Wbx.Sample.Domain.Repository;
using Domain.Models;

public class AddSampleCommand : IRequest<EditResult<Guid>>
{
    public string Name { get; set; }

    public class AddSampleCommandValidator : AbstractValidator<AddSampleCommand>
    {
        public AddSampleCommandValidator()
        {
            RuleFor(command => command.Name).NotNull();
        }
    }

    public class AddSampleCommandHandler : IRequestHandler<AddSampleCommand, EditResult<Guid>>
    {
        private readonly IValidator<AddSampleCommand> _validator;
        private readonly IRepository<Sample, GetSamplesParams> _repository;

        public AddSampleCommandHandler(IValidator<AddSampleCommand> validator, IRepository<Sample, GetSamplesParams> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<EditResult<Guid>> Handle(AddSampleCommand command, CancellationToken cancellationToken )
        {
            var validateResult = _validator.Validate(command);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return new EditResult<Guid>();
            }

            var id = await _repository.Add(new Sample { Name = command.Name });

            return new EditResult<Guid> { IsSuccess = true, Id = id };
        }
    }
}
