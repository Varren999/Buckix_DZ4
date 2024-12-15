namespace Buckix_DZ4
{
    internal class Statistics
    {
        private readonly char[] selector = { ' ', '.', ',' };
        private Dictionary<string, int> dict = new Dictionary<string, int>();

        /// <summary>
        /// Метод создает словарь уникальных слов и подсчитывает количество часто встречающихся слов. 
        /// </summary>
        /// <param name="Words"></param>
        //private void CountingWords(string[] Words)
        //{
        //    foreach (var word in Words)
        //        if (dict.ContainsKey(word))
        //            dict[word]++;
        //        else
        //            dict.Add(word, 1);
        //}

        /// <summary>
        /// Конструктор. Загруженый в него текст сразу обрабатывается,
        /// результат работы можно посмотреть вызвав метод Result.
        /// </summary>
        /// <param name="Text"></param>
        public Statistics(string Text)
        {
            try
            {
                if (Text == string.Empty)
                    throw new Exception("В конструктор передана пустая строка!");

                // Изначально я сделал метод для добавления слов отдельно, но потом решил что можно упростить, да это ухудшило читаемость кода)
                //CountingWords(Text.Split(selector, StringSplitOptions.RemoveEmptyEntries));

                // С LINQ пробовал у меня не вышло получить нужный результат, по этому по старинке.
                foreach (var word in Text.Split(selector, StringSplitOptions.RemoveEmptyEntries))
                    if (dict.ContainsKey(word))
                        dict[word]++;
                    else
                        dict.Add(word, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Выводит результат работы класса Statistics.
        /// </summary>
        public void Result()
        {
            int c = 1;
            Console.WriteLine("{0, 16}{1,30}", "Слово:", "Кол-во:");
            foreach (KeyValuePair<string, int> it in dict.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0, -10}{1,-20}{2,10}", c, it.Key, it.Value);
                c++;
            }
            Console.WriteLine($"\nВсего слов: {dict.Values.Sum()} из них уникальных {dict.Count}\n");
        }
    }
}
