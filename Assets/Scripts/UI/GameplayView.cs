using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI labelScore = null;
    
    public void SetScore(int points)
    {
        labelScore.text = points.ToString();
    }
}
