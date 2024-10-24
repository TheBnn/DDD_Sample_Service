using AutoMapper;
using FluentValidation;
using MediatR;

namespace Wbx.Sample.Application.Features.Sample.Queries;

using Wbx.Sample.Domain.Models;
using Wbx.Sample.Domain.Repository;

public class GetSamplesByParamsQuery : IRequest<IList<Sample>>
{
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }

    public class GetSamplesByParamsQueryValidator : AbstractValidator<GetSamplesByParamsQuery>
    {
        public GetSamplesByParamsQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }

    public class GetSamplesByParamsQueryHandler : IRequestHandler<GetSamplesByParamsQuery, IList<Sample>>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<GetSamplesByParamsQuery> _validator;
        private readonly IRepository<Sample, GetSamplesParams> _repository;

        public GetSamplesByParamsQueryHandler(IMapper mapper, IValidator<GetSamplesByParamsQuery> validator, IRepository<Sample, GetSamplesParams> repository)
        {
            _mapper = mapper;
            _validator = validator;
            _repository = repository;
        }

        public async Task<IList<Sample>> Handle(GetSamplesByParamsQuery request, CancellationToken cancellationToken)
        {
            var validateResult = _validator.Validate(request);
            if (!validateResult.IsValid)
            {
                foreach (var failure in validateResult.Errors)
                {
                }
                return null;
            }

            return await _repository.GetByParams(new GetSamplesParams { Name =new string[] { request.Name } });
        }
    }
}
