namespace CreditCardValidation
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
            this.numberInput = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberInput
            // 
            this.numberInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberInput.Location = new System.Drawing.Point(36, 25);
            this.numberInput.MaxLength = 19;
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(263, 34);
            this.numberInput.TabIndex = 0;
            this.numberInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberInput_KeyPress);
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton.Location = new System.Drawing.Point(326, 25);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(94, 34);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 100);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.numberInput);
            this.Name = "Form1";
            this.Text = "CreditCardValidation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberInput;
        private System.Windows.Forms.Button checkButton;
    }
}

