﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }

        int selectedItem;
        /*
        public int GetSelectedItem()
        {
            return selectedItem;
        }
        public void SetSelectedItem(int value)
        {
            selectedItem = value;
        }*/



        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value < 0)
                {
                    selectedItem = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selectedItem = 0;
                }
                else
                {
                    selectedItem = value;
                }
            }
        }

        public void Draw()
        {
            // подкрашивание выбранной папки\файла
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }
        }
    }

    enum FarMode
    {
        FileView,      // 0
        DirectoryView  // 1 
    }

    class Program
    { 
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\"); // link for our directory 
            Stack<Layer> history = new Stack<Layer>();            // create stack 
            FarMode farMode = FarMode.DirectoryView;

            history.Push(
                new Layer
                {
                    Content = root.GetFileSystemInfos(),      // получаем данные о каталоге с помощью get-set
                    SelectedItem = 0
                });

            while (true)
            {
                if (farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw();               // красим выбранную папку
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key) 
                {
                    case ConsoleKey.UpArrow:                                        // вверх
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;                              // вниз
                        break;
                    case ConsoleKey.Enter:                                          // вход в папку или в файл
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = d.GetFileSystemInfos(), SelectedItem = 0 });   // если папка, добавляем новую "историю" с информацией выбранной папки
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))   //если файл, открываем его для чтения
                            {
                                using (StreamReader sr = new StreamReader(fs))  
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)  // если папка, откатываем "историю" назад
                        {
                            history.Pop();
                        }
                        else if (farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;
                    

                }
            }
        }
    }
}