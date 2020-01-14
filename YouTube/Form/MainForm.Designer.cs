namespace YouTubeAPP
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.musiclist = new System.Windows.Forms.ListView();
            this.ICON = new System.Windows.Forms.ImageList(this.components);
            this.searchtxt = new MetroFramework.Controls.MetroTextBox();
            this.searchbtn = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.SearchTab = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.MusicPlayTab = new MetroFramework.Controls.MetroTabPage();
            this.addmusicbtn = new MetroFramework.Controls.MetroButton();
            this.soundvaluetext = new MetroFramework.Controls.MetroLabel();
            this.minussec = new MetroFramework.Controls.MetroButton();
            this.plussec = new MetroFramework.Controls.MetroButton();
            this.downbtn = new MetroFramework.Controls.MetroButton();
            this.upbtn = new MetroFramework.Controls.MetroButton();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.playagain = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.musiclist2 = new System.Windows.Forms.ListView();
            this.musicnametxt = new MetroFramework.Controls.MetroLabel();
            this.volumtrackbar = new MetroFramework.Controls.MetroTrackBar();
            this.stopbtn = new MetroFramework.Controls.MetroButton();
            this.randombtn = new MetroFramework.Controls.MetroButton();
            this.nowplaytime = new MetroFramework.Controls.MetroLabel();
            this.totalplaytime = new MetroFramework.Controls.MetroLabel();
            this.musicstatustrackbar = new MetroFramework.Controls.MetroTrackBar();
            this.playbtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.MusicTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayInfinite = new System.Windows.Forms.Timer(this.components);
            this.CheckIndex = new System.Windows.Forms.Timer(this.components);
            this.icontray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hahaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초기화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.랜덤재생ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.다음곡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이전곡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반복재생OFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로그램종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabControl1.SuspendLayout();
            this.SearchTab.SuspendLayout();
            this.MusicPlayTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // musiclist
            // 
            this.musiclist.HideSelection = false;
            this.musiclist.Location = new System.Drawing.Point(4, 36);
            this.musiclist.Name = "musiclist";
            this.musiclist.Size = new System.Drawing.Size(654, 383);
            this.musiclist.SmallImageList = this.ICON;
            this.musiclist.TabIndex = 2;
            this.musiclist.UseCompatibleStateImageBehavior = false;
            this.musiclist.View = System.Windows.Forms.View.List;
            this.musiclist.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.musiclist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.musiclist_KeyDown);
            // 
            // ICON
            // 
            this.ICON.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ICON.ImageStream")));
            this.ICON.TransparentColor = System.Drawing.Color.Transparent;
            this.ICON.Images.SetKeyName(0, "icons8-youtube-64.png");
            // 
            // searchtxt
            // 
            this.searchtxt.Location = new System.Drawing.Point(4, 9);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(460, 21);
            this.searchtxt.TabIndex = 3;
            this.searchtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtxt_KeyDown);
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(470, 9);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(85, 21);
            this.searchbtn.Style = MetroFramework.MetroColorStyle.Black;
            this.searchbtn.TabIndex = 4;
            this.searchbtn.Text = "검색";
            this.searchbtn.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.SearchTab);
            this.metroTabControl1.Controls.Add(this.MusicPlayTab);
            this.metroTabControl1.Location = new System.Drawing.Point(8, 49);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(673, 469);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabControl1.TabIndex = 5;
            // 
            // SearchTab
            // 
            this.SearchTab.Controls.Add(this.metroButton2);
            this.SearchTab.Controls.Add(this.musiclist);
            this.SearchTab.Controls.Add(this.searchbtn);
            this.SearchTab.Controls.Add(this.searchtxt);
            this.SearchTab.HorizontalScrollbarBarColor = true;
            this.SearchTab.Location = new System.Drawing.Point(4, 36);
            this.SearchTab.Name = "SearchTab";
            this.SearchTab.Size = new System.Drawing.Size(665, 429);
            this.SearchTab.TabIndex = 0;
            this.SearchTab.Text = "Search";
            this.SearchTab.VerticalScrollbarBarColor = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(561, 9);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(95, 21);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "인기곡 Top100";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // MusicPlayTab
            // 
            this.MusicPlayTab.Controls.Add(this.addmusicbtn);
            this.MusicPlayTab.Controls.Add(this.soundvaluetext);
            this.MusicPlayTab.Controls.Add(this.minussec);
            this.MusicPlayTab.Controls.Add(this.plussec);
            this.MusicPlayTab.Controls.Add(this.downbtn);
            this.MusicPlayTab.Controls.Add(this.upbtn);
            this.MusicPlayTab.Controls.Add(this.metroCheckBox1);
            this.MusicPlayTab.Controls.Add(this.playagain);
            this.MusicPlayTab.Controls.Add(this.metroLabel1);
            this.MusicPlayTab.Controls.Add(this.metroButton1);
            this.MusicPlayTab.Controls.Add(this.musiclist2);
            this.MusicPlayTab.Controls.Add(this.musicnametxt);
            this.MusicPlayTab.Controls.Add(this.volumtrackbar);
            this.MusicPlayTab.Controls.Add(this.stopbtn);
            this.MusicPlayTab.Controls.Add(this.randombtn);
            this.MusicPlayTab.Controls.Add(this.nowplaytime);
            this.MusicPlayTab.Controls.Add(this.totalplaytime);
            this.MusicPlayTab.Controls.Add(this.musicstatustrackbar);
            this.MusicPlayTab.Controls.Add(this.playbtn);
            this.MusicPlayTab.Controls.Add(this.metroLabel2);
            this.MusicPlayTab.HorizontalScrollbarBarColor = true;
            this.MusicPlayTab.Location = new System.Drawing.Point(4, 36);
            this.MusicPlayTab.Name = "MusicPlayTab";
            this.MusicPlayTab.Size = new System.Drawing.Size(665, 429);
            this.MusicPlayTab.TabIndex = 1;
            this.MusicPlayTab.Text = "MusicPlay";
            this.MusicPlayTab.VerticalScrollbarBarColor = true;
            // 
            // addmusicbtn
            // 
            this.addmusicbtn.Location = new System.Drawing.Point(396, 42);
            this.addmusicbtn.Name = "addmusicbtn";
            this.addmusicbtn.Size = new System.Drawing.Size(68, 62);
            this.addmusicbtn.TabIndex = 22;
            this.addmusicbtn.Text = "노래추가";
            this.addmusicbtn.Click += new System.EventHandler(this.addmusicbtn_Click);
            // 
            // soundvaluetext
            // 
            this.soundvaluetext.AutoSize = true;
            this.soundvaluetext.Location = new System.Drawing.Point(630, 64);
            this.soundvaluetext.Name = "soundvaluetext";
            this.soundvaluetext.Size = new System.Drawing.Size(28, 19);
            this.soundvaluetext.TabIndex = 21;
            this.soundvaluetext.Text = "100";
            // 
            // minussec
            // 
            this.minussec.Location = new System.Drawing.Point(331, 42);
            this.minussec.Name = "minussec";
            this.minussec.Size = new System.Drawing.Size(59, 30);
            this.minussec.TabIndex = 20;
            this.minussec.Text = "-20초";
            this.minussec.Click += new System.EventHandler(this.minussec_Click);
            // 
            // plussec
            // 
            this.plussec.Location = new System.Drawing.Point(266, 42);
            this.plussec.Name = "plussec";
            this.plussec.Size = new System.Drawing.Size(59, 30);
            this.plussec.TabIndex = 19;
            this.plussec.Text = "+20초";
            this.plussec.Click += new System.EventHandler(this.plussec_Click);
            // 
            // downbtn
            // 
            this.downbtn.Location = new System.Drawing.Point(639, 148);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(24, 23);
            this.downbtn.TabIndex = 18;
            this.downbtn.Text = "▼";
            this.downbtn.Click += new System.EventHandler(this.downbtn_Click);
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(639, 119);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(24, 23);
            this.upbtn.TabIndex = 17;
            this.upbtn.Text = "▲";
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(548, 44);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(110, 15);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroCheckBox1.TabIndex = 16;
            this.metroCheckBox1.Text = "창을 항상보이기";
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // playagain
            // 
            this.playagain.AutoSize = true;
            this.playagain.Location = new System.Drawing.Point(473, 44);
            this.playagain.Name = "playagain";
            this.playagain.Size = new System.Drawing.Size(71, 15);
            this.playagain.Style = MetroFramework.MetroColorStyle.Black;
            this.playagain.TabIndex = 14;
            this.playagain.Text = "반복재생";
            this.playagain.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(468, 85);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(44, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "볼륨 :";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(136, 42);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(59, 30);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "초기화";
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click_1);
            // 
            // musiclist2
            // 
            this.musiclist2.HideSelection = false;
            this.musiclist2.Location = new System.Drawing.Point(4, 119);
            this.musiclist2.Name = "musiclist2";
            this.musiclist2.Size = new System.Drawing.Size(629, 301);
            this.musiclist2.SmallImageList = this.ICON;
            this.musiclist2.TabIndex = 11;
            this.musiclist2.UseCompatibleStateImageBehavior = false;
            this.musiclist2.View = System.Windows.Forms.View.List;
            this.musiclist2.DoubleClick += new System.EventHandler(this.Musiclist2_DoubleClick);
            this.musiclist2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.musiclist2_KeyDown);
            // 
            // musicnametxt
            // 
            this.musicnametxt.AutoSize = true;
            this.musicnametxt.Location = new System.Drawing.Point(6, 11);
            this.musicnametxt.Name = "musicnametxt";
            this.musicnametxt.Size = new System.Drawing.Size(40, 19);
            this.musicnametxt.TabIndex = 10;
            this.musicnametxt.Text = "NULL";
            // 
            // volumtrackbar
            // 
            this.volumtrackbar.BackColor = System.Drawing.Color.Transparent;
            this.volumtrackbar.Location = new System.Drawing.Point(515, 86);
            this.volumtrackbar.Name = "volumtrackbar";
            this.volumtrackbar.Size = new System.Drawing.Size(143, 19);
            this.volumtrackbar.TabIndex = 9;
            this.volumtrackbar.Text = "metroTrackBar2";
            this.volumtrackbar.Value = 1;
            this.volumtrackbar.ValueChanged += new System.EventHandler(this.Volumtrackbar_ValueChanged);
            // 
            // stopbtn
            // 
            this.stopbtn.Location = new System.Drawing.Point(71, 42);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(59, 30);
            this.stopbtn.TabIndex = 8;
            this.stopbtn.Text = "⬛";
            this.stopbtn.Click += new System.EventHandler(this.Stopbtn_Click);
            // 
            // randombtn
            // 
            this.randombtn.Location = new System.Drawing.Point(201, 42);
            this.randombtn.Name = "randombtn";
            this.randombtn.Size = new System.Drawing.Size(59, 30);
            this.randombtn.TabIndex = 7;
            this.randombtn.Text = "랜덤재생";
            this.randombtn.Click += new System.EventHandler(this.Pausebtn_Click);
            // 
            // nowplaytime
            // 
            this.nowplaytime.AutoSize = true;
            this.nowplaytime.Location = new System.Drawing.Point(310, 85);
            this.nowplaytime.Name = "nowplaytime";
            this.nowplaytime.Size = new System.Drawing.Size(40, 19);
            this.nowplaytime.TabIndex = 6;
            this.nowplaytime.Text = "00:00";
            // 
            // totalplaytime
            // 
            this.totalplaytime.AutoSize = true;
            this.totalplaytime.Location = new System.Drawing.Point(350, 85);
            this.totalplaytime.Name = "totalplaytime";
            this.totalplaytime.Size = new System.Drawing.Size(40, 19);
            this.totalplaytime.TabIndex = 5;
            this.totalplaytime.Text = "00:00";
            // 
            // musicstatustrackbar
            // 
            this.musicstatustrackbar.BackColor = System.Drawing.Color.Transparent;
            this.musicstatustrackbar.Location = new System.Drawing.Point(7, 86);
            this.musicstatustrackbar.Maximum = 300;
            this.musicstatustrackbar.Name = "musicstatustrackbar";
            this.musicstatustrackbar.Size = new System.Drawing.Size(296, 19);
            this.musicstatustrackbar.TabIndex = 3;
            this.musicstatustrackbar.Text = "metroTrackBar1";
            this.musicstatustrackbar.Value = 0;
            this.musicstatustrackbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Musicstatustrackbar_Scroll);
            this.musicstatustrackbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Musicstatustrackbar_MouseDown);
            // 
            // playbtn
            // 
            this.playbtn.Location = new System.Drawing.Point(6, 42);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(59, 30);
            this.playbtn.TabIndex = 2;
            this.playbtn.Text = "▶ / ❚❚";
            this.playbtn.Click += new System.EventHandler(this.Playbtn_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(469, 62);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(104, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "Made By Illusion";
            // 
            // MusicTimer
            // 
            this.MusicTimer.Enabled = true;
            this.MusicTimer.Tick += new System.EventHandler(this.MusicTimer_Tick);
            // 
            // PlayInfinite
            // 
            this.PlayInfinite.Enabled = true;
            this.PlayInfinite.Tick += new System.EventHandler(this.PlayInfinite_Tick);
            // 
            // CheckIndex
            // 
            this.CheckIndex.Enabled = true;
            this.CheckIndex.Tick += new System.EventHandler(this.CheckIndex_Tick);
            // 
            // icontray
            // 
            this.icontray.Icon = ((System.Drawing.Icon)(resources.GetObject("icontray.Icon")));
            this.icontray.Text = "MusicPlayer";
            this.icontray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.icontray_MouseClick);
            this.icontray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icontray_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hahaToolStripMenuItem,
            this.nextSongToolStripMenuItem,
            this.previousSongToolStripMenuItem,
            this.초기화ToolStripMenuItem,
            this.랜덤재생ToolStripMenuItem,
            this.초ToolStripMenuItem,
            this.초ToolStripMenuItem1,
            this.다음곡ToolStripMenuItem,
            this.이전곡ToolStripMenuItem,
            this.반복재생OFFToolStripMenuItem,
            this.프로그램종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 268);
            // 
            // hahaToolStripMenuItem
            // 
            this.hahaToolStripMenuItem.Name = "hahaToolStripMenuItem";
            this.hahaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hahaToolStripMenuItem.Text = "Made By Illusion";
            // 
            // nextSongToolStripMenuItem
            // 
            this.nextSongToolStripMenuItem.Name = "nextSongToolStripMenuItem";
            this.nextSongToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nextSongToolStripMenuItem.Text = "▶ / ❚❚";
            this.nextSongToolStripMenuItem.Click += new System.EventHandler(this.nextSongToolStripMenuItem_Click);
            // 
            // previousSongToolStripMenuItem
            // 
            this.previousSongToolStripMenuItem.Name = "previousSongToolStripMenuItem";
            this.previousSongToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.previousSongToolStripMenuItem.Text = "   ⬛";
            this.previousSongToolStripMenuItem.Click += new System.EventHandler(this.previousSongToolStripMenuItem_Click);
            // 
            // 초기화ToolStripMenuItem
            // 
            this.초기화ToolStripMenuItem.Name = "초기화ToolStripMenuItem";
            this.초기화ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.초기화ToolStripMenuItem.Text = "초기화";
            this.초기화ToolStripMenuItem.Click += new System.EventHandler(this.초기화ToolStripMenuItem_Click);
            // 
            // 랜덤재생ToolStripMenuItem
            // 
            this.랜덤재생ToolStripMenuItem.Name = "랜덤재생ToolStripMenuItem";
            this.랜덤재생ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.랜덤재생ToolStripMenuItem.Text = "랜덤재생";
            this.랜덤재생ToolStripMenuItem.Click += new System.EventHandler(this.랜덤재생ToolStripMenuItem_Click);
            // 
            // 초ToolStripMenuItem
            // 
            this.초ToolStripMenuItem.Name = "초ToolStripMenuItem";
            this.초ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.초ToolStripMenuItem.Text = "+20초";
            this.초ToolStripMenuItem.Click += new System.EventHandler(this.초ToolStripMenuItem_Click);
            // 
            // 초ToolStripMenuItem1
            // 
            this.초ToolStripMenuItem1.Name = "초ToolStripMenuItem1";
            this.초ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.초ToolStripMenuItem1.Text = "-20초";
            this.초ToolStripMenuItem1.Click += new System.EventHandler(this.초ToolStripMenuItem1_Click);
            // 
            // 다음곡ToolStripMenuItem
            // 
            this.다음곡ToolStripMenuItem.Name = "다음곡ToolStripMenuItem";
            this.다음곡ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.다음곡ToolStripMenuItem.Text = "다음곡";
            this.다음곡ToolStripMenuItem.Click += new System.EventHandler(this.다음곡ToolStripMenuItem_Click);
            // 
            // 이전곡ToolStripMenuItem
            // 
            this.이전곡ToolStripMenuItem.Name = "이전곡ToolStripMenuItem";
            this.이전곡ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.이전곡ToolStripMenuItem.Text = "이전곡";
            this.이전곡ToolStripMenuItem.Click += new System.EventHandler(this.이전곡ToolStripMenuItem_Click);
            // 
            // 반복재생OFFToolStripMenuItem
            // 
            this.반복재생OFFToolStripMenuItem.Name = "반복재생OFFToolStripMenuItem";
            this.반복재생OFFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.반복재생OFFToolStripMenuItem.Text = "반복재생 OFF";
            this.반복재생OFFToolStripMenuItem.Click += new System.EventHandler(this.반복재생OFFToolStripMenuItem_Click);
            // 
            // 프로그램종료ToolStripMenuItem
            // 
            this.프로그램종료ToolStripMenuItem.Name = "프로그램종료ToolStripMenuItem";
            this.프로그램종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.프로그램종료ToolStripMenuItem.Text = "프로그램 종료";
            this.프로그램종료ToolStripMenuItem.Click += new System.EventHandler(this.프로그램종료ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 519);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(691, 519);
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "MusicPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.metroTabControl1.ResumeLayout(false);
            this.SearchTab.ResumeLayout(false);
            this.MusicPlayTab.ResumeLayout(false);
            this.MusicPlayTab.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView musiclist;
        private MetroFramework.Controls.MetroTextBox searchtxt;
        private MetroFramework.Controls.MetroButton searchbtn;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage SearchTab;
        private MetroFramework.Controls.MetroTabPage MusicPlayTab;
        private MetroFramework.Controls.MetroButton stopbtn;
        private MetroFramework.Controls.MetroButton randombtn;
        private MetroFramework.Controls.MetroLabel nowplaytime;
        private MetroFramework.Controls.MetroLabel totalplaytime;
        private MetroFramework.Controls.MetroTrackBar musicstatustrackbar;
        private MetroFramework.Controls.MetroButton playbtn;
        private System.Windows.Forms.Timer MusicTimer;
        private MetroFramework.Controls.MetroTrackBar volumtrackbar;
        private MetroFramework.Controls.MetroLabel musicnametxt;
        private System.Windows.Forms.ListView musiclist2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroCheckBox playagain;
        private System.Windows.Forms.Timer PlayInfinite;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ImageList ICON;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroButton downbtn;
        private MetroFramework.Controls.MetroButton upbtn;
        private System.Windows.Forms.Timer CheckIndex;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton minussec;
        private MetroFramework.Controls.MetroButton plussec;
        private MetroFramework.Controls.MetroLabel soundvaluetext;
        private MetroFramework.Controls.MetroButton addmusicbtn;
        private System.Windows.Forms.NotifyIcon icontray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hahaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초기화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 랜덤재생ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 이전곡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다음곡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반복재생OFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로그램종료ToolStripMenuItem;
    }
}

