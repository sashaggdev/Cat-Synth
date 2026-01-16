using UnityEngine;

public class CatScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        ChangeSprite(openSprite);
    }

    void OnMouseExit()
    {
        ChangeSprite(closedSprite);
    }
}
