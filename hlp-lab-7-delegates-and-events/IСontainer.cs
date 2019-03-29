using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_7_delegates_and_events
{
    interface IСontainer<T>
    {
        bool Add(T item);

        T Peak();

        int Count();

        T Remove();

        bool Clear();
    }
}
