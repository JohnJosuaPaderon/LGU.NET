using LGU.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LGU.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static IEnumerable<T> GetSource<T, TModel>(this ObservableCollection<TModel> instance)
            where TModel : ModelBase<T>
        {
            var list = new List<T>();

            foreach (var item in instance)
            {
                list.Add(item.GetSource());
            }

            return list;
        }
    }
}
