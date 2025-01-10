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
    private bool ishealing = false;
    public Transform healPoss;
    public GameObject healing; 
    private Animator healingAnimator;
    private Animator playerDie;
    private GameObject healingInstance; // Biến lưu đối tượng healing

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
        StartCoroutine(HealBar());
        playerDie = transform.Find("charactor").GetComponent<Animator>();
    }

    private IEnumerator HealBar()
    {
        while (true)
        {
            if (currentHealth < maxHealth && !ishealing)
            {
                ishealing = true;
                yield return new WaitForSeconds(healTime);
                if (currentHealth < maxHealth)
                {
                    StartHealing();
                    currentHealth += heal;
                    Debug.Log("Current Health: " + currentHealth);   
                    if (currentHealth >= maxHealth)
                    {  
                        Debug.Log("Reached max health");
                        StopHealing();
                        currentHealth = maxHealth;
                    }
                    healthBar.UpdateBar(currentHealth, maxHealth);
                }
                ishealing = false;
            }
            yield return null;
        }
    }

    public void TakeDam(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
        StopCoroutine(HealBar());
        StartCoroutine(HealBar());
    }

    public void Death()
    {
        // playerDie.SetTrigger("die");

        // Animator[] animators = GetComponentsInChildren<Animator>();    
        // foreach (Animator animator in animators)
        // {
        //     animator.speed = 0; // Dừng tất cả các hoạt ảnh
        // }
    }
  
    private void StartHealing()
    {
        // Nếu healingInstance chưa được tạo, tạo mới healing
        if (healingInstance == null)
        {
            healingInstance = Instantiate(healing, healPoss.position, Quaternion.identity);
            healingInstance.transform.SetParent(transform);
            healingAnimator = healingInstance.GetComponent<Animator>(); // Lưu animator cho đối tượng healing
            healingAnimator.SetBool("isHealing", true);
        }
    }

    private void StopHealing()
    {
        if (healingAnimator != null)
        {
            healingAnimator.SetBool("isHealing", false);
            Destroy(healingInstance, 1f); // Thời gian chờ để hủy healingInstance sau khi dừng hoạt ảnh
            healingInstance = null; // Reset lại healingInstance
        }
        else
        {
            Debug.LogError("healingAnimator is null, cannot stop healing.");
        }
    }
}
