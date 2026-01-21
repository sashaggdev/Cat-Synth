using UnityEngine;

public class CatScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;
    public AudioSource audioSource;
    public float t = 0;
    public AnimationCurve curve;
    public bool HasCatMeowed = false;
    private bool isHovering = false;
    private Vector3 baseScale;
    private Vector2 baseSpriteSize;



    void ChangeSprite(Sprite newSprite)
    {
        Vector2 oldSize = spriteRenderer.bounds.size;

        spriteRenderer.sprite = newSprite;

        Vector2 newSize = spriteRenderer.bounds.size;

        Vector3 scale = transform.localScale;
        scale.x *= oldSize.x / newSize.x;
        scale.y *= oldSize.y / newSize.y;
        transform.localScale = scale;
    }


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        baseScale = transform.localScale;
        baseSpriteSize = spriteRenderer.bounds.size;
    }

    private void Update()
    {
        if (HasCatMeowed && !audioSource.isPlaying) // If the cat has meowed and the sound is finished, reset the flag
        {
            HasCatMeowed = false;
        }

        if (isHovering)                             // If the mouse is hovering over the cat, animate it
        {
            t += Time.deltaTime;
            if (t > 1)
            {
                t = 0;
            }

        // Animation

            float y = curve.Evaluate(t);
            transform.localScale = baseScale * (1 + y * 0.3f);
        }
        else
        {
            t = 0;
            transform.localScale = baseScale;
        }
    }
    void OnMouseEnter()
    {
        isHovering = true;
        ChangeSprite(openSprite);
        spriteRenderer.color.transparent = false;

        if (!HasCatMeowed && !audioSource.isPlaying)    // Play the meow sound only if it hasn't meowed yet and the sound is not already playing
        {
            audioSource.Play();
            HasCatMeowed = true;
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
        ChangeSprite(closedSprite);
    }


}
