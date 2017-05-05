using Goman_Plugin.Modules.PokemonFeeder;
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
            this.tpAutoFavoriteShiny = new System.Windows.Forms.TabPage();
            this.autoFavoriteShinyUserControl1 = new Goman_Plugin.Modules.AutoFavoriteShiny.AutoFavoriteShinyUserControl();
            this.tbAutoEvolveEspeonUmbreon = new System.Windows.Forms.TabPage();
            this.autoEvolveEspeonUmbreonControl1 = new Goman_Plugin.Modules.AutoEvolveEspeonUmbreon.AutoEvolveEspeonUmbreonControl();
            this.tabAutoRename100IVOnCaught = new System.Windows.Forms.TabPage();
            this.autoRename100IVOnCaughtUserControl1 = new Goman_Plugin.Modules.AutoRename100IVOnCaught.AutoRename100IVOnCaughtUserControl();
            this.tpPokemonManager = new System.Windows.Forms.TabPage();
            this.pokemonManagerUserControl1 = new Goman_Plugin.Modules.PokemonManager.PokemonManagerUserControl();
            this.tpPokemonFeeder = new System.Windows.Forms.TabPage();
            this.pokemonFeederUserControl1 = new Goman_Plugin.Modules.PokemonFeeder.PokemonFeederUserControl();
            this.tpAccountMap = new System.Windows.Forms.TabPage();
            this._accountMapUserControl1 = new Goman_Plugin.Modules.AccountMap.AccountMapUserControl();
            this.tpGlobalSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.numericUpDownMaximumLogs = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumLogs = new System.Windows.Forms.Label();
            this.cbkSaveLogs = new System.Windows.Forms.CheckBox();
            this.cbkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tpAutoStratTechnique = new System.Windows.Forms.TabPage();
            this.autoStratTechniqueUserControl1 = new Goman_Plugin.Modules.AutoStratTechnique.AutoStratTechniqueUserControl();
            this.statusStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tpCaptcha.SuspendLayout();
            this.tpAutoFavoriteShiny.SuspendLayout();
            this.tbAutoEvolveEspeonUmbreon.SuspendLayout();
            this.tabAutoRename100IVOnCaught.SuspendLayout();
            this.tpPokemonManager.SuspendLayout();
            this.tpPokemonFeeder.SuspendLayout();
            this.tpAccountMap.SuspendLayout();
            this.tpGlobalSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).BeginInit();
            this.tpAutoStratTechnique.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1118, 22);
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
            this.tabControlMain.Controls.Add(this.tpAutoFavoriteShiny);
            this.tabControlMain.Controls.Add(this.tbAutoEvolveEspeonUmbreon);
            this.tabControlMain.Controls.Add(this.tabAutoRename100IVOnCaught);
            this.tabControlMain.Controls.Add(this.tpPokemonManager);
            this.tabControlMain.Controls.Add(this.tpPokemonFeeder);
            this.tabControlMain.Controls.Add(this.tpAccountMap);
            this.tabControlMain.Controls.Add(this.tpAutoStratTechnique);
            this.tabControlMain.Controls.Add(this.tpGlobalSettings);
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 115);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1118, 302);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpCaptcha
            // 
            this.tpCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpCaptcha.Controls.Add(this.captchaUserControl1);
            this.tpCaptcha.ForeColor = System.Drawing.Color.LightGray;
            this.tpCaptcha.Location = new System.Drawing.Point(116, 1);
            this.tpCaptcha.Name = "tpCaptcha";
            this.tpCaptcha.Size = new System.Drawing.Size(1001, 300);
            this.tpCaptcha.TabIndex = 0;
            this.tpCaptcha.Text = "Captcha";
            // 
            // captchaUserControl1
            // 
            this.captchaUserControl1.Location = new System.Drawing.Point(0, 0);
            this.captchaUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.captchaUserControl1.Name = "captchaUserControl1";
            this.captchaUserControl1.Size = new System.Drawing.Size(1032, 302);
            this.captchaUserControl1.TabIndex = 0;
            // 
            // tpAutoFavoriteShiny
            // 
            this.tpAutoFavoriteShiny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpAutoFavoriteShiny.Controls.Add(this.autoFavoriteShinyUserControl1);
            this.tpAutoFavoriteShiny.ForeColor = System.Drawing.Color.LightGray;
            this.tpAutoFavoriteShiny.Location = new System.Drawing.Point(116, 1);
            this.tpAutoFavoriteShiny.Name = "tpAutoFavoriteShiny";
            this.tpAutoFavoriteShiny.Size = new System.Drawing.Size(1001, 300);
            this.tpAutoFavoriteShiny.TabIndex = 5;
            this.tpAutoFavoriteShiny.Text = "Favorite Shiny";
            // 
            // autoFavoriteShinyUserControl1
            // 
            this.autoFavoriteShinyUserControl1.Location = new System.Drawing.Point(0, -1);
            this.autoFavoriteShinyUserControl1.Name = "autoFavoriteShinyUserControl1";
            this.autoFavoriteShinyUserControl1.Size = new System.Drawing.Size(1001, 301);
            this.autoFavoriteShinyUserControl1.TabIndex = 0;
            // 
            // tbAutoEvolveEspeonUmbreon
            // 
            this.tbAutoEvolveEspeonUmbreon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tbAutoEvolveEspeonUmbreon.Controls.Add(this.autoEvolveEspeonUmbreonControl1);
            this.tbAutoEvolveEspeonUmbreon.Location = new System.Drawing.Point(116, 1);
            this.tbAutoEvolveEspeonUmbreon.Name = "tbAutoEvolveEspeonUmbreon";
            this.tbAutoEvolveEspeonUmbreon.Size = new System.Drawing.Size(1001, 300);
            this.tbAutoEvolveEspeonUmbreon.TabIndex = 6;
            this.tbAutoEvolveEspeonUmbreon.Text = "Evolve Espeon Umbreon";
            // 
            // autoEvolveEspeonUmbreonControl1
            // 
            this.autoEvolveEspeonUmbreonControl1.Location = new System.Drawing.Point(0, -1);
            this.autoEvolveEspeonUmbreonControl1.Name = "autoEvolveEspeonUmbreonControl1";
            this.autoEvolveEspeonUmbreonControl1.Size = new System.Drawing.Size(1002, 301);
            this.autoEvolveEspeonUmbreonControl1.TabIndex = 0;
            // 
            // tabAutoRename100IVOnCaught
            // 
            this.tabAutoRename100IVOnCaught.Controls.Add(this.autoRename100IVOnCaughtUserControl1);
            this.tabAutoRename100IVOnCaught.Location = new System.Drawing.Point(116, 1);
            this.tabAutoRename100IVOnCaught.Name = "tabAutoRename100IVOnCaught";
            this.tabAutoRename100IVOnCaught.Size = new System.Drawing.Size(1001, 300);
            this.tabAutoRename100IVOnCaught.TabIndex = 7;
            this.tabAutoRename100IVOnCaught.Text = "AutoRename100IV";
            this.tabAutoRename100IVOnCaught.UseVisualStyleBackColor = true;
            // 
            // autoRename100IVOnCaughtUserControl1
            // 
            this.autoRename100IVOnCaughtUserControl1.Location = new System.Drawing.Point(0, -1);
            this.autoRename100IVOnCaughtUserControl1.Name = "autoRename100IVOnCaughtUserControl1";
            this.autoRename100IVOnCaughtUserControl1.Size = new System.Drawing.Size(1002, 302);
            this.autoRename100IVOnCaughtUserControl1.TabIndex = 0;
            // 
            // tpPokemonManager
            // 
            this.tpPokemonManager.Controls.Add(this.pokemonManagerUserControl1);
            this.tpPokemonManager.Location = new System.Drawing.Point(116, 1);
            this.tpPokemonManager.Name = "tpPokemonManager";
            this.tpPokemonManager.Size = new System.Drawing.Size(1001, 300);
            this.tpPokemonManager.TabIndex = 4;
            this.tpPokemonManager.Text = "Pokemon Manager";
            this.tpPokemonManager.UseVisualStyleBackColor = true;
            // 
            // pokemonManagerUserControl1
            // 
            this.pokemonManagerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonManagerUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonManagerUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.pokemonManagerUserControl1.Name = "pokemonManagerUserControl1";
            this.pokemonManagerUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.pokemonManagerUserControl1.TabIndex = 0;
            // 
            // tpPokemonFeeder
            // 
            this.tpPokemonFeeder.Controls.Add(this.pokemonFeederUserControl1);
            this.tpPokemonFeeder.Location = new System.Drawing.Point(116, 1);
            this.tpPokemonFeeder.Name = "tpPokemonFeeder";
            this.tpPokemonFeeder.Size = new System.Drawing.Size(1001, 300);
            this.tpPokemonFeeder.TabIndex = 2;
            this.tpPokemonFeeder.Text = "Pokemon Feeder";
            this.tpPokemonFeeder.UseVisualStyleBackColor = true;
            // 
            // pokemonFeederUserControl1
            // 
            this.pokemonFeederUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pokemonFeederUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pokemonFeederUserControl1.Location = new System.Drawing.Point(0, 0);
            this.pokemonFeederUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pokemonFeederUserControl1.Name = "pokemonFeederUserControl1";
            this.pokemonFeederUserControl1.Size = new System.Drawing.Size(1001, 300);
            this.pokemonFeederUserControl1.TabIndex = 0;
            // 
            // tpAccountMap
            // 
            this.tpAccountMap.Controls.Add(this._accountMapUserControl1);
            this.tpAccountMap.Location = new System.Drawing.Point(116, 1);
            this.tpAccountMap.Name = "tpAccountMap";
            this.tpAccountMap.Size = new System.Drawing.Size(1001, 300);
            this.tpAccountMap.TabIndex = 3;
            this.tpAccountMap.Text = "Account Map";
            this.tpAccountMap.UseVisualStyleBackColor = true;
            // 
            // _accountMapUserControl1
            // 
            this._accountMapUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this._accountMapUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountMapUserControl1.Location = new System.Drawing.Point(0, 0);
            this._accountMapUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._accountMapUserControl1.Name = "_accountMapUserControl1";
            this._accountMapUserControl1.Size = new System.Drawing.Size(1001, 300);
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
            this.tpGlobalSettings.Location = new System.Drawing.Point(116, 1);
            this.tpGlobalSettings.Name = "tpGlobalSettings";
            this.tpGlobalSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpGlobalSettings.Size = new System.Drawing.Size(1001, 300);
            this.tpGlobalSettings.TabIndex = 1;
            this.tpGlobalSettings.Text = "Settings";
            // 
            // numericUpDownMaximumLogs
            // 
            this.numericUpDownMaximumLogs.Location = new System.Drawing.Point(6, 52);
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
            this.numericUpDownMaximumLogs.Size = new System.Drawing.Size(54, 20);
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
            this.labelMaximumLogs.Location = new System.Drawing.Point(66, 59);
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
            this.cbkSaveLogs.Location = new System.Drawing.Point(6, 29);
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
            this.cbkAutoUpdate.Location = new System.Drawing.Point(6, 6);
            this.cbkAutoUpdate.Name = "cbkAutoUpdate";
            this.cbkAutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.cbkAutoUpdate.TabIndex = 21;
            this.cbkAutoUpdate.Text = "Auto Update";
            this.cbkAutoUpdate.UseVisualStyleBackColor = true;
            this.cbkAutoUpdate.CheckedChanged += new System.EventHandler(this.ckAutoUpdate_CheckedChanged);
            // 
            // tpAutoStratTechnique
            // 
            this.tpAutoStratTechnique.Controls.Add(this.autoStratTechniqueUserControl1);
            this.tpAutoStratTechnique.Location = new System.Drawing.Point(116, 1);
            this.tpAutoStratTechnique.Name = "tpAutoStratTechnique";
            this.tpAutoStratTechnique.Size = new System.Drawing.Size(1001, 300);
            this.tpAutoStratTechnique.TabIndex = 8;
            this.tpAutoStratTechnique.Text = "Auto Strat";
            this.tpAutoStratTechnique.UseVisualStyleBackColor = true;
            // 
            // autoStratTechniqueUserControl1
            // 
            this.autoStratTechniqueUserControl1.Location = new System.Drawing.Point(0, 0);
            this.autoStratTechniqueUserControl1.Name = "autoStratTechniqueUserControl1";
            this.autoStratTechniqueUserControl1.Size = new System.Drawing.Size(1002, 301);
            this.autoStratTechniqueUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1118, 327);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GoMan Plugin";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tpCaptcha.ResumeLayout(false);
            this.tpAutoFavoriteShiny.ResumeLayout(false);
            this.tbAutoEvolveEspeonUmbreon.ResumeLayout(false);
            this.tabAutoRename100IVOnCaught.ResumeLayout(false);
            this.tpPokemonManager.ResumeLayout(false);
            this.tpPokemonFeeder.ResumeLayout(false);
            this.tpAccountMap.ResumeLayout(false);
            this.tpGlobalSettings.ResumeLayout(false);
            this.tpGlobalSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumLogs)).EndInit();
            this.tpAutoStratTechnique.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tpAccountMap;
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
        private System.Windows.Forms.TabPage tpAutoFavoriteShiny;
        private Modules.AutoFavoriteShiny.AutoFavoriteShinyUserControl autoFavoriteShinyUserControl1;
        private System.Windows.Forms.TabPage tbAutoEvolveEspeonUmbreon;
        private Modules.AutoEvolveEspeonUmbreon.AutoEvolveEspeonUmbreonControl autoEvolveEspeonUmbreonControl1;
        private System.Windows.Forms.TabPage tabAutoRename100IVOnCaught;
        private Modules.AutoRename100IVOnCaught.AutoRename100IVOnCaughtUserControl autoRename100IVOnCaughtUserControl1;
        private System.Windows.Forms.TabPage tpAutoStratTechnique;
        private Modules.AutoStratTechnique.AutoStratTechniqueUserControl autoStratTechniqueUserControl1;
    }
}