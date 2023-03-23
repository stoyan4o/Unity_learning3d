using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody _rigidbody;   // Rigid body of the paddle. This is used to move the paddle

    public GameObject LeftWall;
    public GameObject RightWall;

    float wallWidth = 0;
    float paddleWidth = 0;  // Get this from the 

    public float mouseX = 0;
    public float screenX = 0;
    // Start is called before the first frame update

    public float paddleY = 120;
     
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        paddleWidth = GetComponent<Renderer>().bounds.size.x;
        
        Renderer rend = LeftWall.GetComponent<Renderer>();
        wallWidth = rend.bounds.size.x;

         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseX = Input.mousePosition.x;
        
        Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 26)).x, paddleY, -140); // x,-18,0

       if (newPos.x < LeftWall.transform.position.x + wallWidth)
        {
            newPos.x = LeftWall.transform.position.x + wallWidth*2; // new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0);
        }

        if (newPos.x > RightWall.transform.position.x - wallWidth*2)
            newPos.x = RightWall.transform.position.x - wallWidth*2;

         

        _rigidbody.MovePosition(newPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("ball"))
        {
            // todo: move this to Ball.OnCollisionEnter(..)
            AudioMgr.Instance.PlaySound("hit_paddle");
        }
    }
}
