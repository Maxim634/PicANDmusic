using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

internal class Program
{
    private static async Task Main(string[] args) 
    {
        HttpClient client = new(); // Создаем экземпляр HttpClient

        Console.WriteLine("Введите ссылку для скачивания картинки: ");
        string nameWebsite = Console.ReadLine(); // Получаем ссылку от пользователя для скачивания картинки

        HttpResponseMessage response = await client.GetAsync(nameWebsite); // Отправляем GET-запрос для получения картинки
        byte[] data = await response.Content.ReadAsByteArrayAsync(); // Читаем полученные данные картинки в виде массива байт

        Console.WriteLine("Введите путь сохранения: ");
        string link = Console.ReadLine(); // Получаем путь сохранения от пользователя
        await File.WriteAllBytesAsync(link, data); // Асинхронно сохраняем полученные данные картинки по указанному пути

        Process.Start(new ProcessStartInfo { FileName = link, UseShellExecute = true }); // Запускаем по умолчанию программу для просмотра скачанной картинки

        HttpClient client1 = new HttpClient(); // Создаем новый экземпляр HttpClient (можно использовать существующий, но в данном примере используется новый)

        Console.WriteLine("Введите ссылку для скачивания песни: ");
        string nameWebsite1 = Console.ReadLine(); // Получаем ссылку от пользователя для скачивания песни

        HttpResponseMessage response1 = await client1.GetAsync(nameWebsite1); // Отправляем GET-запрос для получения песни
        byte[] data1 = response1.Content.ReadAsByteArrayAsync().Result; // Читаем полученные данные песни в виде массива байт

        Console.WriteLine("Введите путь сохранения: ");
        string link1 = Console.ReadLine(); // Получаем путь сохранения от пользователя
        File.WriteAllBytes(link1, data1); // Сохраняем полученные данные песни по указанному пути

        Process.Start(new ProcessStartInfo { FileName = link1, UseShellExecute = true }); // Запускаем по умолчанию программу для воспроизведения скачанной песни
    }
}