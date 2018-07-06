using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CodePanel
{
    class Quest
    {
        public readonly string QuestId;
        public readonly string QuestName;
        public readonly string QuestPath;
        public readonly string TaskPath;
        public readonly string QuestAnswer;

        public Quest(string questId, string questName, string questPath, string taskPath, string questAnswer)
        {
            QuestId = questId;
            QuestName = questName;
            QuestPath = questPath;
            TaskPath = taskPath;
            QuestAnswer = questAnswer;
        }

        public string QuestText => GetTextFromResource(QuestPath);

        public string TaskText => GetTextFromResource(TaskPath);

        private string GetTextFromResource(string resourceKey)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(QuestPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream($"CodePanel.Droid.QuestData.{resourceKey}");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
