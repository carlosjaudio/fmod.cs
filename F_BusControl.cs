using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class F_BusControl : MonoBehaviour
{

    Bus Bus;
    public string BusPath;
    private float BusVolume;
    private float FinalBusVolume;
    private Slider Slider;
    EventInstance LevelTest;
    PLAYBACK_STATE pb;

    void Start()
    {
        Bus = RuntimeManager.GetBus("bus:/" + BusPath);
        Bus.getVolume(out BusVolume, out FinalBusVolume);

        Slider = GetComponent<Slider>();
        Slider.value = BusVolume;

        if(BusPath == "SFX")
        {
            LevelTest = RuntimeManager.CreateInstance("event:/SFX/UI/Level Test");
        }
        else
            LevelTest.release();
    }

    public void volumeLevel(float SliderValue)
    {
        Bus.setVolume(SliderValue);
        // LevelTest.start();
        if(BusPath == "SFX")
        {
            LevelTest.getPlaybackState(out pb);
            if(pb != PLAYBACK_STATE.PLAYING)
                LevelTest.start();
        }   
    }

    void OnDestroy()
    {
        if(BusPath == "SFX")
        LevelTest.release();
    }

}
