﻿using System;
using System.Security;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  コンソールに関する便利な機能を提供するクラスです。
	///  このクラスは静的クラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public static class ConsoleUtils
	{
		/// <summary>
		///  何かキーを押されるまで、プログラムの実行を一時停止します。
		/// </summary>
		public static void Pause()
		{
			Console.Write("続行するには何かキーを押してください . . . ");
			Console.ReadKey(true);
			Console.WriteLine();
		}

		/// <summary>
		///  コンソール画面からパスワードの入力を受け付けます。
		/// </summary>
		/// <returns>
		///  入力されたパスワードを保持する、型'<see cref="System.Security.SecureString"/>'の値です。
		/// </returns>
		public static SecureString ReadPassword()
		{
			SecureString result = new SecureString();

			while (true) {
				ConsoleKeyInfo cki = Console.ReadKey(true);
				if (cki.Key == ConsoleKey.Enter) {
					break;
				} else if (cki.Key == ConsoleKey.Backspace) {
					int i = result.Length - 1;
					if (i >= 0) {
						result.RemoveAt(i);
					}
				} else if (cki.KeyChar != '\u0000') {
					result.AppendChar(cki.KeyChar);
				}
			}

			Console.WriteLine();
			return result;
		}
	}
}
