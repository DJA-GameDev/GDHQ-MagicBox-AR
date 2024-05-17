using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    private string _correctGemOrder = "BlueRedGreen";
    private string _enteredGemOrder = "";

    private int _amountOfGems = 3;
    private int _currentGem = 0;

    public Animator _boxAnimator;

    [SerializeField] 
    private Gem[] _gemsInScene;

    [SerializeField]
    private UnityEvent _gameIsWon;

    public void GemSelect(Gem currentSelectedGem)
    {
        _enteredGemOrder += currentSelectedGem._gemColor;

        _currentGem += 1;

        if (_currentGem == _amountOfGems)
        {
            CompareGemOrder();
        }

        currentSelectedGem.ChangeEmission(true);
    }

    void CompareGemOrder()
    {
        if (_correctGemOrder == _enteredGemOrder)
        {
            print("Order is correct");
            CompleteGame();
        }
        else
        {
            print("Order is incorrect");
            ResetGame();
        }
    }

    void CompleteGame()
    {
        _gameIsWon.Invoke();
    }

    void ResetGame()
    {
        _currentGem = 0;
        _enteredGemOrder = "";

        //Reset the gem emission
        foreach (var gem in _gemsInScene)
        {
            gem.ChangeEmission(false);
        }
    }
}
