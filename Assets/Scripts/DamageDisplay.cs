using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField]Canvas damageDisplay;
    [SerializeField]float timeBetweenDisplay =1f;
    void Start()
    {
        damageDisplay.enabled=false;
    }
    IEnumerator Display()
    {
        damageDisplay.enabled=true;
        yield return new WaitForSeconds(timeBetweenDisplay);
        damageDisplay.enabled=false;

    }
    public void DisplayDamage()
    {
        StartCoroutine(Display());
    }
}
