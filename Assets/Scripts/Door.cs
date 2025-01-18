using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Door : MonoBehaviour
{
    private Transform door;
    [SerializeField] private Transform anchor;
    //private Rigidbody door;
    [SerializeField] private bool _isOpen = false;
    private bool _isOpening = false;
    private bool _isClosing = false;
    private bool _isLock = true;
    private float _closeAngle = 0f;
    private float _openAngle = 90f;
    private Vector3 _EulerAngleVelocity;
    private float _openForce = 2;
    [SerializeField] private GameObject _key;

    void Start()
    {
        //door = GetComponent<Transform>();
        //door = GetComponent<Rigidbody>();
        //door.centerOfMass = Vector3.Scale(_centerOfMass.localPosition, transform.localScale); //_centerOfMass.localPosition; Т.к. CenterOfMass не учитывает размеры объектов, то нужно домножить на размер объекта.
        //_EulerAngleVelocity = new Vector3(180f, 180f, 0f);

        if (_key == null)
        {
            _isLock = false;
        }
        
        if (_isOpen)
        {
            _closeAngle = anchor.eulerAngles.y - 90f;
            _openAngle = anchor.eulerAngles.y;
        } else {
            _closeAngle = anchor.eulerAngles.y;
            _openAngle = anchor.eulerAngles.y + 90f;
        }
    }

    void Update()
    {
        if (!_isLock)
        {
            if (_isOpening)
            {
                OpeningDoor();
            }
            if (_isClosing)
            {
                ClosingDoor();
            }
        }
    }

    public void Interaction(GameObject[] obj)
    {
        if (_isOpen)
        {
            _isClosing = true;
        } 
        else
        {
            if (_isLock)
            {
                foreach (GameObject item in obj)
                {
                    if (_key == item)
                    {
                        _isLock = false;
                        break;
                    }
                }
            }

            if (!_isLock)
            {
                _isOpening = true;
            } else
            {
                StartCoroutine(OutputMessage());
            }
        }
    }

    IEnumerator OutputMessage()
    {
        FindAnyObjectByType<MenuController>().OutputMessage("Дверь заперта. Нужен ключ: " + _key.gameObject.name); 
        yield return new WaitForSeconds(3f);
        FindAnyObjectByType<MenuController>().OutputMessage("");
    }

    private void OpeningDoor()
    {
        //door.transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
        //door.AddTorque(Vector3.down);
        //Quaternion deltaRotation = Quaternion.Euler(_EulerAngleVelocity * Time.deltaTime);
        //door.MoveRotation(door.rotation * deltaRotation);

        //Mathf.Lerp(0, 90, 0.5f);

        Quaternion rotation = Quaternion.Euler(0, _openAngle, 0);
        anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, _openForce * Time.deltaTime);

        print(anchor.eulerAngles.y);
        if (anchor.eulerAngles.y >= _openAngle - 0.03f)
        {
            print(_isOpen);
            _isOpen = true;
            print(_isOpen);
            _isOpening = false;
        }

        //door.AddTorque(_EulerAngleVelocity, ForceMode.Impulse);
        //print(door.rotation);
        //if (door.rotation.y > 0.9f)
        //{
        //    door.rotation = new Quaternion(0, 0.9f, 0, 0);
        //    _isOpen = true;
        //}
    }

    private void ClosingDoor()
    {
        print("try rotation");
        Quaternion rotation = Quaternion.Euler(0, _closeAngle, 0);
        anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, _openForce * Time.deltaTime);
        print(anchor.eulerAngles);
        if (anchor.eulerAngles.y <= _closeAngle + 0.03f)
        {
            _isOpen = false;
            _isClosing = false;
        }

        //if (door.rotation.y > 0.99f)
        //{
        //    door.rotation = new Quaternion(0, 0f, 0, 0);
        //    _isOpen = false;
        //}
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    //}
}
