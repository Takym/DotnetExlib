using System.Runtime.InteropServices;
using System.Text;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  WindowsのネイティブのAPIを呼び出します。
	///  このクラスは静的クラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public static class WinAPIWrapper
	{
		/// <summary>
		///  <c>kernel32.dll</c>内のAPIを呼び出します。
		/// </summary>
		[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
		public static class Kernel32
		{
			/// <summary>
			///  このラッパーが参照しているDLLファイルへのファイルパスです。
			/// </summary>
			public const string LibraryPath = @"C:\WINDOWS\system32\KERNEL32.DLL";

			[DllImport(LibraryPath)]
			public static extern uint GetPrivateProfileString(
				string lpAppName,
				string lpKeyName,
				string lpDefault,
				StringBuilder lpReturnedString,
				uint nSize,
				string lpFileName);

			[DllImport(LibraryPath)]
			public static extern uint GetPrivateProfileInt(
				string lpAppName,
				string lpKeyName,
				int nDefault,
				string lpFileName);

			[DllImport(LibraryPath)]
			public static extern uint WritePrivateProfileString(
				string lpAppName,
				string lpKeyName,
				string lpString,
				string lpFileName);
		}
	}
}
