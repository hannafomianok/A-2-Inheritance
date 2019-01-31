﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            Console.WriteLine("Choose print type:");
            Console.WriteLine("1 - Console");
            Console.WriteLine("2 - File");
            Console.WriteLine("3 - Image");

            string type = Console.ReadLine();

            IPrinter printer = null;

            switch (type)
            {
                case "1":
                    printer = new ConsolePrinter(ConsoleColor.Blue);
                    break;
                case "2":
                    printer = new FilePrinter("test");
                    break;
                case "3":
                    printer = new BitmapPrinter("BitmapPrinerExample");
                    Console.WriteLine("You have chosen printing into image");
                    break;
            }

            Console.WriteLine("Write text");

            for (int i = 0; i < 5; i++)
            {
                var text = Console.ReadLine();
                printer?.Print(text);
            }
        }  
         
        public interface IPrinter
        {
            void Print(string str);
        }
        
        public class ConsolePrinter : IPrinter
        {
            public void Print(string str)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(str);
                Console.ResetColor();
            }

            public ConsolePrinter(ConsoleColor color)
            {
                _color = color;
            }

            private ConsoleColor _color;
        }
        public class FilePrinter : IPrinter
        {
            public void Print(string str)
            {
                System.IO.File.AppendAllText($@"D:\{_fileName}.txt",str);
            }

            public FilePrinter(string fileName)
            {
                _fileName = fileName;
            }

            private string _fileName;
        }
        public class BitmapPrinter : IPrinter
        {
            public string FileName { get; }
            public void Print(string str)
            {
                Bitmap bitmap = new Bitmap(1000,1000);
                // Create font and brush.
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                float x = 150.0F;
                float y = 50.0F;

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                // Draw string to screen.
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);

                bitmap.Save($@"D:\{FileName}.png");
            }
            public BitmapPrinter(string fileName)
            {
                FileName = fileName;
            }
        }

    }
}
