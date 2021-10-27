using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [FMODUnity.EventRef]

    public string EventPath;
    public static FMOD.Studio.EventInstance MusicInst;
    private FMOD.Studio.PLAYBACK_STATE MusicState;

    // Start is called before the first frame update
    void Start()
    {
        MusicInst = FMODUnity.RuntimeManager.CreateInstance(EventPath);
        MusicInst.start();
        MusicInst.release();
        MusicInst.getPlaybackState(out MusicState);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MusicState);
    }

    void OnDestroy() 
    {
        MusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
