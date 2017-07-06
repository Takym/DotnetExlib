using System.Drawing;
using DotnetExlib.Properties;

namespace DotnetExlib.Graphics
{
	/// <summary>
	///  <see cref="System.Drawing.Image"/>クラスを<see cref="DotnetExlib.Graphics.Picture"/>にラップするクラスです。
	///  このクラスは継承できません。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public sealed class ImageWrapper : Picture
	{
		private Image _img;

		/// <summary>
		///  ラップする<see cref="System.Drawing.Image"/>オブジェクトを指定して、
		///  新しいインスタンスを生成します。
		/// </summary>
		/// <param name="img">ラップする<see cref="System.Drawing.Image"/>オブジェクトです。</param>
		public ImageWrapper(Image img)
		{
			_img = img;
		}

		/// <summary>
		///  ラップしている画像の大きさです。
		/// </summary>
		public override Size Size
		{
			get
			{
				return _img.Size;
			}
		}

		/// <summary>
		///  このオブジェクトがラップしている<see cref="System.Drawing.Image"/>オブジェクトを返します。
		/// </summary>
		/// <returns>このオブジェクトがラップしている<see cref="System.Drawing.Image"/>オブジェクトです。</returns>
		public override Image ToImage()
		{
			return _img;
		}

		/// <summary>
		///  このオブジェクトのコピーを作成します。
		/// </summary>
		/// <returns>作成されたコピーです。</returns>
		public override object Clone()
		{
			return new ImageWrapper(_img.Clone() as Image);
		}

		/// <summary>
		///  現在のオブジェクトのリソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージドオブジェクトを解放するかどうかです。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				_img.Dispose();
			}

			base.Dispose(disposing);
		}

		/// <summary>
		///  <see cref="System.Drawing.Image"/>を<see cref="DotnetExlib.Graphics.ImageWrapper"/>にキャストする機能を提供します。
		/// </summary>
		/// <param name="obj">変換する<see cref="System.Drawing.Image"/>です。</param>
		public static implicit operator ImageWrapper(Image obj)
		{
			return new ImageWrapper(obj);
		}
	}
}
