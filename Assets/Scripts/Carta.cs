using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] public GameObject CardBack;
    [SerializeField] private SceneScript sceneScript;

    private int _id;
    private bool shaking = false;
    private float shake_intensity = 0.2f;

    Vector3 original_position;

    private bool turned = false;

    private void Start()
    {
        original_position = transform.position;
    }
    public int id
    {
        get { return _id; }
    }

    private void Update()
    {
        if (shaking)
        {
            Vector3 shake_position = original_position + Random.insideUnitSphere * shake_intensity;
            shake_position.y = original_position.y;
            shake_position.z = original_position.z;
            transform.position = shake_position;
        }
    }
    public void OnMouseDown()
    {
        if (CardBack != null)
        {
            if (CardBack.activeSelf)
            {
                sceneScript.MouseDownCard(this);
            }
        }
    }

    public void UpdateCardInfo(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Shake()
    {
        StartCoroutine(ShakeNow());
    }

    private IEnumerator ShakeNow()
    {
        Vector3 original_position = transform.position;
        if (!shaking)
        {
            shaking = true;
        }
        yield return new WaitForSeconds(1f);
        Turn();
        shaking = false;
        transform.position = original_position;
    }

    public void Turn()
    {
        CardBack.SetActive(turned);
        turned = !turned;
    }

}
