using System;
using System.Collections.Generic;
using System.Text;

namespace _18
{
    public class SnailfishReducer
    {
        public void ReduceAll(SnailfishNumber root)
        {
            while (ReduceOnce(root));
        }

        public bool ReduceOnce(SnailfishNumber root)
        {
            try
            {
                var list = ToList(root);

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Depth == 4 && list[i].Number.IsPair())
                    {
                        var numberToExplode = list[i].Number;

                        for (int left = i - 1; left >= 0; left--)
                        {
                            if (list[left].Number.IsValue())
                            {
                                list[left].Number.AddExplosiveMatter(numberToExplode.X.Value.Value);
                                break;
                            }
                        }

                        for (int right = i + 3; right < list.Count; right++)
                        {
                            if (list[right].Number.IsValue())
                            {
                                list[right].Number.AddExplosiveMatter(numberToExplode.Y.Value.Value);
                                break;
                            }
                        }

                        numberToExplode.Explode();
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Number.Split();
                }
            }
            catch (SplitHappens)
            {
                return true;
            }
            catch (BigBadaBoom)
            {
                return true;
            }

            return false;
        }

        //private void Reduce(SnailfishNumber number, int depth)
        //{
        //    if (number.X != null)
        //    {
        //        Reduce(number.X, depth + 1);
        //        Reduce(number.Y, depth + 1);
        //    }

        //    // number.Explode();
        //    number.Split();
        //}

        private List<(SnailfishNumber Number, int Depth)> ToList(SnailfishNumber root)
        {
            var list = new List<(SnailfishNumber, int)>();
            Flatten(root, 0);
            return list;

            void Flatten(SnailfishNumber number, int depth)
            {
                list.Add((number, depth));
                if (number.Value.HasValue)
                    return;

                Flatten(number.X, depth + 1);
                Flatten(number.Y, depth + 1);
            }
        }
    }
}
