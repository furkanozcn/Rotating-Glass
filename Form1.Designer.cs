namespace Deneme2
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
            this.OpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonY = new System.Windows.Forms.Button();
            this.buttonZ = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenGlControl
            // 
            this.OpenGlControl.AccumBits = ((byte)(0));
            this.OpenGlControl.AutoCheckErrors = false;
            this.OpenGlControl.AutoFinish = false;
            this.OpenGlControl.AutoMakeCurrent = true;
            this.OpenGlControl.AutoSwapBuffers = true;
            this.OpenGlControl.BackColor = System.Drawing.Color.Black;
            this.OpenGlControl.ColorBits = ((byte)(32));
            this.OpenGlControl.DepthBits = ((byte)(16));
            this.OpenGlControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.OpenGlControl.Location = new System.Drawing.Point(0, 0);
            this.OpenGlControl.Name = "OpenGlControl";
            this.OpenGlControl.Size = new System.Drawing.Size(500, 500);
            this.OpenGlControl.StencilBits = ((byte)(0));
            this.OpenGlControl.TabIndex = 0;
            this.OpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.myPaint);
            // 
            // buttonX
            // 
            this.buttonX.Location = new System.Drawing.Point(510, 12);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(75, 23);
            this.buttonX.TabIndex = 1;
            this.buttonX.Text = "X Döndür";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonX_MouseClick);
            // 
            // buttonY
            // 
            this.buttonY.Location = new System.Drawing.Point(510, 41);
            this.buttonY.Name = "buttonY";
            this.buttonY.Size = new System.Drawing.Size(75, 23);
            this.buttonY.TabIndex = 2;
            this.buttonY.Text = "Y Döndür";
            this.buttonY.UseVisualStyleBackColor = true;
            this.buttonY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonY_MouseClick);
            // 
            // buttonZ
            // 
            this.buttonZ.Location = new System.Drawing.Point(510, 70);
            this.buttonZ.Name = "buttonZ";
            this.buttonZ.Size = new System.Drawing.Size(75, 23);
            this.buttonZ.TabIndex = 3;
            this.buttonZ.Text = "Z Döndür";
            this.buttonZ.UseVisualStyleBackColor = true;
            this.buttonZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZ_MouseClick);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(591, 17);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(591, 46);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(13, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "0";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(591, 75);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(13, 13);
            this.labelZ.TabIndex = 6;
            this.labelZ.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 500);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.buttonZ);
            this.Controls.Add(this.buttonY);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.OpenGlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Bardak";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl OpenGlControl;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonY;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
    }
}

