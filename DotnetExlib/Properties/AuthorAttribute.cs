using System;
using System.Collections.Generic;

namespace DotnetExlib.Properties
{
	/// <summary>
	///  アセンブリと型(クラス、構造体、列挙型、インターフェース、またはデリゲート)に、
	///  開発者情報を指定できる属性です。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	[AttributeUsage(Targets, AllowMultiple = true, Inherited = false)]
	public class AuthorAttribute : Attribute
	{
		/// <summary>
		///  この属性を適用する事ができるアプリケーション要素です。
		/// </summary>
		public const AttributeTargets Targets
			= AttributeTargets.Assembly
			| AttributeTargets.Class
			| AttributeTargets.Struct
			| AttributeTargets.Enum
			| AttributeTargets.Interface
			| AttributeTargets.Delegate;

		/// <summary>
		///  開発者の名前です。
		/// </summary>
		public string Name { get; }

		/// <summary>
		///  著作権情報です。
		/// </summary>
		public string Copyright { get; }

		/// <summary>
		///  プログラムのライセンスです。
		/// </summary>
		public string License { get; }

		/// <summary>
		///  開発者情報を指定して、新しいインスタンスを生成します。
		/// </summary>
		/// <param name="name">開発者の名前です。</param>
		/// <param name="copyright">著作権情報です。省略できます。</param>
		/// <param name="license">プログラムのライセンスです。限定値は、<c>"LGPLv3"</c>です。</param>
		public AuthorAttribute(string name, string copyright = "", string license = "LGPLv3")
		{
			this.Name = name;
			this.Copyright = copyright;
			this.License = license;
		}

		/// <summary>
		///  指定した型から開発者情報を全て取得します。
		/// </summary>
		/// <param name="type">取得元の型です。</param>
		/// <returns>
		///  開発者情報を表す型'<see cref="DotnetExlib.Properties.AuthorAttribute"/>'の配列です。
		/// </returns>
		public static AuthorAttribute[] GetAuthors(Type type)
		{
			Attribute[] attrs = GetCustomAttributes(type);
			List<AuthorAttribute> result = new List<AuthorAttribute>();
			foreach (var item in attrs) {
				if (item is AuthorAttribute val) {
					result.Add(val);
				}
			}
			return result.ToArray();
		}
	}
}
