using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() => instance = this;

    public AudioSource audioSource;
    public bool isGaming;

    public Transform stage;
    List<GameObject> stages = new List<GameObject>();

    public TextMeshProUGUI timerText,stageText,wrongTeacherName;

    PostProcessVolume volume;
    Vignette vignette;


    public List<Image> disabledImage = new();
    int curStage = 0;
    float timer = 71, wrongTimer;
    bool isDisabled = false;

    void Start()
    {
        stages = new List<GameObject>();
        for (int i = 0; i < stage.childCount; i++)
        {
            stages.Add(stage.GetChild(i).gameObject);
        }
        stages[0].SetActive(true);

        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);
    }

    void Update()
    {
        if (isGaming)
        {
            timerText.text = "Timer : " + timer.ToString("F2");
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            stageText.text = "Stage : " + curStage.ToString();
        }

        if (wrongTimer > 0)
        {
            vignette.intensity.value = wrongTimer / 2;
            wrongTimer -= Time.deltaTime;
            foreach (Image image in disabledImage)
                image.fillAmount = 1 - wrongTimer;
        }
        else
        {
            vignette.intensity.value = 0;
            if (isDisabled)
            {
                foreach (Image image in disabledImage)
                    image.fillAmount = 1;
                disabledImage.Clear();
                isDisabled = false;
            }
        }
    }

    public void GameStart()
    {
        isGaming = true;
        audioSource.Play();
    }

    public void NextStage()
    {
        if (wrongTimer > 0) return;
        stages[curStage++].SetActive(false);
        stages[curStage].SetActive(true);
    }

    public void WrongAnswer()
    {
        if (wrongTimer > 0) return;

        wrongTimer = 1;
        disabledImage.AddRange(FindObjectsOfType<Image>());
        foreach(Image image in disabledImage)
            image.fillAmount = 0;
        isDisabled = true;
    }

    public void TeacherName(TMP_InputField inputField)
    {
        List<string> answer = new List<string>(){ "윤지은 선생님", "윤지은썜", "지은선생님" , "지은쌤", "윤지은 선생님", "윤지은 쌤", "지은 선생님", "지은 쌤" };
        List<string> noTeacher = new List<string>() { "윤지은", "지은" };

        if (answer.Contains(inputField.text))
            NextStage();
        else if (noTeacher.Contains(inputField.text))
            wrongTeacherName.text = "'선생님'을 붙히지 않는 교권 추락의 현장";
        else
            wrongTeacherName.text = "선생님 성함을 몰라?";
    }

    public void Stage6(TMP_InputField inputField)
    {
        List<string> answer = new List<string>() { "아", "ㅏ" };
        if (answer.Contains(inputField.text))
        {
            NextStage();
        }
    }
    public void Stage7(TMP_InputField inputField)
    {
        if (inputField.text == "시치고산")
        {
            NextStage();
        }
    }
    public void Stage8(TMP_InputField inputField)
    {
        if (inputField.text == "크다")
        {
            NextStage();
        }
    }

    public void Stage13(TMP_InputField inputField)
    {
        if(inputField.text == "생일")
        {
            NextStage();
        }
    }

    public void Stage15(TMP_InputField inputField)
    {
        if (inputField.text == "콜라")
        {
            NextStage();
        }
    }

    public void Stage17(TMP_InputField inputField)
    {
        List<string> answer = new List<string>() { "모두", "모두가" };
        if (answer.Contains(inputField.text))
        {
            NextStage();
        }
    }

    public void Stage20(TMP_InputField inputField)
    {
        List<string> answer = new List<string>() { "2일", "2" };
        if (answer.Contains(inputField.text))
        {
            NextStage();
        }
    }

    public void Stage21(TMP_InputField inputField)
    {
        List<string> answer = new List<string>() { "4", "4번" };
        if (answer.Contains(inputField.text))
        {
            NextStage();
        }
    }
    public void Stage22(TMP_InputField inputField)
    {
        List<string> answer = new List<string>() { "도쿄", "도쿄도" };
        if (answer.Contains(inputField.text))
        {
            NextStage();
        }
    }

    public void Stage23(TMP_InputField inputField)
    {
        if (inputField.text == "타나바타")
        {
            NextStage();
        }
    }
}
