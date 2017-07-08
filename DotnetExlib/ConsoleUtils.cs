using System;
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
		}
	}
}
