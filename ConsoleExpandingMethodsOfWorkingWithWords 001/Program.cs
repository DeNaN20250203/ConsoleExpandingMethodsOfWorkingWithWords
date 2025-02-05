namespace ConsoleExpandingMethodsOfWorkingWithWords_001
{
	internal class Program
    {
        static void Main(string[] args)
        {
			var dict = new Dictionary<string, int>
				{
					{ "Яблоко", 1 },
					{ "Банан", 2 }
				};
			{

				// Пытаемся обновить значение по существующему ключу
				bool updated = dict.TryUpdate("Яблоко", 10);
				Console.WriteLine($"Обновлено 'Яблоко': {updated}, новое значение: {dict["Яблоко"]}");

				// Пытаемся обновить значение по несуществующему ключу
				updated = dict.TryUpdate("Апельсин", 3);
				Console.WriteLine($"Обновлено 'Апельсин': {updated}");
			}

			{
				// Получаем значение по существующему ключу
				int appleValue = dict.GetOrAdd("Яблоко", 10);
				Console.WriteLine($"Значение для 'Яблоко': {appleValue}");

				// Добавляем новое значение по несуществующему ключу
				int orangeValue = dict.GetOrAdd("Апельсин", 3);
				Console.WriteLine($"Значение для 'Апельсин': {orangeValue}");

				// Выводим все значения в словаре
				foreach (var kvp in dict)
				{
					Console.WriteLine($"{kvp.Key}: {kvp.Value}");
				}
			}
			Console.ReadKey();
        }
    }
}
