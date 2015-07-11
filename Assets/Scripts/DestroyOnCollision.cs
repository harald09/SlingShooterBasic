using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
    public float veloThreshold = 5.0f;

    void OnCollisionEnter(Collision col)
    {
        if(col.relativeVelocity.magnitude > veloThreshold)
        {
            Destroy(this.gameObject);
        }  
    }
}
