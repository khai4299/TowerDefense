using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text costUpgrade;
    public Button bttUpgrade;
    public Text sellTurret;
    private Node target;
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.transform.position + target.positionOffset;
        if (!target.isUpgrade)
        {
            costUpgrade.text = "$" + target.turretBlueprint.upgradeCost;
            bttUpgrade.interactable = true;
            sellTurret.text = "$" + target.turretBlueprint.sellCost;
        }
        else
        {
            costUpgrade.text = "Done";
            bttUpgrade.interactable = false;
            sellTurret.text = "$" + target.turretBlueprint.sellUpgrade;
        }
        
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
