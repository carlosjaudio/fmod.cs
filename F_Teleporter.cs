using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Teleporter : MonoBehaviour
{

    FMOD.Studio.EventInstance T_hum;

    void Start()
    {
        T_hum = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Interactables/Teleporter");
        T_hum.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(T_hum, transform, GetComponent<Rigidbody>());
        T_hum.release();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Ellen")
        {
            T_hum.setParameterByName("Trigger", 1f, false);
            MusicPlayer.MusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }     
    }
}
