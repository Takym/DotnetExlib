using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DotnetExlib.IO
{
	/// <summary>
	///  アプリケーションのファイルパスを管理します。
	/// </summary>
	public static class FilePathManager
	{
		internal static readonly string TempDirectoryName;

		static FilePathManager()
		{
			TempDirectoryName = StringUtils.GetRandomText(
				8,
				32,
				Process.GetCurrentProcess().Id);
			Directory.CreateDirectory(TempDirectoryName);
		}

		/// <summary>
		///  指定された名前から一時ファイルを作成して、ファイル名とそのストリームを返します。
		/// </summary>
		/// <param name="place">一時ファイルの場所です。</param>
		/// <param name="name">一時ファイルの名前です。</param>
		/// <returns><see langword="FileName"/>は一時ファイル名、<see langword="Stream"/>はそのストリームです。</returns>
		public static (string FileName, FileStream Stream) GetTempFile(FilePlace place, string name)
		{
			string result;
			switch (place) {
				case FilePlace.System:
					result = Path.Combine(
						Environment.GetEnvironmentVariable(
							"Temp",
							EnvironmentVariableTarget.Machine),
						TempDirectoryName,
						name);
					break;
				case FilePlace.User:
					result = Path.Combine(
						Environment.GetEnvironmentVariable(
							"Temp",
							EnvironmentVariableTarget.Process),
						TempDirectoryName,
						name);
					break;
				case FilePlace.Application:
					result = Path.Combine(
						Application.StartupPath,
						"Temp",
						TempDirectoryName,
						name);
					break;
				case FilePlace.CurrentDirectory:
					result = Path.Combine(
						Environment.CurrentDirectory,
						".$Temp$",
						TempDirectoryName,
						name);
					break;
				default:
					throw new ArgumentException($"{place}は不正な値です。");
			}

			Directory.CreateDirectory(Path.GetDirectoryName(result));
			return (result, new FileStream(result, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None));
		}

		/// <summary>
		///  指定したドキュメントの名前から、ドキュメントのファイル名を返します。
		///  <see cref="DotnetExlib.IO.FilePlace"/>を指定する事はできません。
		/// </summary>
		/// <param name="name">ドキュメントの名前です。</param>
		/// <returns>指定したドキュメントの絶対パスです。</returns>
		public static string GetDocumentPath(string name)
		{
			return Path.Combine(Application.StartupPath, "HelpDocs", name);
		}
	}
}
