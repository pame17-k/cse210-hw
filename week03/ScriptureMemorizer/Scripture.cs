using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // dividir el texto en palabras y crear objetor word
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }

    // Getter and Setter for reference
    public Reference GetReference() { return _reference; }
    public void SetReference(Reference reference) { _reference = reference; }
    
    // Getter para Words (solo lectura)
    public List<Word> GetWords() { return _words; }

    // ocultar palabras aleatorias
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        List<Word> visibleWords = new List<Word>();

        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                visibleWords.Add(w);
            }
        }

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Mostrar texto completo con referencia
    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word w in _words)
        {
            scriptureText += w.GetDisplayText() + " ";
        }
        return _reference.GetDisplayText() + " - " + scriptureText.Trim();
    }

    // verificar si todas las palabras estan ocultas
    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}