// For Directory.GetFiles and Directory.GetDirectories 
// For File.Exists, Directory.Exists 

// fsutil file createnew test.txt 52428800 für dummyfiles

using System;
using System.IO;
using System.Linq;

public class EmailFolderProcessor
{
    static string path = "C:\\neu";
    static long byteCount;

    public static void Main()
    {
        byteCount = GetFileSizeSumFromDirectory(path);
        Console.WriteLine("Press any key!");
        Console.ReadKey();
    }
    public static long GetFileSizeSumFromDirectory(string searchDirectory)
    {


        var files = Directory.EnumerateFiles(searchDirectory);

        // get the sizeof all files in the current directory
        var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();
        
        var directories = Directory.EnumerateDirectories(searchDirectory);

        // get the size of all files in all subdirectories
        var subDirSize = (from directory in directories select GetFileSizeSumFromDirectory(directory)).Sum();
        DirectoryInfo info = new DirectoryInfo(@searchDirectory);
        Console.Write(info);
        Console.WriteLine(" " + CountResult(currentSize + subDirSize));
        return currentSize + subDirSize;
    }

    public static string CountResult(long byteCount)
    {
        string answer = "";

        if (byteCount >= 1073741824)
        {
            answer = byteCount / 1073741824 + "." + byteCount % 1073741824 + " GB";
        }
        else if (byteCount >= 1048576)
        {
            answer = byteCount / 1048576 + "." + byteCount % 1048576 + " MB";
        }
        else if (byteCount >= 1024)
        {
            answer = byteCount / 1024 + "." + byteCount % 1024 + " KB";
        }
        else if (byteCount > 1)
        {
            answer = byteCount + " B";
        }
        return answer;
    }
}
