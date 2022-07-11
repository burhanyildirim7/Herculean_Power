using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementalControlScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _sagSutunListesi = new List<GameObject>(), _solSutunListesi = new List<GameObject>(), _karakterListesi = new List<GameObject>();
    [SerializeField] GameObject _yikiciObj;
    [SerializeField] Text _powerIncLevelText, _staminaIncLevelText, _incomeIncLevelText, _powerIncBedelText, _staminaIncBedelText, _incomeIncBedelText;
    [SerializeField] int  _powerIncBedelDeger, _staminaIncBedelDeger, _incomeIncBedelDeger;
    [SerializeField] List<int> _incrementalBedel = new List<int>();

    private int _karakteriGeriCekenKuvvetSayaci;



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ButtonlarIcinIlkSefer")==0)
        {
            PlayerPrefs.SetInt("PowerLevelDegeri", 1);
            PlayerPrefs.SetInt("StaminaLevelDegeri", 1);
            PlayerPrefs.SetInt("IncomeLevelDegeri", 0);

            _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
            _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
            _incomeIncLevelText.text = "+$ "+PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();

            _powerIncBedelText.text = "$" + _powerIncBedelDeger.ToString();
            _staminaIncBedelText.text = "$" + _staminaIncBedelDeger.ToString();
            _incomeIncBedelText.text = "$" + _incomeIncBedelDeger.ToString();

            PlayerPrefs.SetInt("ButtonlarIcinIlkSefer", 1);

            PlayerPrefs.SetInt("SutunDegisimSayaci", 1);
            PlayerPrefs.SetInt("KarakterDegisimSayaci", 1);
        }
        else
        {
            _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
            _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
            _incomeIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();
            _powerIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")];
            _staminaIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")];
            _incomeIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {




        }
    }

    public void PowerButonu()
    {
        PlayerPrefs.SetInt("PowerLevelDegeri", PlayerPrefs.GetInt("PowerLevelDegeri") +1);
        PlayerPrefs.SetInt("PowerCostDegeri", PlayerPrefs.GetInt("PowerCostDegeri") + 1);
        PlayerPrefs.SetInt("KarakterDegisimSayaci", PlayerPrefs.GetInt("KarakterDegisimSayaci") + 1);
        _powerIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")];
        if (PlayerPrefs.GetInt("PowerLevelDegeri") == 100)
        {
            _powerIncLevelText.text = "MAX";
        }
        else
        {
            _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
        }



        if (PlayerPrefs.GetInt("KarakterDegisimSayaci") ==5)
        {
            PlayerPrefs.SetInt("KarakterDegisimSayaci", 0);



        }
    }

    public void StaminaButonu()
    {
        PlayerPrefs.SetInt("StaminaLevelDegeri", PlayerPrefs.GetInt("StaminaLevelDegeri") + 1);
        PlayerPrefs.SetInt("StaminaCostDegeri", PlayerPrefs.GetInt("StaminaCostDegeri") + 1);
        _staminaIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")];
        if (PlayerPrefs.GetInt("StaminaLevelDegeri")==100)
        {
            _staminaIncLevelText.text = "MAX";
        }
        else
        {
            _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
        }


    }

    public void IncomeButonu()
    {
        PlayerPrefs.SetInt("IncomeLevelDegeri", PlayerPrefs.GetInt("IncomeLevelDegeri") + 1);
        PlayerPrefs.SetInt("IncomeCostDegeri", PlayerPrefs.GetInt("IncomeCostDegeri") + 1);
        _incomeIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")];
        if (PlayerPrefs.GetInt("StaminaLevelDegeri") == 100)
        {
            _incomeIncLevelText.text = "MAX";
        }
        else
        {
            _incomeIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();
        }

    }

    public void SutunDegis()
    {



    }

    public void KarakterDegis()
    {



    }



}
