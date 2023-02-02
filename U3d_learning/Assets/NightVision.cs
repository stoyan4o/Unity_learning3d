using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour
{
    public bool bright = true;
    public float brightness = 2.0f;
    public Shader nightvisionShader;

    Camera camera;

    public bool IsEnabled = true;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void OnEnable()
    {
        nightvisionShader = Shader.Find("Unlit/NightVision");
       // nightvisionShader = Shader.Find("Unlit/WireframeShader");
    }

    public void OnPreCull()
    {
        if (bright)
        {
            Shader.SetGlobalFloat("_Brightness", brightness);
            Shader.SetGlobalFloat("_Bright", 1.0f);
        }
        else
        {
            Shader.SetGlobalFloat("_Bright", 0.0f);
        }

        if ( nightvisionShader)
            camera.SetReplacementShader(nightvisionShader, null);
    }
}
