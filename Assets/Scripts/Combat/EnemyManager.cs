using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public EnemyWave[] Waves;
    

    public UnityEvent OnWaveSpawn;
    public UnityEvent OnWavesDone;

    private int currentWave = 0;
    private int activeEnemies;

    public int deathSFX;

    private Spawn[] spawnPoints;

void Start()
{
    spawnPoints = FindObjectsOfType<Spawn>();
    SpawnWave();
}

public void SpawnWave()
{
    if(Waves.Length - 1 < currentWave)
    {
        OnWavesDone.Invoke();
        return;
    }

    if (currentWave > 0)
    {
        //TODO add sound manager
        OnWaveSpawn.Invoke();
    }
    activeEnemies = Waves[currentWave].EnemyNumber;
        print("active enemies: " + activeEnemies);

    for (int i = 0; i <= Waves[currentWave].EnemyNumber - 1; i++)
    {
            print("spawning");
        Spawn spawnPoint = selectRandomSpawn();
        GameObject enemy = Instantiate(selectRandomEnemy(), spawnPoint.transform.position, Quaternion.identity);
        enemy.GetComponent<NPCController>().currentWaypoint = findClosestWayPoint(enemy.transform);

        CharacterStats stats = enemy.GetComponent<CharacterStats>();
        EnemyWave cur = Waves[currentWave];

        stats.SetInitialHP(cur.EnemyHealth);
        stats.SetInitialDamage(cur.EnemyDamage);

    }
}
    public void OnEnemyDeath()
    {
        //Play death sound
        AudioManager.Instance.PlaySFX(deathSFX);
        EnemyWave cur = Waves[currentWave];

        activeEnemies -= 1;
               
        if (activeEnemies == 0)
        {
            
            currentWave += 1;
            SpawnWave();
        }
    }

    private GameObject selectRandomEnemy()
    {
        int enemyIndex = Random.Range(0, Enemies.Length);
        return Enemies[enemyIndex];
    }

    private Spawn selectRandomSpawn()
    {
        int randSpawn = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randSpawn];
    }

    private Waypoint findClosestWayPoint(Transform enemyTransform)
    {
        Vector3 enemyPos = enemyTransform.position;

        Waypoint closestPoint =
            FindObjectsOfType<Waypoint>().OrderBy(
                w => (w.transform.position - enemyPos).sqrMagnitude).First();

        return closestPoint;
    }
}
