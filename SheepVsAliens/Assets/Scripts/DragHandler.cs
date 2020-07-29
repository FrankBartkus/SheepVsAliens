using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DragHandler : MonoBehaviour
{
    public static DragHandler dragHandler;
    [HideInInspector]
    public GameObject dragging;
    [HideInInspector]
    public bool isDragging;
    [HideInInspector]
    public Vector3 mousePosition;
    [HideInInspector]
    public GameObject hoverSprite;
    [HideInInspector]
    public GameObject rangeObject;
    float range;
    int cost;
    Vector3 goTo;
    Vector3 goToNormal;
    float distance;
    float speed = 375f;

    public void SetHover(GameObject turrent)
    {
        if (GameHandler.IsGamePaused())
            return;
        if(!isDragging)
        {
            hoverSprite = new GameObject("TurrentHover");
            hoverSprite.AddComponent<SpriteRenderer>().sprite = turrent.GetComponent<SpriteRenderer>().sprite;
            range = turrent.GetComponent<TowerStats>().range;
            cost = turrent.GetComponent<TowerStats>().cost;
            if (range > 0)
            {
                rangeObject = new GameObject("Range");
                rangeObject.AddComponent<SpriteRenderer>().sprite = GameAssets.i.rangeSprite;
                rangeObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f);
                rangeObject.transform.SetParent(hoverSprite.transform);
                rangeObject.transform.position += new Vector3(0, 0, .5f);
                rangeObject.transform.localScale *= range * 2f;
            }
            dragging = turrent;
            isDragging = true;
        }
        else if(dragging == turrent)
        {
            Destroy(hoverSprite);
            dragging = null;
            isDragging = false;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        dragHandler = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDragging || GameHandler.IsGamePaused())
            return;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        goTo = new Vector3(Mathf.Floor(mousePosition.x) + .5f, Mathf.Floor(mousePosition.y) + .5f, 0);
        distance = Vector2.Distance(hoverSprite.transform.position, goTo);
        goToNormal = (goTo - hoverSprite.transform.position).normalized;
        if(distance < Vector2.Distance(hoverSprite.transform.position, hoverSprite.transform.position + goToNormal * speed * Time.deltaTime))
            hoverSprite.transform.position = goTo;
        else
            hoverSprite.transform.position += goToNormal * speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (!ButtonAtPosition(hoverSprite.transform.position))
            {
                if (cost <= PlayerStats.Money)
                {
                    if(!TurrentAtPosition(hoverSprite.transform.position))
                    {
                        Instantiate(dragging, hoverSprite.transform.position, transform.rotation, GamePlayWindow.GetTransform());
                        PlayerStats.changeMoneyAmount(-cost);
                        SoundManager.PlaySound(SoundManager.Sound.TowerPlace);
                        SoundManager.PlaySound(SoundManager.Sound.TowerPurchase);
                        Destroy(hoverSprite);
                        dragging = null;
                        isDragging = false;
                    }
                    else
                        SoundManager.PlaySound(SoundManager.Sound.Error);
                }
                else
                    SoundManager.PlaySound(SoundManager.Sound.Error);
            }
        }
    }
    bool TurrentAtPosition(Vector3 position)
    {
        foreach (GameObject turrent in GameObject.FindGameObjectsWithTag("Tower"))
            if (Vector3.Distance(turrent.transform.position, position) < 1f)
                return true;
        return false;
    }
    bool ButtonAtPosition(Vector3 position)
    {
        foreach (MouseOver mouseOver in GameObject.FindObjectsOfType<MouseOver>())
            if (mouseOver.mouseOver)
                return true;
        return false;
    }
}
