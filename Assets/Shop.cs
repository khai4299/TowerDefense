using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint turret;
    public TurretBlueprint missile;
    public TurretBlueprint laser;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectTurret()
    {
        buildManager.SelectTurretToBuild(turret);
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missile);
    }
    public void SelectLaser()
    {
        buildManager.SelectTurretToBuild(laser);
    }
}
