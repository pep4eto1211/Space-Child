using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public float moveSpeed;

    public float maxSpeed;

    public float jumpForce;

    public float Vitals;

    public float Suit;

    public float Energy;

    public float energyRecharge;

    public float rechargeTime;

    private bool isJumping = false;

    public GameObject forceField;

    public GameObject fieldCollider;

    private void updateVitals(float newVitals)
    {
        Vitals = newVitals;
        GameObject.Find("Canvas").GetComponent<updateBar>().SendMessage("updateVitalsBar", newVitals);
    }

    private void updateSuit(float newSuit)
    {
        Suit = newSuit;
        GameObject.Find("Canvas").GetComponent<updateBar>().SendMessage("updateSuitBar", newSuit);
    }

    private void updateEnergy(float newEnergy)
    {
        Energy = newEnergy;
        GameObject.Find("Canvas").SendMessage("updateEnergy", newEnergy);
    }

    private void chargeEnergy()
    {
        if (Energy < 100)
        {
            updateEnergy(Energy += energyRecharge);
        }
        else if (Energy > 100)
        {
            updateEnergy(100);
        }
    }
	
    // Use this for initialization
	void Awake () 
    {
        InvokeRepeating("chargeEnergy", rechargeTime, rechargeTime);
	}

    void OnCollisionEnter(Collision col)
    {
        isJumping = false;
    }

    public void showField()
    {
        forceField.gameObject.SetActive(true);
        fieldCollider.SendMessage("startBlastOff");
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(Horizontal * moveSpeed, 0.0f, Vertical * moveSpeed);
        Vector3 maxVelocity = new Vector3(maxSpeed, 0.0f, maxSpeed);
        if ((Mathf.Abs(rigidbody.velocity.x) < maxVelocity.x) && (Mathf.Abs(rigidbody.velocity.z) < maxVelocity.z))
        {
            transform.rigidbody.AddRelativeForce(moveDirection);   
        }
        Animator playerAnimator = this.GetComponent<Animator>();
        AudioSource playerAudioSource = this.GetComponent<AudioSource>();
        if ((moveDirection == Vector3.zero) && !isJumping)
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);
            playerAnimator.SetBool("IsWalking", false);
            playerAudioSource.mute = true;
        }
        else
        {
            playerAnimator.SetBool("IsWalking", true);
            playerAudioSource.mute = false;
        }
        if (Input.GetButton("Jump"))
        {
            if (!isJumping)
            {
                isJumping = true;
                transform.rigidbody.AddForce(Vector3.up * jumpForce * 100);
            }
        }
	}
}
