using Autofac;
using CustomerService.Core.Interfaces;
using CustomerService.Core.Services;

namespace CustomerService.Core;

public class CoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<DeleteCustomerService>().As<IDeleteCustomerService>().InstancePerLifetimeScope();
    builder.RegisterType<CreateCustomerService>().As<ICreateCustomerService>().InstancePerLifetimeScope();
  }
}
