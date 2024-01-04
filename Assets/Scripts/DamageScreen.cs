using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image damageScreen;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        damageScreen.enabled = true;

        for (float t = 1; t >= 0; t -= Time.deltaTime)
        {
            damageScreen.color = new Color(1, 0, 0, t);
            yield return null;
        }

        damageScreen.enabled = false;
    }
}
