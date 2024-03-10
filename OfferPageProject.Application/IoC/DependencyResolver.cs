using Autofac;
using AutoMapper;
using OfferPageProject.Application.Mapper;
using OfferPageProject.Application.Services.CountryService;
using OfferPageProject.Application.Services.IncoTermsService;
using OfferPageProject.Application.Services.ModeService;
using OfferPageProject.Application.Services.MovementTypeService;
using OfferPageProject.Application.Services.OfferService;
using OfferPageProject.Application.Services.Unit1Service;
using OfferPageProject.Application.Services.Unit2Service;
using OfferPageProject.Domain.Repositories;
using OfferPageProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferPageProject.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load (ContainerBuilder builder)
        {
            builder.RegisterType<OfferRepository>().As<IOfferRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OfferService>().As<IOfferService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CountyService>().As<ICountryService>().InstancePerLifetimeScope();
            builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
            builder.RegisterType<ModeRepository>().As<IModeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ModeService>().As<IModeService>().InstancePerLifetimeScope();
            builder.RegisterType<Unit1Repository>().As<IUnit1Repository>().InstancePerLifetimeScope();
            builder.RegisterType<Unit1Service>().As<IUnit1Service>().InstancePerLifetimeScope();
            builder.RegisterType<Unit2Repository>().As<IUnit2Repository>().InstancePerLifetimeScope();
            builder.RegisterType<Unit2Service>().As<IUnit2Service>().InstancePerLifetimeScope();
            builder.RegisterType<MovementTypeRepository>().As<IMovementTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MovementTypeService>().As<IMovementTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<IncoTermsRepository>().As<IIncoTermsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<IncoTermsService>().As<IIncoTermsService>().InstancePerLifetimeScope();


            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion

            base.Load (builder);
        }
    }
}
