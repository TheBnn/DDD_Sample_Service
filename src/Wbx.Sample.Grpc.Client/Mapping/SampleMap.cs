using AutoMapper;
using System;
using System.Collections.Generic;
using Wbx.Sample.Domain.Models;
using Wbx.Sample.Grpc.Proto.Services;
using System.Linq;
using Wbx.Sample.Grpc.Client.Mapping.Converters;

namespace Wbx.Sample.Grpc.Client.Mapping;

public class SampleMap : Profile
{
    public SampleMap()
    {
        CreateMap<Guid, string>().ForMember(d => d, s => s.MapFrom(o => o.ToString()));

        CreateMap<AddSampleParams, AddSampleRequest>();

        CreateMap<Guid, DeleteSampleRequest>();

        CreateMap<Guid, GetSampleByIdRequest>();

        CreateMap<GetSamplesParams, GetSamplesByParamsRequest>();

        CreateMap<UpdateSampleParams, UpdateSampleRequest>();

        CreateMap<GetSampleByIdResponse, Domain.Models.Sample>();

        CreateMap<GetSampleByParamsResponse, IList<Domain.Models.Sample>>()
        .ForMember(d => d,
        s => s.ConvertUsing<RepeatedSampleToSampleListConverter, Google.Protobuf.Collections.RepeatedField<Proto.Entities.Sample>>(o => o.Result));

    }
}
