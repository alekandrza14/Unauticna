using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class savetrigger : MonoBehaviour
{
    public string _Name;
    public string Variable ="";
    public StoryPoint _StoryPoint = StoryPoint.eventer;
    private void Start()
    {



        if (_StoryPoint == StoryPoint.awaker)
        {
            VarSave.SetString(_Name, Variable);
        }

    }
    public void OnTriggerEnter(Collider collision)
    {

        Debug.Log(collision.tag);
        if (_StoryPoint == StoryPoint.eventer && !VarSave.ExistenceVar(_Name) && collision.tag == "Player")
        {
            GameManager.save();
            VarSave.SetString(_Name, Variable);

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (_StoryPoint == StoryPoint.trigger && collision.tag == "Player")
        {
            GameManager.save();
            VarSave.SetString(_Name, Variable);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (_StoryPoint == StoryPoint.booler && VarSave.GetString(_Name) != Variable && collision.tag == "Player")
        {
            GameManager.save();
            VarSave.SetString(_Name, Variable);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
