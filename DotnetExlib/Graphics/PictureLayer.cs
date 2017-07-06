using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DotnetExlib.Properties;
using Grap = System.Drawing.Graphics;

namespace DotnetExlib.Graphics
{
	/// <summary>
	///  複数の画像のレイヤーです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class PictureLayer : Picture, IList<Picture>
	{
		/// <summary>
		///  このオブジェクトに格納されている全ての画像です。
		/// </summary>
		public List<Picture> Items { get; private set; }

		/// <summary>
		///  この画像の大きさです。
		/// </summary>
		public override Size Size
		{
			get
			{
				return _size;
			}
		}
		private Size _size;

		/// <summary>
		///  <see cref="DotnetExlib.Graphics.PictureLayer"/>の新しいインスタンスを生成します。
		/// </summary>
		public PictureLayer()
		{
			this.Items = new List<Picture>();
			_size = new Size(600, 800);
		}

		/// <summary>
		///  このオブジェクトに格納されている全ての画像を重ねた画像を返します。
		/// </summary>
		/// <returns>重ねた後の<see cref="System.Drawing.Image"/>です。</returns>
		public override Image ToImage()
		{
			Image result = new Bitmap(_size.Width, _size.Height);
			using (Grap g = Grap.FromImage(result)) {
				foreach (var img in this.Items) {
					g.DrawImage(img.ToImage(), 0, 0);
				}
			}
			return result;
		}

		/// <summary>
		///  現在のオブジェクトのコピーを作成します。
		/// </summary>
		/// <returns>現在のオブジェクトのコピーです。</returns>
		public override object Clone()
		{
			PictureLayer result = new PictureLayer();
			result.Items = new List<Picture>(this.Items.ToArray());
			return result;
		}

		/// <summary>
		///  このオブジェクトに新しいサイズを設定します。
		/// </summary>
		/// <param name="size">設定するサイズです。</param>
		public void SetSize(Size size)
		{
			_size = size;
		}

		/// <summary>
		///  現在のオブジェクトのリソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージドオブジェクトを解放するかどうかです。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				foreach (var img in this.Items) {
					img.Dispose();
				}
			}

			this.Items.Clear();
			base.Dispose(disposing);
		}

		#region IList
		public Picture this[int index]
		{
			get
			{
				return ((IList<Picture>)Items)[index];
			}

			set
			{
				((IList<Picture>)Items)[index] = value;
			}
		}

		public int Count
		{
			get
			{
				return ((IList<Picture>)Items).Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IList<Picture>)Items).IsReadOnly;
			}
		}

		public void Add(Picture item)
		{
			((IList<Picture>)Items).Add(item);
		}

		public void Clear()
		{
			((IList<Picture>)Items).Clear();
		}

		public bool Contains(Picture item)
		{
			return ((IList<Picture>)Items).Contains(item);
		}

		public void CopyTo(Picture[] array, int arrayIndex)
		{
			((IList<Picture>)Items).CopyTo(array, arrayIndex);
		}

		public IEnumerator<Picture> GetEnumerator()
		{
			return ((IList<Picture>)Items).GetEnumerator();
		}

		public int IndexOf(Picture item)
		{
			return ((IList<Picture>)Items).IndexOf(item);
		}

		public void Insert(int index, Picture item)
		{
			((IList<Picture>)Items).Insert(index, item);
		}

		public bool Remove(Picture item)
		{
			return ((IList<Picture>)Items).Remove(item);
		}

		public void RemoveAt(int index)
		{
			((IList<Picture>)Items).RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IList<Picture>)Items).GetEnumerator();
		}
		#endregion
	}
}
