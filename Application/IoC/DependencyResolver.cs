using Application.AutoMapper;
using Application.Models.DTOs;
using Application.Services.Concrete;
using Application.Services.Interfaces;
using Application.Validation.FluentValidation;
using Autofac;
using AutoMapper;
using Domain.UnitOfWork;
using FluentValidation;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IoC
{
    //Bu sınıfı Ioc Cointanier gibi kullandım.Program cs. bu sınıf çağırdım.
    //Thirtd part cointainer
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //UnitOfWork register ettim.
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ArticleService>().As<IArticleService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();

            builder.RegisterType<LoginValidation>().As<IValidator<LoginDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterDTO>>().InstancePerLifetimeScope();


            //AutoMapper inj ettim.

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>();
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
        }
    }
}
