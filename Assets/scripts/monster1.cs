using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class monster1 : MonoBehaviour
{
    //tạo 1 biến để lấy các thành phần transform của player
    public Transform player;
    //sử dụng để kiểm tra việc xoay
    public bool isFlipped = false;
    public int health = 100;
    public EnemySpawner enemyspawner;
    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void lockAtPlayer()
    {  
        //đặt giá trị rotation.z = 0 để monster k bị xoay 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        //kiểm tra xem vị trí của monster có bé hơn player theo trục x hay không vã đã xoay hay chưa
        if (transform.position.x < player.position.x && isFlipped)
        {
            //nếu có thì xoay hướng của monster
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

      public void SetEnemySpawner(EnemySpawner spawner)
    {
        enemyspawner = spawner; // Lưu đối tượng EnemySpawner
    }

    public void TakeDamage(int damage)
    {
        health -= damage;   
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (enemyspawner != null)
    {
        enemyspawner.OnEnemyDeath();
    }
    else
    {
        Debug.LogError("EnemySpawner is null in monster1!");
    }

    Destroy(gameObject);
    }
   
    
}

