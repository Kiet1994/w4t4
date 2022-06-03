using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
   [SerializeField] private float damage; // cài số damage gây ra
   [SerializeField] private float speed;
   [SerializeField] private float movementDistance; // khoảng cách di chuyển
   private bool movingLeft;
   private float leftEdge; //cạnh trái
   private float rightEdge;//cạnh phải
   

   private void Awake()
   {
      leftEdge = transform.position.x - movementDistance;
      rightEdge = transform.position.x + movementDistance;
      //print (movingLeft);  
   }
   
   private void Update()
   {
      if (movingLeft)// 1. F không thực hiện thực hiện cái else// 4. thực hiện khi T
      {
         if (transform.position.x > leftEdge) // vị trí lớn hơn cạnh trái
         {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); // di chuyển sang trái
         }
         else
            movingLeft = false; // 5. Thực hiện song lại chuyển thành F, thực hiện cái else dười.
      } 
      else// 2. thực hiện cái này. 6.
      {
         if(transform.position.x <  rightEdge)
         {
           transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
         } 
         else
            movingLeft = true; // 3. chuyển thành True thì thựng hiện cái if đầu tiên
        
      }
      //print (movingLeft);  
   }
      
   private void OnTriggerEnter2D(Collider2D w) // phát hiện ra chạm cho xuyên qua:
   {
      if(w.tag == "Player") // nếu chạm Player
      {
         w.GetComponent<Health>().TakeDamage(damage); //
      }
   }
}
