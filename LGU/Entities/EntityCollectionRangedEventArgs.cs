using System.Collections.Generic;

namespace LGU.Entities
{
    public class EntityCollectionRangedEventArgs<T> : EntityCollectionEventArgs
    {
        public EntityCollectionRangedEventArgs(EntityCollectionOperation operation) : base(operation)
        {
        }

        public EntityCollectionRangedEventArgs(EntityCollectionOperation operation, IEnumerable<T> dataList) : base(operation)
        {
            DataList = dataList;
        }

        public IEnumerable<T> DataList { get; }
    }
}