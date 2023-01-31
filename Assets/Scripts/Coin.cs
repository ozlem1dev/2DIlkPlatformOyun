using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] AudioClip collectSound;
    public int countCoins = 0;

    private void Awake()
    {
        _text.text = countCoins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            countCoins++;
            Debug.Log(countCoins);
            AudioSource.PlayClipAtPoint(collectSound, collision.transform.position); //Topladýðým coinlerin pozisyonunda çalýnacak.
            //collision.gameObject.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            _text.text = "Coins: " + countCoins.ToString();
        }
    }
}
