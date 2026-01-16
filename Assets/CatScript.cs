using UnityEngine;

public class CatScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //test
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        Debug.Log("Mouse is over the cat!");
        ChangeSprite(openSprite);
    }

    void OnMouseExit()
    {
        ChangeSprite(closedSprite);
    }
}
