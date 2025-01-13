using System.Drawing.Text;
using System.Reflection;
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
                                    commandKey.SetValue("", Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + $"\\remuxx.exe {format} %1");
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
            string remuxx = @"*\shell\remuxx";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(remuxx, true))
            {
                if (key != null)
                {
                    InstallLabel.Text = "Installed! ^w^";
                    InstallButton.Enabled = false;
                    UninstallButton.Enabled = true;
                }
                else
                {
                    InstallLabel.Text = "Not installed :<";
                    InstallButton.Enabled = true;
                    UninstallButton.Enabled = false;
                }
            }
        }
    }
}