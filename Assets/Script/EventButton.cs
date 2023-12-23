using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour
{
    public void WrongAnswer()
    {
        GameManager.instance.WrongAnswer();
    }
    public void CorrectAnswer()
    {
        GameManager.instance.NextStage();
    }
}
