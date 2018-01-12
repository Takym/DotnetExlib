using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetExlib.Properties;

namespace DotnetExlib.Yastopy
{
	/// <summary>
	///  コピーに関する設定データを管理します。
	/// </summary>
	[Author("Takym", copyright: "Copyright (C) 2017 Takym.")]
	public class CopySettings
	{
		/* Link File Settings */

		/// <summary>
		///  ジャンクションの処理方法を設定します。
		/// </summary>
		public LinkFileProcessing EnableJunctionCopying { get; set; }

		/// <summary>
		///  シンボリックリンクの処理方法を設定します。
		/// </summary>
		public LinkFileProcessing EnableSymbolicLinkCopying { get; set; }

		/// <summary>
		///  ハードリンクの処理方法を設定します。
		/// </summary>
		public LinkFileProcessing EnableHardLinkCopying { get; set; }

		/// <summary>
		///  ショートカットの処理方法を設定します。
		/// </summary>
		public LinkFileProcessing EnableShortcutCopying { get; set; }

		/// <summary>
		///  <see cref="DotnetExlib.Yastopy.LinkFileProcessing.CopyWithoutExclusion"/>が指定されている場合の、
		///  除外するファイルのフィルターを指定します。
		/// </summary>
		public string ExclusionLinkFilter { get; set; }

		/// <summary>
		///  <see cref="DotnetExlib.Yastopy.LinkFileProcessing.CopyWithoutExclusion"/>が指定されている場合の、
		///  <see langword="Yastopy" />専用のリンクファイルに変換するファイルのフィルターを指定します。
		/// </summary>
		public string DedicatedLinkFilter { get; set; }
	}
}
