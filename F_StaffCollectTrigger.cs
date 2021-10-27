using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_StaffCollectTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Interactables/StaffCollect", gameObject);
    }
}
