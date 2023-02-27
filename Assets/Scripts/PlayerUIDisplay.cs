using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider HeathSlider;
    [SerializeField] Heath PlayerHeath;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {   
        HeathSlider.maxValue = PlayerHeath.getHeath();
    }

    
    void Update()
    {
        HeathSlider.value = PlayerHeath.getHeath();
        scoreText.text = scoreKeeper.getCurrentScore().ToString("0000000000000");
        // scoreText.text = "1";
    }
}
