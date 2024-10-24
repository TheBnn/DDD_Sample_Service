using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;
using Wbx.Sample.Grpc.Proto.Services;

namespace Wbx.Sample.Grpc.Client.Mapping.Converters
{
    public class RepeatedSampleToSampleListConverter : IValueConverter<RepeatedField<Proto.Entities.Sample>, List<Domain.Models.Sample>>
    {
        public List<Domain.Models.Sample> Convert(RepeatedField<Proto.Entities.Sample> sourceMember, ResolutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
