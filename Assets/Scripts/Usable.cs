using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class Usable : MonoBehaviour
{
    [SerializeField] private string _name;
    private Outline _outline;

    public string Name { get { return _name; } }

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
    }
}
