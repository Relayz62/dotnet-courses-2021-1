using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task2
{
    public class Observation
    {
        private readonly string _pathToDirect;
        private DirectoryInfo _sourceDirectory;
        private DirectoryInfo _hubDirectory;
        private FileSystemWatcher _fileWatcher;
        private string _pathHub;
        private bool isSub = false;
        private bool isDes = false;
        public Observation(string pathToDirect, string pathHub)
        {
            if (!Directory.Exists(pathToDirect))
            {
                throw new DirectoryNotFoundException();
            }
            _pathToDirect = pathToDirect;
            _pathHub = pathHub;
            _sourceDirectory = new DirectoryInfo(_pathToDirect);
            _fileWatcher = new FileSystemWatcher(_sourceDirectory.FullName, "*.txt");
        }

        public bool OnSubscribe()
        {
            isDes = false;
            isSub = true;
            if (!Directory.Exists(_pathHub))
            {
                Directory.CreateDirectory(_pathHub);
            }         
            _fileWatcher.Created += FileWatcher_Created;
            _fileWatcher.Changed += FileWatcher_Changed;
            _fileWatcher.Renamed += FileWatcher_Renamed;
            _fileWatcher.Deleted += FileWatcher_Deleted;
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.EnableRaisingEvents = true;
            return isSub;

        }

        public bool OnDescribe()
        {
            isSub = false;
            isDes = true;
            _fileWatcher.Created -= FileWatcher_Created;
            _fileWatcher.Changed -= FileWatcher_Changed;
            _fileWatcher.Renamed -= FileWatcher_Renamed;
            _fileWatcher.Deleted -= FileWatcher_Deleted;
            _fileWatcher.EnableRaisingEvents = false;
            return isDes;
        }

        private void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Удалили текстовый файл {e.Name}");
            AddLog($"Удалили текстовый файл {e.Name}");
            SaveChanges();
        }

        private void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Переименовали файл {e.OldName} на {e.Name}");
            AddLog($"Переименовали файл {e.OldName} на {e.Name}");
            SaveChanges();
        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Внесли изменения в файл {e.Name} {e.ChangeType}");
            AddLog($"Внесли изменения в файл {e.Name} {e.ChangeType}");
            SaveChanges();
        }

        private void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Создали файл {e.Name}");     
            AddLog($"Создали файл {e.Name}");
            SaveChanges();

        }

        private void AddLog(string message)
        {
            if (!Directory.Exists(_pathHub))
            {
                Directory.CreateDirectory(_pathHub);
            }
            if (!File.Exists(Path.Combine(_pathHub, "log.txt")))
            {
                FileStream fs = File.Create(Path.Combine(_pathHub, "log.txt"));
                fs.Close();
            }
            using (StreamWriter sw = new StreamWriter(Path.Combine(_pathHub, "log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} : {message}");
            }           
        }


        private void SaveChanges()
        {
            if (!Directory.Exists(_pathHub))
            {
                Directory.CreateDirectory(_pathHub);
            }

            string fileName = $"{DateTime.Now.ToString("dd.MM.yyyy HH.mm")}";
            string hubPath= Path.Combine(_pathHub, fileName);

            Directory.CreateDirectory(hubPath);
            _hubDirectory = new DirectoryInfo(hubPath);
            CopyAll(_sourceDirectory, _hubDirectory);
        }

        private void CopyAll(DirectoryInfo pathDirectory, DirectoryInfo habDirectory)
        {
            foreach (var fileInfo in pathDirectory.GetFiles())
            {
                fileInfo.CopyTo(Path.Combine(habDirectory.ToString(), fileInfo.Name), true);
            }

            foreach (var subDirSource in pathDirectory.GetDirectories())
            {
                var subDirBackup = habDirectory.CreateSubdirectory(subDirSource.Name);
                CopyAll(subDirSource, subDirBackup);
            }
        }
        public void Rollback(string timeRollBack)
        {
            if (!Directory.Exists(_pathToDirect))
            {
                throw new DirectoryNotFoundException();
            }
            if (!Directory.Exists(_pathHub))
            {
                throw new DirectoryNotFoundException();
            }
            string hubDirectory = Path.Combine(_pathHub, timeRollBack);

            DirectoryInfo rollbackDirectory = new DirectoryInfo(hubDirectory);

            CopyAll(rollbackDirectory, _sourceDirectory);
        }
    }
}
