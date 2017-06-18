using System;
using System.Collections.Generic;
using DotnetExlib.Properties;
using Microsoft.Win32;

namespace DotnetExlib.AppRegistry
{
	/// <summary>
	///  ファイル拡張子を管理する為のクラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.MIT)]
	public class FileExtension : IDisposable
	{
		/// <summary>
		///  変更する拡張子です。先頭に<c>"."</c>を付けません。
		/// </summary>
		public string Extension { get; }

		/// <summary>
		///  拡張子の説明です。エクスプローラの種類に表示される文字列です。
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		///  ファイルアイコンのファイルパスです。
		/// </summary>
		public string IconPath { get; set; }

		/// <summary>
		///  アイコンインデックスです。
		/// </summary>
		public int IconIndex = -1;

		/// <summary>
		///  拡張子の動詞の一覧です。
		/// </summary>
		public Dictionary<string, (string Command, string Description)> Verbs { get; }

		/// <summary>
		///  オブジェクトが破棄されているかどうかを取得します。
		/// </summary>
		protected bool IsDisposed { get; private set; }

		private RegistryKey _key_b, _key_ico, _key_shell;

		/// <summary>
		///  操作する拡張子を指定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="ext">変更する拡張子です。先頭に<c>"."</c>を付けません。</param>
		public FileExtension(string ext)
		{
			this.IsDisposed = false;
			this.Extension = ext;
			this.Verbs = new Dictionary<string, (string Command, string Description)>();

			using (var _key_a = Registry.ClassesRoot.CreateSubKey("." + ext, true)) {
				string _key_name = (string)(_key_a.GetValue(null, ext + "_auto_file"));
				_key_a.SetValue(null, _key_name);
				_key_b = Registry.ClassesRoot.CreateSubKey(_key_name, true);
				_key_ico = _key_b.CreateSubKey("DefaultIcon", true);
				_key_shell = _key_b.CreateSubKey("shell", true);
			}
		}

		/// <summary>
		///  現在のオブジェクトの内容をレジストリに保存します。
		/// </summary>
		public void Save()
		{
			if (IsDisposed) throw new ObjectDisposedException(nameof(FileExtension));

			_key_b.SetValue(null, this.Description);
			_key_ico.SetValue(null, $"\"{this.IconPath}\"" + (IconIndex >= 0 ? ", " + IconIndex : string.Empty));

			foreach (var item in this.Verbs) {
				using (var _key_c = _key_shell.CreateSubKey(item.Key, true))
				using (var _key_d = _key_c.CreateSubKey("command", true)) {
					_key_c.SetValue(null, item.Value.Description);
					_key_d.SetValue(null, item.Value.Command);
				}
			}
		}

		/// <summary>
		///  このオブジェクトのファイナライザーです。
		/// </summary>
		~FileExtension()
		{
			this.Dispose(false);
		}

		/// <summary>
		///  このオブジェクトで使用している全てのリソースを開放します。
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		///  このオブジェクトのインスタンスを破棄させます。
		/// </summary>
		/// <param name="disposing">
		///  このクラス内に存在する、他の<see cref="System.IDisposable"/>も破棄するかどうかです。
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!IsDisposed) {
				if (disposing) {
					_key_b.Close();
					_key_ico.Close();
					_key_shell.Close();
				}

				this.Description = null;
				this.IconPath = null;
				IconIndex = 0;
				this.Verbs.Clear();

				IsDisposed = true;
			}
		}
	}
}
