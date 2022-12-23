using Autofac;
using DUR.Api.Services.Financial.Interfaces;
using DUR.Api.Services.Financial.Services;

namespace DUR.Api.Services.Financial;

public static class FinancialServicesInjector
{
    public static void RegisterModule(ContainerBuilder container)
    {
        container.RegisterType<ExpenseGenerator>().As<IExpenseGenerator>();
        container.RegisterType<ExpenseUploader>().As<IExpenseUploader>();
    }
}