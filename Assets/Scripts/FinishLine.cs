using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem finisheffect;
    private void OnTriggerEnter2D(Collider2D other) {
        //eğer bana player etiketli bir şey dokunursa..
        if(other.tag == "Player")
        {
            Debug.Log("You finished!");
            finisheffect.Play(); //bunu invoke dan önce yazmak önemli. invoke dan önce çalışması için.
            //ayrıca play on awake u kapatmamız gerekiyor ki başta çalışmasın.
            GetComponent<AudioSource>().Play(); //çarpışma gerçekleşince bu gameobject üstündeki audiosource daki müziği çalıştır.
            //SceneManager.LoadScene(0); //0 indexli sahneyi yeniden yüklüyoruz. 
            Invoke("ReloadScene", loadDelay); //reloadscene metodunu ''loadDelay'' saniye sonra çalıştır.
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
