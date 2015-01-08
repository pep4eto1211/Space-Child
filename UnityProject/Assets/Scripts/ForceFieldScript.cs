using UnityEngine;
using System.Collections;

public class ForceFieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private bool hideIt = false;
    public GameObject Player;

    public void destroy()
    {
        hideIt = true;
    }

    public void resetBool()
    {
        
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (hideIt && (!Input.GetButton("Fire1") && !(Input.GetAxis("Trigger") < 0f)))
        {
            hideIt = false;
            this.gameObject.SetActive(false);
            Player.GetComponent<Animator>().SetBool("IsBlastingOff", false);
        }
	}
}
