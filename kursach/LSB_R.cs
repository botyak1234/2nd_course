using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace pomogite_kursach_gorit
{
    public static class LSB_R
    {
        public static Bitmap EmbedMessage(Bitmap originalImage, string secretMessage, List<Point> randomPositionsCopy)
        {
            // Генерация случайных позиций для встраивания данных
            List<Point> randomPositions = GenerateRandomPositions(originalImage.Width, originalImage.Height, secretMessage.Length * 8);
            foreach (Point obj in randomPositions) 
            {
                randomPositionsCopy.Add(obj);
            }
                // Создание копии изображения для внедрения сообщения
                Bitmap stegoImage = new Bitmap(originalImage);

            // Внедрение скрытого сообщения
            int messageIndex = 0;
            foreach (Point pos in randomPositions)
            {
                Color pixel = stegoImage.GetPixel(pos.X, pos.Y);
                if (messageIndex < secretMessage.Length * 8)
                {
                    int bitToEmbed = (secretMessage[messageIndex / 8] >> (messageIndex % 8)) & 1;
                    Color newPixel = Color.FromArgb(pixel.R & 254 | bitToEmbed, pixel.G, pixel.B);
                    stegoImage.SetPixel(pos.X, pos.Y, newPixel);
                    messageIndex++;
                }
            }

            return stegoImage;
        }

        public static string ExtractMessage(Bitmap stegoImage, List<Point> randomPositions, int messageLength)
        {
            // Извлечение скрытого сообщения
            string binaryMessage = "";
            foreach (Point pos in randomPositions)
            {
                Color pixel = stegoImage.GetPixel(pos.X, pos.Y);
                int lsb = pixel.R & 1;
                binaryMessage += lsb;
            }

            // Преобразование бинарной строки в текст
            string extractedMessage = BinaryToString(binaryMessage.Substring(0, messageLength));

            return extractedMessage;
        }

        private static List<Point> GenerateRandomPositions(int width, int height, int numPositions)
        {
            Random random = new Random();
            HashSet<Point> positionsSet = new HashSet<Point>();

            while (positionsSet.Count < numPositions)
            {
                int x = random.Next(width);
                int y = random.Next(height);
                positionsSet.Add(new Point(x, y));
            }

            return new List<Point>(positionsSet);
        }

        private static string BinaryToString(string binary)
        {
            byte[] bytes = new byte[binary.Length / 8];
            for (int i = 0; i < binary.Length; i += 8)
            {
                bytes[i / 8] = Convert.ToByte(binary.Substring(i, 8), 2);
            }

            // Конвертация массива байт в строку в кодировке UTF-8
            string text = Encoding.UTF8.GetString(bytes);
            return text;
        }
    }
}
