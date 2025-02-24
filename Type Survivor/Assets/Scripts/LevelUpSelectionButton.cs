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
        if(theWeapon.gameObject.activeSelf == true)
        {
            upgradeDescriptionText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;

             nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel;
        }else
        {
            upgradeDescriptionText.text = "Unlock " + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;

            nameLevelText.text = theWeapon.name;
        }
        

        assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            if(assignedWeapon.gameObject.activeSelf == true)
            {
                assignedWeapon.LevelUp();
            } else
            {
                PlayerController.instance.AddWeapon(assignedWeapon);
            }
            

            UiController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
