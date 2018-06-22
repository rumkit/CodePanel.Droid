using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanel
{
    static class AppData
    {
        public static T GetRandomElement<T>(this T[] array)
        {
            var random = new Random(DateTime.Now.Millisecond);
            return array[random.Next(array.Length - 1)];
        }

        public static string[] LoadingStrings =
        {
            "Раскрутка торсионных полей",
            "Раскрутка торсионных полей1",
            "Раскрутка торсионных полей2",
            "Раскрутка торсионных полей3",
            "Раскрутка торсионных полей4",
            "Раскрутка торсионных полей5",
            "Раскрутка торсионных полей6",
            "Раскрутка торсионных полей7",
            "Раскрутка торсионных полей8",
            "Раскрутка торсионных полей9",
            "Раскрутка торсионных полей0",
            "Раскрутка торсионных полей11",
            "Раскрутка торсионных полей12",
            "Раскрутка торсионных полей13"
        };

        public static Dictionary<string,string> Hints =
            new Dictionary<string,string>()
        {
            {"12345", "Подсказка 1"},
            {"00000", "Подсказка 2"},
            {"45678", "Подсказка 3"}
        };
    }
}
