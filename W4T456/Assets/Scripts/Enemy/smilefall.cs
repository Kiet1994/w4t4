using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smilefall : MonoBehaviour
{
    public HealthEnemy smileParent;
    

    public GameObject[] smile;
    private void Start()
    {
        smile[1].SetActive(false);
        smile[0].SetActive(false);


    }

    private void Update()

    {
        if (smileParent.currentHealth == 0)
        {
            smile[1].SetActive(true);
            smile[0].SetActive(true);
            if (smile[0].GetComponent<HealthEnemy>().currentHealth == 0)
            {
                smile[0].SetActive(false);
            } if (smile[1].GetComponent<HealthEnemy>().currentHealth == 0)
            {
                smile[1].SetActive(false);
            }
        }
    }
}
