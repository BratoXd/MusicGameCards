using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class CardMovementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToParent = null;
    public Image imageCard;
    public Image marco;
    public Image fondo;

    public TextMeshProUGUI tipo;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI Costo;
    public TextMeshProUGUI Apodo;
    public TextMeshProUGUI MelodiaLabel;
    public TextMeshProUGUI ArmoniaLabel;
    public TextMeshProUGUI RitmoLabel;
    public TextMeshProUGUI DireccionLabel;
    public TextMeshProUGUI efectoLabel;
    public TextMeshProUGUI MelodiaScore;
    public TextMeshProUGUI ArmoniaScore;
    public TextMeshProUGUI RitmoScore;
    public TextMeshProUGUI DireccionScore;
    public TextMeshProUGUI efectoScore;
    public DataCard dataCard;

    void setvaluesCurrentCard()
    {

        DataCard[] dataCards = Resources.LoadAll<DataCard>("DataCards");

        dataCard = dataCards[Random.RandomRange(0, dataCards.Length)];


        imageCard.sprite = dataCard.imageCard;
        marco = dataCard.marco;
        fondo = dataCard.fondo;
        tipo.text = dataCard.tipo;
        nombre.text = dataCard.nombre;
        Costo.text = dataCard.Costo.ToString();
        Apodo.text = dataCard.Apodo;
        /*   MelodiaLabel.text = dataCard.MelodiaLabel;
          ArmoniaLabel.text = dataCard.ArmoniaLabel;
          RitmoLabel.text = dataCard.RitmoLabel;
          DireccionLabel.text = dataCard.DireccionLabel; */
        efectoLabel.text = dataCard.efectoLabel;
        MelodiaScore.text = dataCard.MelodiaScore.ToString(); ;
        ArmoniaScore.text = dataCard.ArmoniaScore.ToString(); ;
        RitmoScore.text = dataCard.RitmoScore.ToString(); ;
        DireccionScore.text = dataCard.DireccionScore.ToString(); ;
        efectoScore.text = dataCard.efectoScore.ToString(); ;
    }
    private void Start()
    {
        setvaluesCurrentCard();


    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("comiezo a dragear");
        returnToParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Termindo de  dragear");
        this.transform.SetParent(returnToParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    // Start is called before the first frame update


}
