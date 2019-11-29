namespace WFA_SplitText
{
    partial class Main
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
            this.txt_from = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_to = new System.Windows.Forms.TextBox();
            this.btnplit = new System.Windows.Forms.Button();
            this.btncopy = new System.Windows.Forms.Button();
            this.rbtnQueryText = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_from
            // 
            this.txt_from.Location = new System.Drawing.Point(12, 135);
            this.txt_from.Multiline = true;
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(420, 330);
            this.txt_from.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_to
            // 
            this.txt_to.Location = new System.Drawing.Point(468, 135);
            this.txt_to.Multiline = true;
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(426, 330);
            this.txt_to.TabIndex = 0;
            // 
            // btnplit
            // 
            this.btnplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplit.Location = new System.Drawing.Point(12, 471);
            this.btnplit.Name = "btnplit";
            this.btnplit.Size = new System.Drawing.Size(420, 73);
            this.btnplit.TabIndex = 4;
            this.btnplit.Text = "Split";
            this.btnplit.UseVisualStyleBackColor = true;
            // 
            // btncopy
            // 
            this.btncopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncopy.Location = new System.Drawing.Point(468, 471);
            this.btncopy.Name = "btncopy";
            this.btncopy.Size = new System.Drawing.Size(426, 73);
            this.btncopy.TabIndex = 3;
            this.btncopy.Text = "Copy";
            this.btncopy.UseVisualStyleBackColor = true;
            // 
            // rbtnQueryText
            // 
            this.rbtnQueryText.AutoSize = true;
            this.rbtnQueryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnQueryText.Location = new System.Drawing.Point(112, 13);
            this.rbtnQueryText.Name = "rbtnQueryText";
            this.rbtnQueryText.Size = new System.Drawing.Size(231, 29);
            this.rbtnQueryText.TabIndex = 5;
            this.rbtnQueryText.TabStop = true;
            this.rbtnQueryText.Text = "QueryText2SingelText";
            this.rbtnQueryText.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Option";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnQueryText);
            this.Controls.Add(this.btncopy);
            this.Controls.Add(this.btnplit);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.txt_from);
            this.Name = "Main";
            this.Text = "WFA-SplitText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_from;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txt_to;
        private System.Windows.Forms.Button btnplit;
        private System.Windows.Forms.Button btncopy;
        private System.Windows.Forms.RadioButton rbtnQueryText;
        private System.Windows.Forms.Label label1;
    }
}

