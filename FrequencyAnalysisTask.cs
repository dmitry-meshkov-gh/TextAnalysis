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
            Dictionary<string, int> valueFrequencyList = new Dictionary<string, int>(); //Словарь частотности значений
            Dictionary<string, Dictionary<string, int>> bigramFrequencyList = 
                new Dictionary<string, Dictionary<string, int>>();

            foreach (List<string> sentence in text) // Обход по предложениям к тексте
            {
                if(sentence.Count > 3) //Если в предложении больше 3 значений
                {
                    for (int i = 0; i < sentence.Count - 1; i++) //Количество ключей на 1 меньше количества слов в предложении
                    {
                        // Если ключа нет, то добавить ключ-значение, добавить в словарь значение и частотность
                        if (!bigramList.ContainsKey(sentence[i]))
                        {
                            bigramList.Add(sentence[i], sentence[i + 1]);
                            if (!valueFrequencyList.ContainsKey(sentence[i + 1]))
                            {
                                valueFrequencyList.Add(sentence[i + 1], 1);
                            }
                        }   
                        //Если ключ есть, то проверить значение добавить в словарь частотности
                        else if (bigramList.ContainsKey(sentence[i]))
                        {
                            bigramList.TryGetValue(sentence[i], out string value); //Получаем значение из словаря по ключу
                            if (value == sentence[i + 1]) // Если значение было, то увеличивает частоту на 1
                                valueFrequencyList[sentence[i + 1]] += 1;
                            else if (valueFrequencyList.ContainsKey(sentence[i + 1]))
                                valueFrequencyList[sentence[i + 1]] += 1;
                            else
                                valueFrequencyList.Add(sentence[i + 1], 1); //Если нет, то добавляем новое значение
                        }
                    }
                }
            }
            return bigramList;
        }
    }
}