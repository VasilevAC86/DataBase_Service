namespace DataBase_AutoService
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
            this.cmbMechanic = new System.Windows.Forms.ComboBox();
            this.lblMechanics = new System.Windows.Forms.Label();
            this.picBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMechanic
            // 
            this.cmbMechanic.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbMechanic.FormattingEnabled = true;
            this.cmbMechanic.Location = new System.Drawing.Point(55, 68);
            this.cmbMechanic.Name = "cmbMechanic";
            this.cmbMechanic.Size = new System.Drawing.Size(269, 33);
            this.cmbMechanic.TabIndex = 0;
            this.cmbMechanic.SelectedValueChanged += new System.EventHandler(this.cmbMechanic_SelectedValueChanged);
            // 
            // lblMechanics
            // 
            this.lblMechanics.AutoSize = true;
            this.lblMechanics.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMechanics.Location = new System.Drawing.Point(55, 37);
            this.lblMechanics.Name = "lblMechanics";
            this.lblMechanics.Size = new System.Drawing.Size(105, 26);
            this.lblMechanics.TabIndex = 1;
            this.lblMechanics.Text = "Мастера:";
            // 
            // picBoxAvatar
            // 
            this.picBoxAvatar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.picBoxAvatar.Location = new System.Drawing.Point(398, 68);
            this.picBoxAvatar.Name = "picBoxAvatar";
            this.picBoxAvatar.Size = new System.Drawing.Size(120, 120);
            this.picBoxAvatar.TabIndex = 2;
            this.picBoxAvatar.TabStop = false;
            this.picBoxAvatar.Click += new System.EventHandler(this.picBoxAvatar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBoxAvatar);
            this.Controls.Add(this.lblMechanics);
            this.Controls.Add(this.cmbMechanic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMechanic;
        private System.Windows.Forms.Label lblMechanics;
        private System.Windows.Forms.PictureBox picBoxAvatar;
    }
}

