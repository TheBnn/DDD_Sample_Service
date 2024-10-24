using AutoMapper;

namespace Wbx.Sample.Persistence.Repository;

using DatabaseContext;

public class BaseRepository
{
    protected readonly Context _context;
    protected readonly IMapper _mapper;
    public BaseRepository(IMapper mapper, Context context)
    {
        _context = context;
        _mapper = mapper;
    }
}
