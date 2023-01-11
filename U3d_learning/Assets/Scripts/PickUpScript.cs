using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    bool IsDiying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDiying)
            Die();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // play sound
            IsDiying = true;    
        }
        else if (other.gameObject.CompareTag("Payload"))
        {
           // other.gameObject.GetComponent("PayloadAI").SendMessage("Boost()", 1);
        }
    }

    void Die()
    {
        float speed = 20f;
        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.transform.position, step);

        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1)
        {
            gameObject.SetActive(false);
            IsDiying = false;
        }
    }
}
