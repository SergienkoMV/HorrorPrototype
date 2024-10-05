using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lamppost : MonoBehaviour
{
    [Tooltip("Ссылка на систему частиц для искр")]
    [SerializeField] ParticleSystem _sparks;
    [Tooltip("Ссылка на Свет")]
    [SerializeField] GameObject _spotLight;
    [Tooltip("Ссылка на лампочку")]
    [SerializeField] GameObject _spotLight2;

    [Tooltip("Максимальное время до моргания фонаря")]
    [SerializeField] float _maxActiveTime; //максимальное время работы лампочки фонаря

    private bool _active = false; //проверка активности фонаря

    // Start is called before the first frame update
    void Start()
    {
        SetFlickeringLamppost(false);
    }

    //Основной метод
    //Активация действий фонаря
    public void ActivateObject()
    {
        //_active = true;
        SparksSpread(); //выброс искр
        //FlickeringLamppost(); 
        StartCoroutine(FlickeringLamppostOn());
        //SetFlickeringLamppost(_active); //Включаем фонарь
        //StartCoroutine(FlickeringLamppostOff()); // Запускаем мерцание фонаря
    }

    //Выключение фонаря
    //public void DeactivateObject()
    //{
    //    _active = false;
    //}

    //Выброс искр фонаря
    private void SparksSpread()
    {
        _sparks.Play();
    }

    //Мерцание фонаря
    IEnumerator FlickeringLamppostOn()
    {
        yield return new WaitForSeconds(Random.Range(0, _maxActiveTime));
        SetFlickeringLamppost(true);
        StartCoroutine(FlickeringLamppostOff());
        if (_active)
        {
            
        }
    }

    IEnumerator FlickeringLamppostOff()
    {
        yield return new WaitForSeconds(Random.Range(0, _maxActiveTime));
        SetFlickeringLamppost(false); //включаем фонарь
        
        _active = true;
        if (_active)
        {

        }
    }



    //выключаем/выключаем сечение
    private void SetFlickeringLamppost(bool set)
    {
        _spotLight.gameObject.SetActive(set);
        _spotLight2.gameObject.SetActive(set);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LeshiyController>())
        {
            ActivateObject();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<LeshiyController>() && _active) 
        {
            StartCoroutine(FlickeringLamppostOn());
            _active = false;
        } 
    }
}
