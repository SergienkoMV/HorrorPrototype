using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private Animator doorAnimation;
    private bool _isOpen = false;
    private bool _isLock = true;
    [SerializeField] GameObject _key;


    // Start is called before the first frame update
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    public void UseDoor(GameObject[] obj)
    {
        if (!_isLock)
        {
            ToggleDoor();
        }
        else
        {
            foreach (GameObject item in obj)
            {
                if (_key == item)
                {
                    _isLock = false;
                    ToggleDoor();
                    break;
                }
            }
        }
    }

    public void ToggleDoor()
    {
        _isOpen = !_isOpen;
        doorAnimation.SetBool("IsOpen", _isOpen);
    }
}
