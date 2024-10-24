using AutoMapper;
using Google.Protobuf.Collections;

namespace Wbx.Sample.Grpc.Service.Mappings
{
    public class SampleListToRepeatedSampleConverter : IValueConverter<List<Domain.Models.Sample>, RepeatedField<Proto.Entities.Sample>>
    {
        private readonly IMapper _mapper;
        public SampleListToRepeatedSampleConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RepeatedField<Proto.Entities.Sample> Convert(List<Domain.Models.Sample> sourceMember, ResolutionContext context)
        {
            
           var result= new RepeatedField<Proto.Entities.Sample>();
            foreach (var item in sourceMember)
            {
                result.Add(_mapper.Map<Domain.Models.Sample, Proto.Entities.Sample>(item));
            }
            
            return result;
        }
    }
}
