using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void ChangeSceneAsync(string scene)
    {
        StartCoroutine(SceneAsyncOperation(scene));
    }

    private IEnumerator SceneAsyncOperation(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
