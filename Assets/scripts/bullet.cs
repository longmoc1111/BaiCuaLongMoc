using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   public int time = 3;
   public int damage = 20;
   void OnTriggerEnter2D(Collider2D hitInfo){
        monster1 monster = hitInfo.GetComponent<monster1>();
        if(monster != null){
         monster.TakeDamage(damage);
        }
        Destroy(gameObject);
   }
   void Start(){
      Destroy(gameObject,time);
   }
 
}
