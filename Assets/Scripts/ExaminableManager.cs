using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{

    [SerializeField]
    private Transform _examineTarget;
    private Vector3 _cachedPosition;
    private Vector3 _cachedScale;
    private Quaternion _cachedRotation;
    private Examinable _currentExaminedObject;

    [SerializeField]
    private float _rotateSpeed = 1;

    private bool _isExamining = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isExamining == true)
        { 
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved) 
                {
                    print(touch.deltaPosition);
                    _currentExaminedObject.transform.Rotate(touch.deltaPosition.x * _rotateSpeed, touch.deltaPosition.y * _rotateSpeed, 0);
                }
            }
        }
    }

    public void PerformExamine(Examinable examinable)
    {
        _currentExaminedObject = examinable;

        //Cached examinable transform data for reset
        _cachedPosition = _currentExaminedObject.transform.position;
        _cachedRotation = _currentExaminedObject.transform.rotation;
        _cachedScale = _currentExaminedObject.transform.localScale;

        //Move examinable to target position
        _currentExaminedObject.transform.position = _examineTarget.position;
        _currentExaminedObject.transform.parent = _examineTarget;

        //Offset scale to fit examinable in view
        Vector3 offsetScale = _cachedScale * examinable._examineScaleOffset;
        _currentExaminedObject.transform.localScale = offsetScale;

        _isExamining = true;
    }

    public void PerformUnexamine()
    {
        _currentExaminedObject.transform.position = _cachedPosition;
        _currentExaminedObject.transform.rotation= _cachedRotation;
        _currentExaminedObject.transform.localScale = _cachedScale;

        _currentExaminedObject.transform.parent = null;
        _currentExaminedObject = null;

        _isExamining = false;
    }
}
