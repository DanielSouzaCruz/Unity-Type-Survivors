using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int currentExperience;
    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 100;

    // Start is called before the first frame update
    void Start()
    {
        while(expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;

        if(currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }

        UiController.instance.UpdateExperience(currentExperience, expLevels[currentLevel],currentLevel);
    }

    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValue;
    }

    public void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
        currentLevel++;

        if(currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }

       // PlayerController.instance.activeWeapon.LevelUp();
       UiController.instance.levelUpPanel.SetActive(true);

        Time.timeScale = 0f;

        //UiController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.activeWeapon);
        UiController.instance.levelUpButtons[0].UpdateButtonDisplay(PlayerController.instance.assignedWeapons[0]);
        UiController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[0]);
        UiController.instance.levelUpButtons[2].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[1]);
    }
}
