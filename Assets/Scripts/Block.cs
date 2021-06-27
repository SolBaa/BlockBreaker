using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particle;
    // [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    // / State Variables
    [SerializeField] int timeHits;

    private void Start()
    {
        CountBlocksBreakable();
    }

    private void CountBlocksBreakable()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {

            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {

            timeHits++;
            int maxHits = hitSprites.Length + 1;
            if (timeHits >= maxHits)
            {

                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timeHits - 1;
        if (hitSprites[spriteIndex] != null)
        {

            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Block is missin fro array");
        }

    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(particle, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
