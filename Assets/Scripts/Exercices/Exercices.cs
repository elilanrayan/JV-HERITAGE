using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercices : MonoBehaviour
{
    public string nom;
    public string langue;
    public int hauteur;
    public int largeur;

    private static Exercices instance;
    Exercices(string nom,string langue,int hauteur,int largeur) 
    {
        this.nom = nom;
        this.langue = langue;
        this.hauteur = hauteur;
        this.largeur=largeur;
    }


    void Start()
    {
        if (instance == null)
            instance = new Exercices("Rayan","Anglais",22,12);
        Debug.Log(instance.nom);
        Debug.Log(instance.langue);
        Debug.Log(instance.hauteur);
        Debug.Log(instance.largeur);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
