using System.Collections.Generic;
using DotnetExlib.Properties;

namespace DotnetExlib.AppRegistry
{
	/// <summary>
	///  拡張子またはプロトコルを管理する機能を提供します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public interface IExtensionRegistry
	{
		/// <summary>
		///  変更する拡張子またはプロトコルを取得します。先頭に<c>"."</c>や文字列の終端に<c>":"</c>は付けません。
		/// </summary>
		string Name { get; }

		/// <summary>
		///  拡張子またはプロトコルの説明を取得または設定します。
		/// </summary>
		string Description { get; set; }

		/// <summary>
		///  ファイルアイコンのファイルパスを取得または設定します。
		/// </summary>
		string IconPath { get; set; }

		/// <summary>
		///  アイコンインデックスを取得または設定します。
		/// </summary>
		int IconIndex { get; set; }

		/// <summary>
		///  拡張子またはプロトコルの動詞を表す <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>
		///  型の辞書を取得します。
		/// </summary>
		IDictionary<string, (string Command, string Description)> Verbs { get; }

		/// <summary>
		///  現在のオブジェクトの内容をレジストリに保存します。
		/// </summary>
		void Save();
	}
}
