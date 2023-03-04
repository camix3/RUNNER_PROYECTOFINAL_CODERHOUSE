using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Pool ItemsPool;
    public Pool SafeItemsPool;

    Queue<Transform> elements;
    public float Increment = 0.01f;
    public float Speed = 6;
    private float speed;
    public Vector3 Direction;
    public Vector3 offset;
    public int Quantity = 25;
    public int SafeQuantity = 3;
    public float Displace = 15f;

    Transform tr;


    Vector3 originalPos;
    float currentDisplace;
    int moved = 0;


    private void Awake()
    {
        ItemsPool.Initialize();
        SafeItemsPool.Initialize();
        tr= transform;
        originalPos = tr.position;
        elements = new Queue<Transform>();
    }

    public void Clean() 
    {
        while (elements.Any()) 
        {
            elements.Dequeue().gameObject.SetActive(false);
        }

    }
    public void Generate()
    {
        
        
        for (int i =0; i <Quantity ; i++) 
        {
            tr.position = originalPos;
            speed = Speed;
            currentDisplace = 0;
            moved = 0;
            var elemntTransform = i < SafeQuantity ? SafeItemsPool.GetRandom() : ItemsPool.GetRandom();
            elemntTransform.position = offset - Direction * Displace * i;
            elemntTransform.gameObject.SetActive(true);
            elements.Enqueue(elemntTransform);
            
        }
    }

    private void Update()
    {
        tr.position += Direction * Speed * Time.deltaTime;

        currentDisplace = Mathf.Abs(Vector3.Distance(tr.position, originalPos));
        var timesToInfinite = currentDisplace / Displace;
        if (timesToInfinite > moved + 2)
            toInfinite();

        Speed += Time.deltaTime * Increment;

    }

    public void toInfinite() 
    {
        var last = elements.LastOrDefault();
        var tel = elements.Dequeue();
        tel.gameObject.SetActive(false);

        var elemntTransform = ItemsPool.GetRandom();
        elemntTransform.position = last.position - Direction * Displace;
        elemntTransform.gameObject.SetActive(true);
        elements.Enqueue(elemntTransform);

        moved++;
    }
}
