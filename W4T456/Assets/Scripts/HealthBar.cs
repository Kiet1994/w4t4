using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    

    private void Update()
    {
        transform.localScale = new Vector3( playerHealth.currentHealth * 2.5f / 10, transform.localScale.y);
        
    }
}
