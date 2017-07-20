using System.Collections.Generic;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/>クラスの拡張メソッドと便利関数を提供します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public static class DictionaryExtension
	{
		/// <summary>
		///  <see cref="System.Collections.Generic.KeyValuePair{TKey, TValue}"/>クラスをキーと値に分解します。
		/// </summary>
		/// <typeparam name="TKey">キーの型です。</typeparam>
		/// <typeparam name="TValue">値の型です。</typeparam>
		/// <param name="kvp">分解前のオブジェクトです。</param>
		/// <param name="key">分解後のキーです。</param>
		/// <param name="value">分解後の値です。</param>
		public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
		{
			key = kvp.Key;
			value = kvp.Value;
		}
	}
}
