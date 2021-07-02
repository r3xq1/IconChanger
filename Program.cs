namespace IconChanger
{
    using System;
    using System.Windows.Forms;

    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.Title = "Icon Changer";
            if (args.Length < 1)
            {
                Console.WriteLine("Использование: Перетащите ваш файл на программу");
                Console.ReadKey(true);
                Environment.Exit(1);
            }
            Console.WriteLine("Выберите иконку для замены...");
            using var filedi = new OpenFileDialog
            {
                Title = "[Icon Changer] - Выберите иконку для билд файла",
                Filter = "Ico File (*.ico)|*.ico",
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                Multiselect = false,
                InitialDirectory = Environment.CurrentDirectory
            };
            if (filedi.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"Выбрана иконка: {filedi.FileName}");
                var icon = new IconEditor();
                icon.InjectIcon(args[0], filedi.FileName, false);
                //icon.InjectIcon(args[0], filedi.FileName, true); // с бэкапом
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}