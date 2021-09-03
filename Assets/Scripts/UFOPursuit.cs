using UnityEngine;
using System.Collections;

public class UFOPursuit : MonoBehaviour
{

    Transform player;
    public float speed;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, player.position, step); ;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Bullet")) {
            Destroy(col.gameObject);
            GameManager.instance.AddPoints();
            Destroy(gameObject);
        } else if (col.CompareTag("laser")){
            GameManager.instance.AddPoints();
            Destroy(gameObject);
        }
    }
}