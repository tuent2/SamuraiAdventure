using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider HeathSlider;
    [SerializeField] Heath PlayerHeath;
    // Start is called before the first frame update
    void Start()
    {
        HeathSlider.maxValue = PlayerHeath.getHeath();
    }

    // Update is called once per frame
    void Update()
    {
        HeathSlider.value = PlayerHeath.getHeath();
    }
}
