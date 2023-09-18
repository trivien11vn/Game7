using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPos;
    public float minTime = 0.2f;
    public float bulletForce;
    private float timeFire;
    // Update is called once per frame
    void Update()
    {
        RotateGun();
        timeFire -= Time.deltaTime;
        if(Input.GetMouseButton(0) && timeFire < 0){
            FireBullet();
        }
    }
    void RotateGun(){
        // Input.mousePosition: vi tri con chuot tren man hinh
        // Player nam tren worldpoint.
        // Chuyen vi tri tren man hinh -> tren worldpoint
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0,0,angle);
        transform.rotation = rotation;
        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270){
            transform.localScale = new Vector3(0.5f,-0.4f,0.4f);
        }
        else{
            transform.localScale = new Vector3(0.5f,0.4f,0.4f);
        }
    }
    void FireBullet(){
        timeFire = minTime;
        GameObject bulletInstance = Instantiate(bullet, spawnPos.position, Quaternion.identity);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
