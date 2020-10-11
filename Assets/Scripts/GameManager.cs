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

    [SerializeField]
    private GameObject lettersToShow;

    [SerializeField]
    private GameObject continueButton;

    public CameraController[] cameraControllers;

    private int correctAnswer;

    private int questionsAnswered = 0;

    public void SetQuestion(Question thisQuestion)
    {
        if(thisQuestion.hasBeenAnswered)
        {
            answer1.transform.parent.gameObject.SetActive(false);
            answer2.transform.parent.gameObject.SetActive(false);
            answer3.transform.parent.gameObject.SetActive(false);
            answer4.transform.parent.gameObject.SetActive(false);
            letter.text = "Rétt svar, stafurinn er: " + thisQuestion.letter;
        }
        else
        {
            StartCoroutine(DisableTemporarily());
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
            SoundManager.instance.PlayCorrectSound();

            currentQuestion.hasBeenAnswered = true;
            answer1.transform.parent.gameObject.SetActive(false);
            answer2.transform.parent.gameObject.SetActive(false);
            answer3.transform.parent.gameObject.SetActive(false);
            answer4.transform.parent.gameObject.SetActive(false);
            letter.text = "Rétt svar, stafurinn er: " + currentQuestion.letter;
            StartCoroutine(HideAfterDelay(answer1.transform.root.GetChild(0).gameObject, 2));

            questionsAnswered++;

            if (questionsAnswered == 8)
            {
                continueButton.GetComponent<Button>().enabled = true;
                continueButton.GetComponent<Image>().color = Color.cyan;
            }

            foreach (Transform t in lettersToShow.GetComponentsInChildren<Transform>())
            {
                if (t.name == currentQuestion.letter.ToString() && !t.GetChild(0).gameObject.activeInHierarchy)
                {
                    t.GetChild(0).gameObject.SetActive(true);
                    return;
                }
            }


        }
        else
        {
            StartCoroutine(ToggleWrongAnswer());
            SoundManager.instance.PlayWrongSound();
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

    IEnumerator HideAfterDelay(GameObject objectToHide, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToHide.SetActive(false);

        foreach(CameraController cc in cameraControllers)
        {
            cc.ResumeCameraMovement();
        }
    }

    IEnumerator DisableTemporarily()
    {
        answer1.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        answer2.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        answer3.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        answer4.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.2f);
        answer1.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        answer2.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        answer3.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        answer4.transform.parent.gameObject.GetComponent<Button>().interactable = true;
    }
}
