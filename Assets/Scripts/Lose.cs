using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject LoseScreen;
    public Generator generator;
    public Move move;
    internal Animator anim;
    float yOffset;

    public bool death = false;
    public float deathDuration = 3f;
    public float deathUpDownDuration = 0.5f;
    public float deathScale = -90f;
    float xRotation;
    public AnimationCurve deathCurve;


    public TMPro.TextMeshProUGUI scoreText;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        Trap.OnTrap += Trap_Ontrap;

    }

    private void Update()
    {
    }
    private void Trap_Ontrap(TrapType trapType) 
    {
        scoreText.text = Scores.Instance.current.ToString();
        move.enabled = false;
        Scores.Instance.Save();
       LoseScreen.SetActive(true);
        generator.enabled= false;
    }
    public IEnumerator killed()
    {
        death = true;
        float d = 0;
        anim.CrossFade("Death", deathUpDownDuration);

        while (d < deathUpDownDuration)
        {
            d += Time.deltaTime;
            xRotation = deathCurve.Evaluate(d / deathUpDownDuration) * deathScale;
            yield return null;
        }

        yield return new WaitForSeconds(deathDuration);
        anim.CrossFade("Run", deathUpDownDuration);
        while (d > 0)
        {
            d -= Time.deltaTime;
            xRotation = deathCurve.Evaluate(d / deathUpDownDuration) * deathScale;
            yield return null;
        }

        death = false;
    }


    private void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.CompareTag("obstacle"))
        {
            StartCoroutine(killed());

        }
    }
}
