namespace ExtensionRegister
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.rbExt = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.rbProt = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.description = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.icon = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.iconpath = new System.Windows.Forms.TextBox();
			this.loadicon = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.iconindex = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.verbs = new System.Windows.Forms.ListView();
			this.add = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.load = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.change = new System.Windows.Forms.Button();
			this.iconofd = new System.Windows.Forms.OpenFileDialog();
			this.verb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmdline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iconindex)).BeginInit();
			this.SuspendLayout();
			// 
			// rbExt
			// 
			this.rbExt.AutoSize = true;
			this.rbExt.Checked = true;
			this.rbExt.Location = new System.Drawing.Point(96, 24);
			this.rbExt.Name = "rbExt";
			this.rbExt.Size = new System.Drawing.Size(59, 16);
			this.rbExt.TabIndex = 0;
			this.rbExt.TabStop = true;
			this.rbExt.Text = "拡張子";
			this.rbExt.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(330, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "このダイアログでは拡張子とプロトコルの設定を変更する事ができます。";
			// 
			// rbProt
			// 
			this.rbProt.AutoSize = true;
			this.rbProt.Location = new System.Drawing.Point(168, 24);
			this.rbProt.Name = "rbProt";
			this.rbProt.Size = new System.Drawing.Size(67, 16);
			this.rbProt.TabIndex = 2;
			this.rbProt.Text = "プロトコル";
			this.rbProt.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(342, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "拡張子名またはプロトコル名を下記のテキストボックスに入力してください。\r\n(※ただし、文字列の先頭に\".\"や終端に\":\"を付けません。)";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(8, 80);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(368, 19);
			this.name.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "拡張子またはプロトコルの説明：";
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(8, 120);
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(368, 19);
			this.description.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "設定する項目：";
			// 
			// icon
			// 
			this.icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.icon.Location = new System.Drawing.Point(8, 160);
			this.icon.Name = "icon";
			this.icon.Size = new System.Drawing.Size(64, 64);
			this.icon.TabIndex = 8;
			this.icon.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "アイコンの設定：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(80, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "アイコンファイル：";
			// 
			// iconpath
			// 
			this.iconpath.Location = new System.Drawing.Point(80, 176);
			this.iconpath.Name = "iconpath";
			this.iconpath.Size = new System.Drawing.Size(272, 19);
			this.iconpath.TabIndex = 11;
			this.iconpath.TextChanged += new System.EventHandler(this.iconpath_TextChanged);
			// 
			// loadicon
			// 
			this.loadicon.Location = new System.Drawing.Point(352, 175);
			this.loadicon.Name = "loadicon";
			this.loadicon.Size = new System.Drawing.Size(27, 21);
			this.loadicon.TabIndex = 12;
			this.loadicon.Text = "...";
			this.loadicon.UseVisualStyleBackColor = true;
			this.loadicon.Click += new System.EventHandler(this.loadicon_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(80, 204);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(98, 12);
			this.label7.TabIndex = 13;
			this.label7.Text = "アイコンインデックス：";
			// 
			// iconindex
			// 
			this.iconindex.Location = new System.Drawing.Point(184, 200);
			this.iconindex.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.iconindex.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.iconindex.Name = "iconindex";
			this.iconindex.Size = new System.Drawing.Size(192, 19);
			this.iconindex.TabIndex = 14;
			this.iconindex.ValueChanged += new System.EventHandler(this.iconindex_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 12);
			this.label8.TabIndex = 15;
			this.label8.Text = "動詞の設定：";
			// 
			// verbs
			// 
			this.verbs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.verb,
            this.cmdline,
            this.desc});
			this.verbs.Location = new System.Drawing.Point(8, 248);
			this.verbs.Name = "verbs";
			this.verbs.Size = new System.Drawing.Size(368, 144);
			this.verbs.TabIndex = 16;
			this.verbs.UseCompatibleStateImageBehavior = false;
			this.verbs.View = System.Windows.Forms.View.Details;
			// 
			// add
			// 
			this.add.Location = new System.Drawing.Point(8, 400);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(48, 23);
			this.add.TabIndex = 17;
			this.add.Text = "追加";
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(120, 400);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(48, 23);
			this.delete.TabIndex = 19;
			this.delete.Text = "削除";
			this.delete.UseVisualStyleBackColor = true;
			this.delete.Click += new System.EventHandler(this.delete_Click);
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(304, 432);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 19;
			this.save.Text = "保存 (&S)";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// load
			// 
			this.load.Location = new System.Drawing.Point(224, 432);
			this.load.Name = "load";
			this.load.Size = new System.Drawing.Size(75, 23);
			this.load.TabIndex = 20;
			this.load.Text = "荷重 (&L)";
			this.load.UseVisualStyleBackColor = true;
			this.load.Click += new System.EventHandler(this.load_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(8, 432);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(80, 23);
			this.cancel.TabIndex = 21;
			this.cancel.Text = "キャンセル (&C)";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// change
			// 
			this.change.Location = new System.Drawing.Point(64, 400);
			this.change.Name = "change";
			this.change.Size = new System.Drawing.Size(48, 23);
			this.change.TabIndex = 18;
			this.change.Text = "変更";
			this.change.UseVisualStyleBackColor = true;
			this.change.Click += new System.EventHandler(this.change_Click);
			// 
			// iconofd
			// 
			this.iconofd.Filter = "全てのアイコンファイル (*.ico;*.exe;*.dll)|*.ico;*.exe;*.dll|アイコンファイル (*.ico)|*.ico|実行可能ファイル" +
    " (*.exe)|*.exe|動的リンクライブラリ (*.dll)|*.dll";
			this.iconofd.Title = "アイコンを選択してください";
			// 
			// verb
			// 
			this.verb.Text = "動詞";
			// 
			// cmdline
			// 
			this.cmdline.Text = "コマンドライン";
			this.cmdline.Width = 150;
			// 
			// desc
			// 
			this.desc.Text = "説明";
			this.desc.Width = 150;
			// 
			// Form1
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(384, 461);
			this.Controls.Add(this.change);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.load);
			this.Controls.Add(this.save);
			this.Controls.Add(this.delete);
			this.Controls.Add(this.add);
			this.Controls.Add(this.verbs);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.iconindex);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.loadicon);
			this.Controls.Add(this.iconpath);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.icon);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.description);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.name);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rbProt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rbExt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "拡張子とプロトコルの登録";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iconindex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbExt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbProt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox description;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox icon;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox iconpath;
		private System.Windows.Forms.Button loadicon;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown iconindex;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListView verbs;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button load;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button change;
		private System.Windows.Forms.OpenFileDialog iconofd;
		private System.Windows.Forms.ColumnHeader verb;
		private System.Windows.Forms.ColumnHeader cmdline;
		private System.Windows.Forms.ColumnHeader desc;
	}
}

