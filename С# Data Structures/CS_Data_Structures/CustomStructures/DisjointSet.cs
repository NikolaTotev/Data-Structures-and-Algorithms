using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    //Todo make with generics.
    class DisjointSet<T> where T:IComparable
    {
        private Dictionary<T, T> Parent { get; set; }
        public Dictionary<T, int> Rank { get; set; }

        public DisjointSet()
        {
            Parent = new Dictionary<T, T>();
            Rank = new Dictionary<T, int>();
        }


        public void MakeSet(T x)
        {
            Parent[x] = x;
            Rank[x] = 0;
        }

        public T FindSet(T x)
        {
            if (!Parent[x].Equals(x)) // Parent[x] != x
            {
                Parent[x] = FindSet(Parent[x]);
            }

            return Parent[x];
        }
        public void Union(T x, T y)
        {
            T representativeX = FindSet(x);
            T representativeY = FindSet(y);

            if (Rank[representativeX] == Rank[representativeY])
            {
                Rank[representativeY]++;
                Parent[representativeX] = representativeY;
            }

            if (Rank[representativeX] > Rank[representativeY])
            {
                Parent[representativeY] = representativeX;
            }
            else
            {
                Parent[representativeX] = representativeY;
            }
        }

        public T FindImmediateParent(T x)
        {
            return Parent[x];
        }

        public int FindRank(T x)
        {
            return Rank[x];
        }

    }
}
