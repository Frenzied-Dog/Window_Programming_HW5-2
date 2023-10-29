namespace hw5_2_10_20 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            Timer1 = new System.Windows.Forms.Timer(components);
            StateLabel = new Label();
            StartBtn = new Button();
            TurnLabel = new Label();
            CdLebel = new Label();
            AttrLabel1 = new Label();
            AttrLabel2 = new Label();
            AttrLabel3 = new Label();
            AtkBtn = new Button();
            SkillBtn = new Button();
            UltBtn = new Button();
            TeamLabel1 = new Label();
            BossLabel = new Label();
            TeamLabel2 = new Label();
            SuspendLayout();
            // 
            // Timer1
            // 
            Timer1.Interval = 1000;
            Timer1.Tick += Timer1_Tick;
            // 
            // StateLabel
            // 
            StateLabel.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            StateLabel.Location = new Point(327, 50);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new Size(150, 40);
            StateLabel.TabIndex = 4;
            StateLabel.Text = "準備階段";
            StateLabel.TextAlign = ContentAlignment.TopCenter;
            StateLabel.Visible = false;
            // 
            // StartBtn
            // 
            StartBtn.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            StartBtn.Location = new Point(300, 280);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(200, 80);
            StartBtn.TabIndex = 0;
            StartBtn.Text = "開始遊戲";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // TurnLabel
            // 
            TurnLabel.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TurnLabel.Location = new Point(300, 400);
            TurnLabel.Name = "TurnLabel";
            TurnLabel.Size = new Size(200, 45);
            TurnLabel.TabIndex = 5;
            TurnLabel.TextAlign = ContentAlignment.TopCenter;
            TurnLabel.Visible = false;
            // 
            // CdLebel
            // 
            CdLebel.FlatStyle = FlatStyle.System;
            CdLebel.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            CdLebel.Location = new Point(375, 100);
            CdLebel.Name = "CdLebel";
            CdLebel.Size = new Size(50, 35);
            CdLebel.TabIndex = 6;
            CdLebel.Text = "10";
            CdLebel.TextAlign = ContentAlignment.TopCenter;
            CdLebel.Visible = false;
            // 
            // AttrLabel1
            // 
            AttrLabel1.AutoSize = true;
            AttrLabel1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            AttrLabel1.Location = new Point(102, 280);
            AttrLabel1.Name = "AttrLabel1";
            AttrLabel1.Size = new Size(109, 75);
            AttrLabel1.TabIndex = 7;
            AttrLabel1.Text = "HP = 100\r\nAttack = 3\r\nSpeed = 1\r\n";
            AttrLabel1.Visible = false;
            // 
            // AttrLabel2
            // 
            AttrLabel2.AutoSize = true;
            AttrLabel2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            AttrLabel2.Location = new Point(350, 280);
            AttrLabel2.Name = "AttrLabel2";
            AttrLabel2.Size = new Size(109, 75);
            AttrLabel2.TabIndex = 7;
            AttrLabel2.Text = "HP = 100\r\nAttack = 2\r\nSpeed = 2\r\n";
            AttrLabel2.Visible = false;
            // 
            // AttrLabel3
            // 
            AttrLabel3.AutoSize = true;
            AttrLabel3.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            AttrLabel3.Location = new Point(590, 280);
            AttrLabel3.Name = "AttrLabel3";
            AttrLabel3.Size = new Size(109, 75);
            AttrLabel3.TabIndex = 7;
            AttrLabel3.Text = "HP = 100\r\nAttack = 4\r\nSpeed = 4\r\n";
            AttrLabel3.Visible = false;
            // 
            // AtkBtn
            // 
            AtkBtn.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            AtkBtn.Location = new Point(330, 160);
            AtkBtn.Name = "AtkBtn";
            AtkBtn.Size = new Size(140, 40);
            AtkBtn.TabIndex = 8;
            AtkBtn.Text = "普攻";
            AtkBtn.UseVisualStyleBackColor = true;
            AtkBtn.Visible = false;
            // 
            // SkillBtn
            // 
            SkillBtn.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            SkillBtn.Location = new Point(330, 245);
            SkillBtn.Name = "SkillBtn";
            SkillBtn.Size = new Size(140, 40);
            SkillBtn.TabIndex = 9;
            SkillBtn.Text = "技能";
            SkillBtn.UseVisualStyleBackColor = true;
            SkillBtn.Visible = false;
            // 
            // UltBtn
            // 
            UltBtn.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            UltBtn.Location = new Point(330, 325);
            UltBtn.Name = "UltBtn";
            UltBtn.Size = new Size(140, 40);
            UltBtn.TabIndex = 10;
            UltBtn.Text = "寶具";
            UltBtn.UseVisualStyleBackColor = true;
            UltBtn.Visible = false;
            // 
            // TeamLabel1
            // 
            TeamLabel1.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TeamLabel1.Location = new Point(70, 80);
            TeamLabel1.Name = "TeamLabel1";
            TeamLabel1.Size = new Size(200, 150);
            TeamLabel1.TabIndex = 11;
            TeamLabel1.TextAlign = ContentAlignment.TopCenter;
            TeamLabel1.Visible = false;
            // 
            // BossLabel
            // 
            BossLabel.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            BossLabel.Location = new Point(535, 160);
            BossLabel.Name = "BossLabel";
            BossLabel.Size = new Size(200, 150);
            BossLabel.TabIndex = 12;
            BossLabel.TextAlign = ContentAlignment.TopCenter;
            BossLabel.Visible = false;
            // 
            // TeamLabel2
            // 
            TeamLabel2.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TeamLabel2.Location = new Point(70, 270);
            TeamLabel2.Name = "TeamLabel2";
            TeamLabel2.Size = new Size(200, 150);
            TeamLabel2.TabIndex = 11;
            TeamLabel2.TextAlign = ContentAlignment.TopCenter;
            TeamLabel2.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(BossLabel);
            Controls.Add(TeamLabel2);
            Controls.Add(TeamLabel1);
            Controls.Add(UltBtn);
            Controls.Add(SkillBtn);
            Controls.Add(AtkBtn);
            Controls.Add(AttrLabel3);
            Controls.Add(AttrLabel2);
            Controls.Add(AttrLabel1);
            Controls.Add(CdLebel);
            Controls.Add(TurnLabel);
            Controls.Add(StateLabel);
            Controls.Add(StartBtn);
            Name = "Form1";
            Text = "Games";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer Timer1;
        private Label StateLabel;
        private Button StartBtn;
        private Label TurnLabel;
        private Label CdLebel;
        private Label AttrLabel1;
        private Label AttrLabel2;
        private Label AttrLabel3;
        private Button AtkBtn;
        private Button SkillBtn;
        private Button UltBtn;
        private Label TeamLabel1;
        private Label BossLabel;
        private Label TeamLabel2;
    }
}