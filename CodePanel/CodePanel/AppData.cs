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

        public static InfoMessage[] InfoMessages =
        new[]
        {
            new InfoMessage("Wake up Neo","5 minutes, mum"),
            new InfoMessage("Проснись, Алиса!","Уже встаю"),
            new InfoMessage("Я хочу сыграть с тобой в одну игру…","...Ок?"),
            new InfoMessage("It’s dangerous to go alone! Take this","Ок"),
            new InfoMessage("Зелье Легкой Дороги - Поищи в сумке у кудрявой.","Нашел"),
            new InfoMessage("Prunus Amýgdalus - Поищи в сумке у иностранки.","Нашел"),
            new InfoMessage("Ты готов?","ДА!"),
            new InfoMessage("Отлично.\r\nТебе предстоит миссия: проследовать по кровавому следу диких историй, и подготовиться морально к любому повороту, которые подкинет судьба.\r\nХуже нет незнания, чем неоправданные ожидания.\r\n","НАЧАТЬ")
        };

        public static InfoMessage[] GreetingsMessages =
            new[]
            {
                new InfoMessage("Ты прошла квест. Ура. Поздравляю.","..."),
                new InfoMessage("Ты еще здесь?","..."),
                new InfoMessage("Все заканчивается. Но у тебя только начинается","..."),
                new InfoMessage("Ты. Будешь. Счастливой.","..."),
                new InfoMessage("Ах, да, и мы тебя любим)","..."),
                new InfoMessage("Так выпьем же за это!\n Have fun \n(c)2018 rumkit","bye"),
                
            };

        private static Quest[] Quests =
            new[]
            {
                new Quest("1", "Индийские боги","quest1.txt","task1.txt","5242"),
                new Quest("2", "История про птичницу","quest2.txt","task2.txt","4537"),
                new Quest("3", "История про межвидовую любовь","quest3.txt","task3.txt","1318"),
                new Quest("4", "Посмотри в глаза чудовищ","quest4.txt","task4.txt","1919"),
                new Quest("5", "Музыка в твоей голове","quest5.txt","task5.txt","2457"),
                new Quest("6", "Под землей","quest6.txt","task6.txt","8678"),
                new Quest("7", "Остров","quest7.txt","task7.txt","4482"),
                new Quest("8", "В небе","quest8.txt","task8.txt","9127")
            };

        public static bool NextQuest()
        {
            if (Application.Current.Properties["CurrentQuestId"] == null)
            {
                Application.Current.Properties["CurrentQuestId"] = 1;
                return true;
            }
            var currentId = (int)Application.Current.Properties["CurrentQuestId"];
            var nextId = currentId + 1;
            if (nextId > QuestCount)
            {
                Application.Current.Properties["CurrentQuestId"] = null;
                return false;
            }

            Application.Current.Properties["CurrentQuestId"] = nextId;
            return true;
        }

        public static int QuestCount => 1;
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
