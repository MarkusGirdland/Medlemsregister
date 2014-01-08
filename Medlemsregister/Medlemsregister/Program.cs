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
                        ViewMessage("Tvåan", false);
                        break;

                    case 3:
                        //Info om medlem
                        ViewMessage("Trean", false);
                        break;

                    case 4:
                        // Redigera medlem
                        ViewMessage("Fyran", false);
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
            string nameInput;
            bool continueBool = false;
            Member myMember = new Member();

            do
            {
                Console.WriteLine("Vad är förnamnet?");
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                    break;
                }


                myMember.FirstName = nameInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;

                Console.WriteLine("Vad är efternamnet?");
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                    break;
                }


                myMember.LastName = nameInput;
                continueBool = true;

            } while (!continueBool);


            return myMember;
        }
            
        
    }
}
