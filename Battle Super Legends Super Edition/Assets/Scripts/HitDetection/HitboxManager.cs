using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {
    
    BoxCollider2D hitBox;
    float         xoffset;
    Animator      animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        if (CombinedMove.Cm.moveDirection == 1)
        {
            xoffset = .64f;
        } else if (CombinedMove.Cm.moveDirection == -1) {
            xoffset = -.64f;
        }
        addBoxCollider2D("hitbox", new Vector2(.64f, 1.28f), new Vector2(xoffset, 0), true, false);
    }

    void Update()
    {
        
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

    private void addBoxCollider2D(string name, Vector2 size, Vector2 offset, bool boxType, bool enabled)
    {
        GameObject childbox = new GameObject(name);

        childbox.transform.position = transform.position;
        childbox.transform.SetParent(boxType ? transform.GetChild(1) : transform.GetChild(2));
        
        childbox.AddComponent<BoxCollider2D>();
        childbox.GetComponent<BoxCollider2D>().size = size;
        childbox.GetComponent<BoxCollider2D>().offset = offset;
        childbox.GetComponent<BoxCollider2D>().enabled = enabled;
        if (!boxType)
            childbox.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
