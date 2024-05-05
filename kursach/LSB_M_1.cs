using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace pomogite_kursach_gorit
{
    internal class LSB_M_1
    {
        public static string EmbedMessage(string imagePath, string message, string outputPath)

        {
            Bitmap image = new Bitmap(imagePath);
            // Получаем размеры изображения
            int width = image.Width;
            int height = image.Height;

            // Преобразуем изображение в массив пикселей
            Color[,] pixels = new Color[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] = image.GetPixel(j, i);
                }
            }

            // Преобразуем текст в двоичный код
            byte[] messageBytes = Encoding.ASCII.GetBytes(message + '\0');
            string binary = "";

            foreach (byte b in messageBytes)
            {
                binary += Convert.ToString(b, 2).PadLeft(8, '0');
            }

            // Встраиваем текст в изображение
            int index = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Проверяем, что текст не закончился
                    if (index < binary.Length)
                    {
                        // Получаем младший бит текущего символа текста
                        int lsb = binary[index] - '0';

                        // Изменяем младший бит каждого компонента цвета пикселя
                        int newR = (pixels[i, j].R & ~1) | lsb;
                        int newG = (pixels[i, j].G & ~1) | lsb;
                        int newB = (pixels[i, j].B & ~1) | lsb;
                        pixels[i, j] = Color.FromArgb(newR, newG, newB);

                        index++;
                    }
                }
            }

            // Преобразуем массив пикселей обратно в изображение
            Bitmap stegoImage = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    stegoImage.SetPixel(j, i, pixels[i, j]);
                }
            }

            stegoImage.Save(outputPath, ImageFormat.Bmp);
            return binary;
        }

        public static string ExtractMessage(string stegoImagePath, string binary)
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
