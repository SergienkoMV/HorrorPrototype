using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    //[SerializeField] AudioListener audioListener;
    [SerializeField] AudioSource BreakingBranch;
    [SerializeField] AudioSource UglySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSound()
    {
        BreakingBranch.Play();
        UglySound.Play(44100);
    }
}
