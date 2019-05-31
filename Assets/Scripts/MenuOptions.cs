using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    void Start()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Dificuldade");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void DificuldadeFacil()
    {
        PlayerPrefs.SetString("Dificul", "Fácil");
        SceneManager.LoadScene("GameScene");
    }

    public void DificuldadeMedio()
    {
        PlayerPrefs.SetString("Dificul", "Médio");
        SceneManager.LoadScene("GameScene");
    }

    public void DificuldadeDificil()
    {
        PlayerPrefs.SetString("Dificul", "Difícil");
        SceneManager.LoadScene("GameScene");
    }
}
