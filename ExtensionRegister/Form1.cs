using System;
using System.Drawing;
using System.Windows.Forms;
using DotnetExlib.AppRegistry;
using DotnetExlib.IO;

namespace ExtensionRegister
{
	public partial class Form1 : Form
	{
		private IconLoader _iconLoader;
		private readonly Icon _default_icon;

		public Form1()
		{
			InitializeComponent();
			_iconLoader = new IconLoader();
			_default_icon = this.Icon;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			label1         .TabIndex = 0;
			label2         .TabIndex = 0;
			label3         .TabIndex = 0;
			label4         .TabIndex = 0;
			label5         .TabIndex = 0;
			label6         .TabIndex = 0;
			label7         .TabIndex = 0;
			label8         .TabIndex = 0;
			rbExt          .TabIndex = 1;
			rbProt         .TabIndex = 2;
			name           .TabIndex = 3;
			description    .TabIndex = 4;
			iconpath       .TabIndex = 5;
			loadicon       .TabIndex = 6;
			iconindex      .TabIndex = 7;
			verbs          .TabIndex = 8;
			add            .TabIndex = 9;
			change         .TabIndex = 10;
			delete         .TabIndex = 11;
			cancel         .TabIndex = 12;
			load           .TabIndex = 13;
			save           .TabIndex = 14;
		}

		private void SetIcon()
		{
			try {
				_iconLoader.FileName = iconpath.Text;
				_iconLoader.Index = ((int)(iconindex.Value));

				icon.Image = _iconLoader.GetLargeIcon().ToBitmap();
				this.Icon = _iconLoader.GetSmallIcon();
			} catch {
				icon.Image = new Bitmap(48, 48);
				this.Icon = _default_icon;
			}
		}

		private void loadicon_Click(object sender, EventArgs e)
		{
			DialogResult dr = iconofd.ShowDialog();
			if (dr == DialogResult.OK) {
				iconpath.Text = iconofd.FileName;
			}
			SetIcon();
		}

		private void iconpath_TextChanged(object sender, EventArgs e)
		{
			SetIcon();
		}

		private void iconindex_ValueChanged(object sender, EventArgs e)
		{
			SetIcon();
		}

		private void add_Click(object sender, EventArgs e)
		{

		}

		private void change_Click(object sender, EventArgs e)
		{

		}

		private void delete_Click(object sender, EventArgs e)
		{

		}

		private void cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void load_Click(object sender, EventArgs e)
		{
			IExtensionRegistry extreg;
			if (rbExt.Enabled) {
				extreg = new FileExtension(name.Text);
			} else {
				extreg = new Protocol(name.Text);
			}

			description.Text = extreg.Description;
			iconpath.Text = extreg.IconPath;
			iconindex.Value = extreg.IconIndex;

			foreach (var item in extreg.Verbs) {
				verbs.Items.Add(new ListViewItem(new string[] {
					item.Key,
					item.Value.Command,
					item.Value.Description}));
			}
		}

		private void save_Click(object sender, EventArgs e)
		{

		}
	}
}
