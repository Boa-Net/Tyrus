using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cat
{
    internal class Tyrus // this is an application to run a digimon-esque cat. Named Tyrus just cause
    {
        private int affection; //variable that determines affection and events that happen
        private int dayValue;
        private string catName;
        public static void Main(string[] args)
        {
            Tyrus CatObj = new Tyrus();
            CatObj.FullDay();

            /*CatObj.BootUpArt();

            String catName = CatObj.Name();

            int arrayPicker = CatObj.RndSeed(5);
            CatObj.FoodSeed(arrayPicker, 0);
            CatObj.Feed(catName, arrayPicker);*/
        }
        private void FullDay()
        {
            if (dayValue < 1)
            {
                Tyrus CatObj = new Tyrus();

                DayArt();
                BootUpArt();

                Console.WriteLine("\n{0} is looking neutral today. \nAffection: {1}\n\n", this.affection);
                Console.WriteLine("{0} is hungry for their breakfast! Let's feed them.", catName);
                int arrayPicker = CatObj.RndSeed(5);
                CatObj.FoodSeed(arrayPicker, 0);
                CatObj.Feed(arrayPicker);


                //or perhaps "this" is really useful. Look into fields...
                //
                //perhaps, depending on how much stuff i need to return, have each value correspond to a character in a string.
                //This indicates what value is saved.
                //Ex. the first character is affection points. The string reads this and converts it to carry affection
            }
            else
            {
                DayArt();
                BootUpArt();

                Console.WriteLine("What would you like to do with {0}?", catName);
            }
        }
        private void DayArt()
        {
            Console.WriteLine("r---x\t   ,^,\t\\     /   \t");
            Console.WriteLine("|    \\\t  /   \\\t \\   /   \t");
            Console.WriteLine("|     |\t /_____\\  \\ /   \t");
            Console.WriteLine("|     |\t |     |   |    \t");
            Console.WriteLine("|    /\t |     |   |    \t");
            Console.WriteLine("L___/\t |     |   |    \t");

            if (dayValue == 1)
            {
                Console.WriteLine("\n\n     \t    1");
                Console.WriteLine("     \t   11");
                Console.WriteLine("     \t  1 1");
                Console.WriteLine("     \t    1");
                Console.WriteLine("     \t    1");
                Console.WriteLine("     \t  11111");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 2)
            {
                Console.WriteLine("\n\n     \t   222");
                Console.WriteLine("     \t  2   2");
                Console.WriteLine("     \t       2");
                Console.WriteLine("     \t      2");
                Console.WriteLine("     \t    22");
                Console.WriteLine("     \t  222222");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 3)
            {
                Console.WriteLine("\n\n     \t  3333");
                Console.WriteLine("     \t     3");
                Console.WriteLine("     \t    3");
                Console.WriteLine("     \t     3");
                Console.WriteLine("     \t  3   3");
                Console.WriteLine("     \t   333");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 4)
            {
                Console.WriteLine("\n\n     \t   4 4"); // put escape sequence n twice here. Just easier to read rn
                Console.WriteLine("     \t  4  4");
                Console.WriteLine("     \t  44444");
                Console.WriteLine("     \t     4");
                Console.WriteLine("     \t     4");
                Console.WriteLine("     \t     4");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 5)
            {
                Console.WriteLine("\n\n     \t  55555"); // put escape sequence n twice here. Just easier to read rn
                Console.WriteLine("     \t  5");
                Console.WriteLine("     \t  55");
                Console.WriteLine("     \t    55");
                Console.WriteLine("     \t      5");
                Console.WriteLine("     \t  5555");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 6)
            {
                Console.WriteLine("\n\n     \t  666"); // put escape sequence n twice here. Just easier to read rn
                Console.WriteLine("     \t 6");
                Console.WriteLine("     \t 66");
                Console.WriteLine("     \t 6 666");
                Console.WriteLine("     \t 6    6");
                Console.WriteLine("     \t  6666");
                Console.WriteLine("__________________________");
            }
            else if (dayValue == 7)
            {
                Console.WriteLine("\n\n     \t 7777777"); // put escape sequence n twice here. Just easier to read rn
                Console.WriteLine("     \t      7");
                Console.WriteLine("     \t     7");
                Console.WriteLine("     \t    7");
                Console.WriteLine("     \t   7");
                Console.WriteLine("     \t  7");
                Console.WriteLine("__________________________");
            }
            else
            {
                Console.WriteLine("Something is wrong with this program. You should exit.");
                Thread.Sleep(10000);
                Environment.Exit(107);
            }
            
            Thread.Sleep(2000);

            Console.Clear();

        } //loads day art to give visual cue of days changing.
        private void BootUpArt() //loads art upon bootup
        {

            Console.WriteLine("\t\t        X     X");
            Console.WriteLine("\t\t       / \\   / \\");
            Console.WriteLine("\t\t      /   \\ /   \\");
            Console.WriteLine("\t\t     |     V     |");
            Console.WriteLine("\t\t     | {|}   {|} |");
            Console.WriteLine("\t\t  ==={     X     }===");
            Console.WriteLine("\t\t      \\_________/");
            Console.WriteLine("\t\t       ===(|)===");
            Console.WriteLine("\t\t           0\n");

        }
        private void setName() //asks for name then stores it back in the field
        {
            Console.WriteLine("Name your cat!");
            this.catName = Console.ReadLine();
            Console.WriteLine("Your cat's name is {0}...", catName);
        }

        private int RndSeed(int maxVal) //determines a random number dependent on value put in. This is only done so that FoodSeed has a consistent return depending on the day.
        {

            Random rnd = new Random();
            return rnd.Next(maxVal);

        }
        private int FoodSeed(int arrayPicker, int objectPicker) //random function to determine which array to use for food choice preference, then storing to Main()
        {
            //dont forget to call rndSeed before this function to randomize.
            int[,] fSeedList = new int[6, 3]
               {{ 1, 2, 3 }, 
                { 1, 3, 2 }, 
                { 2, 1, 3 },  // 1 is dislike, 2, is like, 3 is love
                { 2, 3, 1 }, 
                { 3, 2, 1 }, 
                { 3, 1, 2 }}; //return values from these arryas, a random one each time. Hint is dependent on what thing is hit here.


            //ok, maybe turn 0 into a variable for multiple calls that increment the value to change the call
            
            return fSeedList[arrayPicker, objectPicker];
        }
        private void Feed(int arrayPicker)
        {
            Random rnd = new Random();
            Tyrus CatObj = new Tyrus();
            //have to give hint BEFORE food choice determined. Likely another method.
            
            Console.WriteLine("What do you want to feed {0}?", catName);
            Console.WriteLine("1. Mouse\n2. Friskies\n3. Whipped Cream");

            // mouse: mouse will flash on screen, walk, then tyrus appears behind
            // friskie's: make a cat food tin, have it be peeled open with sound, then tyrus appears
            //whipped cream: sound and a pile created


            int mouse = CatObj.FoodSeed(arrayPicker, 0);
            int friskies = CatObj.FoodSeed(arrayPicker, 1); 
            int whippedCream = CatObj.FoodSeed(arrayPicker, 2);

            Console.WriteLine("{0} mouse, {1} friskies, {2} whipped cream", mouse, friskies, whippedCream);

            int loveChoice = 3;
            int likeChoice = 2;
            int hateChoice = 1;

            int foodChoice = 0;
            bool fcLoop = true;
            while (fcLoop == true)
            { 
                if (!int.TryParse(Console.ReadLine(), out var foodType) || ((foodType < 1) || (foodType > 3)))
                {
                    Console.WriteLine("Invalid!");
                }
                else
                {
                    foodChoice = foodType;
                    fcLoop = false;
                } // INCORPORATE SCREEN AND CLEAR TYRUS, have a sort of old slideshow ascii art
            }
                Console.WriteLine(foodChoice);

            string foodDec = "";

            if (foodChoice == 1)
            {
                foodChoice = mouse;
                foodDec = "Mouse";//food "declaration". helps string concantenation later

            }
            else if (foodChoice == 2)
            {
                foodChoice = friskies;
                foodDec = "Friskies";
            }
            else if (foodChoice == 3)
            {
                foodChoice = whippedCream;
                foodDec = "Whipped Cream";
            }

            if (foodChoice == loveChoice)
            {
                Console.WriteLine("{0} loved the {1}!", catName, foodDec);
                affection += 2;
            }
            else if (foodChoice == likeChoice)
            {
                Console.WriteLine("{0} was okay with the {1}!", catName, foodDec);
            }
            else if (foodChoice == hateChoice)
            {
                Console.WriteLine("You have displeased {0} greatly...", catName);
                affection -= 2;
            }

            Console.WriteLine(affection);
        }
    }
}



/*Functions for Tyrus
 * Feed (make a little game for this too)
 * Talk (he will just say meow. 10% chance to give a point, and guarantee to give a hint regarding food preferences)
 * Pet (easy way to gain an affection pet, but random number to determine how many times you can before he bites and you lose all the points gained -1)
 * Play (press space at right time to play)
 * Bath (EXTREME DANGER, alert noises???) MUST GIVE BATH AT 7 POINTS)
 * All nestled in a repeating day function?
 */

//Affection Points function,,, if Tyrus gets to 10, you win! If he gets to -10, he explodes
//press space at right time to play?


//this is IMPORTANT: have affection checker after most main methods