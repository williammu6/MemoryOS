using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{

    static private int rows = 2;
    static private int cols = 8;
    private float offsetX = 2.25f;
    private float offsetY = 4.5f;

    [SerializeField] private Sprite[] imagens;
    [SerializeField] private CartaPrincipal cartaOriginal;
    private CartaPrincipal[] Cartas = new CartaPrincipal[cols * rows];

    private void Start()
    {
        Vector3 startPos = cartaOriginal.transform.position;

        int[] image_number = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        image_number = ShuffleArray(image_number);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                CartaPrincipal carta = (i == 0 && j == 0) ? cartaOriginal : Instantiate(cartaOriginal) as CartaPrincipal;
                int id = i * rows + j;
                carta.SetCardImage(id, imagens[image_number[id]]);
                Cartas[id] = carta;

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;

                carta.transform.position = new Vector3(posX, posY, startPos.z);
            }
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
