using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_RunningWater : MonoBehaviour
{
    FMOD.Studio.EventInstance RW;

    void Start()
    {
        RW = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Enviroment/RunningWater");
        RW.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        RW.start();
        RW.release();
    }

    void OnDestroy() 
    {
        RW.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
