using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pomogite_kursach_gorit
{
    internal class LSB_M_2
    {
        static public string EmbedMessage(string imagePath, string message, string outputPath)
        {
            Bitmap coverImage = new Bitmap(imagePath);

            // Получаем размеры изображения
            int width = coverImage.Width;
            int height = coverImage.Height;

            // Преобразуем изображение в массив пикселей
            byte[,] pixels = new byte[height, width * 3];

            unsafe
            {
                BitmapData bitmapData = coverImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, coverImage.PixelFormat);
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

                coverImage.UnlockBits(bitmapData);
            }

            // Преобразуем текст в двоичный код
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            string binary = "";

            foreach (byte b in bytes)
            {
                binary += Convert.ToString(b, 2).PadLeft(8, '0');
            }

            // Встраиваем текст в изображение
            int index = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width * 3; j++)
                {
                    // Проверяем, что текст не закончился
                    if (index < binary.Length)
                    {
                        // Получаем младший бит текущего символа текста
                        int lsb = binary[index] - '0';

                        // Изменяем младший бит компонента цвета пикселя
                        pixels[i, j] = (byte)((pixels[i, j] & ~1) | lsb);

                        index++;
                    }
                }
            }

            // Преобразуем массив пикселей обратно в изображение
            Bitmap stegoImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bitmapData = stegoImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, stegoImage.PixelFormat);
                byte* ptr = (byte*)bitmapData.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        ptr[i * bitmapData.Stride + j * 3 + 2] = pixels[i, j * 3]; // B
                        ptr[i * bitmapData.Stride + j * 3 + 1] = pixels[i, j * 3 + 1]; // G
                        ptr[i * bitmapData.Stride + j * 3] = pixels[i, j * 3 + 2]; // R
                    }
                }

                stegoImage.UnlockBits(bitmapData);
            }

            // Сохраняем полученное изображение
            stegoImage.Save(outputPath, ImageFormat.Bmp);
            return binary;
        }

        static public string ExtractMessage(string stegoImagePath, string binary)
        {
            Bitmap stegoImageLoaded = new Bitmap(stegoImagePath);

            // Получаем размеры изображения
            int widthStego = stegoImageLoaded.Width;
            int heightStego = stegoImageLoaded.Height;

            // Преобразуем изображение в массив пикселей
            byte[,] pixelsStego = new byte[heightStego, widthStego * 3];

            unsafe
            {
                BitmapData bitmapData = stegoImageLoaded.LockBits(new Rectangle(0, 0, widthStego, heightStego), ImageLockMode.ReadOnly, stegoImageLoaded.PixelFormat);
                byte* ptr = (byte*)bitmapData.Scan0;

                for (int i = 0; i < heightStego; i++)
                {
                    for (int j = 0; j < widthStego; j++)
                    {
                        pixelsStego[i, j * 3] = ptr[i * bitmapData.Stride + j * 3 + 2]; // B
                        pixelsStego[i, j * 3 + 1] = ptr[i * bitmapData.Stride + j * 3 + 1]; // G
                        pixelsStego[i, j * 3 + 2] = ptr[i * bitmapData.Stride + j * 3]; // R
                    }
                }

                stegoImageLoaded.UnlockBits(bitmapData);
            }

            // Извлекаем двоичный код из изображения
            StringBuilder binaryStego = new StringBuilder();

            for (int i = 0; i < heightStego; i++)
            {
                for (int j = 0; j < widthStego * 3; j++)
                {
                    // Получаем младшие биты каждого компонента цвета пикселя изображения
                    int lsb = pixelsStego[i, j] & 1;

                    // Добавляем младшие биты каждого канала в бинарную строку
                    binaryStego.Append(lsb);
                }
            }

            // Преобразуем двоичный код в текст
            int byteLength = binary.Length / 8;
            byte[] bytesStego = new byte[byteLength];

            for (int i = 0; i < byteLength; i++)
            {
                string byteBinary = binaryStego.ToString(i * 8, 8);
                bytesStego[i] = Convert.ToByte(byteBinary, 2);
            }

            string messageStego = Encoding.ASCII.GetString(bytesStego);

            // Выводим извлеченное сообщение
           return messageStego;
        }
    }
}
