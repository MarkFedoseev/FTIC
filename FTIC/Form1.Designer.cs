namespace FTIC
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FtIButt = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.ItFButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FtIButt
            // 
            this.FtIButt.Location = new System.Drawing.Point(12, 12);
            this.FtIButt.Name = "FtIButt";
            this.FtIButt.Size = new System.Drawing.Size(150, 50);
            this.FtIButt.TabIndex = 0;
            this.FtIButt.Text = "File to Image";
            this.FtIButt.UseVisualStyleBackColor = true;
            this.FtIButt.Click += new System.EventHandler(this.FtIButt_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(12, 68);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(306, 20);
            this.Path.TabIndex = 1;
            this.Path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // ItFButt
            // 
            this.ItFButt.Location = new System.Drawing.Point(168, 12);
            this.ItFButt.Name = "ItFButt";
            this.ItFButt.Size = new System.Drawing.Size(150, 50);
            this.ItFButt.TabIndex = 2;
            this.ItFButt.Text = "Image to File";
            this.ItFButt.UseVisualStyleBackColor = true;
            this.ItFButt.Click += new System.EventHandler(this.ItFButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 266);
            this.Controls.Add(this.ItFButt);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.FtIButt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FtIButt;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button ItFButt;
    }
}

