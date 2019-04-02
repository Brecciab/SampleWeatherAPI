namespace WeatherDesktop
{
    partial class Main
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
            this.ResultsDisplay = new System.Windows.Forms.TextBox();
            this.Test1 = new System.Windows.Forms.Button();
            this.WeatherServiceURLInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.APIKeyInput = new System.Windows.Forms.TextBox();
            this.SaveFileLocationInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateConfiguration = new System.Windows.Forms.Button();
            this.ZipInformationLocationInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadZipFromFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ZipCodeInput = new System.Windows.Forms.TextBox();
            this.StartMultipleTimers = new System.Windows.Forms.Button();
            this.StopMultipleTimers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultsDisplay
            // 
            this.ResultsDisplay.Location = new System.Drawing.Point(32, 209);
            this.ResultsDisplay.Multiline = true;
            this.ResultsDisplay.Name = "ResultsDisplay";
            this.ResultsDisplay.Size = new System.Drawing.Size(559, 301);
            this.ResultsDisplay.TabIndex = 0;
            // 
            // Test1
            // 
            this.Test1.Location = new System.Drawing.Point(609, 206);
            this.Test1.Name = "Test1";
            this.Test1.Size = new System.Drawing.Size(121, 37);
            this.Test1.TabIndex = 1;
            this.Test1.Text = "Single Web Call";
            this.Test1.UseVisualStyleBackColor = true;
            this.Test1.Click += new System.EventHandler(this.Test1_ClickAsync);
            // 
            // WeatherServiceURLInput
            // 
            this.WeatherServiceURLInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeatherServiceURLInput.Location = new System.Drawing.Point(185, 27);
            this.WeatherServiceURLInput.Name = "WeatherServiceURLInput";
            this.WeatherServiceURLInput.Size = new System.Drawing.Size(545, 20);
            this.WeatherServiceURLInput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "APIKey:";
            // 
            // APIKeyInput
            // 
            this.APIKeyInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APIKeyInput.Location = new System.Drawing.Point(185, 64);
            this.APIKeyInput.Name = "APIKeyInput";
            this.APIKeyInput.Size = new System.Drawing.Size(545, 20);
            this.APIKeyInput.TabIndex = 5;
            // 
            // SaveFileLocationInput
            // 
            this.SaveFileLocationInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveFileLocationInput.Location = new System.Drawing.Point(185, 101);
            this.SaveFileLocationInput.Name = "SaveFileLocationInput";
            this.SaveFileLocationInput.Size = new System.Drawing.Size(545, 20);
            this.SaveFileLocationInput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Save File Location:";
            // 
            // UpdateConfiguration
            // 
            this.UpdateConfiguration.Location = new System.Drawing.Point(609, 259);
            this.UpdateConfiguration.Name = "UpdateConfiguration";
            this.UpdateConfiguration.Size = new System.Drawing.Size(121, 37);
            this.UpdateConfiguration.TabIndex = 9;
            this.UpdateConfiguration.Text = "Update Configuration";
            this.UpdateConfiguration.UseVisualStyleBackColor = true;
            this.UpdateConfiguration.Click += new System.EventHandler(this.UpdateConfiguration_Click);
            // 
            // ZipInformationLocationInput
            // 
            this.ZipInformationLocationInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZipInformationLocationInput.Location = new System.Drawing.Point(185, 138);
            this.ZipInformationLocationInput.Name = "ZipInformationLocationInput";
            this.ZipInformationLocationInput.Size = new System.Drawing.Size(545, 20);
            this.ZipInformationLocationInput.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "ZipCodes Location:";
            // 
            // LoadZipFromFile
            // 
            this.LoadZipFromFile.Location = new System.Drawing.Point(609, 314);
            this.LoadZipFromFile.Name = "LoadZipFromFile";
            this.LoadZipFromFile.Size = new System.Drawing.Size(121, 37);
            this.LoadZipFromFile.TabIndex = 12;
            this.LoadZipFromFile.Text = "Load ZipCodes from File";
            this.LoadZipFromFile.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Single Zip Code:";
            // 
            // ZipCodeInput
            // 
            this.ZipCodeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZipCodeInput.Location = new System.Drawing.Point(185, 173);
            this.ZipCodeInput.Name = "ZipCodeInput";
            this.ZipCodeInput.Size = new System.Drawing.Size(545, 20);
            this.ZipCodeInput.TabIndex = 14;
            // 
            // StartMultipleTimers
            // 
            this.StartMultipleTimers.Location = new System.Drawing.Point(609, 368);
            this.StartMultipleTimers.Name = "StartMultipleTimers";
            this.StartMultipleTimers.Size = new System.Drawing.Size(121, 37);
            this.StartMultipleTimers.TabIndex = 15;
            this.StartMultipleTimers.Text = "Start Multiple Timers";
            this.StartMultipleTimers.UseVisualStyleBackColor = true;
            this.StartMultipleTimers.Click += new System.EventHandler(this.StartMultipleTimers_Click);
            // 
            // StopMultipleTimers
            // 
            this.StopMultipleTimers.Location = new System.Drawing.Point(609, 423);
            this.StopMultipleTimers.Name = "StopMultipleTimers";
            this.StopMultipleTimers.Size = new System.Drawing.Size(121, 37);
            this.StopMultipleTimers.TabIndex = 16;
            this.StopMultipleTimers.Text = "Stop Multiple Timers";
            this.StopMultipleTimers.UseVisualStyleBackColor = true;
            this.StopMultipleTimers.Click += new System.EventHandler(this.StopMultipleTimers_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.StopMultipleTimers);
            this.Controls.Add(this.StartMultipleTimers);
            this.Controls.Add(this.ZipCodeInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LoadZipFromFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ZipInformationLocationInput);
            this.Controls.Add(this.UpdateConfiguration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SaveFileLocationInput);
            this.Controls.Add(this.APIKeyInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WeatherServiceURLInput);
            this.Controls.Add(this.Test1);
            this.Controls.Add(this.ResultsDisplay);
            this.Name = "Main";
            this.Text = "Basic Weather API service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultsDisplay;
        private System.Windows.Forms.Button Test1;
        private System.Windows.Forms.TextBox WeatherServiceURLInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox APIKeyInput;
        private System.Windows.Forms.TextBox SaveFileLocationInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UpdateConfiguration;
        private System.Windows.Forms.TextBox ZipInformationLocationInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LoadZipFromFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ZipCodeInput;
        private System.Windows.Forms.Button StartMultipleTimers;
        private System.Windows.Forms.Button StopMultipleTimers;
    }
}

