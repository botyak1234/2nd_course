using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pomogite_kursach_gorit
{
    public class LSB_R_1
    {
            public static byte[] EmbedMessage(string imagePath, string message, string outputPath)
            {
                // Загрузка изображения
                Bitmap image = new Bitmap(imagePath);

                // Преобразование сообщения в массив байтов
                byte[] messageBytes = Encoding.ASCII.GetBytes(message + '\0');
                
                
            // Генерация случайной последовательности
            Random random = new Random();

                // Создание массива для хранения позиций измененных пикселей
                List<(int x, int y)> changedPixels = new List<(int x, int y)>();

                // Вложение сообщения в изображение
                for (int i = 0; i < messageBytes.Length; i++)
                {
                    // Получение координат пикселя
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    // Получение цвета пикселя
                    Color color = image.GetPixel(x, y);
                    

                    // Изменение младшего бита каждого компонента цвета
                    int r = (color.R & ~1) | (messageBytes[i] & 1);
                    int g = (color.G & ~1) | ((messageBytes[i] >> 1) & 1);
                    int b = (color.B & ~1) | ((messageBytes[i] >> 2) & 1);
                    

                    // Создание нового цвета
                    Color newColor = Color.FromArgb(r, g, b);

                    // Установка нового цвета пикселя
                    image.SetPixel(x, y, newColor);

                    // Добавление позиции измененного пикселя в массив
                    changedPixels.Add((x, y));
                }

                // Сохранение изображения
                image.Save(outputPath, ImageFormat.Bmp);

                // Сохранение массива позиций измененных пикселей в файл
                using (StreamWriter writer = new StreamWriter("changedPixels.txt"))
                {
                    foreach (var pixel in changedPixels)
                    {
                        writer.WriteLine($"{pixel.x} {pixel.y}");
                    }
                }
            return messageBytes;
            }

        public static string ExtractMessage(string stegoImagePath, byte[] binary)
        {
            // Загружаем изображение с засекреченным сообщением
            Bitmap stegoImage = new Bitmap(stegoImagePath);

            // Получаем размеры изображения
            int width = stegoImage.Width;
            int height = stegoImage.Height;

            // Преобразуем изображение в массив пикселей
            byte[,] pixels = new byte[height, width * 3];

            unsafe
            {
                BitmapData bitmapData = stegoImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, stegoImage.PixelFormat);
                byte* ptr = (byte*)bitmapData.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        pixels[i, j * 3] = ptr[i * bitmapData.Stride + j * 3 + 2]; // B
                        pixels[i, j * 3 + 1] = ptr[i * bitmapData.Stride + j * 3 + 1]; // G
                        pixels[i, j * 3 + 2] = ptr[i * bitmapData.Stride + j * 3]; // R
                    }
                }

                stegoImage.UnlockBits(bitmapData);
            }

            // Извлекаем двоичный код из изображения
            StringBuilder binaryStego = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width * 3; j++)
                {
                    // Получаем младшие биты каждого компонента цвета пикселя изображения
                    int lsb = pixels[i, j] & 1;

                    // Добавляем младшие биты каждого канала в бинарную строку
                    binaryStego.Append(lsb);
                }
            }

            // Преобразуем двоичный код в текст
            int byteLength = binary.Length / 8;
            byte[] bytes = new byte[byteLength];

            for (int i = 0; i < byteLength; i++)
            {
                string byteBinary = binaryStego.ToString(i * 8, 8);
                bytes[i] = Convert.ToByte(byteBinary, 2);
            }

            string message = Encoding.ASCII.GetString(bytes);

            return message;
        }
    }
}
