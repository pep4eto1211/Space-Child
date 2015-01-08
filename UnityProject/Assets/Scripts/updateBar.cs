using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void updateVitalsBar (float newVitals)
    {
        Image vitalsBarImage = GameObject.Find("VitalsBar").GetComponent<Image>();
        vitalsBarImage.fillAmount = newVitals / 100;
    }

    void updateSuitBar(float newSuit)
    {
        Image vitalsBarImage = GameObject.Find("SuitBar").GetComponent<Image>();
        vitalsBarImage.fillAmount = newSuit / 100;
    }

    void updateEnergy(float newEnergy)
    {
        Image vitalsBarImage = GameObject.Find("EnergyBar").GetComponent<Image>();
        vitalsBarImage.fillAmount = newEnergy / 100;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
