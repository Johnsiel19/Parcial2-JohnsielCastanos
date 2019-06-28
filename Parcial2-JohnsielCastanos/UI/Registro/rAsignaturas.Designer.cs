namespace Parcial2_JohnsielCastanos.UI.Registro
{
    partial class rAsignaturas
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
            this.AsignaturaIdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.DescripciontextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CreditosnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AsignaturaIdnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditosnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // AsignaturaIdnumericUpDown
            // 
            this.AsignaturaIdnumericUpDown.Location = new System.Drawing.Point(151, 32);
            this.AsignaturaIdnumericUpDown.Name = "AsignaturaIdnumericUpDown";
            this.AsignaturaIdnumericUpDown.Size = new System.Drawing.Size(97, 22);
            this.AsignaturaIdnumericUpDown.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Descripcion";
            // 
            // DescripciontextBox
            // 
            this.DescripciontextBox.Location = new System.Drawing.Point(151, 78);
            this.DescripciontextBox.Name = "DescripciontextBox";
            this.DescripciontextBox.Size = new System.Drawing.Size(202, 22);
            this.DescripciontextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Creditos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "AsignaturaId";
            // 
            // CreditosnumericUpDown
            // 
            this.CreditosnumericUpDown.Location = new System.Drawing.Point(151, 128);
            this.CreditosnumericUpDown.Name = "CreditosnumericUpDown";
            this.CreditosnumericUpDown.Size = new System.Drawing.Size(97, 22);
            this.CreditosnumericUpDown.TabIndex = 33;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscarbutton.Image = global::Parcial2_JohnsielCastanos.Properties.Resources.search_locate_find_13974;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(260, 25);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(93, 40);
            this.Buscarbutton.TabIndex = 31;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guardarbutton.Image = global::Parcial2_JohnsielCastanos.Properties.Resources.guardar;
            this.Guardarbutton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Guardarbutton.Location = new System.Drawing.Point(156, 188);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(80, 59);
            this.Guardarbutton.TabIndex = 30;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eliminarbutton.Image = global::Parcial2_JohnsielCastanos.Properties.Resources.eliminar;
            this.Eliminarbutton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Eliminarbutton.Location = new System.Drawing.Point(280, 188);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(80, 59);
            this.Eliminarbutton.TabIndex = 29;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nuevobutton.Image = global::Parcial2_JohnsielCastanos.Properties.Resources.nuevo;
            this.Nuevobutton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Nuevobutton.Location = new System.Drawing.Point(35, 188);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(80, 59);
            this.Nuevobutton.TabIndex = 28;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // rAsignaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 268);
            this.Controls.Add(this.CreditosnumericUpDown);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.AsignaturaIdnumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DescripciontextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "rAsignaturas";
            this.Text = "Registro Asignaturas";
            ((System.ComponentModel.ISupportInitialize)(this.AsignaturaIdnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditosnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.NumericUpDown AsignaturaIdnumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DescripciontextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown CreditosnumericUpDown;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}