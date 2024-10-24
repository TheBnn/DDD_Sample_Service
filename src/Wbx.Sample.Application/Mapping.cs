using AutoMapper;

namespace Wbx.Sample.Application;

using Persistence.Entities;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Sample, Domain.Models.Sample>()
           .ForMember(d=>d.Name, o => o.MapFrom(s=>s.Name));
    }
}
