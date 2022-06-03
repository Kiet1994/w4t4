using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthColection : MonoBehaviour
{
    public float healthValue;

    private void OnTriggerEnter2D(Collider2D a)
    {
        if (a.tag == "Player")
        {
            a.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false); // t?t ??i t??ng
        }
    }
}
