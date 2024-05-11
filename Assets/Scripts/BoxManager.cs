using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Management;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private string _correctGemOrder = "BlueGreenRed";
    private string _enteredGemOrder = "";

    private int _amountOfGems = 3;
    private int _currentGem = 0;

    public Animator _boxAnimator;

    public void GemSelect(Gem currentSelectedGem)
    {
        _enteredGemOrder += currentSelectedGem._gemColor;

        _currentGem += 1;

        if (_currentGem == 3)
        {
            CompareGemOrder();
        }

        print("Gem selected");
    }

    public void CompareGemOrder()
    {

    }
}
