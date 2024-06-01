using System.Reflection;
using Autofac;
using CommonLibrary;
using CommonLibrary.Events;
using CommonLibrary.Repository;
using CustomerService.Core.CustomerAggregate;
using CustomerService.Core.Interfaces;
using CustomerService.Infrastructure.Data;
using CustomerService.Infrastructure.Data.Queries;
using CustomerService.Infrastructure.Email;
using CustomerService.UseCases.Customer.Create;
using CustomerService.UseCases.Customer.List;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace CustomerService.Infrastructure;

public class InfrastructureModule : Module
{
  private readonly bool _isDevelopment = false;
  private readonly List<Assembly> _assemblies = [];

  public InfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    AddToAssembliesIfNotNull(callingAssembly);
  }

  private void AddToAssembliesIfNotNull(Assembly? assembly)
  {
    if (assembly != null)
    {
      _assemblies.Add(assembly);
    }
  }

  private void LoadAssemblies()
  {
    // TODO: Replace these types with any type in the appropriate assembly/project
    var coreAssembly = Assembly.GetAssembly(typeof(Customer));
    var infrastructureAssembly = Assembly.GetAssembly(typeof(InfrastructureModule));
    var useCasesAssembly = Assembly.GetAssembly(typeof(CreateCustomerCommand));

    AddToAssembliesIfNotNull(coreAssembly);
    AddToAssembliesIfNotNull(infrastructureAssembly);
    AddToAssembliesIfNotNull(useCasesAssembly);
  }

  protected override void Load(ContainerBuilder builder)
  {
    LoadAssemblies();
    if (_isDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }
    RegisterEF(builder);
    RegisterQueries(builder);
    RegisterMediatR(builder);
  }

  private void RegisterEF(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .InstancePerLifetimeScope();
  }

  private void RegisterQueries(ContainerBuilder builder)
  {
    builder.RegisterType<ListCustomerQueryService>()
      .As<IListCustomerQueryService>()
      .InstancePerLifetimeScope();
  }

  private void RegisterMediatR(ContainerBuilder builder)
  {
    builder
      .RegisterType<Mediator>()
      .As<IMediator>()
      .InstancePerLifetimeScope();

    builder
    .RegisterType<IEventSourceDispatcher>()
    .As<IEventSourceDispatcher>()
    .InstancePerLifetimeScope();

    builder
      .RegisterType<EventPublisher>()
      .As<CommonLibrary.IEventPublisher>()
      .InstancePerLifetimeScope();



    var mediatrOpenTypes = new[]
    {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
        .RegisterAssemblyTypes(_assemblies.ToArray())
        .AsClosedTypesOf(mediatrOpenType)
        .AsImplementedInterfaces();
    }
  }

  private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();

    builder.RegisterType<FakeListCustomerQueryService>()
      .As<IListCustomerQueryService>()
      .InstancePerLifetimeScope();
  }

  private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();
  }
}
