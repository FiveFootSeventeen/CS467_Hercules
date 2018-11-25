using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave.asset", menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public int EnemyHealth;
    public int EnemyDamage;
    public int EnemyNumber;
    public int KillPoints;
    public int WavePoints;
}

