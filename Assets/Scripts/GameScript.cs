using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayAgainBtn;
    public TextMeshProUGUI ScoreText;
    public int score;

    public int rows = 2;
    public int cols = 8;

    [SerializeField] private AudioClip[] AcertouClips;
    [SerializeField] private AudioClip[] ErrouClips;
    [SerializeField] private AudioClip[] GanhouClips;
    private AudioSource audioSource;
    void Start()
    {
        score = 0;
    }

    public void AddScore()
    {
        PlaySound(AcertouClips);
        score++;
        ScoreText.text = "Score: " + score;
    }

    void PlaySound(AudioClip[] clips)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void ErrouSound()
    {
        PlaySound(ErrouClips);
    }

    public void CheckGame()
    {
        if (score == (int)(rows * cols / 2))
        {

            StartCoroutine(PlayerWon());
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator PlayerWon()
    {
        PlaySound(GanhouClips);
        yield return new WaitForSeconds(2f);
        PlayAgainBtn.SetActive(true);
    }
}
