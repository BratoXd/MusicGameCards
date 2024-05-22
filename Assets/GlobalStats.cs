using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public TextMeshProUGUI EnergiaGlobalStat_TMP;
    public TextMeshProUGUI AplausosGlobalStat_TMP;


    public int EnergiaGlobalStat;
    public int AplausosGlobalStat;

    public int EnsambleGlobalStat;
    public int RitmoGlobalStat;
    public int ArmoniasGlobalStat;
    public int MelodiasGlobalStat;
    public TextMeshProUGUI EnsambleGlobalStat_TMP;
    public TextMeshProUGUI RitmoGlobalStat_TMP;
    public TextMeshProUGUI ArmoniasGlobalStat_TMP;
    public TextMeshProUGUI MelodiasGlobalStat_TMP;



    // Start is called before the first frame update


 public static GlobalStats instance;
void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }


    void Start()
    {
            

        EnsambleGlobalStat = 0;
        RitmoGlobalStat = 0;
        ArmoniasGlobalStat = 0;
        MelodiasGlobalStat = 0;
    }

   


}
