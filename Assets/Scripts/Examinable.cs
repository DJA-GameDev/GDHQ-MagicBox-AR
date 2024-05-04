using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField]
    private ExaminableManager _examinableManager;

    // Start is called before the first frame update
    void Start()
    {
        _examinableManager = FindObjectOfType<ExaminableManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Request object to be examined when selected
    public void RequestExamine()
    {
        _examinableManager.PerformExamine(this);
        print("Examine has been requested");
    }

    public void RequestUnexamine()
    {
        _examinableManager.PerformUnexamine();
        print("Unexamine has been requested");
    }
}
