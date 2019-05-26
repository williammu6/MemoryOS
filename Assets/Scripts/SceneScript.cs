using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
    private const float V = 0f;

    private float offsetX = 2.25f;
    private float offsetY = 5f;

    private bool CanClick;

    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Carta carta;
    [SerializeField] private GameScript Game;

    private Carta primeira_carta;

    private void Start()
    {
        int cols = Game.cols;
        int rows = Game.rows;

        CanClick = true;

        primeira_carta = null;

        Vector3 startPos = carta.transform.position;

        int[] image_number = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        image_number = ShuffleArray(image_number);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Carta nova_carta = (i == 0 && j == 0) ? carta : Instantiate(carta) as Carta;

                int id = image_number[i * rows + j];
                nova_carta.UpdateCardInfo(id, imagens[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;

                carta.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private void CheckPair(Carta a, Carta b)
    {
        if (a.id != b.id)
        {
            ShakePair(a, b);
        }
        else
        {
            Game.AddScore();
            Game.CheckGame();
        }
    }

    void ShakePair(Carta a, Carta b)
    {
        Game.ErrouSound();
        CanClick = !CanClick;
        a.Shake();
        b.Shake();
        CanClick = !CanClick;
    }

    public void MouseDownCard(Carta carta)
    {
        if (!CanClick)
        {
            return;
        }

        carta.Turn();

        if (primeira_carta == null)
        {
            primeira_carta = carta;
        }
        else
        {
            CheckPair(primeira_carta, carta);
            primeira_carta = null;
        }
    }

    int[] ShuffleArray(int[] array)
    {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            int k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }
}
