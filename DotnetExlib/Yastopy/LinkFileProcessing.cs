namespace DotnetExlib.Yastopy
{
	/// <summary>
	///  リンクファイルの処理方法を指定します。
	/// </summary>
	public enum LinkFileProcessing
	{
		/// <summary>
		///  リンクファイルはコピーしません。
		/// </summary>
		Ignore,

		/// <summary>
		///  リンク先のファイルパスをテキストファイルに保存します。
		/// </summary>
		SaveLinkTargetPath,

		/// <summary>
		///  <see langword="Yastopy" />専用のリンクファイルに変換します。
		/// </summary>
		SaveYastopyShortcut,

		/// <summary>
		///  そのままのリンク形式でコピーします。
		/// </summary>
		CopyAsLink,

		/// <summary>
		///  リンクの内容を全てコピーします。この処理は時間がかかります。
		/// </summary>
		CopyAll,

		/// <summary>
		///  <see cref="DotnetExlib.Yastopy.CopySettings.ExclusionLinkFilter"/>で指定されているフィルターにマッチするファイルは、
		///  そのままのリンク形式にして、それ以外のリンクの内容は全てコピーします。
		///  <see cref="DotnetExlib.Yastopy.CopySettings.DedicatedLinkFilter"/>で指定されているフィルターにマッチするファイルは、
		///  <see langword="Yastopy" />専用のリンクファイルに変換します。
		/// </summary>
		CopyWithoutExclusion,
	}
}
