using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Scores : MonoBehaviour
{
    static public Scores Instance { get; private set; }
    static string PATH => Application.persistentDataPath + "/scores.bt"; //accede al fichero 

    public Score current;
    public ScoreList scoreList;



    private void Awake()
    {
        Instance = this;
        Load();
    }

   
    public void Save() 
    {
        scoreList.Add(current);
        File.WriteAllBytes(PATH, Encoding.UTF8.GetBytes(JsonUtility.ToJson(scoreList, false))); // Guarda el fichero como Bytes para que el jugador no pueda editarlos
        current = new Score();

    }

    public void Load()
    {
        if (!File.Exists(PATH)) Save();
        scoreList = JsonUtility.FromJson<ScoreList>(Encoding.UTF8.GetString(File.ReadAllBytes(PATH)));
    }



    private void OnDestroy()
    {
        Instance = null;
    }
    private void OnApplicationQuit()
    {
        OnDestroy();
    }
}
[System.Serializable]
public class ScoreList 
{
    //esto ordena los scores a la inversa a como se haya puesto
    static Comparison<Score> comparisor = new Comparison<Score>((s0, s1) => -s0.Compute().CompareTo(s1.Compute())); //<- comparisor es un objeto que sirve para comparar objetos, también para ordenarlos en una lista

    public List<Score> scores = new List<Score>();

    public void Add(Score score)
    {
        scores.Add(score);
        scores.Sort(comparisor);
        if ( scores.Count >10)
        scores.RemoveAt(scores.Count - 1);
    }

    public override string ToString()
    {
        return scores.Select(s => s.km > 0? s.ToString() : "").Aggregate((a,b) => $"{a}\n\n{b}"); //recorre la lista, obtiene su string por cada elemento, los junta con aggregate, y se ordenan.
    }
}


[System.Serializable]
public class Score 
{
    public float km;
    public float Collectable;

    public float Compute() => Mathf.Clamp(km * (Collectable / 10f + 1) , 0f, 9999f);

    public override string ToString()
    {
        return $"°km: {(km/10f).ToString("0.00")} °Collectable:{Collectable.ToString ("0")}";
    }
}
