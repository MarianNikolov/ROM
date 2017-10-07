using ROM.Web.Infrastructure;
using System.Reflection;

namespace ROM.Web.App_Start
{
    public static class MapperConfig
    {
        public static void RegesterMapper()
        {
            var mapper = new AutoMapperConfig();
            mapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}