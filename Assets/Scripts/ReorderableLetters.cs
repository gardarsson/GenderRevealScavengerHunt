using Malee.List;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorderableLetters : MonoBehaviour
{
    [System.Serializable]
    public class StringList : ReorderableArray<string> { }

    [Reorderable]
    public StringList letterList;
}
