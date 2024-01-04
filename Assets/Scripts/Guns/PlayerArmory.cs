using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] guns;
    public int currentGunindex;

    void Start()
    {
        TakeGunByIndex(currentGunindex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == gunIndex)
            {
                guns[i].Activate();
            } else
            {
                guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int amount)
    {
        guns[gunIndex].AddBullets(amount);
    }
}
