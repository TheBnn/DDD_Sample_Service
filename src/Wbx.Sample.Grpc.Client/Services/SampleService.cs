using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Net.Client;
using System;

namespace Wbx.Sample.Grpc.Client.Services;

using Wbx.Sample.Domain.Models;
using Wbx.Sample.Domain.Repository;
using Wbx.Sample.Grpc.Proto.Services;

public class SampleService : Wbx.Sample.Grpc.Proto.Services.SampleService.SampleServiceClient, ISampleService
{
    private readonly IMapper _mapper;
    public SampleService(IMapper mapper, GrpcChannel channel) : base(channel)
    {
        _mapper = mapper;
    }

    public async Task<Domain.Models.EditResult<Guid>> AddSample(AddSampleParams addParams)
    {
        var request = _mapper.Map<AddSampleRequest>(addParams);
        var result = await AddSampleAsync(request);
        return _mapper.Map<Domain.Models.EditResult<Guid>>(result);
    }

    public async Task<Result> DeleteSample(Guid id)
    {
        var request = _mapper.Map<DeleteSampleRequest>(id);
        var result = await DeleteSampleAsync(request);
        return _mapper.Map<Domain.Models.Result>(result);
    }

    public async Task<Sample> GetSampleById(Guid id)
    {
        var request = _mapper.Map<GetSampleByIdRequest>(id);
        var result = await GetSampleByIdAsync(request);
        return _mapper.Map<Sample>(result);
    }

    public async Task<IList<Sample>> GetSamplesByParams(GetSamplesParams getParams)
    {
        var request = _mapper.Map<GetSamplesByParamsRequest>(getParams);
        var result = await GetSamplesByParamsAsync(request);
        return _mapper.Map<IList<Sample>>(result);
    }

    public async Task<Result> ProcessTaskItem(ProcessTaskItemParams itemParams)
    {
        var request = _mapper.Map<ProcessTaskItemRequest>(itemParams);
        var result = await ProcessTaskItemAsync(request);
        return _mapper.Map<Result>(result);
    }

    public async Task<Result> StartProcessTask(StartProcessParams startParams)
    {
        var request = _mapper.Map<StartProcessTaskRequest>(startParams);
        var result = await StartProcessTaskAsync(request);
        return _mapper.Map<Result>(result);
    }

    public async Task<Result> StopProcessTask(StopProcessParams stopParams)
    {
        var request = _mapper.Map<StopProcessTaskRequest>(stopParams);
        var result = await StopProcessTaskAsync(request);
        return _mapper.Map<Result>(result);
    }

    public async Task<Result> UpdateSample(UpdateSampleParams updateParams)
    {
        var request = _mapper.Map<UpdateSampleRequest>(updateParams);
        var result = await UpdateSampleAsync(request);
        return _mapper.Map<Domain.Models.Result>(result);
    }

}
