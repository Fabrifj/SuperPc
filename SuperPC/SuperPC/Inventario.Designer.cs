namespace SuperPC
{
    partial class Inventario
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
            this.btnProvedor = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProvedor
            // 
            this.btnProvedor.Location = new System.Drawing.Point(453, 128);
            this.btnProvedor.Name = "btnProvedor";
            this.btnProvedor.Size = new System.Drawing.Size(143, 71);
            this.btnProvedor.TabIndex = 7;
            this.btnProvedor.Text = "Provedor";
            this.btnProvedor.UseVisualStyleBackColor = true;
            this.btnProvedor.Click += new System.EventHandler(this.btnProvedor_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(204, 128);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(143, 71);
            this.btnProducto.TabIndex = 6;
            this.btnProducto.Text = "Producto";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnPedido
            // 
            this.btnPedido.Location = new System.Drawing.Point(334, 252);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(143, 71);
            this.btnPedido.TabIndex = 5;
            this.btnPedido.Text = "Pedido";
            this.btnPedido.UseVisualStyleBackColor = true;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Inicio";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProvedor);
            this.Controls.Add(this.btnProducto);
            this.Controls.Add(this.btnPedido);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProvedor;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Label label2;
    }
}