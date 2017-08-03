﻿using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  疑似乱数生成器の標準的な機能を提供します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public interface IRandom
	{
		/// <summary>
		///  このインスタンスのシード値です。
		/// </summary>
		ulong Seed { get; }

		/// <summary>
		///  新しいシード値を設定します。
		/// </summary>
		/// <param name="seed">設定するシード値です。</param>
		void SetSeed(ulong seed);

		/// <summary>
		///  シード値を初期値に戻します。
		/// </summary>
		void ResetSeed();

		/// <summary>
		///  64ビット符号無し整数の乱数を生成します。
		/// </summary>
		/// <returns>生成された型'<see cref="System.UInt64"/>'の値です。</returns>
		ulong NextUInt64();

		/// <summary>
		///  64ビット符号無し整数の設定された最大値未満の乱数を生成します。
		/// </summary>
		/// <param name="maxValue">乱数の最大値です。</param>
		/// <returns>生成された型'<see cref="System.UInt64"/>'の値です。</returns>
		ulong NextUInt64(ulong maxValue);

		/// <summary>
		///  64ビット符号無し整数の設定された最小値以上で最大値未満の乱数を生成します。
		/// </summary>
		/// <param name="minValue">乱数の最小値です。</param>
		/// <param name="maxValue">乱数の最大値です。</param>
		/// <returns>生成された型'<see cref="System.UInt64"/>'の値です。</returns>
		ulong NextUInt64(ulong minValue, ulong maxValue);

		/// <summary>
		///  0～1の間の乱数を生成します。
		/// </summary>
		/// <returns>生成された型'<see cref="System.Double"/>'の値です。</returns>
		double NextDouble();
	}
}
