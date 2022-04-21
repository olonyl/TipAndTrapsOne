using System;

namespace FileWtacherExample
{
    class Program
    {
        static void Main(string[] args)
        {
            new FileWatcher().Start();

            Console.ReadLine();
        }
    }

    class FileWatcher
    {
        public void Start()
        {
            var watcher = new System.IO.FileSystemWatcher();

            watcher.Path = @"c:\temp";

            watcher.Filter = "*.txt";

            watcher.NotifyFilter = System.IO.NotifyFilters.FileName;

            watcher.Changed += FileChanged;
            watcher.Created += FileChanged;
            watcher.Deleted += FileChanged;
            watcher.Renamed += FileRenamed;

            watcher.EnableRaisingEvents = true;
        }
        private void FileChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            Console.WriteLine("------File Changed-------------------");

            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.Name);
        }

        private void FileRenamed(object sender, System.IO.RenamedEventArgs e)
        {
            Console.WriteLine("------File Renamed-------------------");

            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.OldName);
            Console.WriteLine(e.Name);
        }
    }
}
