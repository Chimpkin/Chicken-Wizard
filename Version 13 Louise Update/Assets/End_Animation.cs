using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End_Animation : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNewScene()
     {
         UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
     }
}
