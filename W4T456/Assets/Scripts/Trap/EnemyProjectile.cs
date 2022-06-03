using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float movementSpeed;
    private float lifetime;

    public void ActivateProjectile()  // đạn hoạt động
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        movementSpeed = speed * Time.deltaTime;
        transform.Translate(0, movementSpeed, 0);
        
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D vacham)
    {
       base.OnTriggerEnter2D(vacham); // không thừa kế thành phần OnTriggerEnter2D của EnemyDamage
       gameObject.SetActive(false); 
    }
}
