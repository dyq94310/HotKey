﻿namespace WorkUtil
{
    partial class FrmInputKey
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSendKeys = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegKeys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHotKeyId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSendKeys);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRegKeys);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtHotKeyId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 264);
            this.panel1.TabIndex = 0;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(106, 183);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(261, 28);
            this.txtNote.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "备  注";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "确的";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtSendKeys
            // 
            this.txtSendKeys.Location = new System.Drawing.Point(106, 135);
            this.txtSendKeys.Name = "txtSendKeys";
            this.txtSendKeys.Size = new System.Drawing.Size(261, 28);
            this.txtSendKeys.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "映射为";
            // 
            // txtRegKeys
            // 
            this.txtRegKeys.Location = new System.Drawing.Point(106, 76);
            this.txtRegKeys.Name = "txtRegKeys";
            this.txtRegKeys.Size = new System.Drawing.Size(261, 28);
            this.txtRegKeys.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "原始键";
            // 
            // txtHotKeyId
            // 
            this.txtHotKeyId.Location = new System.Drawing.Point(106, 16);
            this.txtHotKeyId.Name = "txtHotKeyId";
            this.txtHotKeyId.Size = new System.Drawing.Size(261, 28);
            this.txtHotKeyId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "热键ID";
            // 
            // FrmInputKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 264);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInputKey";
            this.Text = "FrmInputKey";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtHotKeyId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSendKeys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label4;
    }
}