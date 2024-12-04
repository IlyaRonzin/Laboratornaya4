using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4
{
    public static class ListMergerHelper
    {
        public static void FillTheListInAscendingOrder(List<int> result, List<int> list1, List<int> list2, Iterators iterators)
        {
            if (list1[iterators.i] <= list2[iterators.j])
            {
                result.Add(list1[iterators.i]);
                iterators.i++;
            }
            else
            {
                result.Add(list2[iterators.j]);
                iterators.j++;
            }
        }

        public static void FillTheListInDescendingOrder(List<int> result, List<int> list1, List<int> list2, Iterators iterators)
        {
            if (list1[iterators.i] >= list2[iterators.j])
            {
                result.Add(list1[iterators.i]);
                iterators.i++;
            }
            else
            {
                result.Add(list2[iterators.j]);
                iterators.j++;
            }
        }

        public static void AddElementsToTheEnd(List<int> result, List<int> list, int i)
        {
            while (i < list.Count)
            {
                result.Add(list[i]);
                i++;
            }
        }
    }
}
