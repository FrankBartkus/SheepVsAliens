using System.Collections;
using System.Collections.Generic;
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
    [HideInInspector]
    public float range;

    public void SetHover(GameObject turrent)
    {
        if(!isDragging)
        {
            hoverSprite = new GameObject("TurrentHover");
            hoverSprite.AddComponent<SpriteRenderer>().sprite = turrent.GetComponent<SpriteRenderer>().sprite;
            if (range > 0)
            {
                rangeObject = new GameObject("Range");
                rangeObject.AddComponent<SpriteRenderer>().sprite = GameAssets.i.rangeSprite;
                rangeObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f);
                rangeObject.transform.SetParent(hoverSprite.transform);
                rangeObject.transform.position += new Vector3(0, 0, 1);
                rangeObject.transform.localScale *= range / 2f;
            }
            dragging = turrent;
            isDragging = true;
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
        if (!isDragging)
            return;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hoverSprite.transform.position = new Vector3(Mathf.Floor(mousePosition.x) + .5f, Mathf.Floor(mousePosition.y) + .5f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            if (!TurrentAtPosition(hoverSprite.transform.position))
            {
                Instantiate(dragging, hoverSprite.transform.position, transform.rotation);
                Destroy(hoverSprite);
                dragging = null;
                isDragging = false;
            }
        }
    }
    bool TurrentAtPosition(Vector3 position)
    {
        //  Replace "TurrentShoot" with name of a variable only turrent has
        //  foreach (TurrentShoot turrent in GameObject.FindObjectsOfType<TurrentShoot>())
        //      if (Vector3.Distance(turrent.gameObject.transform.position, position) < 1f)
        //          return true;
        return false;
    }
}
