using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"D:"; // Boshlang'ich yo'l
        string dubpath = path;

        while (true)
        {
            Console.WriteLine("\n Papkalarni ko'rish: ");
            PrintFileFolder(dubpath);
            Console.Write("Enter folder name or command ('../' to go back): ");
            string fold = FolderIO(ref dubpath);
        }
    }

    static string FolderIO(ref string path)
    {
        string newfolder = Console.ReadLine()?.Trim(); // Kiritilgan qiymatni olish
        string fold = newfolder;

        // Agar foydalanuvchi '../' kiritsa, bitta papka orqaga qaytadi
        if (newfolder == "../")
        {
            string parentPath = Path.GetDirectoryName(path); // Yuqori papka yo'li
            if (!string.IsNullOrEmpty(parentPath))
            {
                path = parentPath; // Yuqori papkaga o'tish
            }
            else
            {
                Console.WriteLine("Siz ildiz papkadan chiqolmaysiz!");
            }
        }
        else
        {
            // Kiritilgan nomni hozirgi yo'lga qo'shish
            string newPath = Path.Combine(path, newfolder);
            if (Directory.Exists(newPath)) // Yangi yo'l mavjudligini tekshirish
            {
                path = newPath; // Yangi papkaga o'tish
            }
            else
            {
                Console.WriteLine($"Papka topilmadi: {newfolder}");
            }
        }

        Console.Clear();
        return fold;
    }

    public static void PrintFileFolder(string path)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(path);

        Console.WriteLine($" -- {dirInfo.Name} -- \n");
        Console.WriteLine($"{"|   File/Folder",-50}     | {"Size",-20} |");
        Console.WriteLine(new string('-', 79)); // Jadval chizig'i

        // Papkalarni ko'rsatish
        foreach (DirectoryInfo dir in dirInfo.GetDirectories())
        {
            Console.WriteLine($"| ..{dir.Name,-50} | {"<DIR>",-20} |");
        }

        // Fayllarni ko'rsatish
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            string fileName = file.Name.Length > 47
                ? file.Name.Substring(0, 47) + "..."
                : file.Name;

            Console.WriteLine($"| ..{fileName,-50} | {file.Length + " bytes",-20} |");
        }
    }
}
