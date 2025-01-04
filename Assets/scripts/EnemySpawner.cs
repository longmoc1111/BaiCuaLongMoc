using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minimumSpawner;
    [SerializeField]
    private float maximumSpawner;
    [SerializeField]
    private int phase1MaxEnemy = 5;
    [SerializeField]
    private int phase2MaxEnemy = 10;
    [SerializeField]

    private int phase3MaxEnemy = 20;
    [SerializeField]
    private float phase1Duration = 60f;
    [SerializeField]
    private float phase2Duration = 120f;
    [SerializeField]
    private float phase3Duration = 600f;
    private float timeUnlSpawner;
    private float countEnemy = 0f;
    
    //thoi gian troi qua
    private float elapSedTime;
    void Start()
    {
        SetTimeUnitilSpawner();
    }
    void Update()
    {
        
        elapSedTime += Time.deltaTime;
        timeUnlSpawner -= Time.deltaTime;
        int currentPhase = GetCurrentPhase();
        int maxEnemiesInPhase = GetMaxEnemyForPhase(currentPhase);
        if (timeUnlSpawner <= 0 && countEnemy < maxEnemiesInPhase) 
        {
            SpawnEnemy(); // Tạo quái vật mới
            SetTimeUnitilSpawner();
            countEnemy++;
            Debug.Log(countEnemy);
        }

    }
    private void SpawnEnemy()
    {
        // Tạo quái vật từ prefab
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        // Gọi phương thức SetEnemySpawner từ monster1 để truyền thông tin về EnemySpawner (nếu cần)
        monster1 monsterScript = enemy.GetComponent<monster1>();
        if (monsterScript != null)
        {
            monsterScript.SetEnemySpawner(this); // Truyền EnemySpawner vào monster1
        }
    }
    public void OnEnemyDeath(){
        countEnemy--;
    }
    private void SetTimeUnitilSpawner()
    {
        timeUnlSpawner = Random.Range(minimumSpawner, maximumSpawner);
    }

    private int GetCurrentPhase()
    {
        if (elapSedTime <= phase1Duration){
            return 1;
        }else if(elapSedTime <= phase2Duration){
            return 2;
        }else if(elapSedTime <= phase3Duration){
            return 3;
        }
        return 0;
    }

    private int GetMaxEnemyForPhase(int phase){
        switch(phase){
            case 1:
                return phase1MaxEnemy;
            case 2:
                return phase2MaxEnemy;
            case 3:
                return phase3MaxEnemy;
            default:
                return 0;
        }
    }
}
