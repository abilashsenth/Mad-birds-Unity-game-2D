using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{

    public SpriteRenderer birdie;
    public Rigidbody2D rb;
    public LineRenderer lineRenderer;
    private Vector3 initialPos;
    private bool birdWasLaunched;
    public float speed;
    private float timeSittingAround;

    private void Awake()
    {
        initialPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
        birdie = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }
     
    // Update is called once per frame
    void Update()


    {

        if (birdWasLaunched && rb.velocity.magnitude <= 0.1)
        {
            timeSittingAround += Time.deltaTime;
        }


        if (transform.position.y > 20 ||
            transform.position.y < -20 ||
            transform.position.x >20||
            transform.position.x< -20 ||
            timeSittingAround >3)
        {
            SceneManager.LoadScene("game");
        }

        lineRenderer.SetPosition(1, initialPos);
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDown()
    {
        birdie.color = Color.red;
        lineRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        birdie.color = Color.white;
        Vector2 directionToInitial = initialPos - transform.position;
        rb.AddForce(directionToInitial * speed);
        birdWasLaunched = true;
        rb.gravityScale = 1;
        lineRenderer.enabled = false;

        
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPos.x, newPos.y);
    }
}
