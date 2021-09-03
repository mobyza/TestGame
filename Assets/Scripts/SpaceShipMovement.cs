using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float force;
    public float rotationForce;
    private float forceI;
    private float rotationI;
    public float bulletForce;
    public float laserForce;
    public float Top;
    public float Bottom;
    public float Left;
    public float Right;
    public int LaserShoot;
    public int LaserLeft = 3;
    public float ReloadTime;
    public bool reload = false;
    public Text LaserTxt;
    public Text AngleTxt;


    public GameObject bullet;
    public GameObject laser;
    public Text Coord;

    void Start()
    {
        LaserShoot = LaserLeft;
    }

    void Update() {
        forceI = Input.GetAxis("Vertical");
        rotationI = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.forward * rotationI * Time.deltaTime * -rotationForce);

        //Стрельба
        if (Input.GetKeyDown("space"))
        {

            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet, 1.0f);
        }
        else if (Input.GetKeyDown("e") && LaserLeft > 0){

            GameObject newLaser = Instantiate(laser, transform.position, transform.rotation);
            newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * laserForce);
            LaserLeft--;
            Destroy(newLaser, 1.0f);
            if(LaserLeft < 3)
            {
                Reload();
            }
        }
        LaserTxt.text = "Laser: " + LaserLeft;
        AngleTxt.text = "Angle: " + transform.rotation.z;


        //Портал
        Vector2 newPos = transform.position;
        
        if(transform.position.y > Top){
            newPos.y = Bottom;
        }
        if (transform.position.y < Bottom){
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
        Coord.GetComponent<Text>().text = newPos.x + " : " + newPos.y;
    }

    void FixedUpdate() {
        rb.AddRelativeForce(Vector2.up * forceI);
    }

    void Reload()
    {
        reload = true;
        StartCoroutine(ReloadTimeYield());
    }

    IEnumerator ReloadTimeYield()
    {
        yield return new WaitForSeconds(ReloadTime);
        LaserLeft++;
        if (LaserLeft == LaserShoot)
        {
            reload = false;
        }
    }
}
