using System;
using System.Drawing;
using DotnetExlib.Properties;

namespace DotnetExlib.Graphics
{
	/// <summary>
	///  画像を表すオブジェクトです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.", license: LicenseKind.MIT)]
	public abstract class Picture : DisposableBase, ICloneable
	{
		/// <summary>
		///  この画像の大きさです。
		/// </summary>
		public virtual Size Size
		{
			get
			{
				return ToImage().Size;
			}
		}

		/// <summary>
		///  <see cref="DotnetExlib.Graphics.Picture"/>の新しいインスタンスを生成します。
		/// </summary>
		public Picture() : base() { }

		/// <summary>
		///  現在のオブジェクトを、<see cref="System.Drawing.Image"/>に変換します。
		/// </summary>
		/// <returns>変換後の<see cref="System.Drawing.Image"/>です。</returns>
		public abstract Image ToImage();

		/// <summary>
		///  現在のオブジェクトのコピーを作成します。
		/// </summary>
		/// <returns>現在のオブジェクトのコピーです。</returns>
		public abstract object Clone();

		/// <summary>
		///  <see cref="DotnetExlib.Graphics.Picture"/>を<see cref="System.Drawing.Image"/>にキャストする機能を提供します。
		/// </summary>
		/// <param name="obj">変換する<see cref="DotnetExlib.Graphics.Picture"/>です。</param>
		public static implicit operator Image(Picture obj)
		{
			return obj.ToImage();
		}
	}
}
