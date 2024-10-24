using AutoMapper;
using Grpc.Core;
using MediatR;

namespace Wbx.Sample.Grpc.Service.Services;

using Application.Features.Sample.Commands;
using Application.Features.Sample.Queries;
using Grpc.Proto.Services;

public class SampleService: Proto.Services.SampleService.SampleServiceBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SampleService(IMediator mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async override Task<StartProcessTaskResponse> StartProcessTask(StartProcessTaskRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(_mapper.Map<StartProcessTaskCommand>(request));
         return _mapper.Map<StartProcessTaskResponse>(result);
    }

    public async override Task<StopProcessTaskResponse> StopProcessTask(StopProcessTaskRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(_mapper.Map<StopProcessTaskCommand>(request));
        return _mapper.Map<StopProcessTaskResponse>(result);
    }

    public async override Task<ProcessTaskItemResponse> ProcessTaskItem(ProcessTaskItemRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(_mapper.Map<ProcessTaskItemCommand>(request));
        return _mapper.Map<ProcessTaskItemResponse>(result);
    }

    
    
    //public async override Task<EditResponse> AddSample(AddSampleRequest request, ServerCallContext context)
    //{
    //    var result = await _mediator.Send(_mapper.Map<AddSampleCommand>(request));
    //    return _mapper.Map<EditResponse>(result);
    //}

    //public async override Task<EditResponse> DeleteSample(DeleteSampleRequest request, ServerCallContext context)
    //{
    //    var result = await _mediator.Send(_mapper.Map<DeleteSampleCommand>(request));
    //    return _mapper.Map<EditResponse>(result);
    //}

    //public async override Task<EditResponse> UpdateSample(UpdateSampleRequest request, ServerCallContext context)
    //{
    //    var result = await _mediator.Send(_mapper.Map<UpdateSampleCommand>(request));
    //    return _mapper.Map<EditResponse>(result);
    //}

    //public async override Task<GetSampleByIdResponse> GetSampleById(GetSampleByIdRequest request, ServerCallContext context)
    //{
    //    var result = await _mediator.Send(_mapper.Map<GetSampleByIdQuery>(request));
    //    return _mapper.Map<GetSampleByIdResponse>(result);
    //}

    //public async override Task<GetSamplesByParamsResponse> GetSamplesByParams(GetSamplesByParamsRequest request, ServerCallContext context)
    //{
    //    var result = await _mediator.Send(_mapper.Map<GetSamplesByParamsQuery>(request));
    //    return _mapper.Map<GetSamplesByParamsResponse>(result);
    //}

}
