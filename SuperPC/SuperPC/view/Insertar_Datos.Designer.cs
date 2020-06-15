namespace SuperPC.view
{
    partial class Insertar_Datos
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
            this.lbl_Columna = new System.Windows.Forms.Label();
            this.txt_Dato_Obtenido = new System.Windows.Forms.TextBox();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Columna
            // 
            this.lbl_Columna.AutoSize = true;
            this.lbl_Columna.Location = new System.Drawing.Point(62, 123);
            this.lbl_Columna.Name = "lbl_Columna";
            this.lbl_Columna.Size = new System.Drawing.Size(46, 17);
            this.lbl_Columna.TabIndex = 0;
            this.lbl_Columna.Text = "label1";
            // 
            // txt_Dato_Obtenido
            // 
            this.txt_Dato_Obtenido.Location = new System.Drawing.Point(173, 118);
            this.txt_Dato_Obtenido.Name = "txt_Dato_Obtenido";
            this.txt_Dato_Obtenido.Size = new System.Drawing.Size(169, 22);
            this.txt_Dato_Obtenido.TabIndex = 1;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(94, 278);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(93, 41);
            this.btn_Aceptar.TabIndex = 2;
            this.btn_Aceptar.Text = "ACEPTAR";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(259, 278);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(101, 41);
            this.btn_Cancelar.TabIndex = 3;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // Insertar_Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 367);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.txt_Dato_Obtenido);
            this.Controls.Add(this.lbl_Columna);
            this.Name = "Insertar_Datos";
            this.Text = "Insertar_Datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Columna;
        private System.Windows.Forms.TextBox txt_Dato_Obtenido;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}