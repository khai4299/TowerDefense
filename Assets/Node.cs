using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    BuildManager buildManager;
    public Color hoverColor;
    public Color noEnoughMoney;
    public Vector3 positionOffset;
    public GameObject turret;
    private new Renderer renderer;
    private Color startColor;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    public bool isUpgrade = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;
        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            renderer.material.color = hoverColor;
        }
       else
        {
            renderer.material.color = noEnoughMoney;
        }
    }
    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
            return;
        PlayerStats.money -= blueprint.cost;
        GameObject _turret = Instantiate(blueprint.prefab, transform.position + positionOffset, Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        GameObject buildeffect = Instantiate(buildManager.buildEffect, transform.position + positionOffset, Quaternion.identity);
        Destroy(buildeffect, 5f);
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
            return;
        PlayerStats.money -= turretBlueprint.upgradeCost;
        Destroy(turret);
        GameObject _turret = Instantiate(turretBlueprint.upgradePrefab, transform.position + positionOffset, Quaternion.identity);
        turret = _turret;   
        GameObject buildeffect = Instantiate(buildManager.buildEffect, transform.position + positionOffset, Quaternion.identity);
        Destroy(buildeffect, 5f);
        isUpgrade = true;
    }
    public void SellTurret()
    {
        if (!isUpgrade)
        {
            PlayerStats.money += turretBlueprint.sellCost;
        }
        else
        {
            PlayerStats.money += turretBlueprint.sellUpgrade;
        }
        Destroy(turret);
        turret = null;
        GameObject buildeffect = Instantiate(buildManager.sellEffect, transform.position + positionOffset, Quaternion.identity);
        Destroy(buildeffect, 5f);
    }
}
