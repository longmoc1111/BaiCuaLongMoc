using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public int heal = 5;
    public HealthBar healthBar;
    public float healTime = 5f;
    public UnityEvent OnDeath;
    private bool ishealing = false;
    public Transform healPoss;
    public GameObject healing;
    private Animator healingAnimator;

   
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
        StartCoroutine(HealBar());
        healingAnimator = healing.GetComponent<Animator>();
    }
    private IEnumerator HealBar(){
        while(true){
            if(currentHealth < maxHealth && !ishealing){
                ishealing = true;
                yield return new WaitForSeconds(healTime);
                TriggerHealing();
                if(currentHealth < maxHealth){
                    currentHealth += heal;
                    if(currentHealth >= maxHealth){
                        currentHealth = maxHealth;
                    }
                    healthBar.UpdateBar(currentHealth, maxHealth);
                }
            ishealing = false;
            }
        yield return null;
        }
    }

    public void TakeDam(int damge)
    {
        currentHealth -= damge;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
        StopCoroutine(HealBar());
        StartCoroutine(HealBar());


    }

    public void Death()
    {
        Destroy(gameObject);
    }
    private void TriggerHealing(){
    // Đảm bảo healing được tạo tại vị trí healPoss
    GameObject healingInstance = Instantiate(healing, healPoss.position, Quaternion.identity);
    
    // Kiểm tra Animator trong prefab healing
    Animator healingAnimator = healingInstance.GetComponent<Animator>();
     healingAnimator.SetBool("isHealing", true);
    }

    
}
