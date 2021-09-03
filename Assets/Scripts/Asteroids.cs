using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

    public Rigidbody2D rb;
    public float force;
    public float rotation;
    public float Top;
    public float Bottom;
    public float Left;
    public float Right;
    public int aS;
    public GameObject asteroidMed;
    public GameObject asteroidSmall;

    void Start() {
        Vector2 maxForce = new Vector2(Random.Range(-force, force),Random.Range(-force, force));
        float maxRotation = Random.Range(-rotation, rotation);

        rb.AddForce(maxForce);
        rb.AddTorque(maxRotation);
    }

    void Update() {

        //Портал
        Vector2 newPos = transform.position;
        if (transform.position.y > Top)
        {
            newPos.y = Bottom;
        }
        if (transform.position.y < Bottom)
        {
            newPos.y = Top;
        }
        if (transform.position.x < Left)
        {
            newPos.x = Right;
        }
        if (transform.position.x > Right)
        {
            newPos.x = Left;
        }
        transform.position = newPos;

    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("Bullet")) {
            Destroy(col.gameObject);
            GameManager.instance.AddPoints();

            if (aS == 3){
                Instantiate(asteroidMed, transform.position, transform.rotation);
                Instantiate(asteroidMed, transform.position, transform.rotation);
               

            } else if (aS == 2) {
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                

            } else if (aS == 1) {
                
            }
            
            Destroy(gameObject);
        } else if (col.CompareTag("laser")) {
            GameManager.instance.AddPoints();
            Destroy(gameObject);
        }
    }


}
