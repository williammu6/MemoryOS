using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
    private const float V = 0f;

    private float offsetX = 2.5f;
    private float offsetY = 5f;

    private bool CanClick;

    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Carta carta;
    [SerializeField] private GameScript Game;

    private Carta primeira_carta;
    private GameObject GOPrimeira;

    private void Start()
    {

        int cols = Game.cols;
        int rows = Game.rows;

        CanClick = true;

        primeira_carta = null;
        GOPrimeira = null;

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

    private void CheckPair(Carta a, Carta b, GameObject secondCardGO)
    {
        if (a.id != b.id) 
        {
            StartCoroutine(WrongPair(GOPrimeira, secondCardGO));
        } else {
            Game.AddScore();
            Game.CheckGame();
        }
    }
    public void MouseDownCard(Carta carta, GameObject Cardback)
    {
        if (!CanClick)
            return;

        TurnCard(Cardback, false);

        if (primeira_carta == null)
        {
            primeira_carta = carta;
            GOPrimeira = Cardback;
        }
        else
        {
            CheckPair(primeira_carta, carta, Cardback);

            primeira_carta = null;
            GOPrimeira = null;
        }
    }

    private IEnumerator WrongPair(GameObject a, GameObject b)
    {
        CanClick = !CanClick;
        yield return new WaitForSeconds(1f);
        TurnCard(a, true);
        TurnCard(b, true);
        CanClick = !CanClick;
    }


    void TurnCard(GameObject card, bool front)
    {
        card.SetActive(front);
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
