using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{

    [SerializeField] private GameObject cloudParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bird birb = collision.collider.GetComponent<bird>();
        if(birb != null)
        {
            Destroy(gameObject);
            Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);
        }
        enemies enemy = collision.collider.GetComponent<enemies>();
       
        if(collision.contacts[0].normal.y < -0.5)
        {
            Destroy(gameObject);
            Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);

        }
    }
}
