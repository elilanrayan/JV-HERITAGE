using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;
    public PokemonDataBase database;
    public PokemonData GetData(int id) => database.datas[id];

    public int GetCount() => database.datas.Count;

    public DatabaseManager(PokemonDataBase dataBase) { this.database = database; }

    public void Awake()
    {
        if (instance == null)
            instance =this;

        database.CreateData();
    }

    public static DatabaseManager GetInstance()
    {
        return instance;
    }

}
