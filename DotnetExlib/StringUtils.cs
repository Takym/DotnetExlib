using System;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  <see cref="string"/>クラスの拡張メソッドを提供します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public static class StringUtils
	{
		/// <summary>
		///  キャリッジリターン<c>('\r')</c>をラインフィード<c>('\n')</c>に変換します。
		///  <c>"\r\n"</c>や<c>"\n\r"</c>は、<c>'\n'</c>に変換されます。
		/// </summary>
		/// <param name="text">変換対象の文字列です。</param>
		/// <returns>変換結果の文字列です。</returns>
		public static string CRtoLF(this string text)
		{
			return text.Replace("\r\n", "\n").Replace("\n\r", "\n").Replace("\r", "\n");
		}

		/// <summary>
		///  ラインフィード<c>('\n')</c>をキャリッジリターン<c>('\r')</c>に変換します。
		///  <c>"\r\n"</c>や<c>"\n\r"</c>は、<c>'\r'</c>に変換されます。
		/// </summary>
		/// <param name="text">変換対象の文字列です。</param>
		/// <returns>変換結果の文字列です。</returns>
		public static string LFtoCR(this string text)
		{
			return text.Replace("\r\n", "\r").Replace("\n\r", "\r").Replace("\n", "\r");
		}

		/// <summary>
		///  指定した文字列をブール値に変換します。
		/// </summary>
		/// <param name="s">変換対象の文字列です。</param>
		/// <returns>変換結果のブール値です。</returns>
		/// <exception cref="System.ArgumentException"/>
		public static bool ToBoolean(this string s)
		{
			if (s.TryToBoolean(out var result)) {
				return result;
			} else {
				throw new ArgumentException("指定した文字列はブール値に変換できません。", nameof(s));
			}
		}

		/// <summary>
		///  指定した文字列をブール値に変換できるかどうか試します。
		///  変換結果は<paramref name="result"/>に保持されます。
		/// </summary>
		/// <param name="s">変換対象の文字列です。</param>
		/// <param name="result">変換結果のブール値です。</param>
		/// <returns>
		///  変換に成功した場合は<c>true</c>、失敗した場合は<c>false</c>です。
		/// </returns>
		public static bool TryToBoolean(this string s, out bool result)
		{
			string text = s.ToLower();
			switch (text) {
				case "true":
				case "yes":
				case "on":
				case "pos":
				case "positive":
					result = true;
					return true;
				case "false":
				case "no":
				case "off":
				case "neg":
				case "negative":
					result = false;
					return true;
				default:
					result = false;
					return false;
			}
		}

		/// <summary>
		///  "<c>0-9,a-z,A-Z</c>"と"<c>!#$%&amp;'()-=^~@`[{]};+,._</c>"をランダムに並べた文字列を生成します。
		///  文字数は8-64の間で生成されます。生成された文字列はファイル名に使用できます。
		/// </summary>
		/// <returns>生成された文字列です。</returns>
		public static string GetRandomText()
		{
			return GetRandomText(8, 64, Environment.TickCount);
		}

		/// <summary>
		///  "<c>0-9,a-z,A-Z</c>"と"<c>!#$%&amp;'()-=^~@`[{]};+,._</c>"をランダムに並べた文字列を生成します。
		///  指定した文字数で生成されます。生成された文字列はファイル名に使用できます。
		/// </summary>
		/// <param name="length">生成する文字列の文字数です。</param>
		/// <returns>生成された文字列です。</returns>
		public static string GetRandomText(int length)
		{
			return GetRandomText(length, length, Environment.TickCount);
		}

		/// <summary>
		///  "<c>0-9,a-z,A-Z</c>"と"<c>!#$%&amp;'()-=^~@`[{]};+,._</c>"をランダムに並べた文字列を生成します。
		///  生成された文字列はファイル名に使用できます。
		/// </summary>
		/// <param name="min">文字数の最小です。</param>
		/// <param name="max">文字数の最大です。</param>
		/// <returns>生成された文字列です。</returns>
		public static string GetRandomText(int min, int max)
		{
			return GetRandomText(min, max, Environment.TickCount);
		}

		/// <summary>
		///  <para>
		///   "<c>0-9,a-z,A-Z</c>"と"<c>!#$%&amp;'()-=^~@`[{]};+,._</c>"をランダムに並べた文字列を生成します。
		///   文字数は指定された範囲からランダムで決定します。生成された文字列はファイル名に使用できます。
		///  </para>
		///  <para>
		///   <example>
		///    <code>
		///     string s = DotnetExlib.StringUtils.GetRandomText(8, 8, 34187);
		///     // 's' is "kRgz5izo"
		///    </code>
		///   </example>
		///  </para>
		/// </summary>
		/// <param name="min">文字数の最小です。</param>
		/// <param name="max">文字数の最大です。</param>
		/// <param name="seed">シード値です。</param>
		/// <returns>生成された文字列です。</returns>
		public static string GetRandomText(int min, int max, int seed)
		{
			Xorshift r = new Xorshift(seed);
			int len = r.Next(min, max);
			string result = string.Empty;
			for (int i = 0; i < len; ++i) {
				result += c[r.Next(0, c.Length)];
			}
			return result;
		}
		const string c = "!#$0aAbBcCdDeEfF%&'gGhH1234()-=IiJjKkLlMmNnOoPp^~@[{]}5678qrstuv;+QRSTUV9WXYZwxyz,._";
	}
}
