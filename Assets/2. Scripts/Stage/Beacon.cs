using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public float size;
    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(transform.position,size*Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
        
    }
}
