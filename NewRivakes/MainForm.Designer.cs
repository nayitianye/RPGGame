namespace NewRivakes
{
    partial class MainForm
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
            this.StateBtn = new System.Windows.Forms.Button();
            this.PacksackBtn = new System.Windows.Forms.Button();
            this.RivakesBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // StateBtn
            // 
            this.StateBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateBtn.Location = new System.Drawing.Point(9, 607);
            this.StateBtn.Name = "StateBtn";
            this.StateBtn.Size = new System.Drawing.Size(164, 63);
            this.StateBtn.TabIndex = 0;
            this.StateBtn.Text = "状 态";
            this.StateBtn.UseVisualStyleBackColor = true;
            this.StateBtn.Click += new System.EventHandler(this.StateBtn_Click);
            // 
            // PacksackBtn
            // 
            this.PacksackBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PacksackBtn.Location = new System.Drawing.Point(349, 607);
            this.PacksackBtn.Name = "PacksackBtn";
            this.PacksackBtn.Size = new System.Drawing.Size(201, 63);
            this.PacksackBtn.TabIndex = 2;
            this.PacksackBtn.Text = "装备和技能";
            this.PacksackBtn.UseVisualStyleBackColor = true;
            this.PacksackBtn.Click += new System.EventHandler(this.PacksackBtn_Click);
            // 
            // RivakesBtn
            // 
            this.RivakesBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RivakesBtn.Location = new System.Drawing.Point(179, 607);
            this.RivakesBtn.Name = "RivakesBtn";
            this.RivakesBtn.Size = new System.Drawing.Size(164, 63);
            this.RivakesBtn.TabIndex = 3;
            this.RivakesBtn.Text = "江 湖";
            this.RivakesBtn.UseVisualStyleBackColor = true;
            this.RivakesBtn.Click += new System.EventHandler(this.RivakesBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 589);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 671);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RivakesBtn);
            this.Controls.Add(this.PacksackBtn);
            this.Controls.Add(this.StateBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StateBtn;
        private System.Windows.Forms.Button PacksackBtn;
        private System.Windows.Forms.Button RivakesBtn;
        private System.Windows.Forms.Panel panel1;
    }
}