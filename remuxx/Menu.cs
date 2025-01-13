using System.Drawing.Text;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace remuxx
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            UpdateInstallLabel();
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            string regPath = @"*\shell\remuxx";
            string[] formatList = new string[] { "mp3", "wav", "ogg", "m4a", "wma", "flac", "aac" };

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
            {
                if (key != null)
                {
                    key.SetValue("subcommands", "");

                    using (RegistryKey shellKey = key.CreateSubKey("shell"))
                    {
                        foreach (string format in formatList)
                        {
                            using (RegistryKey formatKey = shellKey.CreateSubKey(format))
                            {
                                formatKey.SetValue("MUIVerb", $"Convert to {format.ToUpper()}");

                                using (RegistryKey commandKey = formatKey.CreateSubKey("command"))
                                {
                                    commandKey.SetValue("", Environment.ProcessPath + $" {format} %1");
                                }
                            }
                        }
                    }
                }
            }
            UpdateInstallLabel();
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            string remuxx = @"*\shell";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(remuxx, true))
            {
                key.DeleteSubKeyTree("remuxx");
            }
            UpdateInstallLabel();
        }

        private void UpdateInstallLabel()
        {
            try
            {
                string remuxx = @"*\shell\remuxx";
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(remuxx, true))
                {
                    if (key != null)
                    {
                        InstallLabel.Text = "Enabled! :3";
                        InstallButton.Enabled = false;
                        UninstallButton.Enabled = true;
                    }
                    else
                    {
                        InstallLabel.Text = "Disabled :<";
                        InstallButton.Enabled = true;
                        UninstallButton.Enabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occurred: Please run as Administrator");
                Environment.Exit(0);
            }
        }

        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "https://github.com/sillycatmoments");
        }
    }
}