using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CodePanel
{
    static class AppData
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        public static T GetRandomElement<T>(this T[] array)
        {
            return array[Random.Next(array.Length - 1)];
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
            "Расчет подгониана",
            "Подсаживаем аккумулятор",
            "Форматирование карты памяти",
            "Построение атласа нормалей поверхности Юпитера",
            "Расчет алкогольной зависимости",
            "В Солекамске приезжие игуаны объявляют забастовку",
            "Расчет вероятностей треш-детектора",
            "Сгибание ложки",
            "Актуализация ревербераций котиков",
            "Подготовка ямы с крокодилами",
            "Скачивание гей-порно в 4к",
            "Кормление полосатеньких хомячков ",
            "Остужение горячих голов",
            "Наблюдение за ростом травы",
            "Переговоры с диванными аналитиками",
            "Я делаю это просто чтоб заставить тебя ждать",
            "АААА!!! Выпустите меня!!!!1",
            "Вывод сайентолога из шкафа",
            "Закрытие гештальта",
            "Что угодно лишь бы не работать",
            "Открытие скрытого смысла",
            "Искоренение ереси, оповещение инквизиции",
            "Приручение нежити",
            "Пытаемся не разбудить родителей",
            "Окружаем вас неудачниками",
            "Пропускаем непропускаемые cut-сцены",
            "Заводим хобби",
            "Мечтаем о личной жизни",
            "Удаляем историю браузера",
            "Возвращаем 2007",
            "Затачиваем молоток"
        };

        public static Dictionary<string,string> Hints =
            new Dictionary<string,string>()
        {
            {"12345", "Подсказка 1"},
            {"00000", "Подсказка 2"},
            {"45678", "Подсказка 3"}
        };

        public static Quest[] Quests =
            new[]
            {
                new Quest("1", "История про индийских богов","quest1.txt","task1.txt","5242"),
                new Quest("2", "История про птичницу","quest2.txt","task2.txt","4537")
            };

        public static Quest CurrentQuest
        {
            get
            {
                var questId = Application.Current.Properties["CurrentQuestId"].ToString();
                return Quests.FirstOrDefault(quest => quest.QuestId == questId);
            }
        }
    }
}
