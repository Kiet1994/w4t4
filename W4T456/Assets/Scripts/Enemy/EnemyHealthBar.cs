using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private HealthEnemy enemyHealth;



    private void Update()
    {
        transform.localScale = new Vector3(enemyHealth.currentHealth * 0.5f / 3, transform.localScale.y);

    }
}
