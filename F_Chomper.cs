using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Chomper : MonoBehaviour
{
    void PlayStep(string Event)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }
}
