using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundSurvived : MonoBehaviour
{
    public Text roundNumber;

    private void OnEnable()
    {
        StartCoroutine(AnimationText());
    }
    IEnumerator AnimationText()
    {
        roundNumber.text = "0";
        int round = 0;
       
        while(round <PlayerStats.round)
        {
            round++;
            roundNumber.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
