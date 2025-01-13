using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;
using static System.Windows.Forms.DataFormats;

namespace remuxx
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            InitRegistry();

        }

        private void InitRegistry()
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
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            ConvertFileDialog(".ogg");
        }

        private void ConvertFileDialog(string format)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.flac;*.aac;*.ogg;*.m4a;*.wma";
            openFileDialog.Multiselect = true;

            DialogResult result = openFileDialog.ShowDialog();
            foreach (string file in openFileDialog.FileNames)
            {
                ConvertFile(file, format);
            }
        }

        private void ConvertFile(string inputFile, string format)
        {
            ProcessStartInfo processArgs = new ProcessStartInfo();

            processArgs.FileName = "ffmpeg";
            processArgs.Arguments = "-i \"" + inputFile + "\" \"" + inputFile + "\"" + format;
            processArgs.UseShellExecute = false;
            processArgs.CreateNoWindow = true;

            Process.Start(processArgs);
        }
    }
}