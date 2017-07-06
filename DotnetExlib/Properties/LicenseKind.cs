namespace DotnetExlib.Properties
{
	/// <summary>
	///  ライセンスの種類を表します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public enum LicenseKind
	{
		/// <summary>
		///  ライセンスを指定しません。
		/// </summary>
		NoLicense,

		/// <summary>
		///  アセンブリに開発者の著作権情報を設定する為にこの値を利用します。
		///  この値はライセンス名ではありません。
		/// </summary>
		Developer,

		/// <summary>
		///  LGPLv3ライセンスです。
		/// </summary>
		LGPLv3,

		/// <summary>
		///  MITライセンスです。
		/// </summary>
		MIT
	}
}
