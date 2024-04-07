using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum pokemonType
{
    feu,
    electrique,
    eau,
    terre,
    vent,
    poison,
    glace,
    métal
}

public class PokemonInfoController : MonoBehaviour
{
    [SerializeField] private Image _imgIcon;
    [SerializeField] private Text _txtName;
    [SerializeField] private Text _size;
    [SerializeField] private Text _weight;
    [SerializeField] private Text _caption;

    PokemonData _data;
    private DatabaseManager _databaseManager;
    private int index=0;
    private int currentHealth;
    public pokemonType[] weakness = { pokemonType.feu, pokemonType.electrique, pokemonType.métal };
    public pokemonType[] strenght = { pokemonType.eau, pokemonType.terre };

    private void Awake()
    {
        _databaseManager = FindFirstObjectByType<DatabaseManager>();
    }


    void Start()
    {
        Affichage(index);
    }

    public void Previous()
    {
        if(index>0) 
        {
            index--;
            Affichage(index); 

        }
        
    }

    public void After()
    {
        if (index < (_databaseManager.GetCount()-1)) 
        {
            index++;
            Affichage(index); 
        }
        
    }

    void Affichage( int _index)
    {
        _data = DatabaseManager.GetInstance().GetData(_index);
        _imgIcon.sprite = _data.icon;
        _txtName.text = $"Nom : {_data.name}";
        _size.text = $"Taille : {_data.size}";
        _weight.text = $"Poids : {_data.weight}";
        _caption.text = $"Description : {_data.caption}";
    }

    void InitCurrentLife(int index)
    {
        _data=_databaseManager.GetData(index);

        currentHealth=_data.statsBase.pv;
    }

    void InitStatsPoints(int index)
    {
        _data = DatabaseManager.GetInstance().GetData(index);
        int AddStats=_data.statsBase.atk+_data.statsBase.pv+_data.statsBase.def;
        
    }

    bool IsPokemonAlive()
    {
        if (currentHealth<=0) return false;
        else return true;
    }



    void TakeDamage(int attack, pokemonType type)
    {
        if (attack > 0 && currentHealth > 0)
        {
            int xpattack = attack;
            foreach (pokemonType w in weakness)
            {
                if (w == type)
                {
                    xpattack = attack * 2;
                    currentHealth -= xpattack;
                  
                    return;

                }

            }
            foreach (pokemonType s in strenght)
            {
                if (s == type)
                {
                    xpattack = attack / 2;
                    currentHealth -= xpattack;
                    return;

                }
            }
            currentHealth -= attack;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }

        }
        else
        {
            Debug.Log("Les dégats sont inférieurs ou égale à O ! ");
        }

    }

    void AttackOpponent()
    {
        if(IsPokemonAlive()==true)
        {
            TakeDamage(default, default);
        }
        else
        {
            Debug.Log("Il ne peux plus attaquer car il a plus de PV");
        }
    }

    public IEnumerator DelayAttack()
    {
        float wait = UnityEngine.Random.Range(1.25f, 3.1f);
        AttackOpponent();
        yield return new WaitForSeconds(wait);

    }
}
 