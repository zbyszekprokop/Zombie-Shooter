using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]int AmmoAmount=10;
    public int GetCurrentAmmo()
    {
        return AmmoAmount;
    }
    public void ReduceCurrentAmmo()
    {
        AmmoAmount--;
    }
}
