using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey key =   Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (checkBox1.Checked)
            {
                if(key.GetValue("DisableTaskMgr") != null)
                {
                    key.DeleteValue("DisableTaskMgr");
                    MessageBox.Show("Settings are saved.");
                }
                else
                {
                    MessageBox.Show("Task Manager is already enabled");
                }
            }
            else
            {
                key.SetValue("DisableTaskMgr", "1");
                MessageBox.Show("Settings are saved.");
            }
            RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
            if (checkBox2.Checked)
            {
                key2.SetValue("ShowSecondsInSystemClock", 1, RegistryValueKind.DWord);
            }
            else
            {
                key2.SetValue("ShowSecondsInSystemClock", 0, RegistryValueKind.DWord);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        { 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Temp");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            
            catch (IOException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Temp");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                
            }

            catch (IOException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

            try
            {
                System.IO.DirectoryInfo dis = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp");
                foreach (FileInfo file in dis.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in dis.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (IOException nn)
            {
                Console.WriteLine(nn.Message);
            }
            MessageBox.Show("Task completed.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo di2 = new DirectoryInfo(@"C:\Windows\Prefetch");
                foreach (FileInfo file in di2.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di2.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch(IOException nn)
            {
                Console.WriteLine(nn.Message);
            }
            MessageBox.Show("Task completed.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string IPADDRESS = new WebClient().DownloadString("https://ifconfig.me/ip");
                ipme.Text = "Your IP : " + IPADDRESS;
            }
            catch(System.Net.WebException)
            {
                MessageBox.Show("Warning!, IP Address will not show because of the internet connection.");
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("explorer").Length > 0)
            {
                Process.Start("taskkill", "/F /IM explorer.exe");
                Thread.Sleep(2000);
                Process.Start("explorer");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("taskkill", "/f /im " + pros.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(pros.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a = pros.Text;
            if (a.Contains(".exe"))
            {
                a = a.Substring(0, a.Length - 4);
            }
            if(Process.GetProcessesByName(a).Length > 0)
            {
                MessageBox.Show("The process is running.");
            }
            else
            {
                MessageBox.Show("The process doesn't exist");
            }
        }
    }
}
