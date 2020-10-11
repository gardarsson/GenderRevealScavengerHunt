using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LetterScrambleManager : MonoBehaviour
{
    public GameObject reorderableParent;
    public string correctWord;
    public GameObject button, lettersBackgroundImage;

    public void CheckIfWordIsCorrect()
    {
        StartCoroutine(DelayedCheck());
    }

    public IEnumerator DelayedCheck()
    {
        yield return new WaitForSeconds(0.25f);

        string word = "";

        for (int i = 0; i < reorderableParent.transform.childCount; i++)
        {
            word += reorderableParent.transform.GetChild(i).name;
        }

        if (word.ToLower() == correctWord.ToLower())
        {
            IfCorrectAnswer();
        }

        Debug.Log("Wrong :(");
    }

    private void IfCorrectAnswer()
    {
        Color imgColor = new Color(160f / 255f, 250f / 255f, 165f / 255f, 100f / 255f);
        button.GetComponent<Button>().interactable = true;
        lettersBackgroundImage.GetComponent<Image>().color = imgColor;
        SoundManager.instance.PlayWin();
    }
}
