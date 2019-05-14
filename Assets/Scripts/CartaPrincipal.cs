using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject CardBack;

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void OnMouseDown()
    {
        CardBack.SetActive(true);
        if (CardBack.activeSelf)
        {
            CardBack.SetActive(false);
        }
    }

    public void SetCardImage(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
