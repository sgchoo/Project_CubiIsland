using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck_UI : MonoBehaviour
{
    public static bool SceneLoad = false;
    
    private int previousSceneIndex;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentSceneIndex = scene.buildIndex;

        if (currentSceneIndex != previousSceneIndex)
        {
            // 이전 씬과 현재 씬이 다른 경우, 로드된 씬이 새로운 씬임을 확인
            Debug.Log("--------------------------새로운 씬이 로드되었습니다.");
            SceneLoad = true;
            // 이전 씬 인덱스를 업데이트합니다.
            previousSceneIndex = currentSceneIndex;
        }
    }
}
