using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveInput;
    private Animator run;
    public SpriteRenderer charactorSR;
    public playerHealth playerHealth;


    // Start is called before the first frame update
   void Start(){
        run = GetComponentInChildren <Animator>();
   }

    // Update is called once per frame
    void Update()
    {

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        run.SetFloat("speed",moveInput.sqrMagnitude);
        // Rotate();

        if(moveInput.x > 0){
            charactorSR.transform.localScale = new Vector3(1,1,0);
        }else if(moveInput.x < 0){
            charactorSR.transform.localScale = new Vector3(-1,1,0);
        }
    }
    public void TakeDamage(int damage){
        playerHealth.TakeDam(damage);
    }
}
