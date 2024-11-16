public class Logic
{
    public static int Width = 10;
    public static int Hight = 10;
    public static int ShipInTheField = 5;

    public static char[,] FieldMain = new char[Hight, Width];
    public static char[,] FieldEnemy = new char[Hight, Width];

    public static void CreateField()
    {
        for (int i = 0; i < Hight; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                FieldMain[i, j] = '.';
                FieldEnemy[i, j] = '.';
            }
        }
    }
    public static void DrawField(int Width, int Hight, char[,] Feld)
    {
        Console.Write("  ");
        for (int Count = 1; Count <= Width; Count++)
        {
            Console.Write(Count + " ");
        }
        Console.WriteLine();

        for (int Row = 0; Row < Hight; Row++)
        {
            Console.Write((char)('a' + Row) + " ");
            for (int Count = 0; Count < Width; Count++)
            {
                Console.Write(Feld[Row, Count] + " ");
            }
            Console.WriteLine();
        }
    }

    public enum TopCord
    {
        a = 1,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j
    }

    public static void PlaceShipsRandom(char[,] Feld)
    {
        Random random = new Random();
        int PaceInField = 0;

        while (PaceInField < ShipInTheField)
        {
            int X = random.Next(0, Width);
            int Y = random.Next(0, Hight);

            if (Feld[Y, X] == '.')
            {
                Feld[Y, X] = 'U';
                PaceInField++;
            }
        }
    }

    public static void KillShips(char[,] Feld, string Coordinates)
    {
        var Part = Coordinates.Split(' ');
        if (Part.Length != 2) return;

        int X = int.Parse(Part[1]) - 1;
        int Y = (int)Enum.Parse(typeof(TopCord), Part[0].ToLower()) - 1;

        if (Feld[Y, X] == 'U')
        {
            DrawGridForShip(Feld, X, Y);
            Feld[Y, X] = 'X';

        }
        else
        {
            Feld[Y, X] = '#';
        }
    }

    private static void DrawGridForShip(char[,] Feld, int X, int Y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int NewX = X + i;
                int NewY = Y + j;

                if (NewX >= 0 && NewX < Width && NewY >= 0 && NewY < Hight)
                {
                    if (Feld[NewY, NewX] == '.')
                        Feld[NewY, NewX] = '#';
                }
            }
        }
    }

    public static void StartGame()
    {
        CreateField();
        PlaceShipsRandom(FieldMain);
        PlaceShipsRandom(FieldEnemy);
    }
}
