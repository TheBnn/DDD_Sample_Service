using AutoMapper;

namespace Wbx.Sample.Grpc.Service.Mapping;

using Domain.Models;
using Grpc.Proto.Services;

public class ResponseMap : Profile
{
    public ResponseMap()
    {
        CreateMap<EditResponse, EditResult<Guid>>().ForMember(d => d.Id, s => s.MapFrom(o => Guid.Parse(o.Id)));
        CreateMap<EditResponse, Result>();
    }
}
