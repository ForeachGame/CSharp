using System.ComponentModel;

namespace HomeWork7
{
    partial class Start
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
            this.buttonDoublerStart = new System.Windows.Forms.Button();
            this.buttonGuessStart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDoublerStart
            // 
            this.buttonDoublerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDoublerStart.Location = new System.Drawing.Point(50, 132);
            this.buttonDoublerStart.Name = "buttonDoublerStart";
            this.buttonDoublerStart.Size = new System.Drawing.Size(200, 100);
            this.buttonDoublerStart.TabIndex = 0;
            this.buttonDoublerStart.Text = "Удвоитель";
            this.buttonDoublerStart.UseVisualStyleBackColor = true;
            this.buttonDoublerStart.Click += new System.EventHandler(this.buttonDoublerStart_Click);
            // 
            // buttonGuessStart
            // 
            this.buttonGuessStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGuessStart.Location = new System.Drawing.Point(250, 132);
            this.buttonGuessStart.Name = "buttonGuessStart";
            this.buttonGuessStart.Size = new System.Drawing.Size(200, 100);
            this.buttonGuessStart.TabIndex = 1;
            this.buttonGuessStart.Text = "Угадай число";
            this.buttonGuessStart.UseVisualStyleBackColor = true;
            this.buttonGuessStart.Click += new System.EventHandler(this.buttonGuessStart_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(50, 250);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(400, 50);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Выход";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(50, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(400, 53);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Домашняя работа 7";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.Location = new System.Drawing.Point(50, 76);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(400, 34);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "Автор: Черемисинов Александр";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonGuessStart);
            this.Controls.Add(this.buttonDoublerStart);
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelAuthor;

        private System.Windows.Forms.Label labelTitle;
        
        private System.Windows.Forms.Button buttonDoublerStart;
        private System.Windows.Forms.Button buttonGuessStart;
        private System.Windows.Forms.Button buttonClose;

        #endregion
    }
}