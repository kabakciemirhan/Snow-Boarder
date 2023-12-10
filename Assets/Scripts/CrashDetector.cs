using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;
    //bunu buraya yazıp sadece audiosource yazmamamızın sebebi, tek karakterde birden çok ses oynatmak istersek burada yeni audioclip değişkenleri yaratarak bunu yapabiliriz.
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        //eğer kafam yere çarparsa...
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls(); //eğer karaktere yere dokunuyorsa, biz karakteri hareket ettiremeyiz. burada, başka gameobjectteki bir metoda da ulaşmış olduk.
            Debug.Log("Ouch! My head!");
            CrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); //belirlediğimiz audioclip'i tek seferde oynat
            //SceneManager.LoadScene(0); //0 indexli sahneyi yeniden yüklüyoruz. 
            Invoke("ReloadScene", loadDelay); //reloadscene metodunu ''loadDelay'' saniye sonra çalıştır.
            //neden capsulecollider da çarpınca bir şey olmuyor? çünkü onda is trigger özelliği açık değil:
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
