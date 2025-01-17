using UnityEngine;

public class Spawner : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(transform.position + new Vector3(0, 0.5f, 0), new Vector3(1, 1, 1));
    } 
}
