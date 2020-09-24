using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Question currentQuestion;
    
    [SerializeField]
    private Text question;

    [SerializeField]
    private Text answer1;

    [SerializeField]
    private Text answer2;

    [SerializeField]
    private Text answer3;

    [SerializeField]
    private Text answer4;

    private int correctAnswer;

    void SetQuestion()
    {
        question.text = currentQuestion.question;
        answer1.text = currentQuestion.answers[0];
        answer2.text = currentQuestion.answers[1];
        answer3.text = currentQuestion.answers[2];
        answer4.text = currentQuestion.answers[3];
        correctAnswer = currentQuestion.correctAnswer;
    }

}
