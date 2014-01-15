using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayPos = 0;
            int input = 0;
            Member[] memberArray = new Member[100];
 
            do
            {
                ViewMenu();

                try
                {
                    input = 10;
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input <= 5)       // Rätt val i menyn
                    {
                    }

                    else
                    {
                        ViewMessage("FEL! Ange ett nummer mellan 0 och 5.", true);
                    }
                }

                catch
                {
                    ViewMessage("FEL! Ange ett nummer mellan 0 och 5.", true);
                }

                switch (input)
                {
                    case 0:
                        continue;

                    case 1:
                        // Skapa medlem 
                        memberArray[arrayPos] = AddMember();
                        arrayPos++;
                        break;

                    case 2:
                        // Lista medlem
                        ViewMembers(memberArray, arrayPos);
                        break;

                    case 3:
                        //Info om medlem
                        if (arrayPos == 0)
                        {
                            ViewMessage("Inga medlemmar finns ännu, försök igen senare.", true);        // Om inga medlemmar finns
                            break;
                        }

                        ViewMessage("Vilken medlem vill du ha information om?", false);
                        int whatMember = GetMemberNumber();     // Skaffar rätt position

                        if (whatMember < 0)
                        {
                        }

                        else if (whatMember > (arrayPos - 1))                   // Kollar data, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                        }

                        else if (whatMember <= arrayPos)
                        {
                            GetMemberInfo(memberArray, whatMember);         // Hittar och visar data
                        }
                            ViewMessage("Inga medlemmar finns ännu, försök igen senare.", true);
                            break;
                        

                    case 4:

                        ViewMessage("Vilken medlem vill du redigera?", false);
                        int whichMember = GetMemberNumber();        // Hittar rätt nummer

                        if (whichMember < 0)
                        {
                        }

                        else if (whichMember > (arrayPos - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                        }

                        else if (whichMember <= arrayPos)
                        {
                            EditMemberInfo(memberArray, whichMember);       // Hittar och tillåter ändring av data
                        }
                        break;

                    case 5:
                        // Ta bort medlem
                        ViewMessage("Vilken medlem vill du radera?", false);
                        int whoMember = GetMemberNumber();        // Hittar rätt nummer

                        if (whoMember < 0)
                        {
                        }

                        else if (whoMember > (arrayPos - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                        }

                        else if (whoMember <= arrayPos)
                        {
                            memberArray = DeleteMember(memberArray, whoMember);       // Hittar och raderar
                            arrayPos--;
                            
                        }
                        break;
                }
            } while (input != 0);
        }       // Mainfunktion


        static void ViewMenu()      // Menyn
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("======================================");
            Console.WriteLine("=                                    =");
            Console.WriteLine("=         Medlemsregister            =");
            Console.WriteLine("=                                    =");
            Console.WriteLine("======================================\n");
            Console.ResetColor();

            Console.WriteLine("0. Avsluta.\n");
            Console.WriteLine("1. Registrera ny medlem \n");
            Console.WriteLine("2. Lista medlemmar \n");
            Console.WriteLine("3. Få ut information om medlem \n");
            Console.WriteLine("4. Redigera medlem \n");
            Console.WriteLine("5. Ta bort medlem \n");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("\nAnge menyval [0-5]:");
        }

        static void ViewMessage(string message, bool error)     // Meddelandefunktion
        {
            if(error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        static Member AddMember()       // Lägg till medlemsfunktion
        {
            string nameInput = "John";
            bool continueBool = false;
            Member myMember = new Member();

            do
            {
                Console.WriteLine("Vad är förnamnet?");         // Förnamn
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                myMember.FirstName = nameInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;

                Console.WriteLine("Vad är efternamnet?");           // Efternamn
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                myMember.LastName = nameInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;
                int numberInput = 0;

                Console.WriteLine("Vad är telefonnumret?");           // Telefonnummer
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                    continueBool = true;
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }



                myMember.PhoneNumber = numberInput;
                

            } while (!continueBool);

            myMember.CreateMemberNumber();

            return myMember;
        }

        static void ViewMembers(Member[] array, int pos)        // Visar medlemmar
        {
            Console.Clear();
            string printString;

            if (pos == 0)
            {
                ViewMessage("Inga medlemmar är inlagda ännu. Försök igen senare.", true);
            }

            else
            {
                for (int i = 0; i < pos; i++)
                {
                    printString = array[i].PrintToString();
                    Console.WriteLine(printString);   
                }

                Console.WriteLine("Tryck på en tangent för att fortsätta...");
                Console.ReadKey();
            }
        }

        static int GetMemberNumber()        
        {
            int numberInput = 0;
  

            
            Console.WriteLine("Obs! Anges i den ordning som medlemmar visas i medlemslistan!");
            Console.WriteLine("(0 för att avbryta)\n");

            do
            {
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Hittade inte medlem, försök igen.", true);
                }

                if(numberInput == 0)
                {
                    break;
                }

                else if(numberInput > 0 && numberInput <= 100)
                {
                    numberInput = numberInput - 1;
                    return numberInput;
                }

                else
                {
                    ViewMessage("Hittade inte medlem, försök igen.", true);
                }
            }while(numberInput != 0);

            return -1;
        }               // Få numret

        static void GetMemberInfo(Member[] array, int pos)
        {
            string printString;

            printString = array[pos].PrintDetailedToString();

            Console.WriteLine(printString);

            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();

        }       // Få info

        static void EditMemberInfo(Member[] array, int pos)
        {
            int input = 10;
            int number;
            string nameInput;
            string name;

            


            

          

            do
            {
                string printIt = array[pos].PrintDetailedToString();
                Console.Clear();
                Console.WriteLine(printIt, "\n");

                Console.WriteLine("Vilken egenskap vill du ändra? \n");
                Console.WriteLine("0. Avsluta\n1. Förnamn\n2. Efternamn\n3. Telefonnummer\n4. Medlemsnummer");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Inte ett tal mellan 0-4, försök igen.", true);
                }

                if (input < 0 && input > 4)
                {
                    ViewMessage("Inte ett tal mellan 0-4, försök igen.", true);
                }

                else if (input == 1)
                {
                    name = array[pos].FirstName;

                    Console.WriteLine("Vad vill du byta {0} till?", name);

                    nameInput = Console.ReadLine();

                    array[pos].FirstName = nameInput;
                }

                else if (input == 2)
                {
                    name = array[pos].LastName;

                    Console.WriteLine("Vad vill du byta {0} till?", name);

                    nameInput = Console.ReadLine();

                    array[pos].LastName = nameInput;
                }

                else if (input == 3)
                {
                    bool continueBool = false;
                    number = array[pos].PhoneNumber;

                    do
                    {
                        continueBool = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", number);           // Telefonnummer

                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool = false;
                        }

                        if (numberInput < 0)
                        {
                            ViewMessage("Måste vara större än 0, försök igen.", true);
                            continueBool = false;
                        }



                        array[pos].PhoneNumber = numberInput;


                    } while (!continueBool);
                }

                else if (input == 4)
                {
                    bool continueBool = false;
                    number = array[pos].MemberNumber;

                    do
                    {
                        continueBool = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", number);           // Medlemsnummer

                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool = false;
                        }

                        if (numberInput < 0)
                        {
                            ViewMessage("Måste vara större än 0, försök igen.", true);
                            continueBool = false;
                        }

                        array[pos].MemberNumber = numberInput;


                    } while (!continueBool);
                }

            } while (input != 0);
        }       // Ändra medlem

        static Member[] DeleteMember(Member[] array, int pos)       // Ta bort medlem
        {

            var newList = array.ToList();
            newList.RemoveAt(pos);
            Member[] newArray = new Member[100];
            newArray = newList.ToArray();

            return newArray;
        }
        
    }
}
