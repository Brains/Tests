using System;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


internal class Program
{
    private static void Main (string[] args)
    {
        SetupConsole();

        Test();

        Console.ReadKey();
    }

    //------------------------------------------------------------------
    private static void SetupConsole()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Clear();
    }

    //------------------------------------------------------------------
    public static void Out (string text)
    {
        Console.WriteLine (text);
    }

    //------------------------------------------------------------------
    public static void Test()
    {

    }
}