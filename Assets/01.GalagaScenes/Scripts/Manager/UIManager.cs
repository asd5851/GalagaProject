using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    private static UIManager myInstance = null;
    public static UIManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            else
            {
                return myInstance;
            }
        }
    }
    private Scene currentScene;
    public TMP_Text ScoreText;
    public Image[] lifeImage;
    public GameObject gameOver;

    private int score;
    // Update is called once per frame
    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        gameOver.SetActive(false);
        currentScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        // # UI Score 업데이트
        // # UI LifeImage 업데이트
    }
    public void LifeImageUpdate(int life)
    {
        lifeImage[life].color = new Color(1, 1, 1, 0);
    }
    public void ClickRe()
    {
        SceneManager.LoadScene("GalagaScene");
        ObjectPoolManager.Instance.SceneReload();
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        foreach(var obj in lifeImage){
            obj.color = new Color(1,1,1,1);
        }
        //PlayerManager.Instance.SetPlayer();
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ScoreAdd(int point){
        score+=point;
        ScoreText.text = "Score\n"+score;
    }
}
