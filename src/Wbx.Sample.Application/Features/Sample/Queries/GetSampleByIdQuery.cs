using AutoMapper;
using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Queries;

using Wbx.Sample.Domain.Models;
using Wbx.Sample.Domain.Repository;

public class GetSampleByIdQuery: IRequest<Sample>
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    public class GetSampleByIdQueryValidator : AbstractValidator<GetSampleByIdQuery>
    {
        public GetSampleByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }

    public class GetSampleByIdQueryHandler : IRequestHandler<GetSampleByIdQuery, Sample>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<GetSampleByIdQuery> _validator;
        private readonly IRepository<Sample, GetSamplesParams> _repository;

        public GetSampleByIdQueryHandler(IMapper mapper, IValidator<GetSampleByIdQuery> validator, IRepository<Sample, GetSamplesParams> repository)
        {
            _mapper = mapper;
            _validator = validator;
            _repository = repository;
        }

        public async Task<Sample> Handle(GetSampleByIdQuery request, CancellationToken cancellationToken)
        {
            var validateResult = _validator.Validate(request);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return null;
            }

            return await _repository.GetById(request.Id);
        }
    }
}
