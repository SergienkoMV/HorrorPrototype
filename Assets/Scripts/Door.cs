using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Door : MonoBehaviour
{
    Rigidbody door;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        door.transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
    }
}
