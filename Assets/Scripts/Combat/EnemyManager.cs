using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
public GameObject[] Enemies;
public EnemyWave[] Waves;
public Events.EventIntegerEvent OnEnemyKilled;
public Events.EventIntegerEvent OnWaveComplete;


public UnityEvent OnWaveSpawn;
public UnityEvent OnWavesDone;

private int currentWave = 0;
private int activeEnemies;

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

    for (int i = 0; i <= Waves[currentWave].EnemyNumber - 1; i++)
    {
        Spawn spawnPoint = selectRandomSpawn();
        GameObject enemy = Instantiate(selectRandomEnemy(), spawnPoint.transform.position, Quaternion.identity);
        enemy.GetComponent<NPCController>().waypointList = findClosestWayPoint(enemy.transform);

        CharacterStats stats = enemy.GetComponent<CharacterStats>();
        EnemyWave cur = Waves[currentWave];

        stats.SetInitialHP(cur.EnemyHealth);
        stats.SetInitialDamage(cur.EnemyDamage);

    }
}
    public void OnEnemyDeath()
    {
        //Play death sound

        EnemyWave cur = Waves[currentWave];

        activeEnemies -= 1;
        OnEnemyKilled.Invoke(cur.KillPoints);
        if (activeEnemies == 0)
        {
            OnWaveComplete.Invoke(cur.WavePoints);
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

    private Transform[] findClosestWayPoint(Transform enemyTransform)
    {
        Vector3 enemyPos = enemyTransform.position;

        Waypoint closestPoint =
            FindObjectsOfType<Waypoint>().OrderBy(
                w => (w.transform.position - enemyPos).sqrMagnitude).First();

        Transform parent = closestPoint.transform.parent;

        Transform[] all = parent.GetComponentsInChildren<Transform>();

        var transforms = 
            from t in all
            where t != parent
            select t;

        return transforms.ToArray();
    }
}
