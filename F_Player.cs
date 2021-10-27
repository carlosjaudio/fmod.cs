using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Player : MonoBehaviour
{

    private float MaterialValue;
    private RaycastHit rh;
    private float distance = 0.3f;
    public LayerMask lm;

    private const string e = "Earth";
    private const string s = "Stone";
    private const string p = "Puddle";
    private const string g = "Grass";

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.blue);
    }

    void PlayRunEvent (string EventPath)
    {
        MaterialCheck();

        FMOD.Studio.EventInstance Run = FMODUnity.RuntimeManager.CreateInstance(EventPath);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Run, transform, GetComponent<Rigidbody>());
        Run.setParameterByName("Material", MaterialValue, false);
        Run.start();
        Run.release();
    }

    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out rh, distance, lm))
        {
            
            switch (rh.collider.tag)
            {
                case e:
                    MaterialValue = 1;
                    break;
                case s:
                    MaterialValue = 2;
                    break;
                case p:
                    MaterialValue = 3;
                    break;
                case g:
                    MaterialValue = 4;
                    break;
                default:
                    MaterialValue = 1;
                    break;
            }
        }
    }
}
