using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakebleItem : Usable, IItem
{
    private string _name;
    //[SerializeField] private GameObject _connectedObject;

    void Start()
    {
        Name = this.name;
    }

    //void Update()
    //{
        
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //print("collision.gameObject: " + collision.gameObject);
        //print("_connectedObject: " + _connectedObject);
        //if (collision.gameObject == _connectedObject)
        //{
        //    print("Collision проверка 1 успешна");
        //    if (collision.gameObject.TryGetComponent<Door>(out Door door))
        //    {
        //        //door.UnlockDoor(_connectedObject);
        //        print("Collision проверка 2 успешна");
        //        //door.DoorInteraction();
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
    //    print("collision.gameObject: " + other.gameObject);
    //    print("_connectedObject: " + _connectedObject);
    //    if (other.gameObject == _connectedObject)
    //    {
    //        print("Trigger проверка 1 успешна");
    //        if (other.gameObject.TryGetComponent<Door>(out Door door))
    //        {
    //            //door.UnlockDoor(_connectedObject);
    //            print("Trigger проверка 2 успешна");
    //            //door.DoorInteraction();
    //        }
    //    }
    }
}
