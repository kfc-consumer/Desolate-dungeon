using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;


public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;



    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];

    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count -1;
        }
        sr.sprite = skins[selectedSkin];

    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "assets/selectedskin.prefab");
        SceneManager.LoadScene("MainGame");
    }

}
