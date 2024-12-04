using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4
{
    public class IfHelper
    {
        public static bool IsAscending(List<int> list)
        {
            return list.Count < 2 || list[0] <= list[^1];
        }
    }
}
