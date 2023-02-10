using UnityEngine;

public class RainScript : MonoBehaviour
{
    public GameObject drop;
    public float dropSpeed = 1f;
    public float spawnInterval = 0.1f;
    public int maxDrops = 100;

    private int currentDrops;
    private float spawnTimer;

    void Update()
    {
        if (currentDrops >= maxDrops)
        {
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            //SpawnRaindrop();
        }
    }

    private void SpawnRaindrop()
    {
         
        //currentDrops++;
       // GameObject newDrop = Instantiate(drop, transform.position, Quaternion.identity);
       // newDrop.GetComponent<Rigidbody>().velocity = Vector3.down * dropSpeed;
    }
}
