using System;
using UnityEngine;

public class TestSettingsCastleResource : MonoBehaviour
{
    public int Eat = 100;
    public int Wood = 100;
    public int Gold = 100;

    [ContextMenu("ChangesToCastleRes")]
    public void ChangesToCastleRes()
    {
        CastleData.Eat = Eat;
        CastleData.Wood = Wood;
        CastleData.Gold = Gold;
    }

    public void Awake()
    {
        Debug.Log("Add Resource in Awake Game");
        ChangesToCastleRes();
    }
}