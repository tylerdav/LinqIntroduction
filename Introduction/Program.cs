﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:windows";
            ShowLargeFilesWithoutLinq(path);
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for(int i =0; i <5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} :{file.Length, 10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
