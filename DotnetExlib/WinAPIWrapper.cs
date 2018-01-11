using System;
using System.Runtime.InteropServices;
using System.Text;
using DotnetExlib.Properties;

namespace DotnetExlib
{
	/// <summary>
	///  WindowsのネイティブのAPIを呼び出します。
	///  このクラスは静的クラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.NoLicense)]
	public static class WinAPIWrapper
	{
		/// <summary>
		///  <see langword="kernel32.dll" />内のAPIを呼び出します。
		/// </summary>
		[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.NoLicense)]
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

		/// <summary>
		///  <see langword="shell32.dll" />内のAPIを呼び出します。
		/// </summary>
		[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.NoLicense)]
		public static class Shell32
		{
			/// <summary>
			///  このラッパーが参照しているDLLファイルへのファイルパスです。
			/// </summary>
			public const string LibraryPath = @"C:\WINDOWS\system32\SHELL32.DLL";

			[DllImport(LibraryPath)]
			public static extern IntPtr ExtractIcon(
				IntPtr hInst,
				[MarshalAs(UnmanagedType.LPTStr)] string lpszExeFileName,
				uint nIconIndex);

			[DllImport(LibraryPath)]
			public static extern uint ExtractIconEx(
				[MarshalAs(UnmanagedType.LPTStr)] string lpszFile,
				int nIconIndex,
				out IntPtr phiconLarge,
				out IntPtr phiconSmall,
				uint nIcons);
		}

		/// <summary>
		///  <see langword="user32.dll" />内のAPIを呼び出します。
		/// </summary>
		[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
		public static class User32
		{
			/// <summary>
			///  このラッパーが参照しているDLLファイルへのファイルパスです。
			/// </summary>
			public const string LibraryPath = @"C:\WINDOWS\system32\USER32.DLL";

			[DllImport(LibraryPath)]
			public static extern bool DestroyIcon(
				IntPtr hIcon);
		}
	}
}
