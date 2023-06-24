using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Extensions
{
    public static class ExclusaoLogica
    {
        public static void AplicarExclusaoLogica(this ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model
            .GetEntityTypes();

            foreach (var entityType in entityTypes)
            {
                var isActiveProperty = entityType.FindProperty("Excluido");
                if (isActiveProperty != null && isActiveProperty.ClrType == typeof(bool))
                {
                    var entityBuilder = modelBuilder.Entity(entityType.ClrType);
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var methodInfo = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool))!;
                    var efPropertyCall = Expression.Call(null, methodInfo, parameter, Expression.Constant("Excluido"));
                    var body = Expression.MakeBinary(ExpressionType.Equal, efPropertyCall, Expression.Constant(false));
                    var expression = Expression.Lambda(body, parameter);
                    entityBuilder.HasQueryFilter(expression);
                }

            }
        }
    }
}
