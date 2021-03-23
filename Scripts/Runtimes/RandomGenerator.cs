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
        /// シード
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
        /// floatの乱数値を取得します
        /// </summary>
        /// <returns>Float乱数[0f, 1f]</returns>
        public float GetFloat()
        {
            uint floatBits = (GetUint() >> 9) | 0x3f800000;
            return BitConverter.ToSingle(BitConverter.GetBytes(floatBits), 0) - 1f;
        }

        /// <summary>
        /// floatの乱数値を範囲を指定して取得します
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns>float乱数[min, max]</returns>
        public float Range(float min, float max)
        {
            float actualMin = Mathf.Min(min, max);
            float actualMax = Mathf.Max(min, max);

            return GetFloat() * (actualMax - actualMin) + actualMin;
        }

        /// <summary>
        /// intの乱数値を範囲を指定して取得します
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値+1</param>
        /// <returns>int型の乱数[min, max-1]</returns>
        public int Range(int min, int max)
        {
            int actualMin = Mathf.Min(min, max);
            int actualMax = Mathf.Max(min, max);

            int mod = (int)(GetUint() % (actualMax - actualMin));
            return mod + actualMin;
        }
    }
}
