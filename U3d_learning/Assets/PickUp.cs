using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
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

    bool IsDiying = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // play sound
            IsDiying = true;    
        }


    }

    void Die()
    {
        float speed = 0.05f;
        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.transform.position,speed);

        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1)
        {
            gameObject.SetActive(false);
            IsDiying = false;
        }
    }
}
