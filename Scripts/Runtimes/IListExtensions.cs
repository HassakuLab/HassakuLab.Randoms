using System.Collections.Generic;
using System.Linq;

namespace HassakuLab.Randoms
{
    /// <summary>
    /// IList拡張
    /// </summary>
    public static partial class IListExtensions
    {
        /// <summary>
        /// Fisher-Yatesシャッフル
        /// </summary>
        public static IList<T> Shuffle<T>(this IList<T> list, RandomGenerator rng)
        {
            IList<T> target = list.ToList();
            for (int i = target.Count; i > 1; --i)
            {
                int a = i - 1;
                int b = rng.Range(0, i);

                T tmp = target[a];
                target[a] = target[b];
                target[b] = tmp;
            }

            return target;
        }
    }
}
