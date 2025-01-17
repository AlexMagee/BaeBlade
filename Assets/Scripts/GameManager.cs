using UnityEngine;

public class GameManager : MonoBehaviour
{

    private BossCore currentBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBoss = GameObject.FindWithTag("MainBoss").GetComponent<BossCore>();
        if(currentBoss)
        {
            Debug.Log("Boss Found");
        }
        else
        {
            Debug.Log("No Boss Found");
        }
    }

    void OnDrawGizmos()
    {
    // Draw a semitransparent green cube at the transforms position
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    } 

    public void BossIsDead()
    {
        Debug.Log("Win");
    }
}
