using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //создать массив для присвоения всех менюшек (чтобы отключать все, кроме текущего выбранного пункт (а может не надо))
    [Tooltip("Ссылка на Основное меню")]
    [SerializeField] Canvas _mainMenu;
    [Tooltip("Ссылка на Меню настроек")]
    [SerializeField] Canvas _settingsMenu;

    [Tooltip("Ссылка на текст для скорости хотьбы")]
    [SerializeField] TextMeshProUGUI _textMoveSpeed;
    [Tooltip("Ссылка на текст для скорости бега")]
    [SerializeField] TextMeshProUGUI _textRunSpeed;
    [Tooltip("Ссылка на текст для скорости поворота")]
    [SerializeField] TextMeshProUGUI _textRotationSpeed;
    [Tooltip("Ссылка на текст для высоты прыжка")]
    [SerializeField] TextMeshProUGUI _textJumpForce;
    [Tooltip("Ссылка на текст для яркости солнца")]
    [SerializeField] TextMeshProUGUI _textSunLightForce;
    [Tooltip("Ссылка на текст для яркости фонарика")]
    [SerializeField] TextMeshProUGUI _textLightFlashlight;
    [Tooltip("Ссылка на текст для угола света фонарика")]
    [SerializeField] TextMeshProUGUI _textWidthLightFlashlight;
    [Tooltip("Ссылка на текст для дальности света фонарика")]
    [SerializeField] TextMeshProUGUI _textRangeLightFlashlight;
    [Tooltip("Ссылка на текст для плотности тумана")]
    [SerializeField] TextMeshProUGUI _textFogDensity;

    [Tooltip("Ссылка на список Dropdown")]
    [SerializeField] private TMP_Dropdown _dropdown;
    [Tooltip("Ссылка на список Skybox")]
    [SerializeField] Material [] _skyboxes;


    private float _moveSpeed;
    private float _runSpeed;
    private float _rotationSpeed;
    private float _jumpForce;
    private float _SunLightForce;
    private float _lightFlashlight;
    private float _widthLightFlashlight;
    private float _rangeLightFlashlight;
    private float _FogDensity;
    private int _FPS;

    int count = 0;
    float deltaTime = 0;

    private void Start()
    {

        _moveSpeed = FindAnyObjectByType<FirstPersonController>().MoveSpeed;
        _textMoveSpeed.text = (getMoveSpeed()).ToString();
        _runSpeed = FindAnyObjectByType<FirstPersonController>().SprintSpeed;
        _textRunSpeed.text = (getRunSpeed()).ToString();
        _rotationSpeed = FindAnyObjectByType<FirstPersonController>().RotationSpeed * 10;
        _textRotationSpeed.text = getRotationSpeed().ToString();
        _jumpForce = FindAnyObjectByType<FirstPersonController>().JumpHeight * 10;
        _textJumpForce.text = getJumpForce().ToString();
        _SunLightForce = GameObject.Find("Directional Light").GetComponent<Light>().intensity;
        _textSunLightForce.text = (getSunLightForce()).ToString();
        _lightFlashlight = GameObject.Find("LightFlashlight").GetComponent<Light>().intensity;
        _textLightFlashlight.text = (getLightFlashlight()).ToString();
        _widthLightFlashlight = GameObject.Find("LightFlashlight").GetComponent<Light>().spotAngle;
        _textWidthLightFlashlight.text = (getWidthLightFlashlight()).ToString();
        _rangeLightFlashlight = GameObject.Find("LightFlashlight").GetComponent<Light>().range;
        _textRangeLightFlashlight.text = (getRangeLightFlashlight()).ToString();
        _FogDensity = RenderSettings.fogDensity;
        _textFogDensity.text = (getFogDensity()).ToString();



        //_textRotationSpeed.text = ((int)(getRotationSpeed() * 100)).ToString();
        //_textJumpForce.text = ((int)(getJumpForce() * 100)).ToString();
    }

    private void Update()
    {
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        //Debug.Log("Quit");
        //        //Application.Quit();
        //        if (_mainMenu.isActiveAndEnabled)
        //        {
        //            _mainMenu.gameObject.SetActive(false);
        //            FindObjectOfType<GameManager>().setPause();
        //        }
        //        else if (_settingsMenu.isActiveAndEnabled) 
        //        {
        //            _settingsMenu.gameObject.SetActive(false);
        //            _mainMenu.gameObject.SetActive(true);
        //        }
        //    }
        //}
        //Debug.Log(GameObject.Find("FPS").GetComponent<TextMeshProUGUI>().text);
        
        //count += 1;
        //Debug.Log("count" + count);

        //GameObject.Find("FPS").GetComponent<TextMeshProUGUI>().SetText((1).ToString());

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        GameObject.Find("FPS").GetComponent<TextMeshProUGUI>().text = "FPS:" + Mathf.Ceil(fps).ToString();
    }

    //private void FixedUpdate()
    //{

    //    timeDelta += 1;
    //    Debug.Log("timeDelta" + timeDelta);
    //    if (timeDelta >= 60)
    //    {
    //        count = 0;
    //        Debug.Log(count);
    //        timeDelta = 0;
    //    }
    //}

    public void ResumeGame()
    {
        _mainMenu.gameObject.SetActive(false); //Закрываем окно меню
        GameManager.FindObjectOfType<GameManager>().setPause(); //Снимаем с паузы    
    }

    //Открытие основного меню
    public void SetupMenu()
    {
        if (!_mainMenu.gameObject.activeSelf && !_settingsMenu.gameObject.activeSelf)
        //Открытие меню
        {
            _mainMenu.gameObject.SetActive(true);
            //_settingsMenu.gameObject.SetActive(false);
            GameManager.FindObjectOfType<GameManager>().setPause();

        }
        //Выход из подменю
        else if (_mainMenu.gameObject.activeSelf)
        {
            //_settingsMenu.gameObject.SetActive(false); 
            _mainMenu.gameObject.SetActive(false);
            ResumeGame();
        }
        else
        //Закрытие меню
        {
            _settingsMenu.gameObject.SetActive(false);
            _mainMenu.gameObject.SetActive(true);
        }
    }
    //Открытие меню настроек


    public void OpenSettings()
    {
        {
            _mainMenu.gameObject.SetActive(false);
            _settingsMenu.gameObject.SetActive(true);
        }
    }

    //Выход из игры
    public void ExitGame()
    {
        Application.Quit();
    }

    //Скорость хотьбы
    public void setMoveSpeed(Slider x)
    {
        _moveSpeed = (float)x.value;
        _textMoveSpeed.text = (getMoveSpeed()).ToString();
    }

    public float getMoveSpeed()
    {
        return _moveSpeed;
    }

    //Скорость бега
    public void setRunSpeed(Slider x)
    {
        _runSpeed = (float)x.value;
        _textRunSpeed.text = (getRunSpeed()).ToString();
    }

    public float getRunSpeed()
    {
        return _runSpeed;
    }

    //Скорость поворота
    public void setRotationSpeed(Slider x)
    {
        _rotationSpeed = (float)x.value;
        _textRotationSpeed.text = (getRotationSpeed()).ToString();
    }

    public float getRotationSpeed()
    {
        return _rotationSpeed;
    }
   
    //Сила прыжка
    public void setJumpForce(Slider x)
    {
        _jumpForce = (float)x.value;
        _textJumpForce.text = (getJumpForce()).ToString();
    }

    public float getJumpForce()
    {
        return _jumpForce;
    }

    //Управление светом солнца
    public void setSunLightForce(Slider x)
    {
        _SunLightForce = (float)x.value;
        _textSunLightForce.text = (getSunLightForce()).ToString();
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = _SunLightForce;
    }

    public float getSunLightForce()
    {
        //нужно округлить до 2 знаков после запятой
        return _SunLightForce;
    }

    //Управление светом фонарика
    public void setFlashlight(Slider x)
    {
        _lightFlashlight = (float)x.value;
        _textLightFlashlight.text = (getLightFlashlight()).ToString();
        GameObject.Find("LightFlashlight").GetComponent<Light>().intensity = _lightFlashlight;

    }

    public float getLightFlashlight()
    {
        //нужно округлить до 2 знаков после запятой
        return _lightFlashlight;
    }

    //Управление шириной света фонарика
    public void setWidthLightFlashlight(Slider x)
    {
        _widthLightFlashlight = (float)x.value;
        _textWidthLightFlashlight.text = (getWidthLightFlashlight()).ToString();
        GameObject.Find("LightFlashlight").GetComponent<Light>().spotAngle = _widthLightFlashlight;

    }

    public float getWidthLightFlashlight()
    {
        //нужно округлить до 2 знаков после запятой
        return _widthLightFlashlight;
    }

    //Управление дальностью света фонарика
    public void setRangeLightFlashlight(Slider x)
    {
        _rangeLightFlashlight = (float)x.value;
        _textRangeLightFlashlight.text = (getRangeLightFlashlight()).ToString();
        GameObject.Find("LightFlashlight").GetComponent<Light>().range = _rangeLightFlashlight;

    }

    public float getRangeLightFlashlight()
    {
        //нужно округлить до 2 знаков после запятой
        return _rangeLightFlashlight;
    }

    //Управление плотностью тумана
    public void setFogDensity(Slider x)
    {
        _FogDensity = (float)x.value;
        _textFogDensity.text = (getFogDensity()).ToString();
        RenderSettings.fogDensity = _FogDensity;
    }

    public float getFogDensity()
    {
        //нужно округлить до 2 знаков после запятой
        return _FogDensity;
    }

    

    //public void GetValueSkybox()
    //{
    //    int pickedSkybox = _dropdown.value;
    //    Debug.Log(pickedSkybox);
    //    setSkybox(pickedSkybox);

    //}


    //public void setSkybox(Int32 x)
    //{
    //    RenderSettings.skybox = _skyboxes[x];
    //}
}
