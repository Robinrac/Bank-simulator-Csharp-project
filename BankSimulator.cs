using System;

namespace Bank 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //välkomstmeddelande samt förklaring till vad programmet är
            Console.WriteLine("--------------------");
            Console.WriteLine("Hej och Välkommen!");
            Console.WriteLine("--------------------");
            Console.WriteLine("Det här är en banksimulatodär du kan sätta in och ta ut pengar ur samt räkna ut ränktebetalning.");
            Console.WriteLine("--------------------");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Vad vill du göra?");

            //skapa värden vid start som senare används och förändras.
            //dessa världen är lagrade som integers eftersom värderna ska inte lagras som decimaler, endast hela tal
            int balance = 0;
            int increase = 0;
            int decrease = 0;

            //starta while loopen
            bool start = true;

            while (start)
            {
                //skriv kommandocenter
                Console.WriteLine("[I] Insättning");
                Console.WriteLine("[U] Uttag");
                Console.WriteLine("[S] Saldo");
                Console.WriteLine("[R] Räntebetalning");
                Console.WriteLine("[A] Avsluta");

                string action = Console.ReadLine();

                //skapa switchsats som genom user input beviljar och förflyttar användaren till handlingen som den vill utföra
                switch (action)
                {
                    //case i/I: be användaren och införa pengar till konto och addera det på saldovärdet
                    case "I":
                    case "i":
                        Console.WriteLine("Hur mycket pengar vill du föra in?");
                        increase = int.Parse(Console.ReadLine());

                        //se till att värdet inte är mindre än 1 genom if sats
                        if (increase <= 0)
                        {
                            Console.WriteLine("Var vänlig och för in ett värde över 0kr");
                        }
                        else if (increase > 0)
                        {
                            balance = balance + increase;
                            Console.WriteLine("Du har satt in " + increase + "kr på ditt bankkonto");
                        }

                        break;
                    //case u/U: be användaren och ta ut pengar från konto och subtrahera det på saldovärdet
                    case "U":
                    case "u": 
                        Console.WriteLine("Hur mycket pengar vill du ta ut?");
                        decrease = int.Parse(Console.ReadLine());

                        //se till att värdet inte är mindre än 1 genom if sats
                        if (decrease <= 0)
                        {
                            Console.WriteLine("Var vänlig och för in ett värde över 0kr");
                        }
                        else if (decrease > 0)
                        {
                            balance = balance - decrease;
                            Console.WriteLine("Du har tagit ut " + decrease + "kr från ditt bankkonto");
                        }
                        break;
                    //case s/S visa det nyast uppdaterade saldo värdet för användaren.
                    case "S":
                    case "s":
                        Console.WriteLine("Ditt saldo är: " + balance + "kr");
                        break;
                    //case r/R Räkna ut räntebetalning vid årlig insättning och visa det till kunden
                    case "R":
                    case "r":

                    //be om användarens årligt insättningsbelopp, räntesats samt år hen vill spara
                    //interestBalance och interestYearsbehöver endast vara en integer eftersom de ska endast lagra hela värden
                    //medans interestPercent behöver vara en double eftersom att den ska inehålla decimal nummer men inte extrema deciam nummer
                        Console.WriteLine("Hur mycket vill du sätta in per år?");
                        int interestBalance = int.Parse(Console.ReadLine());
                        Console.WriteLine("Vad är räntesatsen (i Procentenheter)?");
                        double interestPercent = Convert.ToDouble(Console.ReadLine()) / 100;
                        Console.WriteLine("Hur många år vill spara?");
                        int interestYears = int.Parse(Console.ReadLine());

                        double total = 0;

                    //Gör en for-loop som loopar beräkning av avkastning, öning.
                    //detta ska upprepa koden så många år som användaren ska skapa för att få rätt uträkning
                        for (int i = 1; i <= interestYears; i++)
                        {
                            total = total + interestBalance;


                            double returns = total * interestPercent;
                            total = total + returns;

                            //visa för användaren antal år, totalt belopp och avkastning per år.
                            //jag convertar sedan värderna till integers så att de avrundar till närmsta hela värde
                            Console.WriteLine("År: " + i + " Totalt belopp: " + (Convert.ToInt32(total)) + "kr Avkastning: " + (Convert.ToInt32(returns)) + "kr");

                        }

                        break;
                        //hejdå meddelande samt stänga av while loopen
                    case "A":
                    case "a":
                        Console.WriteLine("Tack för att du använde min banksimulator!");
                        start = false;
                        //om användaren matar in fel värde i while loopen så ska den be användaren att testa med rätt inmatning och ge användaren en till chans.
                        break;
                    default:
                        Console.WriteLine("inmatning fel, testa igen...");
                        break;
                        
                }  
            }
            Console.ReadLine();

        }

    }
}