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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSmiling = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblMood = new System.Windows.Forms.Label();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(604, 354);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // txtSmiling
            // 
            this.txtSmiling.Location = new System.Drawing.Point(705, 161);
            this.txtSmiling.Name = "txtSmiling";
            this.txtSmiling.Size = new System.Drawing.Size(69, 20);
            this.txtSmiling.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(640, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 127);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblMood
            // 
            this.lblMood.AutoSize = true;
            this.lblMood.Location = new System.Drawing.Point(637, 164);
            this.lblMood.Name = "lblMood";
            this.lblMood.Size = new System.Drawing.Size(65, 13);
            this.lblMood.TabIndex = 3;
            this.lblMood.Text = "Your Mood :";
            // 
            // btnSuggest
            // 
            this.btnSuggest.Location = new System.Drawing.Point(638, 191);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(136, 23);
            this.btnSuggest.TabIndex = 4;
            this.btnSuggest.Text = "Suggest Me Music";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(640, 221);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(134, 23);
            this.btnList.TabIndex = 5;
            this.btnList.Text = "Music Lists";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(790, 443);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.lblMood);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtSmiling);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smile Detector";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSmiling;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.Button btnList;
    }
}

