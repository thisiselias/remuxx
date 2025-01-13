using System.Diagnostics;

namespace remuxx
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                string format = args[0];
                string path = "";

                for (int i = 1; i < args.Length; ++i)
                {
                    path += args[i] + " ";
                }

                if (File.Exists(path))
                {
                    ConvertFile(path, format);

                    return;
                }

            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
        }

        static void ConvertFile(string inputFile, string format)
        {
            ProcessStartInfo processArgs = new ProcessStartInfo();

            processArgs.FileName = "ffmpeg";
            processArgs.Arguments = "-i \"" + inputFile + "\" \"" + Path.GetFileNameWithoutExtension(inputFile) + "." + format + "\"";
            processArgs.UseShellExecute = false;
            processArgs.CreateNoWindow = true;

            Process.Start(processArgs);
        }
    }
}