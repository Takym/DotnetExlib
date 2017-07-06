using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DotnetExlib.Properties
{
	/// <summary>
	///  アセンブリからバージョン情報を読み取ります。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public static class CurrentVersion
	{
		/// <summary>
		///  エディションコードの一覧です。
		/// </summary>
		public const string EditionCodes = "試αβγδεζθιηκλμνξοπρστυφχψω◎☆";

		/// <summary>
		///  このアセンブリの構成情報です。
		/// </summary>
		#region Platform Configuration Settings
#if Debug && AnyCPU
		public const string Configuration = "Debug/AnyCPU";
#elif Debug && _32Bit
		public const string Configuration = "Debug/_32Bit";
#elif Debug && _64Bit
		public const string Configuration = "Debug/_64Bit";
#elif Release && AnyCPU
		public const string Configuration = "Release/AnyCPU";
#elif Release && _32Bit
		public const string Configuration = "Release/_32Bit";
#elif Release && _64Bit
		public const string Configuration = "Release/_64Bit";
#elif Debug
		public const string Configuration = "Debug/Unknown";
#elif Release
		public const string Configuration = "Release/Unknown";
#elif AnyCPU
		public const string Configuration = "Unknown/AnyCPU";
#elif _32Bit
		public const string Configuration = "Unknown/_32Bit";
#elif _64Bit
		public const string Configuration = "Unknown/_64Bit";
#else
		public const string Configuration = "Unknown/Unknown";
#endif
		#endregion

		/// <summary>
		///  このライブラリのバージョン情報を文字列形式で取得します。
		/// </summary>
		/// <returns>
		///  このライブラリのアセンブリ情報から生成された、
		///  バージョン情報の文字列形式です。
		/// </returns>
		public static string GetAbout()
		{
			return GetAbout(typeof(CurrentVersion).Assembly);
		}

		/// <summary>
		///  指定したアセンブリからバージョン情報を文字列形式で取得します。
		/// </summary>
		/// <param name="asm">バージョン情報を取得するアセンブリです。</param>
		/// <returns>
		///  指定したアセンブリ情報から生成された、
		///  バージョン情報の文字列形式です。
		/// </returns>
		public static string GetAbout(Assembly asm)
		{
			StringBuilder result = new StringBuilder();
			Version asm_ver = asm.GetName().Version;
			Version file_ver;
			bool success = Version.TryParse(
				asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version,
				out file_ver);

			result.AppendFormat("{0}\n{1}\n--------------------------------\n",
				asm.GetCustomAttribute<AssemblyTitleAttribute>()?.Title,
				asm.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright);

			result.AppendFormat("Name            : {0}\n",
				asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product);

			result.AppendFormat("AssemblyVersion : {0}\n", asm_ver.ToString(4));

			if (success) {
				if (file_ver.Major >= 256 || file_ver.Minor >= 256 || file_ver.Build >= 256 || file_ver.Revision >= 256) {
					result.AppendFormat("FileVersion     : WRONG:{0}\n",
						file_ver.ToString(4));
				} else {
					int i = file_ver.Revision / 10;
					int j = file_ver.Revision - i * 10;
					if (i == 25 && j == 5) {
						i = 26;
						j = 0;
					}
					result.AppendFormat("FileVersion     : {0}/{1}{2}\n",
						file_ver.ToString(3),
						EditionCodes[i],
						j == 0 ? "" : j.ToString());
				}
			} else {
				result.AppendFormat("FileVersion     : WRONG_VERSION\n");
			}

			result.AppendFormat("CodeName        : {0}\n",
				asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);

			result.AppendFormat("Config          : {0}\n",
				asm.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration);

			result.AppendFormat("Comment         : {0}\n",
				asm.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description);

			result.AppendFormat("--------------------------------\n\n");

			return result.ToString();
		}



		/// <summary>
		///  このライブラリのアセンブリ情報を、標準入出力ストリーム(コンソール)に出力します。
		/// </summary>
		public static void ShowInConsole()
		{
			Console.WriteLine(GetAbout(typeof(CurrentVersion).Assembly));
		}

		/// <summary>
		///  このライブラリのアセンブリ情報を、デバッグ用の出力ストリームに出力します。
		/// </summary>
		[Conditional("DEBUG")]
		public static void ShowInDebug()
		{
			Debug.WriteLine(GetAbout(typeof(CurrentVersion).Assembly));
		}

		/// <summary>
		///  このライブラリのアセンブリ情報を、メッセージボックスに表示させます。
		/// </summary>
		/// <param name="onwer">表示するメッセージボックスの親ウィンドウです。</param>
		/// <param name="title">
		///  表示するメッセージボックスのウィンドウタイトルです。
		///  限定値は、<c>"About"</c>です。
		/// </param>
		public static void ShowInMessageBox(IWin32Window onwer, string title = "About")
		{
			MessageBox.Show(onwer, GetAbout(typeof(CurrentVersion).Assembly), title);
		}

		/// <summary>
		///  指定したアセンブリのバージョン情報を、標準入出力ストリーム(コンソール)に出力します。
		/// </summary>
		/// <param name="asm">バージョン情報を取得するアセンブリです。</param>
		public static void ShowInConsole(Assembly asm)
		{
			Console.WriteLine(GetAbout(asm));
		}

		/// <summary>
		///  指定したアセンブリのバージョン情報を、デバッグ用の出力ストリームに出力します。
		/// </summary>
		/// <param name="asm">バージョン情報を取得するアセンブリです。</param>
		[Conditional("DEBUG")]
		public static void ShowInDebug(Assembly asm)
		{
			Debug.WriteLine(GetAbout(asm));
		}

		/// <summary>
		///  指定したアセンブリのバージョン情報を、メッセージボックスに表示させます。
		/// </summary>
		/// <param name="asm">バージョン情報を取得するアセンブリです。</param>
		/// <param name="onwer">表示するメッセージボックスの親ウィンドウです。</param>
		/// <param name="title">
		///  表示するメッセージボックスのウィンドウタイトルです。
		///  限定値は、<c>"About"</c>です。
		/// </param>
		public static void ShowInMessageBox(Assembly asm, IWin32Window onwer, string title = "About")
		{
			MessageBox.Show(onwer, GetAbout(asm), title);
		}
	}
}
