using System;
using UnityEngine;

namespace HassakuLab.Randoms
{
    /// <summary>
    /// Random number generator
    /// </summary>
    public abstract class RandomGenerator
    {
        /// <summary>
        /// シード値
        /// </summary>
        public abstract uint Seed {
            get; set;
        }

        /// <summary>
        /// [0, uint.MaxValue]の乱数を取得します
        /// </summary>
        /// <returns>乱数値[0U, unit.MaxValue]</returns>
        public abstract uint GetUint();

        /// <summary>
        /// float型の乱数値を取得します
        /// </summary>
        /// <returns>Float型乱数値[0f, 1f]</returns>
        public float GetFloat()
        {
            uint floatBits = (GetUint() >> 9) | 0x3f800000;
            return BitConverter.ToSingle(BitConverter.GetBytes(floatBits), 0) - 1f;
        }

        /// <summary>
        /// float型で指定した範囲内の乱数値を取得します
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns>float型乱数値[min, max]</returns>
        public float Range(float min, float max)
        {
            float actualMin = Mathf.Min(min, max);
            float actualMax = Mathf.Max(min, max);

            return GetFloat() * (actualMax - actualMin) + actualMin;
        }

        /// <summary>
        /// int型で指定した範囲内の乱数値を取得します
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns>int型乱数値[min, max-1]</returns>
        public int Range(int min, int max)
        {
            int actualMin = Mathf.Min(min, max);
            int actualMax = Mathf.Max(min, max);

            int mod = (int)(GetUint() % (actualMax - actualMin));
            return mod + actualMin;
        }
    }
}
