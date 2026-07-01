using UnityEngine;

public class player_reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < pos)
        {
           player.transform.position = transform.position;
        }
    }
}
