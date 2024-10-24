using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Commands;

using Domain.Repository;
using Domain.Models;

public class UpdateSampleCommand : IRequest<EditResult<Guid>>
{
    public Guid Id { get; set; }
    /// <summary>
    /// Нимсенование
    /// </summary>
    public string Name { get; set; }

    public class UpdateSampleCommandValidator : AbstractValidator<UpdateSampleCommand>
    {
        public UpdateSampleCommandValidator()
        {
            RuleFor(command => command.Id).NotNull();
            RuleFor(command => command.Name).NotNull();
        }
    }

    public class UpdateSampleCommandHandler : IRequestHandler<UpdateSampleCommand, EditResult<Guid>>
    {
        private readonly IValidator<UpdateSampleCommand> _validator;
        private readonly IRepository<Sample, GetSamplesParams> _repository;


        public UpdateSampleCommandHandler(IValidator<UpdateSampleCommand> validator, IRepository<Sample, GetSamplesParams> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<EditResult<Guid>> Handle(UpdateSampleCommand command, CancellationToken cancellationToken)
        {
            var validateResult = _validator.Validate(command);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return new EditResult<Guid>();
            }

            await _repository.Update(new Sample { Name = command.Name });

            return new EditResult<Guid> { IsSuccess = true };
        }
    }
}
