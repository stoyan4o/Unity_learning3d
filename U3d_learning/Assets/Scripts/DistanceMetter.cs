using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMetter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro editText;

    public GameObject player;
    void Start()
    {
        editText = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
      

        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        editText.text = string.Format("{0:F0} m",dist);
    }
}
