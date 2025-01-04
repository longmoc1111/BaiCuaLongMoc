using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int mindamage;
    public int maxdamage;
    player playerSR;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
         
            playerSR = collision.GetComponent<player>();
            InvokeRepeating("TakeDamagePlayer", 0, 1.5f);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSR = null;
            CancelInvoke("TakeDamagePlayer");
        }

    }
    void TakeDamagePlayer()
    {
        int damage = UnityEngine.Random.Range(mindamage, maxdamage);
         if (playerSR != null)
    {
        playerSR.TakeDamage(damage);  // Giảm máu người chơi
    }
    }
}
