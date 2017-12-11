using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Isabella e Lucas do Passado
public class ScoreManager : MonoBehaviour {
    [SerializeField]
    private GameObject Score, Score2, Highscore;
    public int score;
    private int highscore;

	// Use this for initialization
	void Start () {
        score = 0;
        getPlayerPrefs();
        Score.GetComponent<Text>().text = "Score " + score.ToString();
		Score2.GetComponent<Text>().text = "Score: " + score.ToString();
        Highscore.GetComponent<Text>().text = "Highest Score" + highscore.ToString();
    
    }
	
	
     public void SetScore(int ScoreToAdd)
    {
        score = score + ScoreToAdd;
        Score.GetComponent<Text>().text = "Score: " + score.ToString();
		Score2.GetComponent<Text>().text = "Score: " + score.ToString();
        if (score >= highscore)
        {
            highscore = score;
            setPlayerPrefs(score);
            PlayerPrefs.Save();
        }
        Highscore.GetComponent<Text>().text = "Highest Score: " + highscore.ToString();

    }
    public int GetScore()
    {
        return score;
    }
    void getPlayerPrefs()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    void setPlayerPrefs(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
    }
}
