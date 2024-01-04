using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Automat : Gun
{
    [Header("Automat")]
    public int amountOfBullets;
    public TMP_Text bulletText;
    public PlayerArmory playerArmory;
    [SerializeField] int idexOfAutomat = 1;

    public override void Shot()
    {
        base.Shot();
        amountOfBullets -= 1;
        UpdateText();

        if (amountOfBullets <= 0)
        {
            playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        UpdateText();
        bulletText.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bulletText.enabled = false;
    }

    public override void AddBullets(int amount)
    {
        base.AddBullets(amount);
        amountOfBullets += amount;
        UpdateText();
        playerArmory.TakeGunByIndex(idexOfAutomat);
    }

    private void UpdateText()
    {
        bulletText.text = "Пули:" + amountOfBullets.ToString();
    }
}
