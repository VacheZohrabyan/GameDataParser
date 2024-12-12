namespace GameDataParser.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public string ReadValidFilePath()
    {
        bool isFilePathValid = false;
        var fileName = default(string);
        do
        {
            Console.WriteLine("Enter the name of the file you want to read:");

            fileName = Console.ReadLine();
            if (fileName is null)
            {
                Console.WriteLine("The file name cannot be null.");
            }
            else if (fileName == string.Empty)
            {
                Console.WriteLine("The file name cannot be empty.");
            }
            else if (!File.Exists(fileName))
            {
                Console.WriteLine("The file name does not exist.");
            }
            else
            {
                isFilePathValid = true;
            }
        } 
        while (!isFilePathValid);
        return fileName;
    }

    public void PrintError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"JSON in the {message} file was not" +
                          " in a valid format. JSON body:");
        Console.ForegroundColor = originalColor;
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}