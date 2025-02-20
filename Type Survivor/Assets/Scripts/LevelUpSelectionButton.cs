using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescriptionText, nameLevelText;
    public Image weaponIcon;

    private Weapon assignedWeapon;
   
    public void UpdateButtonDisplay(Weapon theWeapon)
    {
        upgradeDescriptionText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
        weaponIcon.sprite = theWeapon.icon;

        nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel;

        assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            assignedWeapon.LevelUp();

            UiController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
