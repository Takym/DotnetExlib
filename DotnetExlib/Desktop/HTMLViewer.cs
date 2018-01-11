using System;
using System.IO;
using System.Windows.Forms;

namespace DotnetExlib.Desktop
{
	/// <summary>
	///  HTMLページをユーザーに対して表示します。
	/// </summary>
	public partial class HTMLViewer : Form
	{
		private string _first_url;
		private string _first_title;

		/// <summary>
		///  表示したいHTMLファイルのURLを指定して、
		///  新しいインスタンスを生成します。
		/// </summary>
		/// <param name="firstURL">表示するHTMLファイルのアドレスです。</param>
		public HTMLViewer(string firstURL)
		{
			InitializeComponent();
			_first_url = firstURL;
		}

		private void HTMLViewer_Load(object sender, EventArgs e)
		{
			_first_title = this.Text;
			webBrowser1.Navigate(_first_url);
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.Text = $"{_first_title} - [{webBrowser1.DocumentTitle}]";
		}
	}
}
