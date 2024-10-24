using AutoMapper;

namespace Wbx.Sample.Persistence.Mapping;

using Entities;
public class SampleMap : Profile
{
    public SampleMap()
    {
        CreateMap<Sample, Domain.Models.Sample>()
       .AfterMap((source, dest) => source.Name = dest.Name);
    }
}
