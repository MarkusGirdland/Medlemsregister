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

                    if (input >= 0 && input <= 5)
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
                            ViewMessage("Inga medlemmar finns ännu, försök igen senare.", true);
                            break;
                        }

                        ViewMessage("Vilken medlem vill du ha information om?", false);
                        int whatMember = GetMemberNumber();

                        if (whatMember < 0)
                        {
                        }

                        else if (whatMember > (arrayPos - 1))
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                        }

                        else if (whatMember <= arrayPos)
                        {
                            GetMemberInfo(memberArray, whatMember);
                        }

                        break;

                    case 4:
                        // Redigera medlem
                       if (arrayPos == 0)
                        {
                            ViewMessage("Inga medlemmar finns ännu, försök igen senare.", true);
                            break;
                        }

                        ViewMessage("Vilken medlem vill du redigera?", false);
                        int whichMember = GetMemberNumber();

                        if (whichMember < 0)
                        {
                        }

                        else if (whichMember > (arrayPos - 1))
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                        }

                        else if (whichMember <= arrayPos)
                        {
                            EditMemberInfo(memberArray, whichMember);
                        }
                        break;

                    case 5:
                        // Ta bort medlem
                        ViewMessage("Femman", false);
                        break;
                }
            } while (input != 0);
        }


        static void ViewMenu()
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

        static void ViewMessage(string message, bool error)
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

        static Member AddMember()
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

        static void ViewMembers(Member[] array, int pos)
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
        }

        static void GetMemberInfo(Member[] array, int pos)
        {
            string printString;

            printString = array[pos].PrintDetailedToString();

            Console.WriteLine(printString);

            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();

        }

        static void EditMemberInfo(Member[] array, int pos)
        {
        }
        
    }
}
