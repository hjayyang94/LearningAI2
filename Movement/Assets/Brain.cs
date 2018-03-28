using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class Brain : MonoBehaviour {

    public int DNALength = 1;
    public float timeAlive;
    public float distanceTraveled = 0;
    public DNA dna;

    private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private Vector3 lastPosition;
    private bool m_Jump;
    bool alive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        dna = new DNA(DNALength, 6);
        m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
    }

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (dna.GetGene(0) == 0) v = 1;
        else if (dna.GetGene(0) == 1) v = -1;
        else if (dna.GetGene(0) == 2) h = -1;
        else if (dna.GetGene(0) == 3) h = 1;
        else if (dna.GetGene(0) == 4) m_Jump = true;
        else if (dna.GetGene(0) == 5) crouch = true;

        m_Move = v * Vector3.forward + h * Vector3.right;
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;

        if (alive)
        {
            timeAlive += Time.deltaTime;
            distanceTraveled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

        }

    }
}
