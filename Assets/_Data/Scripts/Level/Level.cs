using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : SaiMonoBehavior
{
    [Header("Level")]
    [SerializeField] protected int levelMax = 99;
    [SerializeField] protected int levelCurrent = 0;

    public int LevelMax => levelMax;
    public int LevelCurrent => levelCurrent;

    protected virtual void LevelUp()
    {
        levelCurrent++;
        this.LimitLevel();
    }
    protected virtual void SetLevel(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }
    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if (this.levelMax < 1) this.levelCurrent = 1;
    }

}
