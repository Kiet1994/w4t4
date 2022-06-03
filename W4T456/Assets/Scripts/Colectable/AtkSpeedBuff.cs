using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpeedBuff : MonoBehaviour
{
    public float AttSpeed;

    private void OnTriggerEnter2D(Collider2D b)
    {
        if (b.tag == "Player")
        {
            b.GetComponent<PlayerAttack>().AddAtkSpd(AttSpeed);
            gameObject.SetActive(false); // t?t ??i t??ng
        }
    }
}
