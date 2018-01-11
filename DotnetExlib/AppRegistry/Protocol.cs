using System;
using System.Collections.Generic;
using DotnetExlib.Properties;
using Microsoft.Win32;

namespace DotnetExlib.AppRegistry
{
	/// <summary>
	///  プロトコルを管理する為のクラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.MIT)]
	public class Protocol : DisposableBase, IExtensionRegistry
	{
		/// <summary>
		///  変更するプロトコルです。文字列の終端に<c>":"</c>を付けません。
		/// </summary>
		public string Name { get; }

		/// <summary>
		///  プロトコルの説明です。
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		///  プロトコルアイコンのファイルパスです。
		/// </summary>
		public string IconPath { get; set; }

		/// <summary>
		///  アイコンインデックスです。
		/// </summary>
		public int IconIndex { get; set; } = -1;

		/// <summary>
		///  プロトコルの動詞の一覧です。
		/// </summary>
		public IDictionary<string, (string Command, string Description)> Verbs { get; }

		private RegistryKey _key_b, _key_ico, _key_shell;

		/// <summary>
		///  操作するプロトコルを指定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="prot">変更するプロトコルです。文字列の終端に<c>":"</c>を付けません。</param>
		public Protocol(string prot) : base()
		{
			this.Name = prot;
			this.Verbs = new Dictionary<string, (string Command, string Description)>();

			using (var _key_a = Registry.ClassesRoot.CreateSubKey(@"PROTOCOLS\Handler\" + prot, true)) {
				this.Description = _key_a.GetValue("", "").ToString();
			}

			_key_b = Registry.ClassesRoot.CreateSubKey(prot, true);
			_key_ico = _key_b.CreateSubKey("DefaultIcon", true);
			_key_shell = _key_b.CreateSubKey("shell", true);

			this.Description = _key_b.GetValue(null, "").ToString();
			string[] icopath = _key_ico.GetValue(null, "").ToString().Split(',');
			this.IconPath = icopath[0];
			if (icopath.Length >= 2 &&
				int.TryParse(icopath[1].Trim(), out int i)) {
				this.IconIndex = i;
			}

			foreach (var item in _key_shell.GetValueNames()) {
				(string Command, string Description) val;
				using (var _key_c = _key_shell.CreateSubKey(item, true))
				using (var _key_d = _key_c.CreateSubKey("command", true)) {
					val.Description = _key_c.GetValue(null, "").ToString();
					val.Command = _key_d.GetValue(null, "").ToString();
				}
				this.Verbs.Add(item, val);
			}
		}

		/// <summary>
		///  現在のオブジェクトの内容をレジストリに保存します。
		/// </summary>
		public void Save()
		{
			if (this.IsDisposed) throw new ObjectDisposedException(nameof(FileExtension));

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
		///  このオブジェクトのインスタンスを破棄させます。
		/// </summary>
		/// <param name="disposing">
		///  このクラス内に存在する、他の<see cref="System.IDisposable"/>も破棄するかどうかです。
		/// </param>
		protected override void Dispose(bool disposing)
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

				base.Dispose(disposing);
			}
		}
	}
}
