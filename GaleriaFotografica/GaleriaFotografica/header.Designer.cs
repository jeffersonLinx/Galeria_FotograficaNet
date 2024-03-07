namespace GaleriaFotografica
{
    partial class header
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(header));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regisrtoUsiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Galeria = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Galeria.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.categoriaToolStripMenuItem,
            this.proyectosToolStripMenuItem,
            this.regisrtoUsiarioToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(84, 34);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(124, 34);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // proyectosToolStripMenuItem
            // 
            this.proyectosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.proyectosToolStripMenuItem.Name = "proyectosToolStripMenuItem";
            this.proyectosToolStripMenuItem.Size = new System.Drawing.Size(127, 34);
            this.proyectosToolStripMenuItem.Text = "Proyectos";
            this.proyectosToolStripMenuItem.Click += new System.EventHandler(this.proyectosToolStripMenuItem_Click);
            // 
            // regisrtoUsiarioToolStripMenuItem
            // 
            this.regisrtoUsiarioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.regisrtoUsiarioToolStripMenuItem.Name = "regisrtoUsiarioToolStripMenuItem";
            this.regisrtoUsiarioToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.regisrtoUsiarioToolStripMenuItem.Text = "Registro Usuario";
            this.regisrtoUsiarioToolStripMenuItem.Click += new System.EventHandler(this.regisrtoUsiarioToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(114, 34);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(117, 34);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // Galeria
            // 
            this.Galeria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Galeria.BackgroundImage")));
            this.Galeria.Controls.Add(this.label1);
            this.Galeria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Galeria.Location = new System.Drawing.Point(0, 57);
            this.Galeria.Name = "Galeria";
            this.Galeria.Size = new System.Drawing.Size(847, 60);
            this.Galeria.TabIndex = 1;
            this.Galeria.TabStop = false;
            this.Galeria.Text = "Galeria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Galeria Fotografica";
            // 
            // header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 450);
            this.Controls.Add(this.Galeria);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "header";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "header";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.header_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Galeria.ResumeLayout(false);
            this.Galeria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regisrtoUsiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.GroupBox Galeria;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}