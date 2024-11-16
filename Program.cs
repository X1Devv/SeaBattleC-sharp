public static class Program
{
    public static void Main(string[] args)
    {
        Logic.StartGame();
        bool SwitchMainField = true;

        while (true)
        {
            Console.Clear();

            if (SwitchMainField)
            {
                Console.WriteLine("Your");
                Logic.DrawField(Logic.Width, Logic.Hight, Logic.FieldMain);
            }
            else
            {
                Console.WriteLine("Enemy");
                Logic.DrawField(Logic.Width, Logic.Hight, Logic.FieldEnemy);
            }

            Console.WriteLine("Write Cords:(a-j 1-10)");
            var CoordinatesPLayer = Console.ReadLine();

            Logic.KillShips(SwitchMainField ? Logic.FieldMain : Logic.FieldEnemy, CoordinatesPLayer);
            SwitchMainField = !SwitchMainField;
        }
    }
}
