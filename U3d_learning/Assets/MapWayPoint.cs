using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWayPoint : MonoBehaviour
{
    Color colorRange = Color.blue;

    public int Order = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int _segments = 30;
    float _gizmoSize = 1.0f;
    private void OnDrawGizmos()
    {
       
        DrawMgr.DrawEllipse(transform.position, transform.up, transform.forward, _gizmoSize, _gizmoSize, _segments, colorRange);
    }


    //
    
}
