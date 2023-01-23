using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Hits = 5;
    public int points = 100;
    public Vector3 rotator;

    [SerializeField]
    Material hitMaterial;

    Material _orgMaterial;
    Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
    }

    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        this.Hits--;

        if (Hits <= 0)
        {
            GameManager.Instance.Score += points;

            //GameManager.Instance.RemoveBrick(gameObject);

             Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMaterial;
    }
}
