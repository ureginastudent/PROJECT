using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELLs_FrontEnd
{
    public class CollectionList<T> : List<T>
    {
        public event EventHandler OnAdd;
        public event EventHandler OnRemove;

        public new void Add(T Item)
        {
            OnAdd?.Invoke(Item, null);
            base.Add(Item);
        }

        public new void Remove(T Item)
        {
            OnRemove?.Invoke(Item, null);
            base.Remove(Item);
        }
    }
}
