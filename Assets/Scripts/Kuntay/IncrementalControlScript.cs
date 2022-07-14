using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Obi;

public class IncrementalControlScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _sagSutunListesi = new List<GameObject>(), _solSutunListesi = new List<GameObject>(), _karakterListesi = new List<GameObject>();
    [SerializeField] GameObject _yikiciObj, _powerButonPasifPaneli, _staminaButonPasifPaneli, _incomeButonPasifPaneli;
    [SerializeField] Text _powerIncLevelText, _staminaIncLevelText, _incomeIncLevelText, _powerIncBedelText, _staminaIncBedelText, _incomeIncBedelText;
    [SerializeField] int _powerIncBedelDeger, _staminaIncBedelDeger, _incomeIncBedelDeger;
    [SerializeField] List<int> _incrementalBedel = new List<int>();

    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private List<GameObject> _emojiList = new List<GameObject>();

    [SerializeField] private Slider _ustGucSlider;
    [SerializeField] private Slider _altGucSlider;

    private int _karakteriGeriCekenKuvvetSayaci;

    public bool _yikim;

    private float _staminaDeger;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ButtonlarIcinIlkSefer") == 0)
        {
            PlayerPrefs.SetInt("SutunDegisimSayaci", 0);
            PlayerPrefs.SetInt("PowerLevelDegeri", 1);
            PlayerPrefs.SetInt("StaminaLevelDegeri", 1);
            PlayerPrefs.SetInt("IncomeLevelDegeri", 0);

            _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
            _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
            _incomeIncLevelText.text = "+$ " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();

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

            if (PlayerPrefs.GetInt("IncomeLevelDegeri") == 75)
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
            if (i == PlayerPrefs.GetInt("KarakterSirasi"))
            {
                _karakterListesi[i].SetActive(true);
            }
            else
            {
                _karakterListesi[i].SetActive(false);
            }

        }

        BaslangicButonAyarlari();

        _time = 0;
        Animator _karakterAnimation = _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].GetComponent<Animator>();
        _karakterAnimation.SetFloat("Time", _time);

        _ustGucSlider.value = 0;
        _altGucSlider.value = 0;

        _yikim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {



            Animator _karakterAnimation = _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].GetComponent<Animator>();




            if (_time < 0.7f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + 10);
                    UIController.instance.SetGamePlayScoreText();

                    if (_staminaDeger < 22)
                    {
                        _staminaDeger += 1.5f;

                        if (_ustGucSlider.value < _altGucSlider.value)
                        {
                            _ustGucSlider.value += 1;
                        }
                        else
                        {
                            _altGucSlider.value = _ustGucSlider.value;
                            _ustGucSlider.value += 1;
                            _altGucSlider.value = _ustGucSlider.value;
                            //_altGucSlider.value += 1;
                        }


                        //Animator _karakterAnimation = _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].GetComponent<Animator>();
                        if (_time < 0.7f)
                        {
                            _time += 0.05f;
                            _karakterAnimation.SetFloat("Time", _time);
                        }
                        else
                        {

                        }

                    }
                    else
                    {

                    }



                }
                else
                {
                    if (_staminaDeger > 0)
                    {
                        _staminaDeger -= Time.deltaTime * 2;
                    }
                    else
                    {

                    }

                    _staminaSlider.value = _staminaDeger;

                    if (_time > 0)
                    {
                        _time -= 0.0005f;
                        _karakterAnimation.SetFloat("Time", _time);

                        _ustGucSlider.value -= 0.01f;

                    }
                    else
                    {

                    }

                    if (_ustGucSlider.value > _altGucSlider.value)
                    {
                        _altGucSlider.value = _ustGucSlider.value;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                _ustGucSlider.value += Time.deltaTime * 30;
                _altGucSlider.value += Time.deltaTime * 30;
            }


            if (_time > 0.7f && _time < 1)
            {
                _time += Time.deltaTime;
                _karakterAnimation.SetFloat("Time", _time);

                if (_yikim == false)
                {
                    _yikim = true;
                    _karakterListesi[PlayerPrefs.GetInt("KarakterSirasi")].GetComponent<KarakterObiKontrol>().IpleriKopart();

                }
                else
                {

                }



            }
            else
            {

            }


            //GetComponent<ObiParticleAttachment>().attachmentType = ObiParticleAttachment.AttachmentType.Dynamic;

            StaminaSliderEmojileriAyarla();


            if (_yikim)
            {
                Debug.Log(PlayerPrefs.GetInt("SutunDegisimSayaci"));

                _sagSutunListesi[PlayerPrefs.GetInt("SutunDegisimSayaci")].GetComponent<KinematicAcma>().OpenKinematic();
                _solSutunListesi[PlayerPrefs.GetInt("SutunDegisimSayaci")].GetComponent<KinematicAcma>().OpenKinematic();
            }
        }
        else
        {

        }
    }

    private void BaslangicButonAyarlari()
    {
        if (PlayerPrefs.GetInt("totalScore") < _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")])
        {
            _powerButonPasifPaneli.SetActive(true);
        }
        else
        {
            _powerButonPasifPaneli.SetActive(false);
        }

        if (PlayerPrefs.GetInt("totalScore") < _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")])
        {
            _staminaButonPasifPaneli.SetActive(true);
        }
        else
        {
            _staminaButonPasifPaneli.SetActive(false);
        }

        if (PlayerPrefs.GetInt("totalScore") < _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")])
        {
            _incomeButonPasifPaneli.SetActive(true);
        }
        else
        {
            _incomeButonPasifPaneli.SetActive(false);
        }

    }

    private void StaminaSliderEmojileriAyarla()
    {
        if (_staminaDeger <= 2)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[0].SetActive(true);
        }
        else if (_staminaDeger > 2 && _staminaDeger <= 4)
        {
            _emojiList[0].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[1].SetActive(true);
        }
        else if (_staminaDeger > 4 && _staminaDeger <= 6)
        {
            _emojiList[1].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[2].SetActive(true);
        }
        else if (_staminaDeger > 6 && _staminaDeger <= 8)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[3].SetActive(true);
        }
        else if (_staminaDeger > 8 && _staminaDeger <= 10)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[4].SetActive(true);
        }
        else if (_staminaDeger > 10 && _staminaDeger <= 12)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[5].SetActive(true);
        }
        else if (_staminaDeger > 12 && _staminaDeger <= 14)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[6].SetActive(true);
        }
        else if (_staminaDeger > 14 && _staminaDeger <= 16)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[7].SetActive(true);
        }
        else if (_staminaDeger > 16 && _staminaDeger <= 18)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[8].SetActive(true);
        }
        else if (_staminaDeger > 18 && _staminaDeger <= 20)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[10].SetActive(false);
            _emojiList[9].SetActive(true);
        }
        else if (_staminaDeger > 20)
        {
            _emojiList[1].SetActive(false);
            _emojiList[2].SetActive(false);
            _emojiList[3].SetActive(false);
            _emojiList[4].SetActive(false);
            _emojiList[5].SetActive(false);
            _emojiList[6].SetActive(false);
            _emojiList[7].SetActive(false);
            _emojiList[8].SetActive(false);
            _emojiList[9].SetActive(false);
            _emojiList[0].SetActive(false);
            _emojiList[10].SetActive(true);
        }
        else
        {

        }
    }


    public void PowerButonu()
    {
        if (PlayerPrefs.GetInt("PowerLevelDegeri") < 75 && PlayerPrefs.GetInt("totalScore") > _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")])
        {
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")]);
            PlayerPrefs.SetInt("PowerLevelDegeri", PlayerPrefs.GetInt("PowerLevelDegeri") + 1);
            PlayerPrefs.SetInt("PowerCostDegeri", PlayerPrefs.GetInt("PowerCostDegeri") + 1);
            PlayerPrefs.SetInt("KarakterDegisimSayaci", PlayerPrefs.GetInt("KarakterDegisimSayaci") + 1);
            _powerIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("PowerCostDegeri")];
            UIController.instance.SetTapToStartScoreText();


            BaslangicButonAyarlari();

            if (PlayerPrefs.GetInt("PowerLevelDegeri") == 75)
            {
                _powerIncLevelText.text = "MAX";
                _powerIncBedelText.text = "MAX";
                _powerButonPasifPaneli.SetActive(true);
            }
            else
            {
                _powerIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("PowerLevelDegeri").ToString();
                //_powerButonPasifPaneli.SetActive(false);


            }
            if (PlayerPrefs.GetInt("KarakterDegisimSayaci") == 6)
            {
                PlayerPrefs.SetInt("KarakterDegisimSayaci", 1);
                KarakterDegis();
            }
        }
        else
        {
            _powerButonPasifPaneli.SetActive(true);
        }
    }

    public void StaminaButonu()
    {
        if (PlayerPrefs.GetInt("StaminaLevelDegeri") < 75 && PlayerPrefs.GetInt("totalScore") > _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")])
        {
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")]);
            PlayerPrefs.SetInt("StaminaLevelDegeri", PlayerPrefs.GetInt("StaminaLevelDegeri") + 1);
            PlayerPrefs.SetInt("StaminaCostDegeri", PlayerPrefs.GetInt("StaminaCostDegeri") + 1);
            _staminaIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("StaminaCostDegeri")];
            UIController.instance.SetTapToStartScoreText();


            BaslangicButonAyarlari();

            if (PlayerPrefs.GetInt("StaminaLevelDegeri") == 75)
            {
                _staminaIncLevelText.text = "MAX";
                _staminaIncBedelText.text = "MAX";
                _staminaButonPasifPaneli.SetActive(true);
            }
            else
            {
                _staminaIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("StaminaLevelDegeri").ToString();
                //_staminaButonPasifPaneli.SetActive(false);


            }


        }
        else
        {
            _staminaButonPasifPaneli.SetActive(true);
        }


    }

    public void IncomeButonu()
    {
        if (PlayerPrefs.GetInt("IncomeLevelDegeri") < 75 && PlayerPrefs.GetInt("totalScore") > _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")])
        {
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")]);
            PlayerPrefs.SetInt("IncomeLevelDegeri", PlayerPrefs.GetInt("IncomeLevelDegeri") + 1);
            PlayerPrefs.SetInt("IncomeCostDegeri", PlayerPrefs.GetInt("IncomeCostDegeri") + 1);
            _incomeIncBedelText.text = "$" + _incrementalBedel[PlayerPrefs.GetInt("IncomeCostDegeri")];
            UIController.instance.SetTapToStartScoreText();


            BaslangicButonAyarlari();

            if (PlayerPrefs.GetInt("IncomeLevelDegeri") == 75)
            {
                _incomeIncLevelText.text = "MAX";
                _incomeIncBedelText.text = "MAX";
                _incomeButonPasifPaneli.SetActive(true);
            }
            else
            {
                _incomeIncLevelText.text = "LEVEL " + PlayerPrefs.GetInt("IncomeLevelDegeri").ToString();
                //_incomeButonPasifPaneli.SetActive(false);


            }
        }
        else
        {
            _incomeButonPasifPaneli.SetActive(true);
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
