using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float money;
    public float startMoney = 400f;

    public static int live;
    public int startLive = 20;
    public  static int round;
    private void Start()
    {
        money = startMoney;
        live = startLive;
        round = 0;
    }
 
}
