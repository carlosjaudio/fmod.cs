using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_FireFlies : MonoBehaviour
{
    FMOD.Studio.EventInstance FF;

    void Start()
    {
        FF = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Enviroment/FireFlies");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(FF, transform, GetComponent<Rigidbody>());
        FF.start();
        FF.release();
    }

    void OnDestroy() 
    {
        FF.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}