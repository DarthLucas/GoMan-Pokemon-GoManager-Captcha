using Goman_Plugin.View;

namespace Goman_Plugin.Modules.PokemonManager
{
    partial class PokemonManagerUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.olvLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAccountState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSuccessCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFailedCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPokestopsFarmed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPokemonCaught = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvExp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvExpPerHour = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLevelUp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRunningTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBotState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvProxy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setIVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setQuantityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpgradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoEvolveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlCaptcha = new Goman_Plugin.View.BorderlessTabControl();
            this.tpSettings = new Goman_Plugin.View.BorderlessTabPage();
            this.fastObjectListViewPokemon = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnPokemonId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMinimumIv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMinimumCp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAutoRenameWithIv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAutoFavorite = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAutoUpgrade = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAutoEvolve = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbkEnabled = new System.Windows.Forms.CheckBox();
            this.tpLogs = new Goman_Plugin.View.BorderlessTabPage();
            this.fastObjectListViewLogs = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExceptionMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStackTrace = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.autoRenameToIVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlCaptcha.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewPokemon)).BeginInit();
            this.tpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // olvLevel
            // 
            this.olvLevel.AspectName = "Manager.Level";
            this.olvLevel.DisplayIndex = 1;
            this.olvLevel.Text = "Level";
            this.olvLevel.Width = 42;
            // 
            // olvAccountState
            // 
            this.olvAccountState.AspectName = "Manager.AccountState";
            this.olvAccountState.DisplayIndex = 2;
            this.olvAccountState.Text = "Account State";
            this.olvAccountState.Width = 87;
            // 
            // olvSuccessCount
            // 
            this.olvSuccessCount.AspectName = "SuccessCount";
            this.olvSuccessCount.DisplayIndex = 3;
            this.olvSuccessCount.Text = "Success Count";
            this.olvSuccessCount.Width = 54;
            // 
            // olvFailedCount
            // 
            this.olvFailedCount.AspectName = "FailedCount";
            this.olvFailedCount.DisplayIndex = 4;
            this.olvFailedCount.Text = "Failed Count";
            this.olvFailedCount.Width = 40;
            // 
            // olvPokestopsFarmed
            // 
            this.olvPokestopsFarmed.AspectName = "Manager.PokestopsFarmed";
            this.olvPokestopsFarmed.DisplayIndex = 5;
            this.olvPokestopsFarmed.Text = "Pokestops/23hr";
            this.olvPokestopsFarmed.Width = 40;
            // 
            // olvPokemonCaught
            // 
            this.olvPokemonCaught.AspectName = "Manager.PokemonCaught";
            this.olvPokemonCaught.DisplayIndex = 6;
            this.olvPokemonCaught.Text = "Pokemon/23hr";
            this.olvPokemonCaught.Width = 37;
            // 
            // olvExp
            // 
            this.olvExp.AspectName = "Manager.ExpRatio";
            this.olvExp.DisplayIndex = 7;
            this.olvExp.Text = "Exp";
            this.olvExp.Width = 50;
            // 
            // olvExpPerHour
            // 
            this.olvExpPerHour.AspectName = "Manager.ExpPerHour";
            this.olvExpPerHour.DisplayIndex = 8;
            this.olvExpPerHour.Text = "Exp/Hr";
            this.olvExpPerHour.Width = 52;
            // 
            // olvLevelUp
            // 
            this.olvLevelUp.AspectName = "Manager.TillLevelUp";
            this.olvLevelUp.DisplayIndex = 9;
            this.olvLevelUp.Text = "Level Up";
            this.olvLevelUp.Width = 42;
            // 
            // olvRunningTime
            // 
            this.olvRunningTime.AspectName = "Manager.RunningTime";
            this.olvRunningTime.DisplayIndex = 10;
            this.olvRunningTime.Text = "Time";
            this.olvRunningTime.Width = 48;
            // 
            // olvBotState
            // 
            this.olvBotState.AspectName = "Manager.State";
            this.olvBotState.DisplayIndex = 11;
            this.olvBotState.Text = "Bot State";
            this.olvBotState.Width = 61;
            // 
            // olvProxy
            // 
            this.olvProxy.AspectName = "Manager.Proxy";
            this.olvProxy.DisplayIndex = 12;
            this.olvProxy.Text = "Proxy";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.autoFavoriteToolStripMenuItem,
            this.autoUpgradeToolStripMenuItem,
            this.autoEvolveToolStripMenuItem,
            this.autoRenameToIVToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setIVToolStripMenuItem,
            this.setCPToolStripMenuItem,
            this.setQuantityToolStripMenuItem});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // setIVToolStripMenuItem
            // 
            this.setIVToolStripMenuItem.Name = "setIVToolStripMenuItem";
            this.setIVToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setIVToolStripMenuItem.Text = "Set Minimum IV";
            this.setIVToolStripMenuItem.Click += new System.EventHandler(this.setIVToolStripMenuItem_Click);
            // 
            // setCPToolStripMenuItem
            // 
            this.setCPToolStripMenuItem.Name = "setCPToolStripMenuItem";
            this.setCPToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setCPToolStripMenuItem.Text = "Set Minimum CP";
            this.setCPToolStripMenuItem.Click += new System.EventHandler(this.setCPToolStripMenuItem_Click);
            // 
            // setQuantityToolStripMenuItem
            // 
            this.setQuantityToolStripMenuItem.Name = "setQuantityToolStripMenuItem";
            this.setQuantityToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setQuantityToolStripMenuItem.Text = "Set Quantity";
            this.setQuantityToolStripMenuItem.Click += new System.EventHandler(this.setQuantityToolStripMenuItem_Click);
            // 
            // autoFavoriteToolStripMenuItem
            // 
            this.autoFavoriteToolStripMenuItem.Checked = true;
            this.autoFavoriteToolStripMenuItem.CheckOnClick = true;
            this.autoFavoriteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFavoriteToolStripMenuItem.Name = "autoFavoriteToolStripMenuItem";
            this.autoFavoriteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.autoFavoriteToolStripMenuItem.Text = "Auto Favorite";
            this.autoFavoriteToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoFavoriteToolStripMenuItem_CheckedChanged);
            // 
            // autoUpgradeToolStripMenuItem
            // 
            this.autoUpgradeToolStripMenuItem.Checked = true;
            this.autoUpgradeToolStripMenuItem.CheckOnClick = true;
            this.autoUpgradeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpgradeToolStripMenuItem.Name = "autoUpgradeToolStripMenuItem";
            this.autoUpgradeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.autoUpgradeToolStripMenuItem.Text = "Auto Upgrade";
            this.autoUpgradeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoUpgradeToolStripMenuItem_CheckedChanged);
            // 
            // autoEvolveToolStripMenuItem
            // 
            this.autoEvolveToolStripMenuItem.Checked = true;
            this.autoEvolveToolStripMenuItem.CheckOnClick = true;
            this.autoEvolveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoEvolveToolStripMenuItem.Name = "autoEvolveToolStripMenuItem";
            this.autoEvolveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.autoEvolveToolStripMenuItem.Text = "Auto Evolve";
            this.autoEvolveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoEvolveToolStripMenuItem_CheckedChanged);
            // 
            // tabControlCaptcha
            // 
            this.tabControlCaptcha.Controls.Add(this.tpSettings);
            this.tabControlCaptcha.Controls.Add(this.tpLogs);
            this.tabControlCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCaptcha.ItemSize = new System.Drawing.Size(26, 30);
            this.tabControlCaptcha.Location = new System.Drawing.Point(0, 0);
            this.tabControlCaptcha.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlCaptcha.Multiline = true;
            this.tabControlCaptcha.Name = "tabControlCaptcha";
            this.tabControlCaptcha.SelectedIndex = 0;
            this.tabControlCaptcha.Size = new System.Drawing.Size(1003, 580);
            this.tabControlCaptcha.TabIndex = 2;
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpSettings.Controls.Add(this.fastObjectListViewPokemon);
            this.tpSettings.Controls.Add(this.cbkEnabled);
            this.tpSettings.ForeColor = System.Drawing.Color.LightGray;
            this.tpSettings.Location = new System.Drawing.Point(0, 30);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(4);
            this.tpSettings.Size = new System.Drawing.Size(1003, 550);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            // 
            // fastObjectListViewPokemon
            // 
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnPokemonId);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnQuantity);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnMinimumIv);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnMinimumCp);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnAutoRenameWithIv);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnAutoFavorite);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnAutoUpgrade);
            this.fastObjectListViewPokemon.AllColumns.Add(this.olvColumnAutoEvolve);
            this.fastObjectListViewPokemon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastObjectListViewPokemon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewPokemon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewPokemon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnPokemonId,
            this.olvColumnQuantity,
            this.olvColumnMinimumIv,
            this.olvColumnMinimumCp,
            this.olvColumnAutoRenameWithIv,
            this.olvColumnAutoFavorite,
            this.olvColumnAutoUpgrade,
            this.olvColumnAutoEvolve});
            this.fastObjectListViewPokemon.ContextMenuStrip = this.contextMenuStrip1;
            this.fastObjectListViewPokemon.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewPokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjectListViewPokemon.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewPokemon.FullRowSelect = true;
            this.fastObjectListViewPokemon.Location = new System.Drawing.Point(0, 34);
            this.fastObjectListViewPokemon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fastObjectListViewPokemon.Name = "fastObjectListViewPokemon";
            this.fastObjectListViewPokemon.ShowGroups = false;
            this.fastObjectListViewPokemon.Size = new System.Drawing.Size(1000, 506);
            this.fastObjectListViewPokemon.TabIndex = 13;
            this.fastObjectListViewPokemon.UseCellFormatEvents = true;
            this.fastObjectListViewPokemon.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewPokemon.UseFilterIndicator = true;
            this.fastObjectListViewPokemon.UseFiltering = true;
            this.fastObjectListViewPokemon.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewPokemon.VirtualMode = true;
            this.fastObjectListViewPokemon.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListViewPokemon_FormatCell);
            // 
            // olvColumnPokemonId
            // 
            this.olvColumnPokemonId.AspectName = "PokemonName";
            this.olvColumnPokemonId.Text = "Pokemon";
            this.olvColumnPokemonId.Width = 123;
            // 
            // olvColumnQuantity
            // 
            this.olvColumnQuantity.AspectName = "Quantity";
            this.olvColumnQuantity.Text = "Quantity";
            // 
            // olvColumnMinimumIv
            // 
            this.olvColumnMinimumIv.AspectName = "MinimumIv";
            this.olvColumnMinimumIv.Text = "Minimum IV";
            this.olvColumnMinimumIv.Width = 68;
            // 
            // olvColumnMinimumCp
            // 
            this.olvColumnMinimumCp.AspectName = "MinimumCp";
            this.olvColumnMinimumCp.Text = "Minimum Cp";
            this.olvColumnMinimumCp.Width = 71;
            // 
            // olvColumnAutoRenameWithIv
            // 
            this.olvColumnAutoRenameWithIv.AspectName = "AutoRenameWithIv";
            this.olvColumnAutoRenameWithIv.Text = "Rename With IV";
            this.olvColumnAutoRenameWithIv.Width = 96;
            // 
            // olvColumnAutoFavorite
            // 
            this.olvColumnAutoFavorite.AspectName = "AutoFavorite";
            this.olvColumnAutoFavorite.Text = "Auto Favorite";
            this.olvColumnAutoFavorite.Width = 83;
            // 
            // olvColumnAutoUpgrade
            // 
            this.olvColumnAutoUpgrade.AspectName = "AutoUpgrade";
            this.olvColumnAutoUpgrade.Text = "Auto Upgrade";
            this.olvColumnAutoUpgrade.Width = 81;
            // 
            // olvColumnAutoEvolve
            // 
            this.olvColumnAutoEvolve.AspectName = "AutoEvolve";
            this.olvColumnAutoEvolve.Text = "Auto Evolve";
            this.olvColumnAutoEvolve.Width = 76;
            // 
            // cbkEnabled
            // 
            this.cbkEnabled.AutoSize = true;
            this.cbkEnabled.Checked = true;
            this.cbkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEnabled.Location = new System.Drawing.Point(8, 7);
            this.cbkEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.cbkEnabled.Name = "cbkEnabled";
            this.cbkEnabled.Size = new System.Drawing.Size(78, 20);
            this.cbkEnabled.TabIndex = 12;
            this.cbkEnabled.Text = "Enabled";
            this.cbkEnabled.UseVisualStyleBackColor = true;
            this.cbkEnabled.CheckedChanged += new System.EventHandler(this.cbkEnabled_CheckedChanged);
            // 
            // tpLogs
            // 
            this.tpLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tpLogs.Controls.Add(this.fastObjectListViewLogs);
            this.tpLogs.ForeColor = System.Drawing.Color.LightGray;
            this.tpLogs.Location = new System.Drawing.Point(0, 30);
            this.tpLogs.Margin = new System.Windows.Forms.Padding(4);
            this.tpLogs.Name = "tpLogs";
            this.tpLogs.Size = new System.Drawing.Size(1003, 550);
            this.tpLogs.TabIndex = 3;
            this.tpLogs.Text = "Logs";
            // 
            // fastObjectListViewLogs
            // 
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnDate);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnExceptionMessage);
            this.fastObjectListViewLogs.AllColumns.Add(this.olvColumnStackTrace);
            this.fastObjectListViewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fastObjectListViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDate,
            this.olvColumnMessage,
            this.olvColumnExceptionMessage,
            this.olvColumnStackTrace});
            this.fastObjectListViewLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fastObjectListViewLogs.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewLogs.FullRowSelect = true;
            this.fastObjectListViewLogs.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListViewLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fastObjectListViewLogs.Name = "fastObjectListViewLogs";
            this.fastObjectListViewLogs.ShowGroups = false;
            this.fastObjectListViewLogs.Size = new System.Drawing.Size(1003, 550);
            this.fastObjectListViewLogs.TabIndex = 3;
            this.fastObjectListViewLogs.UseCellFormatEvents = true;
            this.fastObjectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewLogs.UseFilterIndicator = true;
            this.fastObjectListViewLogs.UseFiltering = true;
            this.fastObjectListViewLogs.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewLogs.VirtualMode = true;
            this.fastObjectListViewLogs.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListViewLogs_FormatCell);
            // 
            // olvColumnDate
            // 
            this.olvColumnDate.AspectName = "Date";
            this.olvColumnDate.Text = "Date";
            this.olvColumnDate.Width = 123;
            // 
            // olvColumnMessage
            // 
            this.olvColumnMessage.AspectName = "Message";
            this.olvColumnMessage.Text = "Message";
            this.olvColumnMessage.Width = 176;
            // 
            // olvColumnExceptionMessage
            // 
            this.olvColumnExceptionMessage.AspectName = "ExceptionMessage";
            this.olvColumnExceptionMessage.Text = "Message";
            this.olvColumnExceptionMessage.Width = 174;
            // 
            // olvColumnStackTrace
            // 
            this.olvColumnStackTrace.AspectName = "StackTrace";
            this.olvColumnStackTrace.FillsFreeSpace = true;
            this.olvColumnStackTrace.Text = "StackTrace";
            this.olvColumnStackTrace.Width = 372;
            // 
            // autoRenameToIVToolStripMenuItem
            // 
            this.autoRenameToIVToolStripMenuItem.CheckOnClick = true;
            this.autoRenameToIVToolStripMenuItem.Name = "autoRenameToIVToolStripMenuItem";
            this.autoRenameToIVToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.autoRenameToIVToolStripMenuItem.Text = "Auto Rename With IV";
            this.autoRenameToIVToolStripMenuItem.Click += new System.EventHandler(this.autoRenameToIVToolStripMenuItem_Click);
            // 
            // PokemonManagerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCaptcha);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PokemonManagerUserControl";
            this.Size = new System.Drawing.Size(1003, 580);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControlCaptcha.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewPokemon)).EndInit();
            this.tpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderlessTabControl tabControlCaptcha;
        private BorderlessTabPage tpSettings;
        private System.Windows.Forms.CheckBox cbkEnabled;
        private BorderlessTabPage tpLogs;
        private BrightIdeasSoftware.OLVColumn olvLevel;
        private BrightIdeasSoftware.OLVColumn olvAccountState;
        private BrightIdeasSoftware.OLVColumn olvSuccessCount;
        private BrightIdeasSoftware.OLVColumn olvFailedCount;
        private BrightIdeasSoftware.OLVColumn olvPokestopsFarmed;
        private BrightIdeasSoftware.OLVColumn olvPokemonCaught;
        private BrightIdeasSoftware.OLVColumn olvExp;
        private BrightIdeasSoftware.OLVColumn olvExpPerHour;
        private BrightIdeasSoftware.OLVColumn olvLevelUp;
        private BrightIdeasSoftware.OLVColumn olvRunningTime;
        private BrightIdeasSoftware.OLVColumn olvBotState;
        private BrightIdeasSoftware.OLVColumn olvProxy;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnDate;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnExceptionMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnStackTrace;
        private BrightIdeasSoftware.FastObjectListView fastObjectListViewPokemon;
        private BrightIdeasSoftware.OLVColumn olvColumnPokemonId;
        private BrightIdeasSoftware.OLVColumn olvColumnMinimumIv;
        private BrightIdeasSoftware.OLVColumn olvColumnAutoFavorite;
        private BrightIdeasSoftware.OLVColumn olvColumnAutoUpgrade;
        private BrightIdeasSoftware.OLVColumn olvColumnAutoEvolve;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem autoFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpgradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoEvolveToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumnQuantity;
        private BrightIdeasSoftware.OLVColumn olvColumnMinimumCp;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setIVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setQuantityToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumnAutoRenameWithIv;
        private System.Windows.Forms.ToolStripMenuItem autoRenameToIVToolStripMenuItem;
    }
}
