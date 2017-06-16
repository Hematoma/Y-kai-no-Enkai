using UnityEngine;
using System.Collections;

public class Boundary_Manager : MonoBehaviour
{
    private BoxCollider2D managerBox;
    private Transform player;
    public GameObject boundary;

    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        ManageBoundary();
    }

    void ManageBoundary()
    {
        
        if (managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x &&
            managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
            boundary.tag = "activeBoundary";
        } 
        else
        {
            boundary.SetActive(false);
            boundary.tag = "inactiveBoundary";
        }
    }
}