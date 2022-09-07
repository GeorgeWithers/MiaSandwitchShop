//string words = "Oh boy howdy, these sure are some nice words";
//File.WriteAllText("words.txt", words);

//string readText = File.ReadAllText("words.txt");
//Console.WriteLine(readText);

// start the program

using System.ComponentModel.Design;
// Main loop - this program works by hopping between subroutines so after these blocks its subroutine city
Console.WriteLine("Starting program\nChecking files");
FileCheck(); // Check file integrity
newScreen("mainMenu"); // Display the main menu text

//
//  The input handling subroutines
//

static void mainMenu()
    {
    char key = Console.ReadKey().KeyChar;
    if (key == 'n' || key == 'N') { newScreen("n"); }
    if (key == 'a' || key == 'A') { newScreen("a"); }
    if (key == 'c' || key == 'C') { newScreen("c"); }
    if (key == 'v' || key == 'V') { newScreen("v"); }
    if (key == 'm' || key == 'M') { alreadyHome(); }
    else { badInput(); } 
}

// Clears the screen and writes the contents of the next screen
static void newScreen(string screen) // Inputs for the main menu
{
    Console.Clear();;
    Console.WriteLine(File.ReadAllText(screen + ".txt"));
    whatNext(screen);
}

static void newOrder() {
    Console.WriteLine("Input handling code goes here");
    while (true) ;
}

static void ammendOrder()
{
    Console.WriteLine("Input handling code goes here");
    while (true) ;
}
static void cancelOrder()
{
    Console.WriteLine("Input handling code goes here");
    while (true) ;
}
static void viewOrder()
{
    Console.WriteLine("Input handling code goes here");
    while (true) ;
}


// A function to figure out which set of input handlers to go to next
static void whatNext(string screen)
{
    if (screen == "mainMenu") { mainMenu(); } 
    if (screen == "n") { newOrder(); }
    if (screen == "a") { ammendOrder(); }
    if (screen == "c") { cancelOrder(); }
    if (screen == "v") { viewOrder(); }
    else badParam();
}

//
//  Function checks the integrity of required files (long function - not optimised)
//  Data file missing gets special attention becuase I feel like it
//

    static void FileCheck()
{
    bool file = true;
    //  Check data.txt
    file = File.Exists("data.txt");
    if (file == false) {
        Console.WriteLine("ERROR-noDataTxt");
        noData();
    }
    
    //  Check mainMenu.txt
    file = File.Exists("mainMenu.txt");
    if (file == false) { fileMissing("mainMenu.txt"); }

    //  Check n.txt (new order)
    file = File.Exists("n.txt");
    if (file == false) { fileMissing("n.txt"); }

    //  Check v.txt (view order)
    file = File.Exists("v.txt");
    if (file == false) { fileMissing("v.txt"); }

    //  Check a.txt (ammend order)
    file = File.Exists("a.txt");
    if (file == false) { fileMissing("a.txt"); }

    //  Check c.txt (cancel order)
    file = File.Exists("c.txt");
    if (file == false) { fileMissing("c.txt"); }
    //  If the files pass:
    if (file == true)
    {
        Console.WriteLine("The file check completed successfuly");
        return;
    }
    // Should never get here but just in case of solar flares:
    else {
        Console.WriteLine("The file check has failed for some unknown reason, If the problem persists call support\r\nERROR-fileCheckFail");
        killProgram(true);    
    }
}

//
// ERROR HANDLING AND DEBUGING FUNCS
//

static void alreadyHome() // If the user is trying to access the menu from the main menu call this
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
    Console.Write("You are already at the main menu choose from the list");
    return;
}

static void badInput() // if the user makes a bad selection, call this
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
        return;
    }
    else
    {
        Console.WriteLine("No changes were made.\nRequired data is still missing and without these files being reinstated the app will continue to not fuction.\n\nPress any key to exit");
        Console.ReadKey();
        System.Environment.Exit(0);
    }
}

static void badParam() // Call this if a bad parameter is passed between functions
{
    Console.WriteLine("The prgram encountered and internal error\r\nIf this error persists please contact support\r\n\r\nERROR-badParameter\r\n\r\n");
    killProgram(true);
}

static void fileMissing(string file)
{
    Console.WriteLine("During a check of required program files one or more was missing. Missing file:");
    Console.WriteLine(file);
    Console.WriteLine("ERROR-MissingFile");
    killProgram(true);
}

static void killProgram(bool error) // Takes a bool to decide if it should wait for a key press before exiting
{
    if (error == true)
    {
        Console.WriteLine("Press any key to close the program\r\n");
        Console.ReadKey();
        System.Environment.Exit(0);
    }
    else if (error == false)
    {
        Console.ReadKey();
        System.Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Exit cause unknown\r\nPress any key to exit");
        System.Environment.Exit(0);
    }
} 