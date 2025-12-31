namespace WinAudioLoopback
{
    partial class App
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
            inputDevicesCB = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            outputDevicesCB = new ComboBox();
            toggleBtn = new Button();
            volumeTb = new TrackBar();
            volumeGb = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)volumeTb).BeginInit();
            volumeGb.SuspendLayout();
            SuspendLayout();
            // 
            // inputDevicesCB
            // 
            inputDevicesCB.DropDownStyle = ComboBoxStyle.DropDownList;
            inputDevicesCB.FlatStyle = FlatStyle.Popup;
            inputDevicesCB.FormattingEnabled = true;
            inputDevicesCB.Location = new Point(6, 33);
            inputDevicesCB.Name = "inputDevicesCB";
            inputDevicesCB.Size = new Size(268, 23);
            inputDevicesCB.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inputDevicesCB);
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 70);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input device";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(outputDevicesCB);
            groupBox2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(298, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(280, 70);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output device";
            // 
            // outputDevicesCB
            // 
            outputDevicesCB.DropDownStyle = ComboBoxStyle.DropDownList;
            outputDevicesCB.FlatStyle = FlatStyle.Popup;
            outputDevicesCB.FormattingEnabled = true;
            outputDevicesCB.Location = new Point(6, 33);
            outputDevicesCB.Name = "outputDevicesCB";
            outputDevicesCB.Size = new Size(268, 23);
            outputDevicesCB.TabIndex = 0;
            // 
            // toggleBtn
            // 
            toggleBtn.FlatStyle = FlatStyle.Popup;
            toggleBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toggleBtn.Location = new Point(356, 171);
            toggleBtn.Name = "toggleBtn";
            toggleBtn.Size = new Size(222, 39);
            toggleBtn.TabIndex = 3;
            toggleBtn.Text = "Enable loopback";
            toggleBtn.UseVisualStyleBackColor = true;
            toggleBtn.Click += toggleBtn_Click;
            // 
            // volumeTb
            // 
            volumeTb.Enabled = false;
            volumeTb.LargeChange = 10;
            volumeTb.Location = new Point(6, 22);
            volumeTb.Maximum = 100;
            volumeTb.Name = "volumeTb";
            volumeTb.Size = new Size(554, 45);
            volumeTb.SmallChange = 10;
            volumeTb.TabIndex = 4;
            volumeTb.TickFrequency = 5;
            volumeTb.Value = 50;
            volumeTb.ValueChanged += volumeTb_ValueChanged;
            // 
            // volumeGb
            // 
            volumeGb.Controls.Add(volumeTb);
            volumeGb.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            volumeGb.Location = new Point(12, 88);
            volumeGb.Name = "volumeGb";
            volumeGb.Size = new Size(566, 77);
            volumeGb.TabIndex = 7;
            volumeGb.TabStop = false;
            volumeGb.Text = "Volume: 50%";
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 219);
            Controls.Add(volumeGb);
            Controls.Add(toggleBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinAudioLoopback";
            FormClosing += App_FormClosing;
            Load += App_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)volumeTb).EndInit();
            volumeGb.ResumeLayout(false);
            volumeGb.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox inputDevicesCB;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox outputDevicesCB;
        private Button toggleBtn;
        private TrackBar volumeTb;
        private GroupBox volumeGb;
    }
}
