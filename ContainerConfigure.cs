using Autofac;

namespace CW
{
    public static class ContainerConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<HltvProvider>().As<IProvider>();

            return builder.Build();
        }
    }
}