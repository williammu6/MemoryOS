using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] private GameObject CardBack;


    public float shake_intensity;
    public Vector3 originPosition;
    [SerializeField] private SceneScript sceneScript;
    private int _id;
    public int id
    {
        get { return _id; }
    }

    private void Start()
    {
        originPosition = transform.position;
    }
    public void OnMouseDown()
    {
        if (CardBack.activeSelf)
        {
            sceneScript.MouseDownCard(this, CardBack);
        }
    }

    public void SetCardImage(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    public void Shake()
    {
        transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
    }
}
