using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    [Header("enemy ctrl")]
    [SerializeField] public ScriptableObject _scriptableObject;
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
    