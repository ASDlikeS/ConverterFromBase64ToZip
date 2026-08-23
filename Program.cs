using System.Text;

namespace Base64ToZip;

internal class Program
{
    static void Main(string[] args)
    {
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;

        string inputFileName = args.Length > 0 ? args[0] : "base64.txt";
        string inputPath = Path.Combine(currentDir, inputFileName);

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"[ОШИБКА] Файл не найден: {inputPath}");
            Console.WriteLine(
                "Укажите имя файла как аргумент, или положите файл 'base64.txt' в папку с программой."
            );
            Console.ReadKey();
            return;
        }

        try
        {
            // Читаем весь текст (может быть с переносами строк)
            string base64String = File.ReadAllText(inputPath, Encoding.UTF8)
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace(" ", "");

            if (string.IsNullOrEmpty(base64String))
            {
                Console.WriteLine("[ОШИБКА] Файл пуст.");
                Console.ReadKey();
                return;
            }

            // Декодируем из Base64
            byte[] zipData = Convert.FromBase64String(base64String);

            // Сохраняем как ZIP
            string outputPath = Path.Combine(currentDir, "output.zip");
            File.WriteAllBytes(outputPath, zipData);

            Console.WriteLine($"[УСПЕХ] Архив сохранён: {outputPath}");
            Console.WriteLine($"Размер: {zipData.Length} байт");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("[ОШИБКА] Неверный формат Base64. Проверьте содержимое файла.");
            Console.WriteLine($"Подробности: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ОШИБКА] {ex.Message}");
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
