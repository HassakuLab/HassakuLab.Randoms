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
        /// �V�[�h�l
        /// </summary>
        public abstract uint Seed {
            get; set;
        }

        /// <summary>
        /// [0, uint.MaxValue]�̗������擾���܂�
        /// </summary>
        /// <returns>�����l[0U, unit.MaxValue]</returns>
        public abstract uint GetUint();

        /// <summary>
        /// float�^�̗����l���擾���܂�
        /// </summary>
        /// <returns>Float�^�����l[0f, 1f]</returns>
        public float GetFloat()
        {
            uint floatBits = (GetUint() >> 9) | 0x3f800000;
            return BitConverter.ToSingle(BitConverter.GetBytes(floatBits), 0) - 1f;
        }

        /// <summary>
        /// float�^�Ŏw�肵���͈͓��̗����l���擾���܂�
        /// </summary>
        /// <param name="min">�ŏ��l</param>
        /// <param name="max">�ő�l</param>
        /// <returns>float�^�����l[min, max]</returns>
        public float Range(float min, float max)
        {
            float actualMin = Mathf.Min(min, max);
            float actualMax = Mathf.Max(min, max);

            return GetFloat() * (actualMax - actualMin) + actualMin;
        }

        /// <summary>
        /// int�^�Ŏw�肵���͈͓��̗����l���擾���܂�
        /// </summary>
        /// <param name="min">�ŏ��l</param>
        /// <param name="max">�ő�l</param>
        /// <returns>int�^�����l[min, max-1]</returns>
        public int Range(int min, int max)
        {
            int actualMin = Mathf.Min(min, max);
            int actualMax = Mathf.Max(min, max);

            int mod = (int)(GetUint() % (actualMax - actualMin));
            return mod + actualMin;
        }
    }
}
