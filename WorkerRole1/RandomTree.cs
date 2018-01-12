using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRole1
{
    public class RandomTree<T>
    {
        private static Random r = new Random();
        
        TData root = null;

        public RandomTree()
        {

        }

        public void Add(T Data, int Weight)
        {
            Add(Data, Weight, 1);
        }

        public void Add(T Data, int Weight, uint Flag)
        {
            TData d = new TData(Data, Weight, Flag);
            if (root == null)
            {
                root = d;
            } else
            {
                root.Add(d);
            }
        }

        public T GetRandom()
        {
            return GetRandom(1);
        }

        public T GetRandom(uint flag)
        {
            if (root == null)
            {
                return default(T);
            }
            else
            {
                return Select(root,flag);
            }
        }

        private T Select(TData data, uint flag)
        {
            int lw = data.GetLeftWeight(flag);
            int rw = data.GetRightWeight(flag);
            int rand = r.Next(data.Weight + lw + rw - 1);
            if (rand >= lw + rw) // return base
            {
                return data.Data;
            }
            else if (rand > rw) // check left
            {
                return Select(data.left,flag);
            }
            else //check right
            {
                return Select(data.right,flag);
            }
        }

        public class TData
        {
            public int Weight;
            public uint modeFlags = 1;
            public T Data;
            public TData left = null;
            public TData right = null;

            public TData(T Data, int Weight, uint Flag)
            {
                this.Weight = Weight;
                this.Data = Data;
                this.modeFlags = Flag & 1;
            }
            public int GetLeftWeight(uint flag)
            {
                return (left == null) ? 0 : left._GetLeftWeight(flag);
            }
            public int _GetLeftWeight(uint flag)
            {
                int ret = 0;
                ret += (left == null) ? 0 : left._GetLeftWeight(flag);
                //ret += (right == null) ? 0 : GetRightWeight(flag);
                return ret + (((flag | modeFlags) != 0) ? Weight : 0);
            }
            public int GetRightWeight(uint flag)
            {
                return (right == null) ? 0 : right._GetRightWeight(flag);
            }
            public int _GetRightWeight(uint flag)
            {
                int ret = 0;
                //ret += (left == null) ? 0 : GetLeftWeight(flag);
                ret += (right == null) ? 0 : right._GetRightWeight(flag);
                return ret + (((flag | modeFlags) != 0) ? Weight : 0);
            }

            public void Add(TData data)
            {
                if(left == null)
                {
                    left = data;
                }
                else if(right == null)
                {
                    right = data;
                }
                else
                {
                    if(GetLeftWeight(1) >= GetRightWeight(1))
                    {
                        right.Add(data);
                    }
                    else
                    {
                        left.Add(data);
                    }
                }
            }

        }
    }
}
