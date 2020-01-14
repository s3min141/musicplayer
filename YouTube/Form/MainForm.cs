using System;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;
using MetroFramework.Forms;
using NAudio.Wave;
using System.Diagnostics;
using YoutubeSearch;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using MetroFramework;
using System.Security.AccessControl;
using System.Net;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Media;

namespace YouTubeAPP
{
    public partial class MainForm : MetroForm
    {
        #region Declar
        RegistryKey reg;
        private IWavePlayer wavePlayer;
        private AudioFileReader reader;
        private string fileName = string.Empty;
        private int CurrentIndex;
        private string username;
        private bool ShowPopular = true;

        struct TItem
        {
            public ListViewItem _item;
            public int index;
        }
        #endregion

        #region FormEvent
        public MainForm()
        {            
            try
            {
                //폼로드
                InitializeComponent();
                //최대화버튼 없애기
                this.MaximizeBox = false;
                //유저이름가져오기
                username = Environment.UserName;
                //구버전 경로 확인
                CheckOldPath($"C:\\Users\\{username}\\YouTubeMp3\\");
                //불륨셋팅
                Win32.SetSoundVolume(1);
                //탭인덱스 바꾸기
                metroTabControl1.SelectedIndex = 0;
                //불륨 레지스트리
                reg = Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("MusicVolume");
                if (reg.GetValue("VOLUME", null) != null)
                {
                    volumtrackbar.Value = Convert.ToInt32(reg.GetValue("VOLUME"));
                    soundvaluetext.Text = reg.GetValue("VOLUME").ToString();
                }
                //musiclist 설정
                musiclist.View = View.Details;
                musiclist.HeaderStyle = ColumnHeaderStyle.None;
                ColumnHeader h = new ColumnHeader();
                h.Width = musiclist.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                musiclist.Columns.Add(h);
                //musiclist2 설정
                musiclist2.View = View.Details;
                musiclist2.HeaderStyle = ColumnHeaderStyle.None;
                ColumnHeader h2 = new ColumnHeader();
                h2.Width = musiclist2.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                musiclist2.Columns.Add(h2);
                //재생목록 불러오기
                var route = $"C:\\Users\\{username}\\System\\";
                DirectoryInfo dir = new DirectoryInfo(route);
                if (dir.Exists)
                {
                    UnlockDirectory(username);
                    try
                    {
                        string[] files = Directory.GetFiles(route);
                        foreach (string s in files)
                        {
                            string filename = Path.GetFileName(s);
                            string Full = route + filename;
                            string finalfilename = "";
                            if (filename.Length > 60)
                            {
                                for (int i = 0; i < filename.Length / 2; i++)
                                {
                                    finalfilename += filename[i];
                                }
                                finalfilename += "· · ·.mp3";
                            }
                            else
                            {
                                finalfilename = filename;
                            }
                            musiclist2.Items.Add(Full, finalfilename, 0);
                        }
                        if (musiclist2.Items.Count > 0)
                        {
                            fileName = musiclist2.Items[0].Name;
                            CurrentAudioFile(fileName);
                            metroTabControl1.SelectedIndex = 1;
                        }
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("플레이리스트를 불러오는데 실패했습니다." + a.ToString());
                    }
                    LockDirectory(username);
                    ShowPopularSong();
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            reg.SetValue("VOLUME", volumtrackbar.Value);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowIcon = false;
                icontray.Visible = true;
            }
        }
        #endregion

        #region CheckOldPath
        private void CheckOldPath(string oldpath)
        {
            DirectoryInfo dr = new DirectoryInfo(oldpath);
            if (dr.Exists)
            {
                try
                {
                    string folderPath = oldpath;
                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.RemoveAccessRule(fsa);
                    Directory.SetAccessControl(folderPath, ds);
                    dr.MoveTo($"C:\\Users\\{username}\\System\\");
                }
                catch (Exception e)
                {
                    MessageBox.Show("오류 발생 프로그램을 종료합니다." + e.ToString());
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
        #endregion

        #region Lock, Unlock Directory
        private void LockDirectory(string un)
        {
            try
            {
                string folderPath = $"C:\\Users\\{un}\\System\\";
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                ds.AddAccessRule(fsa);
                Directory.SetAccessControl(folderPath, ds);
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void UnlockDirectory(string un)
        {
            try
            {
                string folderPath = $"C:\\Users\\{un}\\System\\";
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                ds.RemoveAccessRule(fsa);
                Directory.SetAccessControl(folderPath, ds);
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region SearchYoutube
        private void metroButton1_Click(object sender, EventArgs e)
        {
            SearchYoutube(searchtxt.Text);
        }

        private void searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchYoutube(searchtxt.Text);
            }
        }

        private void SearchYoutube(string searchtxt)
        {
            try
            {
                ShowPopular = false;
                this.Enabled = false;
                musiclist.Items.Clear();
                var items = new VideoSearch();
                foreach (var item in items.SearchQuery(searchtxt, 2))
                {
                    musiclist.Items.Add(item.Url, item.Title.Replace("&quot;", "").Replace("&amp;", "").Replace("&#39;", ""), 0);
                }
                this.Enabled = true;
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region DownloadFormYoutube
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (musiclist.SelectedItems.Count == 1)
                {
                    if (ShowPopular == false)
                    {
                        this.Enabled = false;
                        DownloadFromYoutube(musiclist.SelectedItems[0].Name);
                        this.Enabled = true;
                        metroTabControl1.SelectedIndex = 1;
                    }
                    else
                    {
                        var items = new VideoSearch();
                        int index = 0;
                        bool found = false;
                        string youtubeUrl = "";
                        string youtubeTitle = "";
                        while (!found)
                        {
                            youtubeUrl = items.SearchQuery(musiclist.SelectedItems[0].Text, 1)[index].Url;
                            youtubeTitle = items.SearchQuery(musiclist.SelectedItems[0].Text, 1)[index].Title.Trim();
                            if (youtubeTitle.Contains("MUSIC BANK") || youtubeTitle.Contains("MusicBank") || youtubeTitle.Contains("음악중심") || youtubeTitle.Contains("음중") || youtubeTitle.Contains("뮤직뱅크") || youtubeTitle.Contains("뮤뱅") || youtubeTitle.Contains("라이브") || youtubeTitle.Contains("Live") || youtubeTitle.Contains("TJ노래방") || youtubeTitle.Contains("Karaoke") || youtubeTitle.Contains("1시간") || youtubeTitle.Contains("1h") || youtubeTitle.Contains("1Hour") || youtubeTitle.Contains("1hour"))
                            {
                                index++;
                            }
                            else
                            {
                                found = true;
                            }
                        }
                        this.Enabled = false;
                        DownloadFromYoutube(youtubeUrl);
                        this.Enabled = true;
                        metroTabControl1.SelectedIndex = 1;
                    }
                }
                else
                {
                    MessageBox.Show("곡을 한개만 선택해주세요.");
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void DownloadFromYoutube(string URL)
        {
            string youtubeUrl = URL;
            var username = Environment.UserName;
            var route = $"C:\\Users\\{username}\\System\\";
            DirectoryInfo dir = new DirectoryInfo(route);
            if (!dir.Exists)
            {
                dir.Create();
                dir.Attributes = FileAttributes.ReadOnly;
                if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    dir.Attributes = dir.Attributes | FileAttributes.Hidden;
                }
            }
            UnlockDirectory(username);
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(youtubeUrl);
            if (!File.Exists(route + vid.FullName))
            {
                File.WriteAllBytes(route + vid.FullName, vid.GetBytes());
                if (musicnametxt.Text == "NULL")
                {
                    fileName = route + vid.FullName;
                    CurrentAudioFile(fileName);
                }
                File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);
                string finalfilename = "";
                if (vid.FullName.Length > 60)
                {
                    for (int i = 0; i < vid.FullName.Length / 2; i++)
                    {
                        finalfilename += vid.FullName[i];
                    }
                    finalfilename += "· · ·.mp3";
                }
                else
                {
                    finalfilename = vid.FullName;
                }
                musiclist2.Items.Add(route + vid.FullName, finalfilename, 0);
            }
            LockDirectory(username);
        }
        #endregion

        #region PlayAudio
        private void Playbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileName != null)
                {
                    if (this.wavePlayer != null)
                    {
                        if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                        {
                            this.wavePlayer.Pause();
                        }
                        else if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                        {
                            this.wavePlayer.Play();
                        }
                    }
                    else
                    {
                        CurrentAudioFile(fileName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region PauseAudio
        private void Pausebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (musiclist2.Items.Count > 0)
                {
                    if (musiclist2.Items.Count >= 5)
                    {
                        int num = musiclist2.Items.Count - 1;
                        Random r = new Random();
                        int final = r.Next(0, num);
                        fileName = musiclist2.Items[final].Name;
                        CurrentAudioFile(fileName);
                    }
                    else
                    {
                        MessageBox.Show("랜덤재생은 노래가 5개 이상일때만 사용하실수 있습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("재생목록에 노래가 없습니다.");
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region StopAudio
        private void Stopbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.wavePlayer != null)
                {
                    this.wavePlayer.Stop();
                    musicstatustrackbar.Value = 0;
                }
                else
                {
                    MessageBox.Show("재생중인 노래가 없습니다.");
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region OpenAndPlayAudio
        void CurrentAudioFile(string audioFile)
        {
            try
            {
                fileName = audioFile;
                if (fileName != string.Empty)
                {
                    musicstatustrackbar.Value = 0;
                    string finalfilename = "";
                    if (getFileName(fileName).Length > 60) 
                    {
                        for (int i = 0; i < getFileName(fileName).Length / 2; i++)
                        {
                            finalfilename += getFileName(fileName)[i];
                        }
                        musicnametxt.Text = finalfilename + "· · ·.mp3";
                    }
                    else
                    {
                        musicnametxt.Text = getFileName(fileName);
                    }

                    if (this.wavePlayer != null)
                    {
                        CleanUp();  // 기존 재생파일 메모리 제거
                    }

                    Debug.Assert(this.wavePlayer == null);
                    this.wavePlayer = CreateWavePlayer();
                    this.reader = new AudioFileReader(fileName);
                    this.wavePlayer.Init(reader);
                    this.wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
                    this.wavePlayer.Play();
                    MusicTimer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("열린 파일이 없습니다");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region WavePlayer
        void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // we want to be always on the GUI thread and be able to change GUI components
            Debug.Assert(!this.InvokeRequired, "PlaybackStopped on wrong thread");
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CleanUp();
            MusicTimer.Enabled = false;
            nowplaytime.Text = "00:00";
            musicstatustrackbar.Value = 0;
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        private IWavePlayer CreateWavePlayer()
        {
            return new WaveOut();
        }
        #endregion

        #region CleanAllPlayingAudio
        private void CleanUp()
        {
            try
            {
                if (this.reader != null)
                {
                    this.reader.Dispose();
                    this.reader = null;
                }
                if (this.wavePlayer != null)
                {
                    this.wavePlayer.Dispose();
                    this.wavePlayer = null;
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region Modules
        private string getFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", (int)ts.TotalMinutes, ts.Seconds);
        }
        #endregion

        #region TrackbarEvent
        private void Volumtrackbar_ValueChanged(object sender, EventArgs e)
        {
            Win32.SetSoundVolume(volumtrackbar.Value);
            soundvaluetext.Text = volumtrackbar.Value.ToString();
        }

        private void Musicstatustrackbar_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.reader != null)
            {
                reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
            }
        }

        private void Musicstatustrackbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.reader != null)
            {
                double clickValue = ((double)e.X / (double)musicstatustrackbar.Width) * (musicstatustrackbar.Maximum - musicstatustrackbar.Minimum);
                musicstatustrackbar.Value = Convert.ToInt32(clickValue);
                reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
            }
        }
        #endregion

        #region PlayInMusicList
        private void Musiclist2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UnlockDirectory(username);
                if (musiclist2.SelectedItems.Count == 1)
                {
                    CurrentIndex = musiclist2.FocusedItem.Index;
                    fileName = musiclist2.SelectedItems[0].Name;
                    CurrentAudioFile(fileName);
                }
                else
                {
                    MessageBox.Show("곡을 한개만 선택해주세요.");
                }
                LockDirectory(username);
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region ChangeIndexOfPlayList
        private void upbtn_Click(object sender, EventArgs e)
        {
            if (musiclist2.SelectedIndices.Count > 0)
            {
                TItem TItem = new TItem();
                TItem._item = musiclist2.SelectedItems[0];
                TItem.index = musiclist2.SelectedIndices[0];

                if (TItem.index != 0)
                {
                    musiclist2.Items.RemoveAt(musiclist2.SelectedIndices[0]);
                    musiclist2.Items.Insert(TItem.index - 1, TItem._item);
                }
            }
        }

        private void downbtn_Click(object sender, EventArgs e)
        {
            if (musiclist2.SelectedIndices.Count > 0)
            {
                TItem TItem = new TItem();
                TItem._item = musiclist2.SelectedItems[0];
                TItem.index = musiclist2.SelectedIndices[0];

                if (TItem.index != musiclist2.Items.Count - 1)
                {
                    musiclist2.Items.RemoveAt(musiclist2.SelectedIndices[0]);
                    musiclist2.Items.Insert(TItem.index + 1, TItem._item);
                }
            }
        }
        #endregion

        #region ResetPlayList
        private void MetroButton1_Click_1(object sender, EventArgs e)
        {
            if (musiclist2.Items.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("재생목록을 초기화합니다.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UnlockDirectory(username);
                        CleanUp();
                        var route = $"C:\\Users\\{username}\\System\\";
                        DirectoryInfo dir = new DirectoryInfo(route);
                        if (dir.Exists)
                        {
                            string[] files = Directory.GetFiles(route);
                            foreach (string s in files)
                            {
                                string filename = Path.GetFileName(s);
                                string deletefile = route + filename;
                                File.Delete(deletefile);
                            }
                        }
                        LockDirectory(username);
                        musiclist2.Items.Clear();
                        musicnametxt.Text = "NULL";
                        nowplaytime.Text = "00:00";
                        totalplaytime.Text = "00:00";
                        musicstatustrackbar.Value = 0;
                        metroTabControl1.SelectedIndex = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                MessageBox.Show("재생목록에 곡이 없습니다.");
            }
        }
        #endregion

        #region CheckBoxEvnet
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        #endregion

        #region TimerEvnet
        private void MusicTimer_Tick(object sender, EventArgs e)
        {
            if (reader != null)
            {
                nowplaytime.Text = FormatTimeSpan(reader.CurrentTime); // 재생시간
                totalplaytime.Text = FormatTimeSpan(reader.TotalTime);  // 총 시간
                musicstatustrackbar.Value = Math.Min((int)((musicstatustrackbar.Maximum * reader.Position) / reader.Length), musicstatustrackbar.Maximum);
            }
        }

        private void PlayInfinite_Tick(object sender, EventArgs e)
        {
            if (this.wavePlayer != null)
            {
                if (this.reader != null)
                {
                    if (playagain.Checked)
                    {
                        if (musiclist2.Items.Count > 1)
                        {
                            if ((nowplaytime.Text == totalplaytime.Text) && (nowplaytime.Text != "00:00" && totalplaytime.Text != "00:00"))
                            {
                                nowplaytime.Text = "00:00";
                                CurrentAudioFile(fileName);
                                musicstatustrackbar.Value = 0;
                            }
                        }
                    }
                    else
                    {
                        if (musiclist2.Items.Count > 0)
                        {
                            if ((nowplaytime.Text == totalplaytime.Text) && (nowplaytime.Text != "00:00" && totalplaytime.Text != "00:00"))
                            {
                                CurrentIndex += 1;
                                if (CurrentIndex == musiclist2.Items.Count)
                                {
                                    CurrentIndex = 0;
                                }
                                fileName = musiclist2.Items[CurrentIndex].Name;
                                CurrentAudioFile(fileName);
                            }
                        }
                    }
                }
            }

            if (musiclist2.Items.Count <= 1)
            {
                playagain.Enabled = false;
                playagain.Checked = false;
            }
            else
            {
                playagain.Enabled = true;
            }
        }

        private void CheckIndex_Tick(object sender, EventArgs e)
        {
            if (this.wavePlayer != null)
            {
                if (this.reader != null)
                {
                    if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    {
                        for (int i = 0; i < musiclist2.Items.Count; i++)
                        {
                            if (fileName == musiclist2.Items[i].Name)
                            {
                                CurrentIndex = musiclist2.Items[i].Index;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region DeleteInPlayList
        private void musiclist2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UnlockDirectory(username);
                if (e.KeyCode == Keys.Delete)
                {
                    if (musiclist2.SelectedItems.Count > 0)
                    {
                        if (MessageBox.Show("선택하신 항목이 삭제 됩니다 계속 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int count = musiclist2.SelectedItems.Count;
                            for (int i = 0; i < count; i++)
                            {
                                int saveplaytime = musicstatustrackbar.Value;
                                string filename = musiclist2.SelectedItems[0].Name;
                                CleanUp();
                                File.Delete(filename);
                                musiclist2.Items.RemoveAt(musiclist2.SelectedItems[0].Index);
                                if (fileName == filename)
                                {
                                    if (musiclist2.Items.Count > 0)
                                    {
                                        nowplaytime.Text = "00:00";
                                        totalplaytime.Text = "00:00";
                                        CurrentAudioFile(musiclist2.Items[0].Name);
                                    }
                                    else
                                    {
                                        nowplaytime.Text = "00:00";
                                        totalplaytime.Text = "00:00";
                                        musicnametxt.Text = "NULL";
                                        musicstatustrackbar.Value = 0;
                                    }
                                }
                                else
                                {
                                    CurrentAudioFile(fileName);
                                    musicstatustrackbar.Value = Convert.ToInt32(saveplaytime);
                                    reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("선택된 곡이 없습니다.");
                    }
                }
                LockDirectory(username);
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region PopularSong
        private void metroButton2_Click(object sender, EventArgs e)
        {
            searchtxt.Text = "";
            musiclist.Items.Clear();
            ShowPopularSong();
            ShowPopular = true;
        }

        public void ShowPopularSong()
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://www.melon.com/chart/index.htm");
                myRequest.Method = "GET";
                myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                HtmlNodeCollection titles = doc.DocumentNode.SelectNodes("//div[@class='ellipsis rank01']");
                HtmlNodeCollection singer = doc.DocumentNode.SelectNodes("//div[@class='ellipsis rank02']");
                for (int a = 0; a < titles.Count; a++)
                {
                    int txtlength = singer[a].InnerText.Trim().Length / 2;
                    string final = "";
                    for (int b = 0; b < txtlength; b++)
                    {
                        final += singer[a].InnerText.Trim()[b];
                    }
                    musiclist.Items.Add("", $"{a + 1}위 : " + $"({final}) " + titles[a].InnerText.Trim().Replace("&quot;", "").Replace("&amp;", "").Replace("&#39;", ""), 0);
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region DownloadMuliple
        private void musiclist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (musiclist.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("여러곡을 다운받을시 시간이 걸릴수도있습니다.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ShowPopular == false)
                        {
                            this.Enabled = false;
                            for (int i = 0; i < musiclist.SelectedItems.Count; i++)
                            {
                                DownloadFromYoutube(musiclist.SelectedItems[i].Name);
                            }
                            this.Enabled = true;
                            metroTabControl1.SelectedIndex = 1;
                        }
                        else
                        {
                            var items = new VideoSearch();
                            this.Enabled = false;
                            for (int i = 0; i < musiclist.SelectedItems.Count; i++)
                            {
                                string youtubeUrl = items.SearchQuery(musiclist.SelectedItems[i].Text, 2)[0].Url;
                                DownloadFromYoutube(youtubeUrl);
                            }
                            this.Enabled = true;
                            metroTabControl1.SelectedIndex = 1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("선택된 곡이 없습니다.");
                }
            }
        }
        #endregion

        #region P,M SEC
        private void plussec_Click(object sender, EventArgs e)
        {
            musicstatustrackbar.Value += 2;
            reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
        }

        private void minussec_Click(object sender, EventArgs e)
        {
            musicstatustrackbar.Value -= 2;
            reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
        }
        #endregion

        #region ADDMUSIC
        private void addmusicbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                dlgOpen.Filter = "MP4 File|*.mp4";
                dlgOpen.Title = "Select Audio File";
                dlgOpen.Multiselect = true;
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    UnlockDirectory(username);
                    for (int i = 0; i < dlgOpen.FileNames.Length; i++)
                    {
                        FileInfo checkexist = new FileInfo($"C:\\Users\\{username}\\System\\" + dlgOpen.SafeFileNames[i]);
                        if (!checkexist.Exists)
                        {
                            if (musiclist2.Items.Count > 0)
                            {
                                for (int a = 0; a < musiclist2.Items.Count; a++)
                                {
                                    if (CalculateSimilarity(dlgOpen.SafeFileNames[i], musiclist2.Items[i].Text) < 0.35)
                                    {
                                        File.SetAttributes(dlgOpen.FileNames[i], File.GetAttributes(dlgOpen.FileNames[i]) | FileAttributes.Hidden);
                                        File.Move(dlgOpen.FileNames[i], $"C:\\Users\\{username}\\System\\" + dlgOpen.SafeFileNames[i]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                File.SetAttributes(dlgOpen.FileNames[i], File.GetAttributes(dlgOpen.FileNames[i]) | FileAttributes.Hidden);
                                File.Move(dlgOpen.FileNames[i], $"C:\\Users\\{username}\\System\\" + dlgOpen.SafeFileNames[i]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("재생목록에 있는 노래입니다.");
                        }
                    }
                    musiclist2.Items.Clear();
                    // 재생목록 불러오기
                    var route = $"C:\\Users\\{username}\\System\\";
                    DirectoryInfo dir = new DirectoryInfo(route);
                    if (dir.Exists)
                    {
                        try
                        {
                            string[] files = Directory.GetFiles(route);
                            foreach (string s in files)
                            {
                                string filename = Path.GetFileName(s);
                                string Full = route + filename;
                                string finalfilename = "";
                                if (filename.Length > 60)
                                {
                                    for (int i = 0; i < filename.Length / 2; i++)
                                    {
                                        finalfilename += filename[i];
                                    }
                                    finalfilename += "· · ·.mp3";
                                }
                                else
                                {
                                    finalfilename = filename;
                                }
                                musiclist2.Items.Add(Full, finalfilename, 0);
                            }
                            if (musiclist2.Items.Count > 0)
                            {
                                fileName = musiclist2.Items[0].Name;
                                CurrentAudioFile(fileName);
                                metroTabControl1.SelectedIndex = 1;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("플레이리스트를 불러오는데 실패했습니다.");
                        }
                        LockDirectory(username);
                    }
                }
            }
        }
        #endregion

        #region TextSimilarity
        double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
        #endregion

        #region IconTray
        private void icontray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.ShowIcon = true;
            icontray.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void icontray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                icontray.ContextMenuStrip = contextMenuStrip1;
                System.Reflection.MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                methodInfo.Invoke(icontray, null);
                if (playagain.Checked)
                {
                    contextMenuStrip1.Items[9].Text = "반복재생 OFF";
                }
                else
                {
                    contextMenuStrip1.Items[9].Text = "반복재생 ON";
                }
            }
        }

        private void nextSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileName != null)
                {
                    if (this.wavePlayer != null)
                    {
                        if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                        {
                            this.wavePlayer.Pause();
                        }
                        else if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                        {
                            this.wavePlayer.Play();
                        }
                    }
                    else
                    {
                        CurrentAudioFile(fileName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void previousSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.wavePlayer != null)
                {
                    this.wavePlayer.Stop();
                    musicstatustrackbar.Value = 0;
                }
                else
                {
                    MessageBox.Show("재생중인 노래가 없습니다.");
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void 초기화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (musiclist2.Items.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("재생목록을 초기화합니다.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UnlockDirectory(username);
                        CleanUp();
                        var route = $"C:\\Users\\{username}\\System\\";
                        DirectoryInfo dir = new DirectoryInfo(route);
                        if (dir.Exists)
                        {
                            string[] files = Directory.GetFiles(route);
                            foreach (string s in files)
                            {
                                string filename = Path.GetFileName(s);
                                string deletefile = route + filename;
                                File.Delete(deletefile);
                            }
                        }
                        LockDirectory(username);
                        musiclist2.Items.Clear();
                        musicnametxt.Text = "NULL";
                        nowplaytime.Text = "00:00";
                        totalplaytime.Text = "00:00";
                        musicstatustrackbar.Value = 0;
                        metroTabControl1.SelectedIndex = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                MessageBox.Show("재생목록에 곡이 없습니다.");
            }
        }

        private void 초ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicstatustrackbar.Value += 2;
            reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
        }

        private void 초ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            musicstatustrackbar.Value -= 2;
            reader.Position = (musicstatustrackbar.Value * reader.Length) / musicstatustrackbar.Maximum;
        }

        private void 랜덤재생ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (musiclist2.Items.Count > 0)
                {
                    if (musiclist2.Items.Count >= 5)
                    {
                        int num = musiclist2.Items.Count - 1;
                        Random r = new Random();
                        int final = r.Next(0, num);
                        fileName = musiclist2.Items[final].Name;
                        CurrentAudioFile(fileName);
                    }
                    else
                    {
                        MessageBox.Show("랜덤재생은 노래가 5개 이상일때만 사용하실수 있습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("재생목록에 노래가 없습니다.");
                }
            }
            catch
            {
                MessageBox.Show("오류 발생 프로그램을 종료합니다.");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void 다음곡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentIndex == musiclist2.Items.Count - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex += 1;
            }
            fileName = musiclist2.Items[CurrentIndex].Name;
            CurrentAudioFile(fileName);
        }

        private void 이전곡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentIndex == 0)
            {
                CurrentIndex = musiclist2.Items.Count - 1;
            }
            else
            {
                CurrentIndex -= 1;
            }
            fileName = musiclist2.Items[CurrentIndex].Name;
            CurrentAudioFile(fileName);
        }

        private void 반복재생OFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playagain.Checked)
            {
                playagain.Checked = false;
                contextMenuStrip1.Items[9].Text = "반복재생 ON";
            }
            else
            {
                playagain.Checked = true;
                contextMenuStrip1.Items[9].Text = "반복재생 OFF";
            }
        }

        private void 프로그램종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reg.SetValue("VOLUME", volumtrackbar.Value);
            Process.GetCurrentProcess().Kill();
        }
        #endregion
    }

    public class Win32
    {
        #region SetSound
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void SetSoundVolume(int volume)
        {
            try
            {
                int newVolume = ((ushort.MaxValue) * volume / 100);
                uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
                waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);
            }
            catch (Exception) { }
        }
        #endregion
    }
}