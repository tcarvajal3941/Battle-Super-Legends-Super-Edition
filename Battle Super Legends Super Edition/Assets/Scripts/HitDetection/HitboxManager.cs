using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {
    
    public static CombinedMove Cm;
    public BoxCollider2D hitBox;
    GameObject Player;
    Animator   animator;
    float      xoffset;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        hitBox.enabled = false;

    }

    void Update()
    {
        if (CombinedMove.facingRight)
        {
            xoffset = .64f;
        } else if (!CombinedMove.facingRight) {
            xoffset = -.64f;
        }
        
        hitBox.transform.position = transform.position;
        hitBox.GetComponent<BoxCollider2D>().size = new Vector2(.64f, .64f);
        hitBox.GetComponent<BoxCollider2D>().offset = new Vector2(xoffset, 0);
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Detected");
    }

    public void activate()
    {
        hitBox.enabled = true;
        Debug.Log("Hitbox Activated");
    }
    public void deactivate()
    {
        hitBox.enabled = false;
        Debug.Log("Hitbox Deactivated");
    }
    public void end()
    {
        animator.SetInteger("action", 0);
        Debug.Log("Action set to 0");
    }
}
