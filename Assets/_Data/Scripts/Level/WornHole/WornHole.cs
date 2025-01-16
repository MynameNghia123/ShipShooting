using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WornHole : SaiMonoBehavior
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }
    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(sceneName);
    }
}
