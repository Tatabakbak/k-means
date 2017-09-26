namespace k_means2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_random = new System.Windows.Forms.RadioButton();
            this.rb_group = new System.Windows.Forms.RadioButton();
            this.clusters_group = new System.Windows.Forms.GroupBox();
            this.rb_4 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.clusters_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(322, 404);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(403, 404);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(886, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(67, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "CLUSTERS:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_random);
            this.groupBox1.Controls.Add(this.rb_group);
            this.groupBox1.Location = new System.Drawing.Point(786, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(78, 70);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dataset";
            // 
            // rb_random
            // 
            this.rb_random.AutoSize = true;
            this.rb_random.Location = new System.Drawing.Point(5, 42);
            this.rb_random.Name = "rb_random";
            this.rb_random.Size = new System.Drawing.Size(65, 17);
            this.rb_random.TabIndex = 1;
            this.rb_random.Text = "Random";
            this.rb_random.UseVisualStyleBackColor = true;
            this.rb_random.CheckedChanged += new System.EventHandler(this.rb_random_CheckedChanged);
            // 
            // rb_group
            // 
            this.rb_group.AutoSize = true;
            this.rb_group.Checked = true;
            this.rb_group.Location = new System.Drawing.Point(5, 19);
            this.rb_group.Name = "rb_group";
            this.rb_group.Size = new System.Drawing.Size(59, 17);
            this.rb_group.TabIndex = 0;
            this.rb_group.TabStop = true;
            this.rb_group.Text = "Groups";
            this.rb_group.UseVisualStyleBackColor = true;
            this.rb_group.CheckedChanged += new System.EventHandler(this.rb_group_CheckedChanged);
            // 
            // clusters_group
            // 
            this.clusters_group.Controls.Add(this.rb_4);
            this.clusters_group.Controls.Add(this.rb_3);
            this.clusters_group.Controls.Add(this.rb_2);
            this.clusters_group.Controls.Add(this.rb_1);
            this.clusters_group.Location = new System.Drawing.Point(786, 85);
            this.clusters_group.Name = "clusters_group";
            this.clusters_group.Size = new System.Drawing.Size(78, 120);
            this.clusters_group.TabIndex = 5;
            this.clusters_group.TabStop = false;
            this.clusters_group.Text = "Clusters";
            // 
            // rb_4
            // 
            this.rb_4.AutoSize = true;
            this.rb_4.Location = new System.Drawing.Point(5, 91);
            this.rb_4.Name = "rb_4";
            this.rb_4.Size = new System.Drawing.Size(31, 17);
            this.rb_4.TabIndex = 6;
            this.rb_4.TabStop = true;
            this.rb_4.Text = "4";
            this.rb_4.UseVisualStyleBackColor = true;
            this.rb_4.CheckedChanged += new System.EventHandler(this.rb_4_CheckedChanged);
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Checked = true;
            this.rb_3.Location = new System.Drawing.Point(5, 68);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(31, 17);
            this.rb_3.TabIndex = 2;
            this.rb_3.TabStop = true;
            this.rb_3.Text = "3";
            this.rb_3.UseVisualStyleBackColor = true;
            this.rb_3.CheckedChanged += new System.EventHandler(this.rb_3_CheckedChanged);
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Location = new System.Drawing.Point(5, 43);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(31, 17);
            this.rb_2.TabIndex = 1;
            this.rb_2.Text = "2";
            this.rb_2.UseVisualStyleBackColor = true;
            this.rb_2.CheckedChanged += new System.EventHandler(this.rb_2_CheckedChanged);
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Location = new System.Drawing.Point(5, 20);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(31, 17);
            this.rb_1.TabIndex = 0;
            this.rb_1.Text = "1";
            this.rb_1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rb_1.UseVisualStyleBackColor = true;
            this.rb_1.CheckedChanged += new System.EventHandler(this.rb_1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 439);
            this.Controls.Add(this.clusters_group);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnClear);
            this.Name = "Form1";
            this.Text = "K-means clustering";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.clusters_group.ResumeLayout(false);
            this.clusters_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb_random;
		private System.Windows.Forms.RadioButton rb_group;
        private System.Windows.Forms.GroupBox clusters_group;
        private System.Windows.Forms.RadioButton rb_3;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.RadioButton rb_4;
    }
}

