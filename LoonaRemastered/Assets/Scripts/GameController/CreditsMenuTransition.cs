using UnityEngine;
using System.Collections;
//Isabella
public class CreditsMenuTransition : MonoBehaviour {
    public GameObject pivo;
    public GameObject credits;
    public GameObject loonaLogo;
	// Use this for initialization
	void Start () {
	    
	}
	
	public void GoToCredits()
    {
        loonaLogo.SetActive(false);
        pivo.SetActive(false);
        credits.SetActive(true);
    }

    public void GoToMenu()
    {
        loonaLogo.SetActive(true);
        pivo.SetActive(true);
        credits.SetActive(false);
    }
}
