using Univent.Api.Registrars;

namespace Univent.Api.Extensions
{
    public static class RegistrarExtensions
    {
        /* IRegistrar is only a marker interface */
        private static IEnumerable<T> GetRegistrars<T>(Type scanningType) where T : IRegistrar
        {
            return scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance).Cast<T>();
        }

        public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
        {
            var registrars = GetRegistrars<IWebApplicationBuilderRegistrar>(scanningType);
            foreach (var registrar in registrars)
            { 
                registrar.RegisterServices(builder);
            }
        }

        public static void RegisterPipelineComponents(this WebApplication app, Type scanningType)
        {
            var registrars = GetRegistrars<IWebApplicationRegistrar>(scanningType);
            foreach (var registrar in registrars)
            {
                registrar.RegisterPipelineComponents(app);
            }
        }
    }
}
