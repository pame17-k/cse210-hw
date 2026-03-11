using System;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _promptText = prompt;
        _entryText = text;
    }

    public void Display()
    {
        Console.WriteLine(_date + " - Prompt: " + _promptText);
        Console.WriteLine("Response: " + _entryText);
        Console.WriteLine();
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _promptText;
    }

    public string GetResponse()
    {
        return _entryText;
    }
}