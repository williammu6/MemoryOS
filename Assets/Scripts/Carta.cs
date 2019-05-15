using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] private GameObject CardBack;
    [SerializeField] private SceneScript sceneScript;

    private int _id;

    public int id
    {
        get { return _id; }
    }

    public void OnMouseDown()
    {
        if (CardBack != null) {
            if (CardBack.activeSelf)
            {
                sceneScript.MouseDownCard(this, CardBack);
            }
        }
    }

    public void UpdateCardInfo(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
