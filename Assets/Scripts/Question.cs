using UnityEngine;

[System.Serializable]
public class Question : MonoBehaviour
{
    public bool hasBeenAnswered = false;
    public string question;
    public string[] answers;
    public char letter;
    public int correctAnswer;
  
}
