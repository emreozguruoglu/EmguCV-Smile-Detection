namespace EmguCVFace
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMusic = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.lblMood = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSmiling = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMusic);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Controls.Add(this.btnSuggest);
            this.panel1.Controls.Add(this.lblMood);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtSmiling);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 597);
            this.panel1.TabIndex = 0;
            // 
            // lblMusic
            // 
            this.lblMusic.AutoSize = true;
            this.lblMusic.ForeColor = System.Drawing.Color.White;
            this.lblMusic.Location = new System.Drawing.Point(830, 286);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(0, 15);
            this.lblMusic.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(652, 304);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(425, 214);
            this.listBox1.TabIndex = 14;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Black;
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.Location = new System.Drawing.Point(655, 237);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(201, 40);
            this.btnList.TabIndex = 13;
            this.btnList.Text = "Müzik Listesi";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnSuggest
            // 
            this.btnSuggest.BackColor = System.Drawing.Color.Black;
            this.btnSuggest.ForeColor = System.Drawing.Color.White;
            this.btnSuggest.Location = new System.Drawing.Point(873, 237);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(204, 40);
            this.btnSuggest.TabIndex = 12;
            this.btnSuggest.Text = "Rastgele Müzik";
            this.btnSuggest.UseVisualStyleBackColor = false;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // lblMood
            // 
            this.lblMood.AutoSize = true;
            this.lblMood.ForeColor = System.Drawing.Color.White;
            this.lblMood.Location = new System.Drawing.Point(652, 216);
            this.lblMood.Name = "lblMood";
            this.lblMood.Size = new System.Drawing.Size(79, 15);
            this.lblMood.TabIndex = 11;
            this.lblMood.Text = "Ruh Haliniz :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(655, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(175, 179);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // txtSmiling
            // 
            this.txtSmiling.BackColor = System.Drawing.Color.Black;
            this.txtSmiling.ForeColor = System.Drawing.Color.White;
            this.txtSmiling.Location = new System.Drawing.Point(737, 210);
            this.txtSmiling.Name = "txtSmiling";
            this.txtSmiling.Size = new System.Drawing.Size(92, 21);
            this.txtSmiling.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 493);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::EmguCVFace.Properties.Resources.backgorund5__1159_605_;
            this.ClientSize = new System.Drawing.Size(1206, 622);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smile Detector";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMusic;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSmiling;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

