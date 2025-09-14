using StarterAssets;
using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour , IExecute
{
    //private bool _inChest = false;
    private bool _inProcess = false;
    private FirstPersonController player;
    [SerializeField] private Transform _outPoint;
    [SerializeField] private Transform _inPoint;

    public void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    public void Update()
    {
        if ((Input.GetKey(KeyCode.E) || (Input.GetKeyDown(KeyCode.Space))) && player.PlayerHiden && !_inProcess) //переделать на Actions из InputSystem
        {
            player.PlayerHiden = false;
            Debug.Log("-======-");
            LeaveChest();
        }
    }

    public void Execute()
    {
        Debug.Log("Method Execute");
        if (!_inProcess && !player.PlayerHiden)
        {
            Debug.Log("-======-");
            Debug.Log("Not InProcess");
            //if (!_inChest)
            //{
                EnterToChest();
            //}
        } 
        else
        {
            Debug.Log("-======-");
            Debug.Log("_inProcess = "+ _inProcess);
            Debug.Log("PlayerHiden = " + player.PlayerHiden);
            Debug.Log("Can not use");
        }
    }

    private void EnterToChest()
    {
        Debug.Log("Method EnterToChest");
        player.transform.rotation = this.transform.rotation;
        var newPosition = new Vector3(_inPoint.position.x, player.transform.position.y, _inPoint.position.z);
        player.Teleport(newPosition);
        Debug.Log(player.transform.position);
        Debug.Log("EnterToChest");
        player.PlayerHiden = true;
        Debug.Log("PlayerHiden = " + player.PlayerHiden);
        StartCoroutine(Wait());
    }

    private void LeaveChest()
    {
        Debug.Log("Method LeaveChest");
        Debug.Log(player.transform.position);
        player.transform.rotation = _outPoint.rotation;
        var newPosition = new Vector3(_outPoint.position.x, player.transform.position.y, _outPoint.position.z);
        player.Teleport(newPosition);
        Debug.Log(player.transform.position);
        Debug.Log("LeaveChast");
        player.PlayerHiden = false;
        Debug.Log("PlayerHiden = " + player.PlayerHiden);
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        _inProcess = true;
        Debug.Log("_inProcess = " + _inProcess);
        yield return new WaitForSeconds(2);
        //_inChest = !_inChest;
        //Debug.Log("_inChest = " + _inChest);
        
        
        _inProcess = false;
        Debug.Log("_inProcess = " + _inProcess);
    }
}
