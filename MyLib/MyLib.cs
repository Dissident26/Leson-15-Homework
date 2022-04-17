using System.IO.Compression;

namespace MyLib
{
    public static class FileSearch
    {
        private static string PathToFile = string.Empty;
        public static string FindFirstMatchingFilePath(string initialPath, string fileName)
        {
            FindFirstMatchingFileInDirectory(initialPath, fileName);

            if (PathToFile != string.Empty)
            {
               return PathToFile;
            }

            throw new Exception($"File '{fileName}', not found in {initialPath} directory");
        }

        private static void FindFirstMatchingFileInDirectory(string dirPath, string fileName)
        {
            var currentDirectory = new DirectoryInfo(dirPath);
            var files = currentDirectory.GetFiles(fileName);

            if(files.Length > 0)
            {
                PathToFile = files[0].FullName;
            }

            var subDirectories = currentDirectory.GetDirectories();
            foreach (var subDirectory in subDirectories)
            {
                FindFirstMatchingFileInDirectory(subDirectory.FullName, fileName);
            }
        }
    }

    public static class FileArchiever
    {
        public static string AddToArchive(string pathToFile)
        {
            var directoryPath = Path.GetDirectoryName(pathToFile);
            var fileName = Path.GetFileNameWithoutExtension(pathToFile);
            var pathToArchieve = $@"{directoryPath}/{fileName}.zip";

            using (var fileStream = new FileStream($@"{directoryPath}/{fileName}.zip", FileMode.Create))
            using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(pathToFile, fileName);
            }

            return pathToArchieve;
        }
    }
}