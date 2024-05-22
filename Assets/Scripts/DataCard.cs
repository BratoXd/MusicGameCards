using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewDataCard", menuName = "Scriptable Objects/Card", order = 1)]
public class DataCard : ScriptableObject
{

      public zoneType CurrentCardZone;
  public Image marco;
  public Image fondo;
  public Sprite imageCard;
  public string tipo;
  public string nombre;
  public int Costo;
  public string Apodo;
  public string MelodiaLabel;
  public string ArmoniaLabel;
  public string RitmoLabel;
  public string DireccionLabel;
  public string efectoLabel;


  public int MelodiaScore;
  public int ArmoniaScore;
  public int RitmoScore;
  public int DireccionScore;
  public int efectoScore;


  public int calculatePower(){
    return MelodiaScore + ArmoniaScore + RitmoScore + DireccionScore + efectoScore;
  }

}
