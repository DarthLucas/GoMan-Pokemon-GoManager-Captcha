﻿using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.Modules.PokemonManager;

namespace Goman_Plugin.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDiscord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDonate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAccountCreator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCheapProxy = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new Goman_Plugin.View.BorderlessTabControl();
            this.tpCaptcha = new System.Windows.Forms.TabPage();
            this.captchaUserControl1 = new Goman_Plugin.Modules.Captcha.CaptchaUserControl();
            this.tpPokemonManager = new System.Windows.Forms.TabPage();
            this.pokemonManagerUserControl1 = new Goman_Plugin.Modules.PokemonManager.PokemonManagerUserControl();
            this.tpPokemonFeeder = new System.Windows.Forms.TabPage();
            this.pokemonFeederUserControl1 = new Goman_Plugin.Modules.PokemonFeeder.PokemonFeederUserControl();
            this.tpAccountFeeder = new System.Windows.Forms.TabPage();
            this._accountMapUserControl1 = new Goman_Plugin.Modules.AccountMap.AccountMapUserControl();
            this.tpGlobalSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.numericUpDownMaximumLogs = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumLogs = new System.Windows.Forms.Label();
            this.cbkSaveLogs = new System.Windows.Forms.CheckBox();
            this.cbkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tpCaptcha.SuspendLayout();
            this.tpPokemonManager.SuspendLayout();
            this.tpPokemonFeeder.SuspendLayout();
            this.tpAccountFeeder.SuspendLayout();
            this.tpGlobalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDiscord,
            this.toolStripStatusLabelDonate,
            this.toolStripStatusLabelAccountCreator,
            this.toolStripStatusLabelCheapProxy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 380);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1491, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDiscord
            // 
            this.toolStripStatusLabelDiscord.IsLink = true;
            this.toolStripStatusLabelDiscord.LinkColor = System.Drawing.Color.Olive;
            this.toolStripStatusLabelDiscord.Name = "toolStripStatusLabelDiscord";
            this.toolStripStatusLabelDiscord.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabelDiscord.Tag = "";
            this.toolStripStatusLabelDiscord.Text = "Discord";
            this.toolStripStatusLabelDiscord.Click += new System.EventHandler(this.toolStripStatusLabelDiscord_Click);
            // 
            // toolStripStatusLabelDonate
            // 
            this.toolStripStatusLabelDonate.IsLink = true;
            this.toolStripStatusLabelDonate.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripStatusLabelDonate.Name = "toolStripStatusLabelDonate";
            this.toolStripStatusLabelDonate.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelDonate.Tag = "";
            this.toolStripStatusLabelDonate.Text = "Donate";
            this.toolStripStatusLabelDonate.Click += new System.EventHandler(this.toolStripStatusLabelDonate_Click);
            // 
            // toolStripStatusLabelAccountCreator
            // 
            this.toolStripStatusLabelAccountCreator.IsLink = true;
            this.toolStripStatusLabelAccountCreator.LinkColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabelAccountCreator.Name = "toolStripStatusLabelAccountCreator";
            this.toolStripStatusLabelAccountCreator.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabelAccountCreator.Tag = "";
            this.toolStripStatusLabelAccountCreator.Text = "Account Creator";
            this.toolStripStatusLabelAccountCreator.Click += new System.EventHandler(this.toolStripStatusLabelAccountCreator_Click);
            // 
            // toolStripStatusLabelCheapProxy
            // 
            this.toolStripStatusLabelCheapProxy.IsLink = true;
            this.toolStripStatusLabelCheapProxy.LinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelCheapProxy.Name = "toolStripStatusLabelCheapProxy";
            this.toolStripStatusLabelCheapProxy.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabelCheapProxy.Tag = "";
            this.toolStripStatusLabelCheapProxy.Text = "Pokemon Go Proxy";
            this.toolStripStatusLabelCheapProxy.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tpCaptcha);
            this.tabControlMain.Controls.Add(this.tpPokemonManager);
            this.tabControlMain.Controls.Add(this.tpPokemonFeeder);
            this.tabControlMain.Controls.Add(this.tpAccountFeeder);
            this.tabControlMain.Controls.Add(this.tpGlobalSettings);
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 115);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1491, 372);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpCaptcha
            // 
            this.tpCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpCaptcha.Controls.Add(this.captchaUserControl1);
            this.tpCaptcha.ForeColor = System.Drawing.Color.LightGray;
            this.tpCaptcha.Location = new System.Drawing.Point(115, 0);
            this.tpCaptcha.Margin = new System.Windows.Forms.Padding(4);
            this.tpCaptcha.Name = "tpCaptcha";
            this.tpCaptcha.Size = new System.Drawing.Size(1376, 372);
            this.tpCaptcha.TabIndex = 0;
            this.tpCaptcha.Text = "Captcha";
            // 
            // captchaUserControl1
            // 
            this.captchaUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captchaUserControl1.Location = new System.Drawing.Point(0, 0);
            this.captchaUserControl1.Margin = new System.Windows.Forms.Padding(5);
            this.captchaUserControl1.Name = "captchaUserControl1";
            this.captchaUserControl1.Size = new System.Drawing.Size(1376, 372);
            this.captchaUserControl1.TabIndex = 0;
            // 
            // tpPokemonManager
            // 
            this.tpPokemonManager.Controls.Add(this.pokemonManagerUserControl1);
            this.tpPokemonManager.Location = new System.Drawing.Point(115, 0);
            this.tpPokemonManager.Margin = new System.Windows.Forms.Padding(4);
            this.tpPokemonManager.Name = "tpPokemonManager";
            this.tpPokemonManager.Size = new System.Drawing.Size(1376, 372);
            this.tpPokemonManager.TabIndex = 4;
            this.tpPokemonManager.Text = "Pokemon Manager";
            this.tpPokemonManager.UseVisualStyleBackColor = true;
            // 
            // pokemonManagerUserControl1
            // 
            this.pokemonManagerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonManagerUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonManagerUserControl1.Margin = new System.Windows.Forms.Padding(5);
            this.pokemonManagerUserControl1.Name = "pokemonManagerUserControl1";
            this.pokemonManagerUserControl1.Size = new System.Drawing.Size(1376, 372);
            this.pokemonManagerUserControl1.TabIndex = 0;
            // 
            // tpPokemonFeeder
            // 
            this.tpPokemonFeeder.Controls.Add(this.pokemonFeederUserControl1);
            this.tpPokemonFeeder.Location = new System.Drawing.Point(115, 0);
            this.tpPokemonFeeder.Margin = new System.Windows.Forms.Padding(4);
            this.tpPokemonFeeder.Name = "tpPokemonFeeder";
            this.tpPokemonFeeder.Size = new System.Drawing.Size(1376, 372);
            this.tpPokemonFeeder.TabIndex = 2;
            this.tpPokemonFeeder.Text = "Pokemon Feeder";
            this.tpPokemonFeeder.UseVisualStyleBackColor = true;
            // 
            // pokemonFeederUserControl1
            // 
            this.pokemonFeederUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pokemonFeederUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonFeederUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonFeederUserControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pokemonFeederUserControl1.Name = "pokemonFeederUserControl1";
            this.pokemonFeederUserControl1.Size = new System.Drawing.Size(1376, 372);
            this.pokemonFeederUserControl1.TabIndex = 0;
            // 
            // tpAccountFeeder
            // 
            this.tpAccountFeeder.Controls.Add(this._accountMapUserControl1);
            this.tpAccountFeeder.Location = new System.Drawing.Point(115, 0);
            this.tpAccountFeeder.Margin = new System.Windows.Forms.Padding(4);
            this.tpAccountFeeder.Name = "tpAccountFeeder";
            this.tpAccountFeeder.Size = new System.Drawing.Size(1376, 372);
            this.tpAccountFeeder.TabIndex = 3;
            this.tpAccountFeeder.Text = "Account Feeder";
            this.tpAccountFeeder.UseVisualStyleBackColor = true;
            // 
            // _accountMapUserControl1
            // 
            this._accountMapUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this._accountMapUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountMapUserControl1.Location = new System.Drawing.Point(0, 0);
            this._accountMapUserControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._accountMapUserControl1.Name = "_accountMapUserControl1";
            this._accountMapUserControl1.Size = new System.Drawing.Size(1376, 372);
            this._accountMapUserControl1.TabIndex = 0;
            // 
            // tpGlobalSettings
            // 
            this.tpGlobalSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpGlobalSettings.Controls.Add(this.numericUpDownMaximumLogs);
            this.tpGlobalSettings.Controls.Add(this.labelMaximumLogs);
            this.tpGlobalSettings.Controls.Add(this.cbkSaveLogs);
            this.tpGlobalSettings.Controls.Add(this.cbkAutoUpdate);
            this.tpGlobalSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpGlobalSettings.Location = new System.Drawing.Point(115, 0);
            this.tpGlobalSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tpGlobalSettings.Name = "tpGlobalSettings";
            this.tpGlobalSettings.Padding = new System.Windows.Forms.Padding(4);
            this.tpGlobalSettings.Size = new System.Drawing.Size(1376, 372);
            this.tpGlobalSettings.TabIndex = 1;
            this.tpGlobalSettings.Text = "Settings";
            // 
            // numericUpDownMaximumLogs
            // 
            this.numericUpDownMaximumLogs.Location = new System.Drawing.Point(8, 64);
            this.numericUpDownMaximumLogs.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownMaximumLogs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.Name = "numericUpDownMaximumLogs";
            this.numericUpDownMaximumLogs.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownMaximumLogs.TabIndex = 25;
            this.numericUpDownMaximumLogs.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMaximumLogs.ValueChanged += new System.EventHandler(this.numericUpDownMaximumLogs_ValueChanged);
            // 
            // labelMaximumLogs
            // 
            this.labelMaximumLogs.AutoSize = true;
            this.labelMaximumLogs.Location = new System.Drawing.Point(88, 73);
            this.labelMaximumLogs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaximumLogs.Name = "labelMaximumLogs";
            this.labelMaximumLogs.Size = new System.Drawing.Size(77, 13);
            this.labelMaximumLogs.TabIndex = 24;
            this.labelMaximumLogs.Text = "Maximum Logs";
            // 
            // cbkSaveLogs
            // 
            this.cbkSaveLogs.AutoSize = true;
            this.cbkSaveLogs.Checked = true;
            this.cbkSaveLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkSaveLogs.Location = new System.Drawing.Point(8, 36);
            this.cbkSaveLogs.Margin = new System.Windows.Forms.Padding(4);
            this.cbkSaveLogs.Name = "cbkSaveLogs";
            this.cbkSaveLogs.Size = new System.Drawing.Size(77, 17);
            this.cbkSaveLogs.TabIndex = 22;
            this.cbkSaveLogs.Text = "Save Logs";
            this.cbkSaveLogs.UseVisualStyleBackColor = true;
            this.cbkSaveLogs.CheckedChanged += new System.EventHandler(this.cbkSaveLogs_CheckedChanged);
            // 
            // cbkAutoUpdate
            // 
            this.cbkAutoUpdate.AutoSize = true;
            this.cbkAutoUpdate.Checked = true;
            this.cbkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkAutoUpdate.Location = new System.Drawing.Point(8, 7);
            this.cbkAutoUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.cbkAutoUpdate.Name = "cbkAutoUpdate";
            this.cbkAutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.cbkAutoUpdate.TabIndex = 21;
            this.cbkAutoUpdate.Text = "Auto Update";
            this.cbkAutoUpdate.UseVisualStyleBackColor = true;
            this.cbkAutoUpdate.CheckedChanged += new System.EventHandler(this.ckAutoUpdate_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1491, 402);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "GoMan Plugin";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tpCaptcha.ResumeLayout(false);
            this.tpPokemonManager.ResumeLayout(false);
            this.tpPokemonFeeder.ResumeLayout(false);
            this.tpAccountFeeder.ResumeLayout(false);
            this.tpGlobalSettings.ResumeLayout(false);
            this.tpGlobalSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BorderlessTabControl tabControlMain;
        private System.Windows.Forms.TabPage tpCaptcha;
        private BorderlessTabPage tpGlobalSettings;
        private System.Windows.Forms.CheckBox cbkAutoUpdate;
        private System.Windows.Forms.CheckBox cbkSaveLogs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCheapProxy;
        private System.Windows.Forms.TabPage tpPokemonFeeder;
        private System.Windows.Forms.TabPage tpAccountFeeder;
        private PokemonFeederUserControl pokemonFeederUserControl1;
        private Modules.AccountMap.AccountMapUserControl _accountMapUserControl1;
        private Modules.Captcha.CaptchaUserControl captchaUserControl1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaximumLogs;
        private System.Windows.Forms.Label labelMaximumLogs;
        private System.Windows.Forms.TabPage tpPokemonManager;
        private PokemonManagerUserControl pokemonManagerUserControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDonate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAccountCreator;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDiscord;
    }
}