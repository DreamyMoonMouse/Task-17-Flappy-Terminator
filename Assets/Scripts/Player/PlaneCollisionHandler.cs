using System;
using UnityEngine;
  

[RequireComponent(typeof(Plane))]
public class PlaneCollisionHandler : MonoBehaviour
{
   public event Action<IInteractable> CollisionDetected;
   
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.collider.TryGetComponent(out IInteractable interactable))
      {
         CollisionDetected?.Invoke(interactable);
      }
   }
}
