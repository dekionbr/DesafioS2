using AmigoCrud.S2.Application.Interfaces;
using AmigoCrud.S2.Application.Services;
using AmigoCrud.S2.Domain.Bus;
using AmigoCrud.S2.Domain.CommandHandlers;
using AmigoCrud.S2.Domain.Commands;
using AmigoCrud.S2.Domain.EventHandlers;
using AmigoCrud.S2.Domain.Events;
using AmigoCrud.S2.Domain.Interfaces;
using AmigoCrud.S2.Domain.Notifications;
using AmigoCrud.S2.Infra.CrossCutting.Bus;
using AmigoCrud.S2.Infra.CrossCutting.Identity.Authorization;
using AmigoCrud.S2.Infra.CrossCutting.Identity.Models;
using AmigoCrud.S2.Infra.CrossCutting.Identity.Services;
using AmigoCrud.S2.Infra.Data.Context;
using AmigoCrud.S2.Infra.Data.Repository;
using AmigoCrud.S2.Infra.Data.UoW;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoCrud.S2.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IJogoAppService, JogoAppService>();
            services.AddScoped<IAmigoAppService, AmigoAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Jogo
            services.AddScoped<INotificationHandler<JogoRegisteredEvent>, JogoEventHandler>();
            services.AddScoped<INotificationHandler<JogoUpdatedEvent>, JogoEventHandler>();
            services.AddScoped<INotificationHandler<JogoRemovedEvent>, JogoEventHandler>();
            
            //Amigo
            services.AddScoped<INotificationHandler<AmigoRegisteredEvent>, AmigoEventHandler>();
            services.AddScoped<INotificationHandler<AmigoUpdatedEvent>, AmigoEventHandler>();
            services.AddScoped<INotificationHandler<AmigoRemovedEvent>, AmigoEventHandler>();

            
            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterNewJogoCommand>, JogoCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateJogoCommand>, JogoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveJogoCommand>, JogoCommandHandler>();

            services.AddScoped<INotificationHandler<RegisterNewAmigoCommand>, AmigoCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateAmigoCommand>, AmigoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveAmigoCommand>, AmigoCommandHandler>();

            // Infra - Data
            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AmigoCrudContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
