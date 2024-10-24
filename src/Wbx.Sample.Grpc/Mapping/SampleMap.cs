using AutoMapper;

namespace Wbx.Sample.Grpc.Service.Mapping;

using Wbx.Sample.Application.Features.Sample.Commands;
using Wbx.Sample.Application.Features.Sample.Queries;
using Wbx.Sample.Domain.Models;
using Wbx.Sample.Grpc.Proto.Services;
using Wbx.Sample.Grpc.Service.Mappings;

public class SampleMap : Profile
{
    public SampleMap()
    {
        CreateMap<string, Guid>().ForMember(d => d, s => s.MapFrom(o => Guid.Parse(o)));

        CreateMap<GetSampleByIdRequest, GetSampleByIdQuery>();

        CreateMap<GetSamplesByParamsRequest, GetSamplesByParamsQuery>();

        CreateMap<UpdateSampleRequest, UpdateSampleCommand>();

        CreateMap<AddSampleRequest, AddSampleCommand>();

        CreateMap<DeleteSampleRequest, DeleteSampleCommand>();

        CreateMap<Sample, GetSampleByIdResponse>();

        CreateMap<List<Sample>, GetSampleByParamsResponse>().ForMember(d=>d.Result, 
            s=>s.ConvertUsing<SampleListToRepeatedSampleConverter, List<Sample>>(o => o));
      

    }
}
