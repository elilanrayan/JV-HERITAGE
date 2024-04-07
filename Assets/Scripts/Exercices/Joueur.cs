using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public string nom = "Rayan";
    public int ID;
    public int IP;

    public static int nbConnectedPlayers = 0;




    private void OnDestroy()
    {
        nbConnectedPlayers--;
    }

    public static void OnCreate()
    {
        nbConnectedPlayers++;
    }

}
