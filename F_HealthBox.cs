using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using Gamekit3D;

public class F_HealthBox : MonoBehaviour
{

    [FMODUnity.EventRef]

    public string EventPath;
    private EventInstance HC;
    private GameObject Player;
    private Damageable D;

    // Start is called before the first frame update
    void Start()
    {
        HC = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(HC, transform, GetComponent<Rigidbody>());
        HC.start();
        HC.release();

        Player = GameObject.Find("Ellen");
        D = Player.GetComponent<Damageable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            HC.setParameterByName("Health", D.currentHitPoints);
            HC.setParameterByName("Trigger", 1f, true);
        }
    }

    private void OnDestroy()
    {
        HC.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}