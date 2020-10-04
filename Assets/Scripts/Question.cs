using UnityEngine;

[System.Serializable]
public class Question : MonoBehaviour
{
    public bool hasBeenAnswered = false;
    public string question;
    public string[] answers;
    public string letter;
    public int correctAnswer;
  
}
