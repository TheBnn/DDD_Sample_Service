namespace Wbx.Sample.Domain.Repository;

using Models;

public interface ISampleService
{
    Task<Result> StartProcessTask(StartProcessParams startParams);
    Task<Result> StopProcessTask(StopProcessParams stopParams);
    Task<Result> ProcessTaskItem(ProcessTaskItemParams itemParams);
    //Task<EditResult<Guid>> AddSample(AddSampleParams addParams);
    //Task<EditResult> UpdateSample(UpdateSampleParams updateParams);
    //Task<EditResult> DeleteSample(Guid id);
    //Task<Sample> GetSampleById(Guid id);
    //Task<IList<Sample>> GetSamplesByParams(GetSamplesParams getParams);
}
