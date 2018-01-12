using System.Drawing;
using DotnetExlib.Properties;

namespace DotnetExlib.Graphics.Shapes
{
	/// <summary>
	///  図形を描画するために必要な機能を提供する、抽象クラスです。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public abstract class DrawerBase : Picture
	{
		public virtual Point Location { get; set; }

		public virtual Point[] Points { get; }
	}
}
