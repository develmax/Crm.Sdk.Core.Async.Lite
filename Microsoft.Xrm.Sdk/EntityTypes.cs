using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Xrm.Sdk;

public static class EntityTypes
{
    private static IEnumerable<string> _modules;
    internal static IEnumerable<TypeInfo> types;

    public static void EnableProxyTypes()
    {
        List<TypeInfo> typeList = new List<TypeInfo>();
        
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly assembly in assemblies)
        {
            if (_modules == null || _modules.Contains(assembly.ManifestModule.Name))
            {
                foreach (TypeInfo type in assembly.DefinedTypes)
                {
                    // Store only CRM Entities.
                    if (type.BaseType == typeof(Entity))
                        typeList.Add(type);
                }
            }
        }

        types = typeList.ToArray();
    }

    public static void SetProxyModules(IEnumerable<string> modules)
    {
        _modules = modules;
    }

    public static void SetProxyTypes(IEnumerable<TypeInfo> types)
    {
        EntityTypes.types = types;
    }

    internal static Entity ConvertToEarlyBound(Entity entity)
    {
        if (types == null)
            return entity;
        TypeInfo currentType = types.Where(x => x.Name.ToLower() == entity.LogicalName).FirstOrDefault();
        if (currentType == null)
            return entity;
        else
            // Then convert it by using Entity.ToEntity<T> method.
            return (Entity)typeof(Entity).GetRuntimeMethod("ToEntity", new Type[] { }).
                MakeGenericMethod(currentType.AsType()).Invoke(entity, null);
    }
}