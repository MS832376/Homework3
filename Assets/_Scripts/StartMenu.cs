using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }


}
