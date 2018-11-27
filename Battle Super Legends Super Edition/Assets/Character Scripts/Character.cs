using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	/*
	public static Character Ct;
	public int health { get; set; }
	public float forwardSpeed { get; set; }
	public float backwardSpeed { get; set; }
	public string characterName { get; set; }

	public class move
	{
		
	}

	public class hitbox
	{
		public int hitboxID { get; set; }
		public float xSize { get; set; }
		public float ySize { get; set; }
		public float xPos { get; set; }
		public float yPos { get; set; }
		public int delay { get; set; }
		public int duration { get; set; }

		/*
		public hitbox (int hitboxID, float xSize, float ySize, float xPos, float yPos,
					   int delay, int duration)
		{
			this.hitboxID = hitboxID;
			this.xSize = xSize;
			this.ySize = ySize;
			this.xPos = xPos;
			this.yPos = yPos;
			this.delay = delay;
			this.duration = duration;
		}
		*/
	}

	public class hurtbox
	{
		public int hitboxID { get; set; }
		public float xSize { get; set; }
		public float ySize { get; set; }
		public float xPos { get; set; }
		public float yPos { get; set; }
		public int delay { get; set; }
		public int duration { get; set; }

		/*
		public hurtbox (int hitboxID, float xSize, float ySize, float xPos, float yPos,
					   int delay, int duration)
		{
			this.hitboxID = hitboxID;
			this.xSize = xSize;
			this.ySize = ySize;
			this.xPos = xPos;
			this.yPos = yPos;
			this.delay = delay;
			this.duration = duration;
		}
		*/
	}

	public class hitboxData
	{
		public int moveID { get; set; }              // searchable move ID
		public List<hitbox>[] hitbox { get; set; }   // detection box for HITTING OPPONENT (ID, x offset, y offset, x size, y size, duration)
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

		/*
		public hitboxData (int moveID, int damage, float meterMultiplier,
		                   float chipMultiplier, int blockAttribute, int moveAttribute, 
						   float p1, int level, int hitEffect, int airHitEffect, int counterHitEffect,
						   float groundKB, float airKB, int groundAngle, int airAngle)
		{
			this.moveID = moveID;
			this.hitbox = hitbox;
			this.damage = damage;
			this.meterMultiplier = meterMultiplier;
			this.chipMultiplier = chipMultiplier;
			this.blockAttribute = blockAttribute;
			this.moveAttribute = moveAttribute;
			this.p1 = p1;
			this.level = level;
			this.hitEffect = hitEffect;
			this.airHitEffect = airHitEffect;
			this.counterHitEffect = counterHitEffect;
			this.airCounterHitEffect = airCounterHitEffect;
			this.groundKB = groundKB;
			this.airKB = airKB;
			this.groundAngle = groundAngle;
			this.airAngle = airAngle;
		}
		*/
	}

	public class hurtboxData
	{
		public int moveID { get; set; }                // searchable move ID
    	public int startup { get; set; }               // startup frames
    	public int active { get; set; }                // active frames
    	public int recovery { get; set; }              // recovery frames
    	public int total { get; set; }                 // total frames (startup + active + recovery)
		public ArrayList hurtbox { get; set; }         // detection box for GETTING HIT (ID, x offset, y offset, x size, y size, start delay, duration)
		public ArrayList hitCancels { get; set; }      // cancels on hit
		public ArrayList blockCancels { get; set; }    // cancels on block
		public ArrayList whiffCancels { get; set; }    // cancels on whiff
		public ArrayList attributeInvuln { get; set; } // invulnerability to attributes
		public ArrayList movement { get; set; }        // x/y movement

		/*
		public hurtboxData (int moveID, int startup, int active, int recovery, int total,
		                    ArrayList hurtbox, ArrayList hitCancels, ArrayList blockCancels,
							ArrayList whiffCancels, ArrayList attributeInvuln, ArrayList movement)
		{
			this.moveID = moveID;
    		this.startup = startup;
    		this.active = active;
    		this.recovery = recovery;
    		this.total = this.startup + this.active + this.recovery;
			this.hurtbox = hurtbox;
			this.hitCancels = hitCancels;
			this.blockCancels = blockCancels;
			this.whiffCancels = whiffCancels;
			this.attributeInvuln = attributeInvuln;
			this.movement = movement;
		}
		*/
	}

	void Start () 
	{
		//check if any of the properties are null. If they are, throw a Debug.LogError
		//move data here?

		var moveList = new List<hurtboxData>();
		hurtboxData a5 = new hurtboxData(
			hurtboxData.moveID = 1, 
			hurtboxData.startup = 5, 
			hurtboxData.active = 2, 
			hurtboxData.recovery = 11, 
			hurtboxData.total = 19, 
			hurtboxData.hurtbox.Add(0, 5, 5, 6, 6, 0, 5),
			hurtboxData.hitCancels.Add(0),
			hurtboxData.blockCancels.Add(0),
			hurtboxData.whiffCancels.Add(0),
			hurtboxData.attributeInvuln.Add(-1),
			hurtboxData.movement.Add(0)
			);
		moveList.Add(a5);
	}
	*/
}