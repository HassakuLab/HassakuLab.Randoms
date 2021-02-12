using System;

namespace HassakuLab.Randoms
{
    /// <summary>
    /// Random value generator uisng XorShift algorithm
    /// 周期2^128版
    /// </summary>
    /// <remarks>
    /// paper : http://www.jstatsoft.org/v08/i14/paper
    /// </remarks>
    [Serializable]
    public class XorShift128 : RandomGenerator
    {
        private uint grandSeed;
        private uint[] seed = new uint[4];

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="seed">シード値</param>
        public XorShift128(uint seed)
        {
            Seed = seed;
        }

        /// <summary>
        /// シード値
        /// </summary>
        public override uint Seed {
            get => grandSeed;
            set {
                grandSeed = value;
                for(uint i = 0; i < 4; ++i)
                {
                    unchecked
                    {
                        seed[i] = value = 1812433253U * (value ^ (value >> 30)) + i + 1;
                    }
                }
            }
        }

        /// <summary>
        /// [0, uint.MaxValue]の乱数を取得します
        /// </summary>
        /// <returns>乱数値[0U, unit.MaxValue]</returns>
        public override uint GetUint()
        {
            unchecked
            {
                uint t, w;
                t = seed[0];
                seed[0] = seed[1];
                seed[1] = seed[2];
                seed[2] = w = seed[3];
                t ^= (t << 11);
                w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
                seed[3] = w;
                return w;
            }
        }
    }
}
