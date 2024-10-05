//using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//using UnityEngine.InputSystem.PlayerInput;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Ссылка на Основное меню")]
    [SerializeField] Canvas _menu;
    [Tooltip("Ссылка на фонарик в руке")]
    [SerializeField] GameObject _flashlight;

    private bool _pause = false; //переменная для состояния паузы
            
    private StarterAssetsInputs _inputMapping;
     
    private void Awake() => _inputMapping = new StarterAssetsInputs();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //        InputActionMap playerActionMap = GetComponent<PlayerInput>().actions.GetActionMap("Player");
        //        playerActionMap.Enable();
        //        playerActionMap.GetAction("TestAction").Enable(); //Just to be sure
        
        //Включаю мышь принудительно, так как она отключается при запуске игры в режиме Play focused
        if (!Mouse.current.enabled)
        {

            InputSystem.EnableDevice(Mouse.current);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Открытие меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Menu").GetComponent<MenuController>().SetupMenu();
            //            _menu.GetComponent<MenuController>().OpenSettings();

            //if (!_menu.isActiveAndEnabled && !_pause)
            //{
            //    _menu.gameObject.SetActive(true);
            //    setPause();

            //}

            //if (_menu.<_mainMenu.Transform> _mainMenu.isActiveAndEnabled)
            //{
            //    _mainMenu.gameObject.SetActive(false);
            //    FindObjectOfType<GameManager>().setPause();
            //}
            //else if (_settingsMenu.isActiveAndEnabled)
            //{
            //    _settingsMenu.gameObject.SetActive(false);
            //    _mainMenu.gameObject.SetActive(true);
            //}
            //else
            //{
            //    _menu.gameObject.SetActive(false);
            //    setPause();
            //}
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneLoad(0);
        }

        //Выключатель фонарика
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_flashlight.gameObject.activeSelf)
            {
                _flashlight.gameObject.SetActive(false);
            } else
            {
                _flashlight.gameObject.SetActive(true);
            }      
        }
    }

    //Установка/снятие паузы
    public void setPause()
    {
        if (_pause)
        {
            _pause = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else
        {
            _pause = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    //Статус паузы
    public bool getPause()
    {
        return _pause;
    }

    //Загрузка сцены
    public void SceneLoad(int x)
    {
        SceneManager.LoadScene(x);
        Time.timeScale = 1f;
    }

    ////Route and Un-route events
    //private void OnEnable() => _inputMapping.Enable();
    //private void OnDisable() => _inputMapping.Disable();
}
