using MyLib;

const string dirPath = @"C:\sample folder";
const string fileName = @"file.txt";

FindAndArchivate(dirPath, fileName);

void FindAndArchivate(string path, string fileName)
{
    var pathToFile = FileSearch.FindFirstMatchingFilePath(dirPath, fileName);

    try
    {
        var pathToArchieve = FileArchiever.AddToArchive(pathToFile);
        Console.WriteLine("Archivation Successfull!");
        Console.WriteLine($"Path to archieve: {pathToArchieve}");
    }
    catch
    {
        throw new Exception("Archivation Failed!");
    }

}