using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {
        //tork, rigidbody'ye uygulanacak. bu yüzden buranın değerini çekiyoruz   
        //Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); //oyundaki surfaceeffector2d componentini bulur ve ona yönelir. oyunumuzda bir tane var ve o da zeminde, dolayısıyla onu bulacak...
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RespondToBoost()
    {
        // if we push up, then speed up
        // otherwise stay at normal speed
        // access the surfaceeffector2d and change the speed.
        if(Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed; //tuşa basınca surfaceeffector speedini 30 a eşitle ki karakter daha da hızlansın
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed; //bir şeye basılmıyorsa hız basespeed de kalsın
        }
    }

    void RotatePlayer()
    {
        //burada rb2d den bahsetmek için kodun genelinde rb2d yi class olarak tanıtmak gerekiyor. Eğer tanıtmazsak, sadece start içindeki değeri update içindeki değer okuyamaz, ikisi farklı metotlar.
        if (Input.GetKey(KeyCode.A)) //a tuşuna basarsak ne olur?
            rb2d.AddTorque(torqueAmount);
        //torque un normal döndürmeden farkı şu: normal döndürme yani rotation u değiştirme yerçekimini umursamıyor. addtorque ise yerçekiminin değerine göre döndürme yapıyor yani daha gerçekçi oluyor.
        else if (Input.GetKey(KeyCode.D)) //else if yapmamızın sebebi, iki tuşa aynı anda basıldığında problem olmasını engellemektir.
            rb2d.AddTorque(-torqueAmount);
    }

    //ilk defa burada public kullandık
    public void DisableControls()
    {
        canMove = false; //bool değerleriyle kontrolü iptal ettik.
    }
}
