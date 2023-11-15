internal class Program
{
    public static int NewZametki = 0;
    public static int BorderAll = 0;
    public static int BorderFirst = 3;
    public static int BorderThird = 2;
    public static int BorderMinusSecond = 1;
    public static List<Zam> zametki = new List<Zam>();
    public static DateTime mydate = new DateTime(2023, 11, 7);
    public static int WhichDay = 0;
    public static int WhereStrelka = 0;
    public static Zam FirstFirst = new Zam()
    {
        name = "Сходить на работу",
        data = new DateTime(2023, 11, 7),
        description = "Собраться, отработать рабочий день."
    };
    public static Zam SecondFirst = new Zam()
    {
        name = "Сходить на улицу",
        data = new DateTime(2023, 11, 7),
        description = "Выгулить собаку, выкинуть мусор."
    };
    public static Zam ThirdFirst = new Zam()
    {
        name = "Заплатить за учёбу",
        data = new DateTime(2023, 11, 7),
        description = "Снять деньги, зайти на сайт оплатить."
    };
    public static Zam FirstThird = new Zam()
    {
        name = "Приготовить ужин",
        data = new DateTime(2023, 11, 9),
        description = "Купить продуктов, приготовить по рецепту."
    };
    public static Zam SecondThird = new Zam()
    {
        name = "Убратсья дома",
        data = new DateTime(2023, 11, 9),
        description = "Подготовить химию для уборки, начать уборку"
    };
    public static Zam FirstMinusSecond = new Zam()
    {
        name = "Сходить пошопится",
        data = new DateTime(2023, 11, 6),
        description = "Заказать такси до тц, купить одежды"
    };
    static void Main()
    {
        Start();
    }
    static void Start()
    {
        zametki.Add(FirstFirst);
        zametki.Add(SecondFirst);
        zametki.Add(ThirdFirst);
        zametki.Add(FirstThird);
        zametki.Add(SecondThird);
        zametki.Add(FirstMinusSecond);
        while (true)
        {
            Menu();
            ConsoleKeyInfo Choice = Console.ReadKey();
            switch (Choice.Key)
            {
                case ConsoleKey.RightArrow:
                    IzmData("Вправо");
                    break;
                case ConsoleKey.LeftArrow:
                    IzmData("Влево");
                    break;
                case ConsoleKey.DownArrow:
                    Strelochki("Вниз");
                    break;
                case ConsoleKey.UpArrow:
                    Strelochki("Вверх");
                    break;
                case ConsoleKey.Enter:
                    List<Zam> sortedZametki = zametki.Where(note => note.data == mydate).ToList();
                    DopInf(sortedZametki[WhereStrelka - 1]);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
    static void Strelochki(string WhichSide)
    {
        Console.Clear();
        if (WhichSide == "Вверх")
        {
            if (WhereStrelka != 0)
            {
                WhereStrelka--;
            }
            if (WhereStrelka != 0)
            {
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
        }
        if (WhichSide == "Вниз")
        {
            if (WhichDay == 0 && WhereStrelka != BorderFirst)
            {
                WhereStrelka++;
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
            else if (WhichDay == -1 && WhereStrelka != BorderMinusSecond)
            {
                WhereStrelka++;
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
            else if (WhichDay == 2 && WhereStrelka != BorderThird)
            {
                WhereStrelka++;
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
            else if (WhichDay != 2 && WhichDay != -1 && WhichDay != 0 && BorderAll != 0)
            {
                WhereStrelka++;
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
            else
            {
                Console.SetCursorPosition(0, WhereStrelka);
                Console.Write("->");
            }
        }
    }
    static void IzmData(string WhichStrelochka)
    {
        Console.Clear();
        if (WhichStrelochka == "Влево")
        {
            mydate = mydate.AddDays(-1);
            WhichDay--;
            WhereStrelka = 0;
        }
        else if (WhichStrelochka == "Вправо")
        {
            mydate = mydate.AddDays(1);
            WhichDay++;
            WhereStrelka = 0;
        }
    }
    static void DopInf(Zam SelectedZametka)
    {
        Console.Clear();
        Console.WriteLine($"{SelectedZametka.name}\n{SelectedZametka.data}\n{SelectedZametka.description}");
        ConsoleKeyInfo i;
        if (WhereStrelka != 0)
        {
            do
            {
                i = Console.ReadKey();
            } while (i.Key != ConsoleKey.Enter);
        }
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        WhereStrelka = 0;
    }
    static void Menu()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"Выбрана дата {mydate}");
        int i = 0;
        foreach (Zam note in zametki)
        {
            if (note.data == mydate)
            {
                i++;
                Console.SetCursorPosition(2, i);
                Console.Write($"{i}.{note.name}");
            }
        }
    }
}
