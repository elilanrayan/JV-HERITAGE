using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonController : MonoBehaviour
{
    [SerializeField] private Image _imgSprite;
    [SerializeField] private Text _txtLabel;

    [Header("PV")]
    [SerializeField] private Image _imgPV;
    [SerializeField] private Text _txtPV;
    private PokemonData data;



}
