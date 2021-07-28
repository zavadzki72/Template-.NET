using AutoMapper;

namespace DotNetTemplate.CrossCutting.AutoMapper {
    public static class MappingExtensions {

        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression) {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }

    }
}
