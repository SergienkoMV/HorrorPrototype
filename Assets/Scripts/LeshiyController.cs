using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeshiyController : MonoBehaviour
{
    [SerializeField] AudioSource LeshiyVoice;
    [SerializeField] GameObject LeshyBody;
    [SerializeField] float LeshySpeed;
    [SerializeField] GameObject LeshyDeformationSystem;
    Rigidbody Leshy;
    // Start is called before the first frame update
    void Start()
    {
        Leshy = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Leshy.AddForce(0, 0, -LeshySpeed, ForceMode.Impulse);
        //transform.position.z += 10;
        //this.gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Взаимодействие с игроком
        if (other.gameObject.GetComponent<FirstPersonController>()) 
        {
            LeshiyVoice.Play();
            GroundLeshiy(2);
            LeshySpeed = 0;
            //Quaternion playerSide =  //other.gameObject.transform.position * transform.position;
            //gameObject.transform.rotation = Quaternion.identity;
            
            Vector3 playerSide = other.gameObject.transform.position - gameObject.transform.position;
            gameObject.transform.LookAt(playerSide); //other.gameObject.transform.position
        }

        //Взаимодействие с фонарным столбом
        //if (other.gameObject.GetComponent<Lamppost>())
        //{
        //    other.GetComponent<Lamppost>().ActivateObject(); //Активируем фонарь
        //}

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //Взаимодействие с фонарным столбом
    //    if (other.gameObject.GetComponent<Lamppost>())
    //    {
    //        other.GetComponent<Lamppost>().DeactivateObject(); //Отключаем мерцание
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<FirstPersonController>())
    //    {
    //        GroundLeshiy(10);
    //    }
    //}

    //Включаем фазу 3
    private void GroundLeshiy(int x)
    {
        LeshyDeformationSystem.transform.localScale = Vector3.one * x;
        LeshyBody.gameObject.GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(Timer());
    }

    //(временное решение) Отключение фазы 3
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        LeshyDeformationSystem.transform.localScale = Vector3.one * 1;
        LeshyBody.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        StopCoroutine("Timer");
    }
}
