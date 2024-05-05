using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AleVerDes.LeoEcsLiteZoo
{
    public class EcsQueryGenerator
    {
        private const string ScriptTemplate = @"
// CODEGEN
// Collection of classes for EcsQuery (LeoECS Lite Zoo by Alexander Travkin @aleverdes)
// Version 4.2.0
// https://github.com/aleverdes/leoecslite-zoo

using System.Runtime.CompilerServices;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    {INCLUDES}

    internal interface IEcsQuery
    {
        EcsFilter.Enumerator GetEnumerator();
        EcsFilter GetFilter();
    }
}
";

        private const string IncludeClassTemplate = @"
    public sealed class EcsQuery<{INCLUDE_TYPES}> : IEcsQuery {INCLUDE_DEFINITIONS}
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        {EXCLUDES}
    }
";
        
        private const string ExcludeClassTemplate = @"
        public sealed class Exc<{EXCLUDE_TYPES}> : IEcsQuery {EXCLUDE_DEFINITIONS}
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }
";

        private const string TypeDefinitionTemplate = @"where {TYPE} : struct";

        private static int _includesCount = 16;
        private static int _excludesCount = 16;
        
#if UNITY_EDITOR
        [MenuItem("Window/LeoECS Lite Zoo/Generate EcsQuery classes")]
#endif
        private static void Generate()
        {
            var text = "";

            var excludes = GenerateExcludes();

            var includes = "";
            for (int i = 0; i < _includesCount; i++)
            {
                var include = IncludeClassTemplate;
                
                var includeTypes = new string[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    includeTypes[j] = "TInclude" + j;
                }
                include = include.Replace("{INCLUDE_TYPES}", string.Join(", ", includeTypes));
                
                var includeDefinitions = new string[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    includeDefinitions[j] = TypeDefinitionTemplate.Replace("{TYPE}", "TInclude" + j);
                }
                
                include = include.Replace("{INCLUDE_DEFINITIONS}", string.Join(" ", includeDefinitions));
                include = include.Replace("{EXCLUDES}", excludes);

                includes += include;
            }

            text = ScriptTemplate
                .Replace("{INCLUDES}", includes);
            
            File.WriteAllText(Path.Combine(Application.dataPath, "EcsQuery.cs"), text);
        }

        private static string GenerateExcludes()
        {
            var excludes = "";
            
            for (int e = 0; e < _excludesCount; e++)
            {
                var exclude = ExcludeClassTemplate;

                var excludeTypes = new string[e + 1];
                for (int j = 0; j < e + 1; j++)
                {
                    excludeTypes[j] = "TExclude" + j;
                }

                exclude = exclude.Replace("{EXCLUDE_TYPES}", string.Join(", ", excludeTypes));

                var excludeDefinitions = new string[e + 1];
                for (int j = 0; j < e + 1; j++)
                {
                    excludeDefinitions[j] = TypeDefinitionTemplate.Replace("{TYPE}", "TExclude" + j);
                }

                exclude = exclude.Replace("{EXCLUDE_DEFINITIONS}", string.Join(" ", excludeDefinitions));

                excludes += exclude;
            }

            return excludes;
        }
    }
}