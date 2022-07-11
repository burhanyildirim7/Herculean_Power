using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementalControlScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _sagSutunListesi = new List<GameObject>(), _solSutunListesi = new List<GameObject>(), _karakterListesi = new List<GameObject>();
    [SerializeField] GameObject _yikiciObj,_powerButonPasifPaneli, _staminaButonPasifPaneli, _incomeButonPasifPaneli;
    [SerializeField] Text _powerIncLevelText, _staminaIncLevelText, _incomeIncLevelText, _powerIncBedelText, _staminaIncBedelText, _incomeIncBedelText;
    [SerializeField] int  _powerIncBedelDeger, _staminaIncBedelDeger, _incomeIncBedelDeger;
    [SerializeField] List<int> _incrementalBedel = new List<int>();

    private int _karakteriGeriCekenKuvvetSayaci;

    public bool _yikim;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ButtonlarIcinIlkSefer")==0)
        {
            PlayerPrefs.SetInt("SutunDegisimSayaci",0);
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
            PlayerPrefs.SetInt("KarakterDegisimSayaci", 1);
            _powerButonPasifPaneli.SetActive(false);
            _staminaButonPasifPaneli.SetActive(false);
            _incomeButonPasifPaneli.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("PowerLevelDegeri") == 75)
            {
                _powerIncLevelText.text = "MAX";
                _powerIncBedelText.text = "MAX";
                _powerButonPasifPaneli.SetActive(true);

            }
            else
            {
                _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
                _powerIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")];
                _powerButonPasifPaneli.SetActive(false);
            }

            if (PlayerPrefs.GetInt("StaminaLevelDegeri") == 75)
            {
                _staminaIncLevelText.text = "MAX";
                _staminaIncBedelText.text = "MAX";
                _staminaButonPasifPaneli.SetActive(true);
            }
            else
            {
                _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
                _staminaIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")];
                _staminaButonPasifPaneli.SetActive(false);
            }

            if (PlayerPrefs.GetInt("IncomeLevelDegeri") ==75)
            {
                _incomeIncLevelText.text = "MAX";
                _incomeIncBedelText.text = "MAX";
                _incomeButonPasifPaneli.SetActive(true);
            }
            else
            {
                _incomeIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();
                _incomeIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")];
                _incomeButonPasifPaneli.SetActive(false);
            }
        }
        for (int i = 0; i < _karakterListesi.Count; i++)
        {
            if (i==PlayerPrefs.GetInt("KarakterSirasi"))
            {
                _karakterListesi[i].SetActive(true);
            }
            else
            {
                _karakterListesi[i].SetActive(false);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_yikim)
            {
                Debug.Log(PlayerPrefs.GetInt("SutunDegisimSayaci"));
                
                _sagSutunListesi[PlayerPrefs.GetInt("SutunDegisimSayaci")].GetComponent<KinematicAcma>().OpenKinematic();
                _solSutunListesi[PlayerPrefs.GetInt("SutunDegisimSayaci")].GetComponent<KinematicAcma>().OpenKinematic();
            }
        }
    }

    public void PowerButonu()
    {
        if (PlayerPrefs.GetInt("PowerLevelDegeri")<75)
        {
            PlayerPrefs.SetInt("PowerLevelDegeri", PlayerPrefs.GetInt("PowerLevelDegeri") + 1);
            PlayerPrefs.SetInt("PowerCostDegeri", PlayerPrefs.GetInt("PowerCostDegeri") + 1);
            PlayerPrefs.SetInt("KarakterDegisimSayaci", PlayerPrefs.GetInt("KarakterDegisimSayaci") + 1);
            _powerIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")];
            if (PlayerPrefs.GetInt("PowerLevelDegeri") == 75)
            {
                _powerIncLevelText.text = "MAX";
                _powerIncBedelText.text = "MAX";
                _powerButonPasifPaneli.SetActive(true);
            }
            else
            {
                _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
                _powerButonPasifPaneli.SetActive(false);
            }
            if (PlayerPrefs.GetInt("KarakterDegisimSayaci") == 6)
            {
                PlayerPrefs.SetInt("KarakterDegisimSayaci", 1);
                KarakterDegis();
            }
        }
        else
        {

        }
    }

    public void StaminaButonu()
    {
        if (PlayerPrefs.GetInt("StaminaLevelDegeri") <75)
        {
            PlayerPrefs.SetInt("StaminaLevelDegeri", PlayerPrefs.GetInt("StaminaLevelDegeri") + 1);
            PlayerPrefs.SetInt("StaminaCostDegeri", PlayerPrefs.GetInt("StaminaCostDegeri") + 1);
            _staminaIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")];
            if (PlayerPrefs.GetInt("StaminaLevelDegeri") == 75)
            {
                _staminaIncLevelText.text = "MAX";
                _staminaIncBedelText.text = "MAX";
                _staminaButonPasifPaneli.SetActive(true);
            }
            else
            {
                _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
                _staminaButonPasifPaneli.SetActive(false);

            }


        }
        else
        {

        }


    }

    public void IncomeButonu()
    {
        if (PlayerPrefs.GetInt("IncomeLevelDegeri") <75)
        {
            PlayerPrefs.SetInt("IncomeLevelDegeri", PlayerPrefs.GetInt("IncomeLevelDegeri") + 1);
            PlayerPrefs.SetInt("IncomeCostDegeri", PlayerPrefs.GetInt("IncomeCostDegeri") + 1);
            _incomeIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")];
            if (PlayerPrefs.GetInt("IncomeLevelDegeri") == 75)
            {
                _incomeIncLevelText.text = "MAX";
                _incomeIncBedelText.text = "MAX";
                _incomeButonPasifPaneli.SetActive(true);
            }
            else
            {
                _incomeIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();
                _incomeButonPasifPaneli.SetActive(false);
            }
        }
        else
        {

        }
    }

    public void SutunDegis()
    {

    }

    public void KarakterDegis()
    {

        _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].SetActive(false);
        PlayerPrefs.SetInt("KarakterSirasi", PlayerPrefs.GetInt("KarakterSirasi") + 1);
        _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].SetActive(true);

    }



}
