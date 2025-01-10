    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class monster1_run : StateMachineBehaviour
    {
        //khoảng cánh nguy hiểm có thể bị monster tấn công
        public float attackranger = 1f; 
        Transform player;
        public float speed = 3.0f;
        Rigidbody2D rb;
        monster1 monster1;
        //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        monster1 = animator.GetComponent<monster1>();
        }

        //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            monster1.lockAtPlayer();
            Vector2 target = new Vector2(player.position.x, player.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target,speed * Time.deltaTime);
            rb.MovePosition(newPos);

            // kiểm tra khoảng cách giữa monsters và player
            if(Vector2.Distance(player.position, rb.position) <= attackranger/3.0f){
                    animator.SetTrigger("attack");
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        animator.ResetTrigger("attack");
        }


    }
