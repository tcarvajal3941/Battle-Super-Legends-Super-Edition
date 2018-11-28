using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {

    //set in editor
    public BoxCollider2D attackbox;
 
    //used for organization
    private BoxCollider2D[] colliders;
 
    //collider on this game object
    private BoxCollider2D localCollider;
 
    public enum hitBoxes
    {
        attackbox,
        clear
    }
     
    void Start()
    {
        //set hitbox array
        colliders = new BoxCollider2D[]{attackbox};
 
        //create hitbox
        localCollider = gameObject.AddComponent<BoxCollider2D>();
        localCollider.isTrigger = true;//set as trigger so it doesn't collide with environment
     }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collider hit something!");
    }
 
    public void setHitBox(hitBoxes val)
    {
        if(val != hitBoxes.clear)
        {
            //localCollider.SetPath(0, colliders[(int)val].GetPath(0));
			localCollider.enabled = true;
            return;
        }
     }
}
