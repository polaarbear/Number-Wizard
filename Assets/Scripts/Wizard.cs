using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wizard : MonoBehaviour
{
    private int min;
    private int max;
    private int currentGuess;
    private List<int> previousGuesses;

    [SerializeField] private TextMeshProUGUI guessText;

    void Start()
    {
        min = 1;
        max = 1001;
        currentGuess = min;
        previousGuesses = new List<int>();
        NextGuess();
    }

    public void NextGuess()
    {
        do
        {
            currentGuess = Random.Range(min, max + 1);
        } while (IsPreviouslyGuessed(currentGuess) == true);

        previousGuesses.Add(currentGuess);
        guessText.text = currentGuess.ToString();        
    }

    private bool IsPreviouslyGuessed(int nextGuess)
    {
        bool isGuessed = false;
        foreach(int guess in previousGuesses)
        {
            if (guess == nextGuess)
            {
                isGuessed = true;
            }
        }
        return isGuessed;
    }
    
    public void IsHigher()
    {
        min = currentGuess;
        NextGuess();
    }

    public void IsLower()
    {
        max = currentGuess;
        NextGuess();
    }
}
