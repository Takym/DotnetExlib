using DotnetExlib.Properties;

namespace DotnetExlib.IO
{
	/// <summary>
	///  ファイルの場所を表します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public enum FilePlace
	{
		/// <summary>
		///  システムディレクトリです。
		/// </summary>
		System,

		/// <summary>
		///  現在のユーザーのディレクトリです。
		/// </summary>
		User,

		/// <summary>
		///  現在、実行しているアプリケーションが置かれているディレクトリです。
		/// </summary>
		Application,

		/// <summary>
		///  現在の作業ディレクトリです。
		/// </summary>
		CurrentDirectory,
	}
}
