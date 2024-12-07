namespace Garland
{
    partial class Form1
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
            start = new Button();
            stop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            slow_button = new Button();
            centered_button = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(456, 372);
            start.Name = "start";
            start.Size = new Size(118, 29);
            start.TabIndex = 0;
            start.Text = "Fast";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // stop
            // 
            stop.Location = new Point(590, 372);
            stop.Name = "stop";
            stop.Size = new Size(94, 29);
            stop.TabIndex = 1;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = true;
            stop.Click += stop_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // slow_button
            // 
            slow_button.Location = new Point(456, 407);
            slow_button.Name = "slow_button";
            slow_button.Size = new Size(118, 29);
            slow_button.TabIndex = 0;
            slow_button.Text = "Slow";
            slow_button.Click += slow_button_Click;
            // 
            // centered_button
            // 
            centered_button.Location = new Point(707, 372);
            centered_button.Name = "centered_button";
            centered_button.Size = new Size(94, 29);
            centered_button.TabIndex = 2;
            centered_button.Text = "Centered";
            centered_button.UseVisualStyleBackColor = true;
            centered_button.Click += centered_button_Click;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 616);
            Controls.Add(centered_button);
            Controls.Add(slow_button);
            Controls.Add(stop);
            Controls.Add(start);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button start;
        private Button stop;
        private System.Windows.Forms.Timer timer1;
        private Button slow_button;
        private Button centered_button;
        private System.Windows.Forms.Timer timer2;
    }
}
