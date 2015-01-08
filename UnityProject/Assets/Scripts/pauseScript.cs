using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour {

    public GameObject pausePanel;
    private bool isPaused = false;
    private bool canChange = true;
    int selected = 1;
    public Sprite buttonBackground;

	// Use this for initialization
	void Start () {
        pausePanel.SetActive(false);
	}

    public void unpause()
    {
        Time.timeScale = 1;
        Screen.showCursor = false;
        Screen.lockCursor = true;
        isPaused = false;
        GameObject.Find("Camera").GetComponent<AudioListener>().enabled = true;
        pausePanel.SetActive(false);
        Debug.Log(isPaused);
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                Screen.showCursor = true;
                Screen.lockCursor = false;
                isPaused = true;
                GameObject.Find("Camera").GetComponent<AudioListener>().enabled = false;
                pausePanel.SetActive(true);
                GameObject dot = GameObject.Find("Dot");
                RectTransform rect = dot.GetComponent<RectTransform>();
                Transform thePlayer = GameObject.Find("Player").transform;
                rect.anchoredPosition = new Vector2(thePlayer.position.x / 5.7f, thePlayer.position.z / 5.7f);
                /*string selectedButtonName = "PauseButton" + selected.ToString();
                Image buttonImage = GameObject.Find(selectedButtonName).GetComponent<Image>();
                buttonImage.sprite = buttonBackground;
                buttonImage.color = new Color(255f, 255f, 255f, 255f);
                Debug.Log(Input.GetAxisRaw("Vertical"));*/
            }
            else
            {
                Time.timeScale = 1;
                Screen.showCursor = false;
                Screen.lockCursor = true;
                isPaused = false;
                GameObject.Find("Camera").GetComponent<AudioListener>().enabled = true;
                pausePanel.SetActive(false);
            }
        }
	}
}
