using System.ComponentModel;

namespace HomeWork7
{
    partial class GuessNumber
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonCheckNumber = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelPleaseNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(460, 65);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Заголовок";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCount
            // 
            this.labelCount.Location = new System.Drawing.Point(12, 126);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(460, 30);
            this.labelCount.TabIndex = 9;
            this.labelCount.Text = "Количество попыток:";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(144, 159);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(277, 20);
            this.textBoxNumber.TabIndex = 10;
            this.textBoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyDown);
            // 
            // buttonCheckNumber
            // 
            this.buttonCheckNumber.Location = new System.Drawing.Point(427, 159);
            this.buttonCheckNumber.Name = "buttonCheckNumber";
            this.buttonCheckNumber.Size = new System.Drawing.Size(43, 20);
            this.buttonCheckNumber.TabIndex = 11;
            this.buttonCheckNumber.Text = "Ok";
            this.buttonCheckNumber.UseVisualStyleBackColor = true;
            this.buttonCheckNumber.Click += new System.EventHandler(this.buttonCheckNumber_Click);
            // 
            // labelResult
            // 
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(12, 74);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(460, 28);
            this.labelResult.TabIndex = 12;
            this.labelResult.Text = "Результат";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPleaseNumber
            // 
            this.labelPleaseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPleaseNumber.Location = new System.Drawing.Point(12, 159);
            this.labelPleaseNumber.Name = "labelPleaseNumber";
            this.labelPleaseNumber.Size = new System.Drawing.Size(126, 20);
            this.labelPleaseNumber.TabIndex = 13;
            this.labelPleaseNumber.Text = "Введите число";
            this.labelPleaseNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GuessNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.labelPleaseNumber);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonCheckNumber);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelTitle);
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "GuessNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuessNumber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuessNumber_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelPleaseNumber;

        private System.Windows.Forms.Label labelResult;

        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonCheckNumber;

        private System.Windows.Forms.Label labelTitle;

        #endregion
    }
}