using System;
using System.Drawing;

public class StickerGenerator
{
    public static void CreateSticker(string serialNumber, string filePath)
    {
        // Настройки стикера
        int width = 400;
        int height = 180;
        string fontName = "Arial";
        int fontSize = 54;

        // Создаем новое изображение
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Задаем белый фон
                graphics.Clear(Color.Black);

                // Создаем шрифт
                using (Font font = new Font(fontName, fontSize))
                {
                    // Задаем цвет текста
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        // Вычисляем позицию текста
                        SizeF serialSize = graphics.MeasureString(serialNumber, font);


                        float serialX = (width - serialSize.Width) / 2;
                        float serialY = 50;

                        // Рисуем текст
                        graphics.DrawString(serialNumber, font, textBrush, new PointF(serialX, serialY));
                    }
                }
            }

            // Сохраняем изображение
            bitmap.Save(filePath);
        }
    }
}

class Program
{
    static void Main()
    {
        int ID = 3000;
        for (int i = 2000; i < 3000; i++) {
            StickerGenerator.CreateSticker("ID: " + i, "image/" + i + ".png");
        }
    }
}
