using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//[RequireComponent(typeof(Usable))]

public class ReadNote : Usable
{
    
    [SerializeField] private string _text;
    [SerializeField] private GameObject _paper;
    [SerializeField] private TextMeshProUGUI _note;

    public void Start()
    {
        _note.text = _text;
    }

    public void ShowText()
    {
        if (_paper.activeInHierarchy)
        {
            _paper.SetActive(false);
        }
        else
        {
            _paper.SetActive(true);
        }
        GameManager.FindObjectOfType<GameManager>().IsPause = _paper.activeInHierarchy;
    }

}
