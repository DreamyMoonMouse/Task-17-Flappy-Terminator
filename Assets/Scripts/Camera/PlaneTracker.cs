using UnityEngine;

public class PlaneTracker : MonoBehaviour
{
   [SerializeField] private float _xOffset;
   [SerializeField] private Plane _plane;
   
   private void LateUpdate()
   {
       var position = transform.position;
       position.x = _plane.transform.position.x + _xOffset;
       transform.position = position;
   }
}
