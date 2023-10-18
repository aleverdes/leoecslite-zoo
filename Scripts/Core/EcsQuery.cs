
// CODEGEN
// Collection of classes for EcsQuery (LeoECS Lite Zoo by Alexander Travkin @aleverdes)
// Version 2.1.0
// https://github.com/aleverdes/leoecslite-zoo

using System.Runtime.CompilerServices;
using Leopotam.EcsLite;

namespace AleVerDes.LeoEcsLiteZoo
{
    
    public sealed class EcsQuery<TInclude0> : IEcsQuery where TInclude0 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1> : IEcsQuery where TInclude0 : struct where TInclude1 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10, TInclude11> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct where TInclude11 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10, TInclude11, TInclude12> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct where TInclude11 : struct where TInclude12 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10, TInclude11, TInclude12, TInclude13> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct where TInclude11 : struct where TInclude12 : struct where TInclude13 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10, TInclude11, TInclude12, TInclude13, TInclude14> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct where TInclude11 : struct where TInclude12 : struct where TInclude13 : struct where TInclude14 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }

    public sealed class EcsQuery<TInclude0, TInclude1, TInclude2, TInclude3, TInclude4, TInclude5, TInclude6, TInclude7, TInclude8, TInclude9, TInclude10, TInclude11, TInclude12, TInclude13, TInclude14, TInclude15> : IEcsQuery where TInclude0 : struct where TInclude1 : struct where TInclude2 : struct where TInclude3 : struct where TInclude4 : struct where TInclude5 : struct where TInclude6 : struct where TInclude7 : struct where TInclude8 : struct where TInclude9 : struct where TInclude10 : struct where TInclude11 : struct where TInclude12 : struct where TInclude13 : struct where TInclude14 : struct where TInclude15 : struct
    {
        private EcsFilter _filter;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter GetFilter() => _filter;
        
        
        public sealed class Exc<TExclude0> : IEcsQuery where TExclude0 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1> : IEcsQuery where TExclude0 : struct where TExclude1 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

        public sealed class Exc<TExclude0, TExclude1, TExclude2, TExclude3, TExclude4, TExclude5, TExclude6, TExclude7, TExclude8, TExclude9, TExclude10, TExclude11, TExclude12, TExclude13, TExclude14, TExclude15> : IEcsQuery where TExclude0 : struct where TExclude1 : struct where TExclude2 : struct where TExclude3 : struct where TExclude4 : struct where TExclude5 : struct where TExclude6 : struct where TExclude7 : struct where TExclude8 : struct where TExclude9 : struct where TExclude10 : struct where TExclude11 : struct where TExclude12 : struct where TExclude13 : struct where TExclude14 : struct where TExclude15 : struct
        {
            private EcsFilter _filter;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter.Enumerator GetEnumerator() => _filter.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EcsFilter GetFilter() => _filter;
        }

    }


    internal interface IEcsQuery
    {
    }
}
