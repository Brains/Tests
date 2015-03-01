using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;


internal class Program
{
    private static void Main (string[] args)
    {
        SetupConsole();

        Test();

        Console.ReadKey(true);
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

