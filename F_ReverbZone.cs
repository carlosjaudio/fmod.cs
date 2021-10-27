using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_ReverbZone : MonoBehaviour
{
    FMOD.Studio.EventInstance Reverb;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Reverb = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Reverb Zone 1");
        Player = GameObject.Find("Ellen");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
            Reverb.start();
    }

    void OnDestroy()
    {
        Reverb.release();
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
            Reverb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
