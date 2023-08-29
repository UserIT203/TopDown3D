using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using IJunior.TypedScenes;

public class DiePanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartGame);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnRestartGame()
    {
        Time.timeScale = 1;
        TestScene.Load();
    }
}
