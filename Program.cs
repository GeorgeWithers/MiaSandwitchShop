//string words = "Oh boy howdy, these sure are some nice words";
//File.WriteAllText("words.txt", words);

//string readText = File.ReadAllText("words.txt");
//Console.WriteLine(readText);

// start the program

Console.WriteLine("Starting program\nChecking files");
FileCheck(); // Check file integrity

Console.WriteLine(File.ReadAllText("mainMenu.txt")); // Display the main menu text

while (true)
{
    char key = Console.ReadKey().KeyChar;
    if (key == 'n' || key == 'N') { Console.WriteLine("n pressed"); }
    if (key == 'a' || key == 'A') { Console.WriteLine("a pressed"); }
    if (key == 'c' || key == 'C') { Console.WriteLine("c pressed"); }
    if (key == 'v' || key == 'V') { Console.WriteLine("v pressed"); }
    if (key == 'm' || key == 'M') { Console.WriteLine("Already at the main menu. Please make a slection from the list"); }
    else badInput();
    
}

static void newScreen(string screen)
{
    Console.Clear();;
    Console.WriteLine(File.ReadAllText(screen + ".txt"));
    return;
}

    static void FileCheck()
{
    bool file = true;
    file = File.Exists("data.txt");
    if (file == false) {
        Console.WriteLine("ERROR-noDataTxt");
        noData();
    }
    file = File.Exists("mainMenu.txt");
    if (file == false)
    {
        Console.WriteLine("ERROR-noMainMenuTxt");
        noData();
    }
    if (file == true)
    {
        return;
    }
}

static void badInput()
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
    Console.Write("Invalid Selection, choose a selection from the list ");
    return;
}

static void noData() // A function to handle the lack of needed data, either replaces file and continues or does nothing and exit
{
    Console.WriteLine("It seems the file that stores order data is missing. Would you like to replace these files with blank versions?\n\nBE ADVISED THIS WILL REMOVE ALL DATA\n\nERROR-noDataTxt \n\n Press \"y\" to complete this action or press any key to exit");
    string pressed = Console.ReadLine();
    if (pressed == "y")
    {
        File.Create("data.txt");
        Console.WriteLine("The missing data has been replaced. Normal operation will now resume.");
    }
    else
    {
        Console.WriteLine("No changes were made.\nRequired data is still missing and without these files being reinstated the app will continue to not fuction.\n\nPress any key to exit");
        Console.ReadKey();
        System.Environment.Exit(0);
    }
}