using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayloadAI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject NextWP;
    public GameObject CurrentWP;
    public GameObject Player;                   // For multiple player keep list of players, Add/Remove them with colider. Get PlayersInRange is slower

    public float MoveSpeed = 1.0f;              // Speed to move to next waypoint
    public float rangePushedByPlayer = 4.0f;

    int idxWayPoint = 0;
    public List<GameObject> wayPoints;
    
    void Start()
    {
        CurrentWP = wayPoints[0];
        idxWayPoint = 1;
        NextWP = wayPoints[idxWayPoint];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer > rangePushedByPlayer)
        {
            // SlowlyFallBack();
            return;
        }

        float distToNextWP = Vector3.Distance(transform.position, NextWP.transform.position);

        if (distToNextWP < 1)
        {
            // На Waypoint сме, набелязваме следващ waypoint за да се върви
            FindNextWayPoint();
        }
        else 
        {
            // Има още път до следващия wp
            MoveToDestWaypoint();
        }
    }

    void SlowlyFallBack()
    {
        var step = this.MoveSpeed * Time.deltaTime * 0.2f;          // calculate distance to move 5 times slower than speed to move to next waypoint

        transform.LookAt(NextWP.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, CurrentWP.transform.position, step);
    }

    
    void FindNextWayPoint()
    {
        idxWayPoint++;
        NextWP = wayPoints[idxWayPoint];
    }

    void MoveToDestWaypoint()
    {
        var step = this.MoveSpeed * Time.deltaTime;          // calculate distance to move

        transform.LookAt(NextWP.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, NextWP.transform.position, step);
    }
}
