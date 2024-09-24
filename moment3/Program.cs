
using Guestspace;

string input = "";
Guest[] currentGuestBook;

while (input != "1" || input != "2" || input != "x")
{
    Console.WriteLine("C A L L E ' S   G U E S T B O O K");
    Console.WriteLine("\n\n1. Skriv i gästboken\n2. Ta bort inlägg \n\nX. Avsluta\n");
    currentGuestBook = Guestbook.getOldBook();
    Console.WriteLine("\nVäntar på kommand");
    input = Console.ReadLine().ToLower();
    if (input == "1")
    {
        Guestbook.addToBook(currentGuestBook);
    }
    else if (input == "2")
    {
        Guestbook.removeFromBook(currentGuestBook);
    }
    else if (input == "x")
    {
        break;
    }
    Console.Clear();
}


