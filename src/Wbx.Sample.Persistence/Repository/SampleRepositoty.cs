using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Wbx.Sample.Persistence.Repository;

using Domain;
using Entities;
using DatabaseContext;

public class SampleRepositoty : BaseRepository, Domain.Repository.IRepository<Sample, Domain.Models.GetSamplesParams>
{
   
    public SampleRepositoty(IMapper mapper, Context context): base(mapper, context)
    {
    }

    public async Task<Guid> Add(Sample sampleParams)
    {
        var sample = await _context.AddAsync(sampleParams);
        await _context.SaveChangesAsync();
        return sample.Entity.Id;
    }

    public async Task Delete(Guid id)
    {
        var sample = await _context.Samples.FirstAsync(x => x.Id == id);
        _context.Samples.Remove(sample);
        await _context.SaveChangesAsync();
    }

    public async Task<Domain.Models.Sample> GetById(Guid id)
    {
        return _mapper.Map<Domain.Models.Sample>(await _context.Samples.FirstAsync(x => x.Id == id));
    }

    public async Task<IList<Domain.Models.Sample>> GetByParams(Domain.Models.GetSamplesParams filterParams)
    {
        //TODO: пройти по всем параметрам и составить выражение
        Expression<Func<Sample, bool>> where = x => filterParams.Name.Contains(x.Name);
           
        return _mapper.Map<IList<Domain.Models.Sample>>(await _context.Samples.Where(where).ToListAsync());
    }

    public async Task Update(Domain.Models.Sample sampleParams)
    {
        var isChanged = false;
        var sample = await _context.Samples.FirstOrDefaultAsync(x => x.Id == sampleParams.Id);
        if (sample.Name != sampleParams.Name)
        {
            isChanged = true;
            sample.Name = sampleParams.Name;
        }

        if (isChanged)
            await _context.SaveChangesAsync();
    }

    public Task Update(Sample entityParams)
    {
        throw new NotImplementedException();
    }
}
