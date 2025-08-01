namespace AppListas
{
    partial class formPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            principalContextMenuStrip = new ContextMenuStrip(components);
            menuStrip = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            inicioContextToolStripMenuItem = new ToolStripMenuItem();
            principalContextMenuStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // principalContextMenuStrip
            // 
            principalContextMenuStrip.ImageScalingSize = new Size(24, 24);
            principalContextMenuStrip.Items.AddRange(new ToolStripItem[] { inicioContextToolStripMenuItem });
            principalContextMenuStrip.Name = "principalContextMenuStrip";
            principalContextMenuStrip.Size = new Size(127, 36);
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Gold;
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 33);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inicioToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(91, 29);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(270, 34);
            inicioToolStripMenuItem.Text = "Início";
            // 
            // inicioContextToolStripMenuItem
            // 
            inicioContextToolStripMenuItem.Name = "inicioContextToolStripMenuItem";
            inicioContextToolStripMenuItem.Size = new Size(126, 32);
            inicioContextToolStripMenuItem.Text = "Início";
            // 
            // formPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "formPrincipal";
            Text = "Jovem Programadora - Listas";
            principalContextMenuStrip.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip principalContextMenuStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem inicioContextToolStripMenuItem;
    }
}
