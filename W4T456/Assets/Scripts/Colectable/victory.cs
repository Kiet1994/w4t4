using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour
{
    [SerializeField]
    private GameObject vic;
    [SerializeField]
    private GameObject player;
    
    private void Awake()
    {
             vic.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            vic.SetActive(true);
          
            player.SetActive(false);
        }
    }


}
