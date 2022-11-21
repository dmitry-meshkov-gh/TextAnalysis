using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            Dictionary<string, string> bigramList = GetBigramList(text);

            return result;
        }

        private static Dictionary<string, string> GetBigramList(List<List<string>> text)
        {
            var bigramList = new Dictionary<string, string>();
            foreach(List<string> sentence in text) // Обход по предложениям к тексте
            {
                if(sentence.Count > 3) //Если в предложении больше 3 значений
                {
                    for (int i = 0; i < sentence.Count - 1; i++) //Количество ключей на 1 меньше количества слов в предложении
                    {
                        if (!bigramList.ContainsKey(sentence[i])) // Если ключа нет, то добавить ключ-значение
                            bigramList.Add(sentence[i], sentence[i + 1]);
                    }
                }
            }
            return bigramList;
        }
    }
}