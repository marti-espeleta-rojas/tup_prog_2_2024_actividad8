namespace Ejercicio1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVerCuentas = new System.Windows.Forms.Button();
            this.btnImportarCuentas = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnExportarCuentas = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.lbxVer = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnVerCuentas
            // 
            this.btnVerCuentas.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCuentas.Location = new System.Drawing.Point(556, 15);
            this.btnVerCuentas.Name = "btnVerCuentas";
            this.btnVerCuentas.Size = new System.Drawing.Size(144, 39);
            this.btnVerCuentas.TabIndex = 0;
            this.btnVerCuentas.Text = "1- Ver Cuentas";
            this.btnVerCuentas.UseVisualStyleBackColor = true;
            this.btnVerCuentas.Click += new System.EventHandler(this.btnVerCuentas_Click);
            // 
            // btnImportarCuentas
            // 
            this.btnImportarCuentas.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarCuentas.Location = new System.Drawing.Point(556, 60);
            this.btnImportarCuentas.Name = "btnImportarCuentas";
            this.btnImportarCuentas.Size = new System.Drawing.Size(144, 39);
            this.btnImportarCuentas.TabIndex = 1;
            this.btnImportarCuentas.Text = "2- Importar Cuentas";
            this.btnImportarCuentas.UseVisualStyleBackColor = true;
            this.btnImportarCuentas.Click += new System.EventHandler(this.btnImportarCuentas_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(556, 150);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(144, 39);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "4- Resguardar (Backup)";
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnExportarCuentas
            // 
            this.btnExportarCuentas.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCuentas.Location = new System.Drawing.Point(556, 105);
            this.btnExportarCuentas.Name = "btnExportarCuentas";
            this.btnExportarCuentas.Size = new System.Drawing.Size(144, 39);
            this.btnExportarCuentas.TabIndex = 3;
            this.btnExportarCuentas.Text = "3- Exportar Cuentas";
            this.btnExportarCuentas.UseVisualStyleBackColor = true;
            this.btnExportarCuentas.Click += new System.EventHandler(this.btnExportarCuentas_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.Location = new System.Drawing.Point(556, 195);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(144, 39);
            this.btnRestaurar.TabIndex = 4;
            this.btnRestaurar.Text = "5- Restaurar (Restore)";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // lbxVer
            // 
            this.lbxVer.FormattingEnabled = true;
            this.lbxVer.Location = new System.Drawing.Point(13, 13);
            this.lbxVer.Name = "lbxVer";
            this.lbxVer.Size = new System.Drawing.Size(537, 264);
            this.lbxVer.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 284);
            this.Controls.Add(this.lbxVer);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnExportarCuentas);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnImportarCuentas);
            this.Controls.Add(this.btnVerCuentas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerCuentas;
        private System.Windows.Forms.Button btnImportarCuentas;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnExportarCuentas;
        private System.Windows.Forms.Button btnRestaurar;
        public System.Windows.Forms.ListBox lbxVer;
    }
}

