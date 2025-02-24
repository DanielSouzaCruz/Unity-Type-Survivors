using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{

    public static UiController instance;

    private void Awake()
    {
        instance = this; 
    }

    public Slider explvlSlider;
    public TMP_Text explvlText;

    public LevelUpSelectionButton[] levelUpButtons;
    public GameObject levelUpPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;
        explvlText.text = "Level: " + currentLvl;
    }

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
