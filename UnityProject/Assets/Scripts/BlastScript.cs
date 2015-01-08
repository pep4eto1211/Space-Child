using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;

public class BlastScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        hideForceField();
	}

    private List<GameObject> objectsInHitZone = new List<GameObject>();
    public float HitForce;
    public GameObject forceField;
    public GameObject Player;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.name != "Terrain")
        {
            objectsInHitZone.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.name != "Terrain")
        {
            objectsInHitZone.Remove(col.gameObject);
        }
    }

    public void startBlastOff()
    {
        foreach (GameObject singleObject in objectsInHitZone)
        {
            Vector3 ForceDirection = singleObject.transform.position - transform.position;
            ForceDirection.Normalize();
            singleObject.rigidbody.AddForce(ForceDirection * HitForce * 10, ForceMode.Impulse);
        }
    }

    public void hideForceField()
    {
        forceField.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        if (Input.GetButton("Fire1") || Input.GetAxis("Trigger") < 0f)
        {
            if (Player.GetComponent<CharacterControl>().Energy > 99)
            {
                Player.GetComponent<Animator>().SetBool("IsBlastingOff", true);
                Player.SendMessage("updateEnergy", 0f);
            }
        }
        else
        {
            //forceField.gameObject.SetActive(false);
        }
	}
}
