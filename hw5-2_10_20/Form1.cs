namespace hw5_2_10_20 {
    public partial class Form1 : Form {
        enum State {
            READY, PREPARE, FIGHT, END
        }
        State state = State.READY;
        List<Servant> team = new();
        Random rnd = new Random();
        int t, turn;
        Button[] btns = new Button[3];
        Button[] fightBtns = new Button[3];
        Label[] attrs = new Label[3];
        Label[] fightLabels = new Label[3];
        Beast boss = new Beast();

        class Servant : ICloneable {
            public object Clone() {
                return MemberwiseClone();
            }
            public string? character;
            public int hp, charge, atk, speed, cd;
            public virtual void Skill() { }
            public virtual string Ult(List<Servant> team, Servant boss) { return ""; }
            public void Atk(Servant target) { target.hp -= atk; }
        }

        class Saber : Servant {
            public Saber() {
                character = "Saber";
                hp = 100; charge = 0; atk = 3;
                speed = 1; cd = 2;
            }
            override public void Skill() { atk *= 2; }
            override public string Ult(List<Servant> team, Servant boss) {
                hp += 5;
                boss.hp -= atk + 25;
                return $"Saber使用了寶具:\n對Beast造成了{atk + 25}點傷害並回覆5點血量";
            }
        }

        class Caster : Servant {
            public Caster() {
                character = "Caster";
                hp = 100; charge = 0; atk = 2;
                speed = 2; cd = 2;
            }
            override public void Skill() { hp += 100 / 2; }
            override public string Ult(List<Servant> team, Servant boss) {
                foreach (Servant s in team) {
                    if (s.character == "Beast") continue;
                    s.atk++; s.hp += 10;
                }
                return $"Caster使用了寶具:\n全體隊友加1點攻擊、回覆10點血量";
            }
        }

        class Berserker : Servant {
            public Berserker() {
                character = "Berserker";
                hp = 100; charge = 0; atk = 4;
                speed = 4; cd = 2;
            }
            override public void Skill() { atk *= 2; hp -= hp / 2; }
            override public string Ult(List<Servant> team, Servant boss) {
                boss.hp -= atk + 50;
                return $"Berserker使用了寶具:\n對Beast造成了{atk + 50}點傷害";
            }
        }

        class Beast : Servant {
            public Beast() {
                character = "Beast";
                hp = 500; charge = 0; atk = 2;
                speed = 3; cd = 3;
            }
            override public void Skill() { atk += 2; }
            override public string Ult(List<Servant> team, Servant boss) {
                foreach (Servant s in team) {
                    if (s.character == "Beast") continue;
                    s.hp -= atk * 2;
                }
                return $"Beast使用了寶具:\n對全體隊友造成{atk * 2}點傷害";
            }
        }

        public Form1() {
            InitializeComponent();
            for (int i = 0; i < 3; i++) {
                btns[i] = new Button {
                    Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point),
                    Location = new Point(80 + 245 * i, 180),
                    Name = $"Btn{i}",
                    Size = new Size(150, 70),
                    TabIndex = i,
                    UseVisualStyleBackColor = true,
                    Visible = false,
                };
                btns[i].Click += ChooseBtn_Click;
                Controls.Add(btns[i]);
            }
            btns[0].Tag = new Saber(); btns[0].Text = "Saber";
            btns[1].Tag = new Caster(); btns[1].Text = "Caster";
            btns[2].Tag = new Berserker(); btns[2].Text = "Berserker";
            attrs = new Label[] { AttrLabel1, AttrLabel2, AttrLabel3 };
            fightBtns = new Button[] { AtkBtn, SkillBtn, UltBtn };
            fightLabels = new Label[] { TeamLabel1, TeamLabel2, BossLabel, TurnLabel };
            foreach (Button b in fightBtns) b.Click += FightBtn_Click;
        }

        private void Update_Label(Servant boss) {
            bool first = true;
            foreach (Servant s in team) {
                if (s.character == "Beast") continue;
                if (first) {
                    TeamLabel1.Text = $"{s.character}\nHP: {s.hp}\nCharge: {s.charge}%\nAttack: {s.atk}";
                    first = false;
                } else {
                    TeamLabel2.Text = $"{s.character}\nHP: {s.hp}\nCharge: {s.charge}%\nAttack: {s.atk}";
                }
            }
            if (team.Count < 3) TeamLabel2.Text = "";
            BossLabel.Text = $"Beast\nHP: {boss.hp}\nCharge: {boss.charge}%\nAttack: {boss.atk}";
        }

        private void FightBtn_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            Servant servant = team[turn];
            switch (btn.Text) {
            case "普攻":
                int ifAtk = rnd.Next(0, 100);
                if (ifAtk >= 50) {
                    servant.Atk(boss); servant.Atk(boss);
                    servant.charge += 30;
                    Update_Label(boss);
                    MessageBox.Show($"對Beast造成了{servant.atk * 2}點暴擊傷害");
                } else {
                    servant.Atk(boss);
                    servant.charge += rnd.Next(20, 26);
                    Update_Label(boss);
                }
                break;
            case "技能":
                if (servant.cd > 0) {
                    MessageBox.Show($"技能冷卻中(剩餘回合:{servant.cd})");
                    return;
                }
                servant.Skill();
                Update_Label(boss);
                MessageBox.Show($"{servant.character}使用了技能");
                servant.cd = 3;
                return;
            case "寶具":
                if (servant.charge < 100) {
                    MessageBox.Show($"充能不足，無法施放寶具!");
                    return;
                }
                string str = servant.Ult(team, boss);
                servant.charge -= 100;
                Update_Label(boss);
                MessageBox.Show(str);
                break;
            }
            if (servant.cd > 0) servant.cd--;

            // Check if Beast is dead
            if (boss.hp <= 0) {
                state++;
                Timer1.Stop();
                MessageBox.Show($"You Win!\n通關時間: {t}");
                team.Clear();
                boss = new Beast();
                foreach (Button b in fightBtns) b.Visible = false;
                foreach (Label l in fightLabels) l.Visible = false;
                StartBtn.Visible = true;
                StateLabel.Visible = false;
                CdLebel.Visible = false;
                state = State.READY;
                return;
            }

            // Beast's turn
            if (team[(++turn) % team.Count].character == "Beast") {
                TurnLabel.Text = "Beast turn";
                // Beast's skill
                if (boss.cd == 0) {
                    boss.Skill();
                    boss.cd = 4;
                    Update_Label(boss);
                    MessageBox.Show($"Beast使用了技能\n當前ATK:{boss.atk}");
                }

                // Beast's Ult
                if (boss.charge == 100) {
                    string str = boss.Ult(team, boss);
                    boss.charge = 0;
                    Update_Label(boss);
                    MessageBox.Show(str);
                } else {
                    // Beast's attack
                    foreach (Servant s in team) {
                        if (s.character == "Beast") continue;
                        boss.Atk(s);
                    }
                    boss.charge += 20;
                    Update_Label(boss);
                    MessageBox.Show($"Beast對全體隊友造成{boss.atk}點傷害!");
                }
                boss.cd--;

                foreach (Servant s in team.ToList()) {
                    if (s.character == "Beast") continue;
                    if (s.hp <= 0) {
                        MessageBox.Show($"{s.character}倒下了!");
                        team.Remove(s);
                        if (turn == 2) turn--;
                    }
                }
                // Check if all Servants are dead
                if (team.Count == 1) {
                    state++;
                    Timer1.Stop();
                    MessageBox.Show($"You Lose\n戰鬥時間: {t}");
                    team.Clear();
                    boss = new Beast();
                    foreach (Button b in fightBtns) b.Visible = false;
                    foreach (Label l in fightLabels) l.Visible = false;
                    StartBtn.Visible = true;
                    StateLabel.Visible = false;
                    CdLebel.Visible = false;
                    state = State.READY; 
                    return;
                }
                turn++;
            }
            turn %= team.Count;
            Update_Label(boss);
            TurnLabel.Text = $"{team[turn].character} turn";
        }

        private void StartBtn_Click(object sender, EventArgs e) {
            StateLabel.Visible = true;
            StateLabel.Text = "準備階段";
            CdLebel.Visible = true;
            CdLebel.Text = "10";
            StartBtn.Visible = false;
            foreach (Button b in btns) {
                b.Visible = true;
                b.BackColor = Color.White;
            }
            foreach (Label l in attrs) l.Visible = true;
            state++;
            t = 10;
            Timer1.Start();
        }

        private void ChooseBtn_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int index = team.FindIndex(e => e.character == btn.Text);
            if (index >= 0) {
                team.RemoveAt(index);
                btn.BackColor = Color.White;
            } else if (team.Count < 2) {
                team.Add((Servant)((Servant)btn.Tag).Clone());
                btn.BackColor = Color.LightGreen;
            } else {
                MessageBox.Show("只能選擇兩個Servant!");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            if (state != State.PREPARE && state != State.FIGHT) return;
            if (state == State.PREPARE) {
                CdLebel.Text = (--t).ToString();
                if (t == 0) {
                    if (team.Count < 2) {
                        foreach (Button b in btns) {
                            if (team.Contains(b.Tag)) continue;
                            team.Add((Servant)((Servant)b.Tag).Clone());
                            if (team.Count == 2) break;
                        }
                    }
                    foreach (Button b in btns) b.Visible = false;
                    foreach (Label l in attrs) l.Visible = false;
                    foreach (Button b in fightBtns) b.Visible = true;
                    foreach (Label l in fightLabels) l.Visible = true;
                    StateLabel.Text = "時間";
                    turn = 0;
                    team.Add(boss);
                    team.Sort((a, b) => a.speed - b.speed);
                    Update_Label(boss);
                    TurnLabel.Text = $"{team[turn].character} turn";
                    state++;
                }
            } else {
                CdLebel.Text = (++t).ToString();
            }
        }
    }
}