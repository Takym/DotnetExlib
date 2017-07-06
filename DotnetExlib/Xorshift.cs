using System;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  Xorshiftを使用した疑似乱数生成器です。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class Xorshift : Random
	{
		/// <summary>
		///  最初に与えられたシード値です。
		/// </summary>
		public readonly ulong Seed;

		private ulong x, y, z, w;

		/// <summary>
		///  シード値を以下の様に設定して、新しいインスタンスを生成します。
		///  <see cref="DotnetExlib.Xorshift.Seed"/> =
		///  <see cref="System.Environment.TickCount"/> XOR <see cref="System.Random.Sample"/>
		/// </summary>
		public Xorshift()
		{
			ulong a = ((ulong)(Sample() * long.MaxValue));
			Seed = ((ulong)(Environment.TickCount)) ^ a;
			this.ResetSeed();
		}

		/// <summary>
		///  シード値を設定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="Seed">シード値です。</param>
		public Xorshift(long Seed)
		{
			this.Seed = ((ulong)(Seed));
			this.ResetSeed();
		}

		/// <summary>
		///  シード値を設定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="Seed">シード値です。</param>
		public Xorshift(ulong Seed)
		{
			this.Seed = Seed;
			this.ResetSeed();
		}

		/// <summary>
		///  シード値を初期値に戻します。
		/// </summary>
		public void ResetSeed()
		{
			x = 0x83F38C937DE3A4B3;
			y = Seed ^ 0xCF2628AE4CD41B08;
			z = ((Seed >> 32) | (Seed & 0xFFFFFFFF00000000)) & 1;
			w = x ^ z;
		}

		/// <summary>
		///  符号無し64bitの乱数を生成します。
		/// </summary>
		/// <returns>乱数です。</returns>
		public virtual ulong NextUInt64()
		{
			ulong i = x ^ (x << 11);
			x = y; y = z; z = w;
			return w = (w ^ (w >> 19)) ^ (i ^ (i >> 8));
		}

		/// <summary>
		///  符号有り64bitの乱数を生成します。
		/// </summary>
		/// <returns>乱数です。</returns>
		public virtual long NextSInt64()
		{
			ulong i = x ^ (x << 11);
			x = y; y = z; z = w;
			return ((long)(w = (w ^ (w >> 19)) ^ (i ^ (i >> 8))));
		}

		/*
		public override int Next()
		{
			return unchecked((int)(NextSInt64() >> 32 & 0xFFFFFFFF));
		}

		public override int Next(int maxValue)
		{
			return unchecked((int)(NextSInt64() >> 32 & 0xFFFFFFFF)) % maxValue;
		}

		public override int Next(int minValue, int maxValue)
		{
			return Next(minValue + maxValue) - minValue;
		}

		public override double NextDouble()
		{
			return 1D / NextUInt64();
		}
		//*/

		public override void NextBytes(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; i += 8) {
				ulong a = NextUInt64();
				buffer[i + 0] = ((byte)(a & 0x00000000000000FF));
				buffer[i + 1] = ((byte)(a & 0x000000000000FF00));
				buffer[i + 2] = ((byte)(a & 0x0000000000FF0000));
				buffer[i + 3] = ((byte)(a & 0x00000000FF000000));
				buffer[i + 4] = ((byte)(a & 0x000000FF00000000));
				buffer[i + 5] = ((byte)(a & 0x0000FF0000000000));
				buffer[i + 6] = ((byte)(a & 0x00FF000000000000));
				buffer[i + 7] = ((byte)(a & 0xFF00000000000000));
			}
		}

		/// <summary>
		///  このオブジェクトのSEED値を文字列形式で取得します。
		/// </summary>
		/// <returns>string型の値です。</returns>
		public override string ToString()
		{
			return $"Seed:{Seed}, X:{x}, Y:{y}, Z:{z}, W:{w}";
		}

		/// <summary>
		///  このオブジェクトのハッシュコードです。
		/// </summary>
		/// <returns>int型の値です。</returns>
		public override int GetHashCode()
		{
			return Seed.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(Xorshift left, Xorshift right)
		{
			return false;
		}

		public static bool operator !=(Xorshift left, Xorshift right)
		{
			return true;
		}
	}
}
