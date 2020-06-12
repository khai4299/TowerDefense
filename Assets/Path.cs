using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static Transform[] paths;
    private void Awake()
    {
        paths = new Transform[transform.childCount];
        for (int i = 0; i < paths.Length; i++)
        {
            paths[i] = transform.GetChild(i);
        }
    }
}
