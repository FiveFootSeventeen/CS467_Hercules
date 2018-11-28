using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave.asset", menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public int EnemyNumber;
    public GameObject[] Enemies;
}

