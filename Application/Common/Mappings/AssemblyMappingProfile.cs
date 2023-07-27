using System.Reflection;
using AutoMapper;

namespace Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
    {
        ApplyMappingsFromAssembly(assembly);
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapWith<>))
            );

        foreach (var type in types)
        {
            Type currentType = type;
            
            if (type.IsGenericType)
            {
                Type[] typeArgs = { typeof(string) };
                currentType = type.MakeGenericType(typeArgs);
            }
            
            var instance = Activator.CreateInstance(currentType);
            var methodInfo = currentType.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new[] { this });
        }
    }
}