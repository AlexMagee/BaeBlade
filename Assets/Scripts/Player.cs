using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private Stat spin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        spin.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spin.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            spin.CurrentVal += 10;
        }
    }
}
