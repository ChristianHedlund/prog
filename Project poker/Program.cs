//kortlek
using System.Globalization;
using System.Runtime.InteropServices;
List<string> cards = new List<string>()
{
"Hjärter Ess", "Hjärter 2", "Hjärter 3", "Hjärter 4", "Hjärter 5", "Hjärter 6", "Hjärter 7", "Hjärter 8", "Hjärter 9", "Hjärter 10", "Hjärter Knekt", "Hjärter Dam", "Hjärter Kung", "Spader Ess", "Spader 2", "Spader 3", "Spader 4", "Spader 5", "Spader 6", "Spader 7", "Spader 8", "Spader 9","Spader 10", "Spader Knekt", "Spader Dam", "Spader Kung", "Klöver Ess", "Klöver 2", "Klöver 3", "Klöver 4", "Klöver 5", "Klöver 6", "Klöver 7", "Klöver 8", "Klöver 9", "Klöver 10", "Klöver Knekt", "Klöver Dam", "Klöver Kung", "Ruter Ess", "Ruter 2", "Ruter 3", "Ruter 4", "Ruter 5", "Ruter 6", "Ruter 7", "Ruter 8", "Ruter 9", "Ruter 10", "Ruter Knekt", "Ruter Dam", "Ruter Kung"
};

//hand
List<string> hand = new List<string>(5);
Random rand = new Random();
for (int i = 0;  i < 5; i++)
{
    Deal();
}


Console.WriteLine("Låt oss spela poker");
Thread.Sleep(1000);
Console.WriteLine("Här är din hand");
Thread.Sleep(1000);
show();
Thread.Sleep(1000);


//Byte 1
string ans = "Start";
while(ans.ToLower() != "nej" && ans.ToLower() != "ja")
{
    Console.WriteLine("Vill du byta kort? 1/2 (ja eller nej)");
    ans = Console.ReadLine();
    try
    {
        if (ans.ToLower() == "ja")
        {
            while(true)
            {

                try
                {
                    Console.WriteLine("Vilka kort vill du byta?(skriv in alla nummer som du vill byta med ett mellanslag mellan varje nummer)");
                    ans = Console.ReadLine();
                    var cardchange = ans.Split(' ');
                    for (int i = 0; i < cardchange.Length; i++)
                    {
                        var indexcards = rand.Next(cards.Count);
                        int indexhand = int.Parse(cardchange[i]);
                        hand[indexhand] = (cards[indexcards]);
                        cards.RemoveAt(indexcards);
                    }
                    show();
                    break;
                }
                catch
                {
                    Console.WriteLine("Nu blev det fel inmatning. Talen måste vara mellan 0 och 4. Det får inte vara något mellanrum i slutet häller.");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
            //Byte 2
            Thread.Sleep(1000);
            while(ans.ToLower() != "nej" && ans.ToLower() != "ja")
            {
                Console.WriteLine("Vill du byta kort? 2/2 (ja eller nej)");
                ans = Console.ReadLine();
                try
                {
                    if (ans.ToLower() == "ja")
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Vilka kort vill du byta?(skriv in alla nummer som du vill byta med ett mellanslag mellan varje nummer)");
                                var ans2 = Console.ReadLine();
                                var cardchange = ans2.Split(' ');
                                for (int i = 0; i < cardchange.Length; i++)
                                {
                                    var indexcards = rand.Next(cards.Count);
                                    int indexhand = int.Parse(cardchange[i]);
                                    hand[indexhand] = (cards[indexcards]);
                                    cards.RemoveAt(indexcards);
                                }
                                show();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Nu blev det fel inmatning. Talen måste vara mellan 0 och 4. Det får inte vara något mellanrum i slutet häller.");
                                Console.WriteLine();
                                Thread.Sleep(1000);
                            }
                        }
                    }
                    else if (ans.ToLower() == "nej")
                    {
                        show();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Nu blev det inte rätt. Skriv endast ja eller nej");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
        else if (ans.ToLower() == "nej")
        {
            show();
        }
        else
        {
                throw new ArgumentException();
        }
    }
    catch(ArgumentException)
    {
        Console.WriteLine("Nu blev det inte rätt. Skriv endast ja eller nej");
        Console.WriteLine();
        Thread.Sleep(1000);
    }
}
try
{
    while (ans!= "jag")
    {

        Console.WriteLine("Vilka kort vill du byta?(skriv in alla nummer som du vill byta med ett mellanslag mellan varje nummer)");
        ans = Console.ReadLine();
        var cardchange = ans.Split(' ');
        for (int i = 0; i < cardchange.Length; i++)
        {
            var indexcards = rand.Next(cards.Count);
            int indexhand = int.Parse(cardchange[i]);
            hand[indexhand] = (cards[indexcards]);
            cards.RemoveAt(indexcards);
        }

        show();
    }
}
catch
{
    Console.WriteLine();
}
Thread.Sleep(1000);

//Räknar ut resultat
List<string> house = new List<string>()
{
    "Hjärter","Spader","Ruter", "Klöver"
};

List<string> number = new List<string>()
{

    "Ess","2","3","4","5","6","7","8","9","10","Knekt","Dam","Kung","Ess"

};

List<string> maxnum = new List<string>();
List<string> maxhouse = new List<string>();

for (int i = 0; i < 14; i++)

{

    int count = 0;

    foreach (string str in hand)
    {

        if (str.EndsWith(number[i])) count++;

    }

    maxnum.Add(count.ToString());
}

for (int i = 0; i<4; i++)
{
    int count = 0;
        foreach (string str in hand)
    {
        if (str.StartsWith(house[i])) count++;
    }
    maxhouse.Add(count.ToString());
}


for (int i = 0; i < 4; i++)
{
    int count = 0;
    foreach (string str in hand)
    {
        if (str.StartsWith(house[i])) count++;
    }
    maxhouse.Add(count.ToString());
}
int par = 0;
foreach (string str in maxnum)
{
    if (str.Contains("2"))
    {
        par++;
    }
}
bool triss = false;
foreach (string str in maxnum)
{
    if (str.Contains("3"))
    {
        triss=true;
    }
}
bool fyrtal = false;
foreach (string str in maxnum)
{
    if (str.Contains("4"))
    {
        fyrtal=true;
    }
}
bool färg = false;
foreach (string x in maxhouse)
{
    if (x.Contains("5"))
    {
        färg=true;
    }
}
bool stege = false;
int count1 = 0;
foreach  (string i in maxnum)
{
    if (i == "1")
    {
        count1++;
    }
    else
    {
        count1 = 0;
    }
   if (count1 == 5)
    {
        stege = true;
    }
}


//Par
bool worth = false;
if (par >= 1)
{
    if (par == 2)
    {
        Console.WriteLine("Två Par!");
    }
    else if(triss == true)
    {
        Console.WriteLine("Kåk");
    }
    else
    {
        Console.WriteLine("Par!");
    }
    worth = true;
}
//Triss och fyrtal
if(triss == true)
{
    if(fyrtal == true)
    {
        Console.WriteLine("Fyrtal!");
    }
    else
    {
    Console.WriteLine("Triss!");
    }
    worth = true;
}
//Färg, Färgad stege och Royal flush
if(färg == true)
{
    if (stege == true && hand.Contains("Kung") && hand.Contains("Ess"))
    {
        Console.WriteLine("Royal Flush! Riktigt tur!");
    }
    else if (stege == true )
    {
        Console.WriteLine("Färg stege!");
    }
    else 
    {
        Console.WriteLine("Färg!");
    }
    worth = true;
}
if(stege == true)
{
    Console.WriteLine("Stege");
    worth = true;
}
if (worth == false)
{
    Console.WriteLine("Ajdå. Du fick inget!");
}


void Deal()
{
    int index = rand.Next(cards.Count);
    hand.Add(cards[index]);
    cards.RemoveAt(index);
}

void show()
{
    int num = -1;
    foreach (string a in hand)
    {
        num = num + 1;
        Console.Write(num + ": ");
        Console.WriteLine(a);
    }
}