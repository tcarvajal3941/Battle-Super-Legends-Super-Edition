using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitstunData : MonoBehaviour {

	float[,] hitstunData = new float[6, 13];

	// Use this for initialization
	void Start () {
		hitstunData[0, 0] = 8;//hitstop
		hitstunData[0, 1] = 0;//ch hitstop
		hitstunData[0, 2] = 10;//standing hitstun
		hitstunData[0, 3] = 12;//crouching hitstun
		hitstunData[0, 4] = 14;//ch hitstun
		hitstunData[0, 5] = 13;//fc hitstun
		hitstunData[0, 6] = 12;//air untech
		hitstunData[0, 7] = 23;//ch air untech
		hitstunData[0, 8] = 9;//blockstun
		hitstunData[0, 9] = 11;//air blockstun
		hitstunData[0, 10] = 6;//ex block stun
		hitstunData[0, 11] = 5;//air ex block stun
		hitstunData[0, 12] = .75f;//p2 scaling

		hitstunData[1, 0] = 9;//hitstop
		hitstunData[1, 1] = 0;//ch hitstop
		hitstunData[1, 2] = 12;//standing hitstun
		hitstunData[1, 3] = 14;//crouching hitstun
		hitstunData[1, 4] = 16;//ch hitstun
		hitstunData[1, 5] = 15;//fc hitstun
		hitstunData[1, 6] = 12;//air untech
		hitstunData[1, 7] = 23;//ch air untech
		hitstunData[1, 8] = 11;//blockstun
		hitstunData[1, 9] = 13;//air blockstun
		hitstunData[1, 10] = 8;//ex block stun
		hitstunData[1, 11] = 7;//air ex block stun
		hitstunData[1, 12] = .8f;//p2 scaling

		hitstunData[2, 0] = 10;//hitstop
		hitstunData[2, 1] = 1;//ch hitstop
		hitstunData[2, 2] = 14;//standing hitstun
		hitstunData[2, 3] = 16;//crouching hitstun
		hitstunData[2, 4] = 18;//ch hitstun
		hitstunData[2, 5] = 17;//fc hitstun
		hitstunData[2, 6] = 14;//air untech
		hitstunData[2, 7] = 26;//ch air untech
		hitstunData[2, 8] = 13;//blockstun
		hitstunData[2, 9] = 15;//air blockstun
		hitstunData[2, 10] = 10;//ex block stun
		hitstunData[2, 11] = 9;//air ex block stun
		hitstunData[2, 12] = .85f;//p2 scaling

		hitstunData[3, 0] = 11;//hitstop
		hitstunData[3, 1] = 2;//ch hitstop
		hitstunData[3, 2] = 17;//standing hitstun
		hitstunData[3, 3] = 19;//crouching hitstun
		hitstunData[3, 4] = 22;//ch hitstun
		hitstunData[3, 5] = 20;//fc hitstun
		hitstunData[3, 6] = 17;//air untech
		hitstunData[3, 7] = 31;//ch air untech
		hitstunData[3, 8] = 16;//blockstun
		hitstunData[3, 9] = 18;//air blockstun
		hitstunData[3, 10] = 13;//ex block stun
		hitstunData[3, 11] = 12;//air ex block stun
		hitstunData[3, 12] = .89f;//p2 scaling

		hitstunData[4, 0] = 12;//hitstop
		hitstunData[4, 1] = 5;//ch hitstop
		hitstunData[4, 2] = 19;//standing hitstun
		hitstunData[4, 3] = 21;//crouching hitstun
		hitstunData[4, 4] = 24;//ch hitstun
		hitstunData[4, 5] = 22;//fc hitstun
		hitstunData[4, 6] = 19;//air untech
		hitstunData[4, 7] = 34;//ch air untech
		hitstunData[4, 8] = 18;//blockstun
		hitstunData[4, 9] = 20;//air blockstun
		hitstunData[4, 10] = 15;//ex block stun
		hitstunData[4, 11] = 14;//air ex block stun
		hitstunData[4, 12] = .92f;//p2 scaling

		hitstunData[5, 0] = 13;//hitstop
		hitstunData[5, 1] = 8;//ch hitstop
		hitstunData[5, 2] = 21;//standing hitstun
		hitstunData[5, 3] = 23;//crouching hitstun
		hitstunData[5, 4] = 27;//ch hitstun
		hitstunData[5, 5] = 24;//fc hitstun
		hitstunData[5, 6] = 21;//air untech
		hitstunData[5, 7] = 37;//ch air untech
		hitstunData[5, 8] = 20;//blockstun
		hitstunData[5, 9] = 22;//air blockstun
		hitstunData[5, 10] = 17;//ex block stun
		hitstunData[5, 11] = 16;//air ex block stun
		hitstunData[5, 12] = .94f;//p2 scaling
	}
}
