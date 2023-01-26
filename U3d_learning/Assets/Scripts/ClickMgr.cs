using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ButtonPlay_Click()
    {
        SceneManager.LoadScene("BB_GameScene");
    }

    public void ButtonOptions_Click()
    {

    }

    public static void ButtonQuit_Click()
    {

    }


}


