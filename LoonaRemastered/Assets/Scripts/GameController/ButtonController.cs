using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour {
	public GameObject [] ButtonsHideAppear;
    public GameObject Fade;
	public string OnTrigger, OffTrigger;
	public Sprite ButtonON, ButtonOFF;
	public int Speed;
	public GameObject ButtonToChange;
    public float DelayTimeToLoad;
    public string GameSceneName;
    public string LoadingSceneName;
	private bool Active;
	private Animator Animation;
    public bool GameIsPaused = false;
    private float DelayTimeToPause = 0.1f;
    public GameObject ExitPopUp;
    public string SkipMissionTrigger = "SkipMission";
    public GameObject PivoObject;
    private GameObject PlayerController,Player;
    private bool CanIShoot;
    public Animator BotãoPOwerUP;
    
    // Use this for initialization

    void Start () {
        Active = false;



		if (SceneManager.GetActiveScene().name.StartsWith("Level"))
        {
           
            //Player = GameObject.FindGameObjectWithTag("Player");
            //PlayerController = GameObject.FindGameObjectWithTag("PlayerController");
        }
		//Animation = GameObject.Find("Pivo").GetComponent<Animator>();
	
	}
	public void Appear(){
		if (!Active) {
			for (int i= 0; i< ButtonsHideAppear.Length; i++) {
				ButtonsHideAppear [i].GetComponent<Animator> ().speed= Speed;
				ButtonsHideAppear [i].GetComponent<Animator> ().SetTrigger (OnTrigger);
				ButtonToChange.GetComponent<Image>().sprite=ButtonOFF;
				Active=true;
			}
		}
		 else {
			for (int i= 0; i< ButtonsHideAppear.Length; i++) {
				ButtonsHideAppear [i].GetComponent<Animator> ().SetTrigger (OffTrigger);
				ButtonToChange.GetComponent<Image>().sprite=ButtonON;
				ButtonsHideAppear [i].GetComponent<Animator> ().speed= Speed;
				Active=false;
			}
		}
	}
    

	public void LoadScene(string Scene){
        PlayerPrefs.SetString("NextScene", Scene);
        //Fade.GetComponent<Animator>().SetBool("Fade", true);
		SceneManager.LoadScene(Scene);

	}
    public void LoadGame()
    {
     
        PlayerPrefs.SetString("NextScene", GameSceneName);
        Fade.GetComponent<Animator>().SetBool("Fade", true);
    }

	public void Pause(string pause)
	{
        GameIsPaused = true;
		Time.timeScale = 0;
		Animation.SetTrigger (pause);
	}
	public void Play(string play)
	{
        Time.timeScale = 1;
		Animation.SetTrigger (play);
        Invoke("SetGamePausedFalse", DelayTimeToPause);
	}
	public void Restart()
    {
        Fade.GetComponent<Animator>().SetBool("Fade", true);
        PlayerPrefs.SetString("NextScene",SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel);
    }
    public void SetTriggerAnimator(string triggertoset)
    {
        Animation.SetTrigger(triggertoset);
    }

    public void PlayOnStart(GameObject PopUpToDestroy)
    {
        Time.timeScale = 1;
        Destroy(PopUpToDestroy);
        Invoke("PlayInTime",0.2f);
    }
    void PlayInTime()
    {
        Time.timeScale = 1;
    }
    void SetGamePausedFalse()
    {
        GameIsPaused = false;
    }

    public void InvokeExitPopUp()
    {
        ExitPopUp.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UninvokeExitPopUp()
    {
        ExitPopUp.SetActive(false);
    }

    public void SkipMission()
    {
        PivoObject.GetComponent<Animator>().SetTrigger(SkipMissionTrigger);
    }
    public void CloseAbb(string DesactiveObject)
    {
        Time.timeScale = 1;
        GameObject.Find(DesactiveObject).SetActive(false);
    }

}
