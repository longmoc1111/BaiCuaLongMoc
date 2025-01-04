using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public GameObject bullet;
    //định vị nơi tạo ra đạn
    public Transform firePos;

    //quản lý tốc độ bắn
    public float TimeBtwFire = 0.2f;
    //lực viên đạn khi rời khỏi súng

    private float timeBtwFire;
    public float bulletForce;
   void Update(){
        RotateGun(); 
          timeBtwFire  -= Time.deltaTime;
        //nếu người chơi ấn chuột 
        if(Input.GetMouseButton(0) && timeBtwFire < 0){
            FireBullet();
        }
   }
    void RotateGun(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0,0,angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270){
            transform.localScale = new Vector3(1,-1,0);
        }else{
            transform.localScale = new Vector3(1,1,0);
        }

   }

    void FireBullet(){
        timeBtwFire = TimeBtwFire;
        //tạo 1 bản sao của đối tượng firebullet giá trị 1: đối tượng cần sao chep ; 2: vị trí vector3, 3: góc quay : identity là k quay
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
