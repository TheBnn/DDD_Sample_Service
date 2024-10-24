using AutoMapper;
using System;
using Wbx.Sample.Domain.Models;
using Wbx.Sample.Grpc.Proto.Services;

namespace Wbx.Sample.Grpc.Client.Mapping;

public class EditResultMap : Profile
{
    public EditResultMap()
    {
        CreateMap<EditResponse, EditResult<Guid>>().ForMember(d=>d.Id, s =>s.MapFrom(o=> Guid.Parse(o.Id)));
        CreateMap<EditResponse, Result>();
    }
}
