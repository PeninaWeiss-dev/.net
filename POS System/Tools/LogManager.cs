
namespace Tools;

public static class LogManager
{
    private const string path = "Log";
    public static string getThisMonthDir()
    {
        string route = $@"{path}\{DateTime.Now.Year}-{DateTime.Now.Month}";
        if (!Directory.Exists(route))
            Directory.CreateDirectory(route);
        return route;
    }

    public static string getTodayFile()
    {
        string route = $@"{getThisMonthDir()}\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.txt";
        if (!File.Exists(route))
            File.Create(route).Close();
        return route;
    }
    public static void WriteToLog(string projectName, string funcName, string message)
    {
        using (StreamWriter sw = new StreamWriter(getTodayFile(), true))
        {
            sw.WriteLine($"{DateTime.Now}\t{projectName}.{funcName}:\t{message}");
        }
    }

    public static void CleanOldDir()
    {
        if (!Directory.Exists(path))
            return;
        var directories = Directory.GetDirectories(path);
        foreach (var d in directories)
        {
            if (DateTime.TryParseExact(d, "yyyy-M",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime folderDate))
            {
                if (folderDate.AddMonths(2) < DateTime.Now)
                {
                    Directory.Delete(d, true);
                }
            }
        }
        Console.WriteLine("cleaned...");
    }
}
