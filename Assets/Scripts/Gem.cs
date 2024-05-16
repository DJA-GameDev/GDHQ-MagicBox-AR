using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public string _gemColor = "";
    [SerializeField]
    private Material _targetMaterial;

    private Color _initialEmissionColor;

    // Start is called before the first frame update
    void Start()
    {
        //cache gem intial emission color
        _initialEmissionColor = _targetMaterial.GetColor("_EmissionColor");

        //set gem emmission color to black
        _targetMaterial.SetColor("_EmissionColor", Color.black);
    }


    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting == true) 
        {
            //make this gem emmissive
            _targetMaterial.SetColor("_EmissionColor", _initialEmissionColor);
        }
        else 
        {
            //make this gem unemissive
            _targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }
}
