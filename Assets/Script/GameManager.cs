using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] Stages;
    public bool GameStart;
    public GameObject EndScreen;
    public int curStage = 0;
    public float timer = 0;
    public TextMeshProUGUI timerText,stage,wrongTeacherName;
    public AudioSource audio;
    public TMP_InputField teacherName, stage6,stage7;
    public bool audioStart = false;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameStart)
        {
            if (audioStart == false)
            {
                audioStart = true;
                Audio();
            }
   
            timerText.text = "Timer : " + timer.ToString("F2");
            if (timer < 71)
            {
                timer += Time.deltaTime;
            }

            stage.text = "Stage : " + curStage.ToString();
        }
        
       
    }

    public void NextStage()
    {
        if(curStage == Stages.Length-1)
        {
            Debug.Log("ss");
            GameEnd();
        }
        curStage++;
        for (int i = 0; i < Stages.Length; i++)
        {
            if(i == curStage)
            {
                Stages[i].SetActive(true);
            }
            else
            {
                Stages[i].SetActive(false);
            }
        }
        
    }

    private void Audio()
    {
        audio.Play();
    }

    public void TeacherName()
    {
        if(teacherName.text == "윤지은선생님" || teacherName.text == "윤지은쌤" || teacherName.text == "지은선생님" || teacherName.text == "지은쌤")
        {
            NextStage();
        }
        else if (teacherName.text == "윤지은" || teacherName.text == "지은")
        {
            wrongTeacherName.text = "'선생님'을 붙히지 않는 교권 추락의 현장";
        }
        else
        {
            wrongTeacherName.text = "선생님 성함을 몰라?";
        }
       
    }

    public void Stage6()
    {
        if (stage6.text == "아" || stage6.text == "ㅏ")
        {
            NextStage();
        }
    }
    public void Stage7()
    {
        if (stage7.text == "시치고산")
        {
            NextStage();
        }
    }


    public void GameEnd()
    {
        GameStart = false;
        EndScreen.SetActive(true);
        
    }
}
