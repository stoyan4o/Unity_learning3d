using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuardAI : MonoBehaviour
{

    public Vector3 SpawnPoint;
    // If there is an target GO
    public GameObject target;

    public float proximityToPlayer = 4.0f;  // At what distance we should go near the player
    public float maxRangeToFollowPlayer = 20.0f; // If player is further than this go back to spawn point. You dont see the player

    public float moveSpeed = 2.5f;

    bool IsReturningToSpawnPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        this.SpawnPoint = this.transform.position;  // remember our spawn point

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = FindNearestGObjectByTag("Player");


        if (target == null)
            return;


        // Distance between go to target(Player)
        float dist = Vector3.Distance(this.transform.position, target.transform.position);
        // Distance between go and his spawn point
        float distToSpawnPoint = Vector3.Distance(this.transform.position, this.SpawnPoint);

        // Is GO on his spawn point
        if (distToSpawnPoint < 1)
            this.IsReturningToSpawnPoint = false;

        // Is player too far away and need to go back
        if (distToSpawnPoint > maxRangeToFollowPlayer)
                IsReturningToSpawnPoint = true;

        // If we are returning to spawnpoint dont check anything else
        if (IsReturningToSpawnPoint)
            MoveBackToSpawnPoint();
        else if (dist > proximityToPlayer) 
        {
            float distPlayerToSpawn = Vector3.Distance(this.transform.position, this.SpawnPoint);
            if (distPlayerToSpawn < maxRangeToFollowPlayer)
                MoveToTarget();
        }


    }

    void MoveBackToSpawnPoint()
    {
        var step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, this.SpawnPoint, step);

    }

    void MoveToTarget()
    {
        var step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    private GameObject FindNearestGObjectByTag(string tagName)
    {
        List<GameObject> res = new List<GameObject>();

        res = GameObject.FindGameObjectsWithTag("Player").ToList();

        Vector3 currentPos = transform.position;

        double minDist = double.MaxValue;
        GameObject closestGO = null;
        foreach(GameObject go in res)
        {
            float goDist = Vector3.Distance(go.transform.position, currentPos);
            if (goDist < minDist)
            {
                closestGO = go;
                minDist = goDist;
            }
        }

        return closestGO;
    }
}
