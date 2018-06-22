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
            "Отправка почтовой совы",
            "Подогрев чая на МКС",
            "Анализ поведенческих девиаций вомбатов",
            "Восхваление Вишну",
            "Просто немного подождем",
            "Учет стратосферных колебаний",
            "Рассчет подгониана",
            "Подсаживаем аккумулятор",
            "Форматирование карты памяти",
            "Построение атласа нормалей поверхности Юпитера",
            "Рассчет алкогольной зависимости",
            "В Солекамске приезжие игуаны объявляют забастовку",
            "Просчет вероятностей треш-детектора"
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
