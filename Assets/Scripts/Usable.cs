using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class Usable : MonoBehaviour
{
    [SerializeField] private string _name;
    public Outline _outline;

    //public string Name { get { return _name; } }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }


    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0;
        if (_name == "")
        {
            _name = this.name;
        }
    }

    public void Interaction(float width)
    {
        _outline.OutlineWidth = width;
        print(width);
    }
}
