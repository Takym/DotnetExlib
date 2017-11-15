using System.Collections.Generic;
using DotnetExlib.Properties;

namespace DotnetExlib.IO.Database
{
	/// <summary>
	///  データベースの一つのノードを表します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public interface INode
	{
		/// <summary>
		///  このノードの名前です。ファイル名に利用できない文字は使用しないでください。
		/// </summary>
		string Name { get; set; }

		/// <summary>
		///  このノードの値です。この<see cref="byte"/>配列の値は、継承したクラスまたは構造体が解析します。
		/// </summary>
		byte[] Value { get; set; }

		/// <summary>
		///  このノードの親ノードです。この値が<c>null</c>の場合、
		///  必ず<see cref="DotnetExlib.IO.Database.INode.IsRoot"/>の値は<c>true</c>になります。
		/// </summary>
		INode Parent { get; }

		/// <summary>
		///  このノードの子ノードを格納しているリストオブジェクトです。
		/// </summary>
		IList<INode> Children { get; }

		/// <summary>
		///  このノードがルートノードの場合は<c>true</c>、それ以外は<c>false</c>です。
		///  このプロパティを継承する場合、必ず<c>this.Parent == null</c>の値を返すようにしてください。
		/// </summary>
		bool IsRoot { get; }

		/// <summary>
		///  このノードの親ノードを設定します。
		///  <c>null</c>値を利用する事でルートノードに設定する事ができます。
		/// </summary>
		/// <param name="parent">親ノードにしたいオブジェクトです。</param>
		void SetParent(INode parent);

		/// <summary>
		///  このノードをディスク上に保存する時の拡張子を返します。
		/// </summary>
		/// <returns><c>".xxx"</c>形式の拡張子です。</returns>
		string GetTypeExtension();
	}
}
