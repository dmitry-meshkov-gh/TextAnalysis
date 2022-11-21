using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            List<List<string>> sentencesList = new List<List<string>>();
            //Предложения состоят из слов и отделены друг от друга одним из следующих символов
            char[] separators = new[] { '.', '!', '?', ';', ':', '(', ')' };
            //Разделяем текст на предложения
            foreach (string sentance in text.ToLower().Split(separators,
                StringSplitOptions.RemoveEmptyEntries))
            {
                if(String.IsNullOrEmpty(sentance)) //Пропускаем пустые предложения
                    continue;
                else if (GetWords(sentance).Count > 0) //Проверяем, если строка содержит символы
                    sentencesList.Add(GetWords(sentance));
            }
            return sentencesList;
        }

        private static List<string> GetWords(string sentance)
        {
            List<string> words = new List<string>();
            StringBuilder stringBuilder = new StringBuilder(sentance);
            foreach(string word in RemoveOtherSeparator(stringBuilder).
                Split(new string[] {" ", "\t", "\n", "\r"}, 
                StringSplitOptions.RemoveEmptyEntries))
                words.Add(word);
            return words;
        }
        private static string RemoveOtherSeparator(StringBuilder stringBuilder)
        {
            for(int i = 0; i < stringBuilder.Length; i++)
            {
                if (Char.IsLetter(stringBuilder[i]) || stringBuilder[i].ToString() == "\'")
                    continue;
                else
                    //Если stringBuilder содержит любой разделитель - меняем на пробел " "
                    stringBuilder.Replace(stringBuilder[i], ' '); 
            }
            return stringBuilder.ToString();
        }
    }
}