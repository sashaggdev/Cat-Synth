using UnityEngine;

public class CatScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;
    public AudioSource audioSource;
    public float t = 0;
    public AnimationCurve curve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
        }
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        ChangeSprite(openSprite);
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

        float y = curve.Evaluate(t);

        transform.localScale = new Vector3(1 + y * 0.3f, 1 + y * 0.3f, 1);
    }

    void OnMouseExit()
    {
        ChangeSprite(closedSprite);
    }
}
