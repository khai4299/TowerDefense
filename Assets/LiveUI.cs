using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LiveUI : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        text.text = PlayerStats.live + " lives";
    }
}
