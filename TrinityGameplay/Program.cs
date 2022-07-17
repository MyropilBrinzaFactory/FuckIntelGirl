using System;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace TrinityGameplay
{
    class Program
    {
        static void Main(string[] args)
        {
            DeclarelmplicitVars();

            Console.ReadKey();
        }

        #region var

        static void DeclarelmplicitVars()
        {
            var myInt = 0;
            var myBool = true;
            var myString = "Morgen";

            Console.WriteLine($"myString type: {myString.GetType().Name}");

            string upper = myString.ToUpper();
            // ошибка: int x = myString;
        }

        #endregion

        #region checked

        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)(b1 + b2); // иза переполнения типа sum будет равна 94 (350-256=94)
        }

        #endregion

        #region Явное преобразование без потери данных

        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;

            // Явно привести int к byte (без потери данных).
            myByte = (byte)myInt;
        }

        #endregion

        #region StringBuilder

        static void FunWithStnngBuilder()
        {
            // Создать экземпляр StringBuilder с исходным размером в 256 символов.
            // StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);

            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"sb has {sb.Length} chars");
        }

        #endregion

        #region бесполезность строк в мире больших текстов

        static void StringsArelmmutable()
        {
            string s1 = "This is my string.";
            Console.WriteLine($"s1 = {s1}");

            // преобразованна ли строка s1 в верхний регистр?
            string upperString = s1.ToUpper();
            Console.WriteLine($"upperString = {upperString}");

            Console.WriteLine($"s1 = {s1}"); // осталась в том же виде
        }

        #endregion

        #region модификация поведения сравнения строк

        static void StnngEqualitySpecifyingCompareRules()
        {
            string s1 = "Hello!", s2 = "HELLO!";
            Console.WriteLine($"s1 = {s1}\ns2 = {s2}\n");
            Console.WriteLine($"Default rules: s1 = {s1}, s2 = {s2} {s1.Equals(s2)}");
            Console.WriteLine($"Ignore case: {s1.Equals(s2, StringComparison.OrdinalIgnoreCase)}");
            Console.WriteLine($@"Ignore case, Invarariant Culture: {s1.Equals(s2, 
                StringComparison.InvariantCultureIgnoreCase)}\n");
            Console.WriteLine("Default rules: s1 = {0}, s2 = {1} s1.IndexOf(\"E\"): {2}",
                s1, s2, s1.IndexOf("E"));
            Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCulture" +
                "IgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));

        }

        #endregion

        #region сравнение строк

        static void StringEquality()
        {
            string s1 = "Hello!";
            string s2 = "Yo";
            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
            Console.WriteLine();
            // проверка строк на равенство:
            Console.WriteLine($"{s1 == s2}");
            Console.WriteLine($"{s1 == "Hello!"}");
            Console.WriteLine($"{s1 == "HELLO"}");
            Console.WriteLine($"{s1 == "hello!"}");
            Console.WriteLine($"{s1.Equals(s2)}");
            Console.WriteLine($"{"Yo".Equals(s2)}");
            Console.WriteLine();
        }

        #endregion

        #region ескейп последовательности 

        static void EscapeChars()
        {
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello World \"\a");
            Console.WriteLine("C:\\MBFSecretDirectory\\sonik\\Dota2\a");

            Console.WriteLine("All finished. \n\n\n\a");
            Console.WriteLine();
        }

        #endregion

        #region робота со строками

        static void BasicStringFunctionality()
        {
            string firstName = "Emmet";
            Console.WriteLine($"Value of firstName: {firstName}");
            Console.WriteLine($"Length firstName: {firstName.Length}");
            Console.WriteLine($"ToUpper firstName: {firstName.ToUpper()}");
            Console.WriteLine($"ToLower firstName {firstName.ToLower()}");
            Console.WriteLine($"firstName contains the letter y?: {firstName.Contains("y")}");
            Console.WriteLine($"firstName after replace: {firstName.Replace("met", "")}");
        }

        #endregion

        #region разделитель цифр

        static void DigitSeparators()
        {
            Console.WriteLine("Integer:");
            Console.WriteLine(123_456);
            Console.WriteLine("Long:");
            Console.WriteLine(123_456_789L);
            Console.WriteLine("Float:");
            Console.WriteLine(123_456.1234F);
            Console.WriteLine("Double:");
            Console.WriteLine(123_456.12);
        }

        #endregion

        #region BigInteger

        static void UseBiglnteger()
        {
            BigInteger biggy = BigInteger.Parse("999999999999999999999999999999999999999999999999");
            Console.WriteLine($"Value of biggy is {biggy}");
            Console.WriteLine($"Is biggy an even value?: {biggy.IsEven}");
            Console.WriteLine($"Is biggy a power of two?: {biggy.IsPowerOfTwo}");
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("99999999999999999999999999999999999999"));
            Console.WriteLine($"Value of reallyBig is {reallyBig}");
        }

        #endregion

        #region DateTime, TimeSpan

        static void UseDatesAndTimes()
        {
            // Конструктор даты (год, месяц, день)
            DateTime dt = new DateTime(2015, 10, 17);

            // День месяца
            Console.WriteLine($"The day of {dt.Date} is {dt.DayOfWeek}");

            // Месяц декабрь
            dt = dt.AddMonths(2); // добавления месяцев
            Console.WriteLine($"Daylight savings {dt.IsDaylightSavingTime()}");

            // Констуктор времени (час, минута, секунда)
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            // Вычесть время из текущего значения TimeSpan (15)
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
        }

        #endregion

        #region tryparse, parse

        static void ParseFromStringsWithTryParse() // преобразует если возможно
        {
            if(bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b {0}", b);
            }
            string value = "Hello";
            if(double.TryParse(value, out double d))
            {
                Console.WriteLine("Value of d {0}", d);
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        static void ParseFromStrings()
        {
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99. 884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}: i");
            char c = char.Parse("w");
            Console.WriteLine("Value of c: {0}:", c);
            Console.WriteLine();
        }

        #endregion

        #region проверка char

        static void CharFunctionality()
        {
            char myChar = 'a';
            Console.WriteLine($"{char.IsDigit(myChar)}");
            Console.WriteLine($"{char.IsLetter(myChar)}");
            Console.WriteLine($"{char.IsWhiteSpace("Hello There", 5)}");
            Console.WriteLine($"{char.IsWhiteSpace("Hello There", 6)}");
            Console.WriteLine($"{char.IsPunctuation('?')}");
            Console.WriteLine();
        }

        #endregion

        #region форматирование

        static void DisplayMessage()
        {
            string userMessage = string.Format("10000 in hex is {0:x}", 10000);

            System.Windows.MessageBox.Show(userMessage);
        }

        static void FormatNumericalData()
        {
            Console.WriteLine("This value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);

            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
        }

        #endregion

        #region Environment

        static void ShowEnvironmentDetails()
        {
            foreach (string drive in Environment.GetLogicalDrives())
                MessageBox.Show($"Drive {drive}");

            MessageBox.Show($"OS {Environment.OSVersion}");

            MessageBox.Show($"Number of processors: {Environment.ProcessorCount}");
            MessageBox.Show($".NET Version {Environment.Version}");
            MessageBox.Show($"Name user: {Environment.UserName}");
            MessageBox.Show($"Machine name: {Environment.MachineName}");
            MessageBox.Show($"Woring set: {Environment.WorkingSet}");
        }

        #endregion
    }
}
