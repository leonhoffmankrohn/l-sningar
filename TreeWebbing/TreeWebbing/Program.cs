using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

List<string> not404Pages = new List<string>();

string content404Page = "404"; 
double branchlength = 8;
string symbols = " abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ1234567890!\"#¤%&/()=?+\\}][{€$£@§½";

WebClient client = new();

Run();

void Run()
{
    try
    {
        UrlBrancher(PromptUrl());
        PrintTree();
        OpenInWeb(PromptOpenWeb());
    }
    catch(Exception e) { Console.Clear();Console.WriteLine(e.Message); }
}

int PromptOpenWeb()
{
    Console.WriteLine("\nPlease enter index you want to open:");
    int.TryParse(Console.ReadLine(), out int index);
    return index;
}

void PrintTree()
{
    Console.Clear();
    for (int i = 0; i < not404Pages.Count; i++)
    {
        Console.WriteLine(i + " - " + not404Pages[i]);
    }
}

void OpenInWeb(int index)
{
    string content = ContentFinder(not404Pages[index]);
    StreamWriter writer = new StreamWriter("index.html");
    writer.Write(content);
    writer.Close();
    Process.Start("cmd", $"/c start {Path.GetFullPath("index.html")}");
}

string PromptUrl()
{
    Console.Clear();
    Console.WriteLine("Please enter a webURL: ");
    string url = Console.ReadLine();
    url = (url == "") ? "https://www.uddevallapingst.se" : url;
    return url;
}

string ContentFinder(string url)
{
    try
    {
        Console.Write("\nTesting: " + url);
        string content = client.DownloadString(url);
        Console.Write(" Found");
        return content;
    }
    catch { Console.Write(" Not found"); return "404"; }
}

void UrlBrancher(string ogURL)
{
    
    for (double i = 0; i < Math.Pow(branchlength,symbols.Length); i++)
    {
        string branch = ogURL + "/";
        int x;
        branch += symbols[(int)i % symbols.Length];
        for (int j = 1; j < branchlength; j++)
        {
            x = (int)(i / Math.Pow(symbols.Length, j));
            branch += symbols[x];
        }
        SaveBranch(branch);
    }
}

async void SaveBranch(string branch)
{
    string content = ContentFinder(branch).Trim();
    if (content != content404Page) not404Pages.Add(branch);
}