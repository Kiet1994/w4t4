using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown; // thời gian hồi
    [SerializeField] private Transform firePoint; //điểm bắn
    [SerializeField] private GameObject[] arrows; // các đạn
    private float cooldownTimer; //bộ đếm thời gian hồi chiêu

    private void Attack()
    {
        cooldownTimer = 0;

        arrows[FindArrow()].transform.position = firePoint.position; //thiết lập vị trí bắn đạn
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();  //
    }
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer +=Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();

    }
       

}
