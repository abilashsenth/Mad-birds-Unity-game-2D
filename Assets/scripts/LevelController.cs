using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour

{

    private enemies[] enem;

    private void OnEnable()
    {
        enem = FindObjectsOfType<enemies>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(enemies e in enem)
        {
            if(e != null)
            {
                return;
            }
        }
        string nextLevel = "level2";
        SceneManager.LoadScene(nextLevel);
    }
}
