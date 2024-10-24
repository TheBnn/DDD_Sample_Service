using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wbx.Sample.Application.Features;
using Wbx.Sample.Application.Features.Sample.Commands;
using Wbx.Sample.Application.Features.Sample.Queries;
using Wbx.Sample.Domain.Models;
using Wbx.Sample.Domain.Repository;
using Wbx.Sample.Persistence.Repository;
using static Wbx.Sample.Application.Features.Sample.Commands.AddSampleCommand;
using static Wbx.Sample.Application.Features.Sample.Queries.GetSampleByIdQuery;

namespace Wbx.Sample.Application
{
    public static class Entry
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddTransient<IRequestHandler<AddSampleCommand, Domain.Models.EditResult<Guid>>, AddSampleCommandHandler>();
            //services.AddTransient<IValidator<AddSampleCommand>, AddSampleCommandValidator>();
            //services.AddTransient<IRepository<Sample.Persistence.Entities.Sample, GetSamplesParams>, SampleRepositoty>();

            services.AddTransient<IRequestHandler<GetSampleByIdQuery, Domain.Models.Sample>, GetSampleByIdQueryHandler>();
            services.AddTransient<IValidator<GetSampleByIdQuery>, GetSampleByIdQueryValidator>();
            //services.AddTransient<IRepository<Sample.Persistence.Entities.Sample, GetSamplesParams>, SampleRepositoty>();
        }
    }
}
