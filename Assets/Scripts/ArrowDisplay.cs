using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDisplay : MonoBehaviour
{
   Vector3 baseScale;
   private void Start()
   {
      baseScale = transform.localScale;
   }
   public void ShowDirection(Vector2 direction, float throwForce)
   {
      transform.localScale = baseScale * throwForce;
      Vector3 dir = new Vector3(direction.x , 0, direction.y);
      Quaternion look = Quaternion.LookRotation(dir, Vector3.up);
      transform.localRotation = Quaternion.RotateTowards(transform.localRotation,look,500 * Time.deltaTime);
   }

   public void DisableArrow()
   {
     
   }
}
