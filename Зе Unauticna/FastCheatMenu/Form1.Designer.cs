﻿namespace FastCheatMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Day";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Day);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "UnlockOniscience";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.UnlockOmniscience);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "ClearEffect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ClearEffect);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "iddqd";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.iddqd);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "OrtoCam";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OrtoCam);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(191, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "ranall";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Ranall);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(10, 186);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(191, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "DataFolder";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.DataFolder);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(213, 217);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FCM";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

