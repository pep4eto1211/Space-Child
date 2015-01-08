using UnityEngine;
using System.Collections;

public class hideCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.showCursor = false;
        Screen.lockCursor = true;
	}

    private bool isPaused = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Cancel"))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                Screen.showCursor = true;
                Screen.lockCursor = false;
                isPaused = true;
                GameObject.Find("Camera").GetComponent<AudioListener>().enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                Screen.showCursor = false;
                Screen.lockCursor = true;
                isPaused = false;
                GameObject.Find("Camera").GetComponent<AudioListener>().enabled = true;
            }
        }
	}
}
