using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class Usable : MonoBehaviour
{
    [SerializeField] protected string _name;
    private Outline _outline;

    public string Name { get { return this._name; } set { _name = value; }}
    public float OutlineWidth { get { return _outline.OutlineWidth; } set { _outline.OutlineWidth = value; }}

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        OutlineWidth = 0;
    }

    void Start()
    {

        //if (_name == "")
        //{
        //    _name = this.name;
        //}
    }

    //public void Interaction(float width)
    //{
    //    //OutlineWidth = this.GetComponent<Outline>(); //вероятно так не должно быть, но ссылка из Старта не передается сюда. 
    //    Outline smField = OutlineWidth;
    //    //OutlineWidth.OutlineWidth = width;
    //    smField.OutlineWidth = width;
    //    print(width);
    //}
}
