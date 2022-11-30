using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayloadAI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject NextWP;
    public GameObject CurrentWP;
    public GameObject Player;

    public float MoveSpeed = 1.0f;
    public float rangePushedByPlayer = 4.0f;

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
            // �� Waypoint ���, ����������� ������� waypoint �� �� �� �����
            FindNextWayPoint();
        }
        else 
        {
            // ��� ��� ��� �� ��������� wp
            MoveToDestWaypoint();
        }
    }

    private void SlowlyFallBack()
    {
        var step = this.MoveSpeed * Time.deltaTime * 0.2f;          // calculate distance to move

        transform.LookAt(NextWP.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, CurrentWP.transform.position, step);
    }

    int idxWayPoint = 0;
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
