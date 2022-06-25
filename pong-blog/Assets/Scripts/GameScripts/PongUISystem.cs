using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PongUISystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI leftPLayerScore;
    [SerializeField]
    TextMeshProUGUI rightPlayerScore;

    [SerializeField]
    TextMeshProUGUI pongHeroText;

    public void UpdateScore(int LeftPlayerScore,int RightPlayerScore)
    {
        leftPLayerScore.text = LeftPlayerScore.ToString();
        rightPlayerScore.text = RightPlayerScore.ToString();
    }
}
