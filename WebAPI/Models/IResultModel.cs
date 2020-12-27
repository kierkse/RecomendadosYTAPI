using System.Collections.Generic;

namespace RecomendadosYTAPI.WebAPI.Models
{
    public interface IResultModel<TEntity>
    {
        bool HasSucceeded { get; }
        IEnumerable<ResultDetail> Details { get; }
        TEntity Data { get; }
    }
}