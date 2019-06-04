using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{

    void Start()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Dificuldade");
    }

}
