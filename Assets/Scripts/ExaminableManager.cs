using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{

    [SerializeField]
    private Transform _examineTarget;
    private Vector3 _cachedPosition;
    private Quaternion _cachedRotation;
    private Examinable _currentExaminedObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformExamine(Examinable examinable)
    {
        _currentExaminedObject = examinable;

        _cachedPosition = examinable.transform.position;
        _cachedRotation = examinable.transform.rotation;

        _currentExaminedObject.transform.position = _examineTarget.position;
        _currentExaminedObject.transform.parent = _examineTarget;
    }

    public void PerformUnexamine()
    {
        _currentExaminedObject.transform.position = _cachedPosition;
        _currentExaminedObject.transform.rotation= _cachedRotation;
        _currentExaminedObject.transform.parent = null;
    }
}
