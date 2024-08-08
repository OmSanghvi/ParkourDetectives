using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;

    private void Awake()
    {
        tryAgainButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GalaxyOneProject);
        });
    }
}
