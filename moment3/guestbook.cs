using System.Text.Json;
namespace Guestspace
{
    public class Guestbook
    {
        public static Guest[] getOldBook()
        {
            string oldbook = File.ReadAllText(@"guestbook.json");
            if (oldbook != "") //kollar så json filen är blank
            {
                Guest[] oldbookArr = JsonSerializer.Deserialize<Guest[]>(oldbook); //omvandlar json datan till array av guests
                for (int i = 0; i < oldbookArr.Length; i++)
                {
                    Console.WriteLine($"[{i+1}] {oldbookArr[i].Name} - {oldbookArr[i].Message}"); //skriver ut alla inlägg i boken
                }
                return oldbookArr; //returnerar en array med de olika guest objekten
            }
            return []; // om json är blank returneras en tom array
        }
        public static void addToBook(Guest[] currentBook)
        {
            List<Guest> bookList = new List<Guest>(currentBook); //omvandlar array till lista för att lättare justera innehåll
            string inputOwner = "";
            string inputMessage = "";
            bool validation = false;
            while (validation == false) //så länge någon av inputs lämnas blankt körs den om
            {
                Console.WriteLine("Skriv ditt namn");
                inputOwner = Console.ReadLine();
                Console.WriteLine("Lämna ett medelande");
                inputMessage = Console.ReadLine();
                if (inputOwner != "" && inputMessage != "")
                {
                    validation = true;
                }
            }
            Guest newGuest = new Guest() //skapar ett nytt guest objekt med input
            {
                Name = inputOwner,
                Message = inputMessage
            };
            bookList.Add(newGuest); //lägger till guest till lista
            updateBook(JsonSerializer.Serialize(bookList)); //konverterar listan till json och skickar till updateBook
        }

        public static void removeFromBook(Guest[] currentBook)
        {
            List<Guest> bookList = new List<Guest>(currentBook); //omvandlar array till lista för att lättare justera innehåll
            Console.WriteLine("Skriv numret på det inlägg som ska tas bort");
            string inputIndex = Console.ReadLine();
            bool isNr = int.TryParse(inputIndex, out int nr); //kollar så input är ett nummer
            int length = bookList.Count -1; //gör miuns 1 eftersom index startar på 0
            if (isNr) 
            {
                if (nr <= length) //om nummer som skrivit är mindre eller lika med length tas indexet bort
                {
                    bookList.RemoveAt(nr-1);
                    updateBook(JsonSerializer.Serialize(bookList)); //konverterar listan till json och skickar till updateBook
                }
            }
            
        }

        private static void updateBook (string newBook){
            File.WriteAllText(@"guestbook.json", newBook); //skriver in den nya json datan i filen guestbook.json
        }
    }
}