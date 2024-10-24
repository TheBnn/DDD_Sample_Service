using Grpc.Net.Client;
using System;

namespace Wbx.Sample.Grpc.Client;

public  class Client
{
    public Client()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:55662");

        var client = new Proto.Services.SampleService.SampleServiceClient(channel);
        // обмениваемся сообщениями с сервером
        var reply = client.GetSampleById(new Proto.Services.GetSampleByIdRequest { Id = Guid.NewGuid().ToString() });
    }
}
