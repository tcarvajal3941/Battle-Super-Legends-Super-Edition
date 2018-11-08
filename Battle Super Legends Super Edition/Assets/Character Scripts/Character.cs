using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	public int health { get; set; }
	public float forwardSpeed { get; set; }
	public float backwardSpeed { get; set; }
	public string characterName { get; set; }

	void Start () 
	{
		//check if any of the properties are null. If they are, throw a Debug.LogError
		//move data here?

		var moveList = new List<hurtboxData>();
	}
	public class hitboxData
	{
		public string moveID { get; set; }           // searchable move ID
		public ArrayList hitbox { get; set; }        // detection box for HITTING OPPONENT (ID, x offset, y offset, x size, y size, duration)
		public int damage { get; set; }              // damage
		public float meterMultiplier { get; set; }   // meter gain multiplier
		public float chipMultiplier { get; set; }    // damage multiplier on block
    	public int blockAttribute { get; set; }      // how to block (Mid, High, Low, Throw, Airthrow)
		public int moveAttribute { get; set; }       // move attribute (H, B, F, T, P)
		public float p1 { get; set; }                // starter damage scaling
		public int level { get; set; }               // hitstun data
		public int hitEffect { get; set; }           // hit effect (none, Soft KD, Hard KD, Wallbounce, Groundbounce)
		public int airHitEffect { get; set; }        // hit effect vs. airial opponent
		public int counterHitEffect { get; set; }    // ground counter hit effect
		public int airCounterHitEffect { get; set; } // air counter hit effect
		public float groundKB { get; set; }          // knockback vs. ground
		public float airKB { get; set; }             // knockback vs. air
		public int groundAngle { get; set; }         // launch angle vs. ground
		public int airAngle { get; set; }            // launch angle vs. air
	}
	public class hurtboxData
	{
		public string moveID { get; set; }             // searchable move ID
    	public int startup { get; set; }               // startup frames
    	public int active { get; set; }                // active frames
    	public int recovery { get; set; }              // recovery frames
    	public int total { get; set; }                 // total frames (startup + active + recovery)
		public ArrayList hurtbox { get; set; }         // detection box for GETTING HIT
		public ArrayList hitCancels { get; set; }      // cancels on hit
		public ArrayList blockCancels { get; set; }    // cancels on block
		public ArrayList whiffCancels { get; set; }    // cancels on whiff
		public ArrayList attributeInvuln { get; set; } // invulnerability to attributes
		public ArrayList movement { get; set; }        // x/y movement
	}
}