using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private string _correctGemOrder = "BlueRedGreen";
    private string _enteredGemOrder = "";

    private int _amountOfGems = 3;
    private int _currentGem = 0;

    public Animator _boxAnimator;

    public void GemSelect(Gem currentSelectedGem)
    {
        _enteredGemOrder += currentSelectedGem._gemColor;

        _currentGem += 1;

        if (_currentGem == _amountOfGems)
        {
            CompareGemOrder();
        }

        print("Gem selected");
    }

    void CompareGemOrder()
    {
        if (_correctGemOrder == _enteredGemOrder)
        {
            print("Order is correct");
            OpenBox();
        }
        else
        {
            print("Order is incorrect");
            ResetGame();
        }
    }

    void OpenBox()
    {
        _boxAnimator.SetTrigger("Open");
    }

    void ResetGame()
    {
        _currentGem = 0;
        _enteredGemOrder = "";

        //Reset the gem emission
    }
}
