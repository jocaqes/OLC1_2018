namespace CRLapp
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_cursor = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_label_ejecucion = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boton_imagenes = new System.Windows.Forms.Button();
            this.boton_album = new System.Windows.Forms.Button();
            this.boton_errores = new System.Windows.Forms.Button();
            this.boton_ejecutar = new System.Windows.Forms.Button();
            this.boton_guardar_como = new System.Windows.Forms.Button();
            this.boton_guardar = new System.Windows.Forms.Button();
            this.boton_abrir = new System.Windows.Forms.Button();
            this.boton_nuevo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbox_consola1 = new System.Windows.Forms.RichTextBox();
            this.tbox_consola2 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_cursor,
            this.status_label_ejecucion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_cursor
            // 
            this.status_cursor.Name = "status_cursor";
            this.status_cursor.Size = new System.Drawing.Size(0, 17);
            // 
            // status_label_ejecucion
            // 
            this.status_label_ejecucion.Name = "status_label_ejecucion";
            this.status_label_ejecucion.Size = new System.Drawing.Size(66, 17);
            this.status_label_ejecucion.Text = "Bienvenido";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(13, 524);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1042, 185);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imagenes";
            // 
            // tab_main
            // 
            this.tab_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_main.Location = new System.Drawing.Point(13, 109);
            this.tab_main.MinimumSize = new System.Drawing.Size(100, 60);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(678, 405);
            this.tab_main.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.boton_imagenes);
            this.groupBox2.Controls.Add(this.boton_album);
            this.groupBox2.Controls.Add(this.boton_errores);
            this.groupBox2.Controls.Add(this.boton_ejecutar);
            this.groupBox2.Controls.Add(this.boton_guardar_como);
            this.groupBox2.Controls.Add(this.boton_guardar);
            this.groupBox2.Controls.Add(this.boton_abrir);
            this.groupBox2.Controls.Add(this.boton_nuevo);
            this.groupBox2.Location = new System.Drawing.Point(17, 27);
            this.groupBox2.MinimumSize = new System.Drawing.Size(905, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1039, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Herramientas";
            // 
            // boton_imagenes
            // 
            this.boton_imagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_imagenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_imagenes.Image = global::CRLapp.Properties.Resources.imagen;
            this.boton_imagenes.Location = new System.Drawing.Point(899, 17);
            this.boton_imagenes.Name = "boton_imagenes";
            this.boton_imagenes.Size = new System.Drawing.Size(56, 53);
            this.boton_imagenes.TabIndex = 7;
            this.boton_imagenes.UseVisualStyleBackColor = true;
            // 
            // boton_album
            // 
            this.boton_album.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_album.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_album.Image = global::CRLapp.Properties.Resources.album;
            this.boton_album.Location = new System.Drawing.Point(792, 17);
            this.boton_album.Name = "boton_album";
            this.boton_album.Size = new System.Drawing.Size(56, 53);
            this.boton_album.TabIndex = 6;
            this.boton_album.UseVisualStyleBackColor = true;
            // 
            // boton_errores
            // 
            this.boton_errores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_errores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_errores.Image = global::CRLapp.Properties.Resources.buen_error;
            this.boton_errores.Location = new System.Drawing.Point(669, 17);
            this.boton_errores.Name = "boton_errores";
            this.boton_errores.Size = new System.Drawing.Size(56, 53);
            this.boton_errores.TabIndex = 5;
            this.boton_errores.UseVisualStyleBackColor = true;
            // 
            // boton_ejecutar
            // 
            this.boton_ejecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_ejecutar.Image = global::CRLapp.Properties.Resources.correr;
            this.boton_ejecutar.Location = new System.Drawing.Point(545, 17);
            this.boton_ejecutar.Name = "boton_ejecutar";
            this.boton_ejecutar.Size = new System.Drawing.Size(56, 53);
            this.boton_ejecutar.TabIndex = 4;
            this.boton_ejecutar.UseVisualStyleBackColor = true;
            this.boton_ejecutar.Click += new System.EventHandler(this.boton_ejecutar_Click);
            // 
            // boton_guardar_como
            // 
            this.boton_guardar_como.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_guardar_como.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_guardar_como.Image = global::CRLapp.Properties.Resources.guardar_como;
            this.boton_guardar_como.Location = new System.Drawing.Point(420, 17);
            this.boton_guardar_como.Name = "boton_guardar_como";
            this.boton_guardar_como.Size = new System.Drawing.Size(56, 53);
            this.boton_guardar_como.TabIndex = 3;
            this.boton_guardar_como.UseVisualStyleBackColor = true;
            this.boton_guardar_como.Click += new System.EventHandler(this.boton_guardar_como_Click);
            // 
            // boton_guardar
            // 
            this.boton_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_guardar.Image = global::CRLapp.Properties.Resources.guardar_pagina;
            this.boton_guardar.Location = new System.Drawing.Point(306, 17);
            this.boton_guardar.Name = "boton_guardar";
            this.boton_guardar.Size = new System.Drawing.Size(56, 53);
            this.boton_guardar.TabIndex = 2;
            this.boton_guardar.UseVisualStyleBackColor = true;
            this.boton_guardar.Click += new System.EventHandler(this.boton_guardar_Click);
            // 
            // boton_abrir
            // 
            this.boton_abrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_abrir.CausesValidation = false;
            this.boton_abrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_abrir.Image = global::CRLapp.Properties.Resources.abrir_pagina;
            this.boton_abrir.Location = new System.Drawing.Point(188, 17);
            this.boton_abrir.Name = "boton_abrir";
            this.boton_abrir.Size = new System.Drawing.Size(56, 53);
            this.boton_abrir.TabIndex = 1;
            this.boton_abrir.UseVisualStyleBackColor = true;
            this.boton_abrir.Click += new System.EventHandler(this.boton_abrir_Click);
            // 
            // boton_nuevo
            // 
            this.boton_nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.boton_nuevo.CausesValidation = false;
            this.boton_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_nuevo.Image = global::CRLapp.Properties.Resources.nueva_pagina;
            this.boton_nuevo.Location = new System.Drawing.Point(79, 17);
            this.boton_nuevo.Name = "boton_nuevo";
            this.boton_nuevo.Size = new System.Drawing.Size(56, 53);
            this.boton_nuevo.TabIndex = 0;
            this.boton_nuevo.TabStop = false;
            this.boton_nuevo.UseVisualStyleBackColor = true;
            this.boton_nuevo.Click += new System.EventHandler(this.boton_nuevo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Location = new System.Drawing.Point(697, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 405);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consolas";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbox_consola1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbox_consola2);
            this.splitContainer1.Size = new System.Drawing.Size(352, 386);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbox_consola1
            // 
            this.tbox_consola1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbox_consola1.Font = new System.Drawing.Font("Monospac821 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_consola1.Location = new System.Drawing.Point(4, 4);
            this.tbox_consola1.Name = "tbox_consola1";
            this.tbox_consola1.Size = new System.Drawing.Size(345, 190);
            this.tbox_consola1.TabIndex = 0;
            this.tbox_consola1.Text = "";
            // 
            // tbox_consola2
            // 
            this.tbox_consola2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbox_consola2.BackColor = System.Drawing.Color.Yellow;
            this.tbox_consola2.Font = new System.Drawing.Font("Monospac821 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_consola2.ForeColor = System.Drawing.Color.Black;
            this.tbox_consola2.Location = new System.Drawing.Point(4, 3);
            this.tbox_consola2.Name = "tbox_consola2";
            this.tbox_consola2.Size = new System.Drawing.Size(345, 183);
            this.tbox_consola2.TabIndex = 0;
            this.tbox_consola2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 734);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tab_main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(953, 39);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_cursor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox tbox_consola1;
        private System.Windows.Forms.RichTextBox tbox_consola2;
        private System.Windows.Forms.Button boton_nuevo;
        private System.Windows.Forms.Button boton_abrir;
        private System.Windows.Forms.Button boton_guardar;
        private System.Windows.Forms.Button boton_guardar_como;
        private System.Windows.Forms.Button boton_ejecutar;
        private System.Windows.Forms.Button boton_album;
        private System.Windows.Forms.Button boton_errores;
        private System.Windows.Forms.Button boton_imagenes;
        private System.Windows.Forms.ToolStripStatusLabel status_label_ejecucion;
    }
}

