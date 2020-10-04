using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    Question currentQuestion;

    [SerializeField]
    private TextMeshProUGUI question;

    [SerializeField]
    private TextMeshProUGUI answer1;

    [SerializeField]
    private TextMeshProUGUI answer2;

    [SerializeField]
    private TextMeshProUGUI answer3;

    [SerializeField]
    private TextMeshProUGUI answer4;
    
    [SerializeField]
    private TextMeshProUGUI letter;

    private int correctAnswer;

    public void SetQuestion(Question thisQuestion)
    {
        if(thisQuestion.hasBeenAnswered)
        {
            answer1.transform.parent.gameObject.SetActive(false);
            answer2.transform.parent.gameObject.SetActive(false);
            answer3.transform.parent.gameObject.SetActive(false);
            answer4.transform.parent.gameObject.SetActive(false);
            letter.text = thisQuestion.letter;
        }
        else
        {
            currentQuestion = thisQuestion;
            question.text = thisQuestion.question;
            answer1.text = thisQuestion.answers[0];
            answer2.text = thisQuestion.answers[1];
            answer3.text = thisQuestion.answers[2];
            answer4.text = thisQuestion.answers[3];
            correctAnswer = thisQuestion.correctAnswer;
            letter.text = "";
            answer1.transform.parent.gameObject.SetActive(true);
            answer2.transform.parent.gameObject.SetActive(true);
            answer3.transform.parent.gameObject.SetActive(true);
            answer4.transform.parent.gameObject.SetActive(true);
        }
    }

    public void IsCorrectAnswer(int index)
    {
        correctAnswer = currentQuestion.correctAnswer;
        if(index  == correctAnswer)
        {
            currentQuestion.hasBeenAnswered = true;
            answer1.transform.parent.gameObject.SetActive(false);
            answer2.transform.parent.gameObject.SetActive(false);
            answer3.transform.parent.gameObject.SetActive(false);
            answer4.transform.parent.gameObject.SetActive(false);
            letter.text = currentQuestion.letter;
        }
        else
        {
            StartCoroutine(ToggleWrongAnswer());
        }

    }

    IEnumerator ToggleWrongAnswer()
    {
        answer1.transform.parent.gameObject.SetActive(false);
        answer2.transform.parent.gameObject.SetActive(false);
        answer3.transform.parent.gameObject.SetActive(false);
        answer4.transform.parent.gameObject.SetActive(false);
        letter.text = "Rangt svar. \n Prófið aftur.";
        yield return new WaitForSeconds(2);
        letter.text = "";
        answer1.transform.parent.gameObject.SetActive(true);
        answer2.transform.parent.gameObject.SetActive(true);
        answer3.transform.parent.gameObject.SetActive(true);
        answer4.transform.parent.gameObject.SetActive(true);
    }
}
