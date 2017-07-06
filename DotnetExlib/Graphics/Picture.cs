using System;
using System.Drawing;
using DotnetExlib.Properties;

namespace DotnetExlib.Graphics
{
	/// <summary>
	///  画像を表すオブジェクトです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public abstract class Picture : IDisposable, ICloneable
	{
		/// <summary>
		///  現在のオブジェクトが破棄されている場合は<c>true</c>、されていない場合は<c>false</c>です。
		/// </summary>
		protected bool IsDisposed { get; private set; }

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
		public Picture()
		{
			this.IsDisposed = false;
		}

		/// <summary>
		///  このクラスのデストラクタです。
		/// </summary>
		~Picture()
		{
			this.Dispose(false);
		}

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
		///  現在のオブジェクトの全てのリソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		///  現在のオブジェクトのリソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージドオブジェクトを解放するかどうかです。</param>
		protected virtual void Dispose(bool disposing)
		{
			this.IsDisposed = true;
		}

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
