using UnityEngine;
using System.Collections;

public class Collide_e : MonoBehaviour {

    private SpriteRenderer MySprite;
	void Start ()
    {
        MySprite = GetComponent<SpriteRenderer>();  
	}
	
    void OnTriggerEnter2D (Collider2D Col)
    {
        if (Col.tag == "Player")
        {
            MySprite.enabled = true;
        }
    }

    void OnTriggerExit2D (Collider2D Col)
    {
        if (Col.tag == "Player")
        {
            MySprite.enabled = false;
        }
    }
}
