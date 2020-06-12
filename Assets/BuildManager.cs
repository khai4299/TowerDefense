using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node selectNode;
    public NodeUI nodeUI;
    public static BuildManager instance;
    public GameObject buildEffect;
    public GameObject sellEffect;
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

     
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money>=turretToBuild.cost; } }
   
    public void SelectNode(Node node)
    {
        if (selectNode==node)
        {
            DeselectNode();
            return;
        }
        selectNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectNode = null;
        nodeUI.Hide();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
