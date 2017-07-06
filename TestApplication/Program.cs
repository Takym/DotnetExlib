//#define NO_DEV_CHECK // 開発者情報チェックプログラムを実行しない場合はNO_DEV_CHECKを宣言

using System;
using System.Collections.Generic;
using System.Reflection;
using DotnetExlib.Properties;

namespace TestApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			// バージョン情報表示
			CurrentVersion.ShowInConsole();
			CurrentVersion.ShowInConsole(typeof(Program).Assembly);
			Console.ReadLine();

			#region 開発者情報に不正が存在しないかチェック
#if !NO_DEV_CHECK
			Console.WriteLine("開発者情報のチェック");

			try {
				List<(string name, string copyright)> devs = new List<(string name, string copyright)>();
				List<(string name, string copyright)> devs2 = new List<(string name, string copyright)>();
				Assembly asm = typeof(CurrentVersion).Assembly;
				List<LicenseKind> dev_lic = new List<LicenseKind>();

				foreach (var dev_class in asm.GetTypes()) {
					// <PrivateImplementationDetails>を除外
					if (dev_class.Name == "<PrivateImplementationDetails>") continue;
					// このループで全てのクラスから、開発者情報を取得する。
					foreach (var dev_class_author in AuthorAttribute.GetAuthors(dev_class)) {
						// もし、おかしなライセンスだったら
						if (dev_class_author.License == LicenseKind.Developer) {
							throw new Exception(
								"開発者情報チェックでエラーが発生しました。ライセンスがdeveloperになっています。クラス："
								+ dev_class.ToString());
						}
						dev_lic.Add(dev_class_author.License);
						// 同じ人を追加しない様にする。
						if (!devs.Contains((dev_class_author.Name, dev_class_author.Copyright))) {
							devs.Add((dev_class_author.Name, dev_class_author.Copyright));
						}
					}
					// ライセンスが重複していないか？
					bool a = true;
					LicenseKind lk = dev_lic?[0] == null ? LicenseKind.NoLicense : dev_lic[0];
					foreach (var dev_lic_item in dev_lic) {
						a &= lk == dev_lic_item;
					}
					// もし、重複していたらエラー。
					if (!a) {
						throw new Exception(
							"開発者情報チェックでエラーが発生しました。ライセンスが重複しています。クラス："
							+ dev_class.ToString());
					}
					dev_lic.Clear();
				}

				foreach (var dev_item in AuthorAttribute.GetAuthors(asm)) {
					if (!devs.Contains((dev_item.Name, dev_item.Copyright))) {
						throw new Exception(
							"開発者情報チェックでエラーが発生しました。開発者情報がクラスに存在しません。開発者："
							+ dev_item.Name);
					} else {
						devs2.Add((dev_item.Name, dev_item.Copyright));
					}

					if (dev_item.License != LicenseKind.Developer) {
						throw new Exception(
							"開発者情報チェックでエラーが発生しました。ライセンス設定が不正です。開発者："
							+ dev_item.Name);
					}
				}

				foreach (var dev_item in devs) {
					if (!devs2.Contains(dev_item)) {
						throw new Exception(
							"開発者情報チェックでエラーが発生しました。開発者情報がAssemblyInfo.csに存在しません。開発者："
							+ dev_item.name);
					}
				}

				Console.WriteLine("正常。");
			} catch (Exception error) {
				Console.WriteLine(error.ToString());
			}

			Console.WriteLine("--------------------------------\n\n");
			Console.ReadLine();
#endif
			#endregion
		}
	}
}
