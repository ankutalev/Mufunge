using System.Collections.Generic;

namespace funge_98.FactoriesStuff

{
    public interface IFactory<out T>
    {
        IEnumerable<T> CreateProducts();
    }
}