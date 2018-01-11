using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DotnetExlib.IO
{
	/// <summary>
	///  指定されたアイコンを読み込みます。
	/// </summary>
	public class IconLoader
	{
		/// <summary>
		///  読み込むアイコンのファイル名を取得または設定します。
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		///  アイコンインデックスを取得または設定します。
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		///  型'<see cref="DotnetExlib.IO.IconLoader"/>'の新しいインスタンスを生成します。
		/// </summary>
		public IconLoader() { }

		/// <summary>
		///  アイコンファイルを指定して、
		///  型'<see cref="DotnetExlib.IO.IconLoader"/>'の新しいインスタンスを生成します。
		/// </summary>
		/// <param name="filename">読み込むアイコンのファイル名です。</param>
		public IconLoader(string filename)
		{
			this.FileName = filename;
		}

		/// <summary>
		///  アイコンファイルとアイコンインデックスを指定して、
		///  型'<see cref="DotnetExlib.IO.IconLoader"/>'の新しいインスタンスを生成します。
		/// </summary>
		/// <param name="filename">読み込むアイコンのファイル名です。</param>
		/// <param name="index">読み込むアイコンのアイコンインデックスです。</param>
		public IconLoader(string filename, int index)
		{
			this.FileName = filename;
			this.Index = index;
		}

		/// <summary>
		///  指定したファイル名とアイコンインデックスからアイコンを取得します。
		/// </summary>
		/// <param name="large">取得した大きいアイコンです。</param>
		/// <param name="small">取得した小さいアイコンです。</param>
		public void GetIcons(out Icon large, out Icon small)
		{
			large = small = null;
			/*
			Module[] m = Assembly.GetEntryAssembly().GetModules();
			IntPtr hInst = Marshal.GetHINSTANCE(m[0]);
			IntPtr ico = WinAPIWrapper.Shell32.ExtractIcon(hInst, this.FileName, unchecked((uint)(this.Index)));
			large = small = ((Icon)(Icon.FromHandle(ico).Clone()));
			WinAPIWrapper.User32.DestroyIcon(ico);

			WinAPIWrapper.Shell32.ExtractIconEx(this.FileName, this.Index, out var hLarge, out var hSmall, 2);
			large = ((Icon)(Icon.FromHandle(hLarge).Clone()));
			small = ((Icon)(Icon.FromHandle(hSmall).Clone()));
			WinAPIWrapper.User32.DestroyIcon(hLarge);
			WinAPIWrapper.User32.DestroyIcon(hSmall);
			*/
		}

		/// <summary>
		///  指定したファイル名とアイコンインデックスから大きいアイコンを取得します。
		/// </summary>
		/// <returns>取得した大きいアイコンです。</returns>
		public Icon GetLargeIcon()
		{
			GetIcons(out var large, out var small);
			return large;
		}

		/// <summary>
		///  指定したファイル名とアイコンインデックスから小さいアイコンを取得します。
		/// </summary>
		/// <returns>取得した小さいアイコンです。</returns>
		public Icon GetSmallIcon()
		{
			GetIcons(out var large, out var small);
			return small;
		}
	}
}
