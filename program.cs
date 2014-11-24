// For Directory.GetFiles and Directory.GetDirectories 
// For File.Exists, Directory.Exists 
using System;
using System.IO;

public class FolderCheck
{
    static string path = "C:\\neu";
    static int depth = 3;
    static int actualDepth;
    static long byteCount;
    static string order;

    public static void Main()
    {
        if (File.Exists(path))
        {
            ProcessFile(path); // This path is a file
        }
        else if (Directory.Exists(path))
        {
            ProcessDirectory(path); // This path is a directory
        }
        else
        {
            Console.WriteLine("{0} is not a valid file or directory.", path);
        }
        Console.WriteLine(CountResult(byteCount));
        Console.ReadKey();
    }
    public static void ProcessDirectory(string targetDirectory)
    {
            // Process the list of files found in the directory. 
            string[] arrayOfFiles = Directory.GetFiles(targetDirectory);
            foreach (string fileName in arrayOfFiles)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
    }

    // Insert logic for processing found files here. Now only filecounter++ to get amount of files
    public static void ProcessFile(string fileName)
    {
       FileInfo info = new FileInfo(fileName);
       byteCount += info.Length;
    }

    public static string CountResult(long byteCount)
    {
        if (byteCount < 1024)
        {
            order = "B";
        }
        else if (byteCount < 1048576)
        {
            order = "KB";
            byteCount = byteCount / 1024;
        }
        else if (byteCount < 1073741824)
        {
            order = "MB";
            byteCount = byteCount / 1048576;

        }
        else if (byteCount >= 1073741824)
        {
            order = "GB";
            byteCount = byteCount / 1073741824;
        }
        string result = byteCount + " " + order;
        return result;
    }


}
