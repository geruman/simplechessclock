using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToApp : MonoBehaviour
{
    

    private float timer = 0f;
    private bool sceneLoaded = false;

    private void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Verificar si ha pasado el tiempo deseado y la escena no ha sido cargada aún
        if (timer >= 7f && !sceneLoaded)
        {
            // Cargar la escena
            SceneManager.LoadScene(1);
            sceneLoaded = true;
        }
    }
}
