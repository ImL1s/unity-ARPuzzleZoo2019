using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public partial class MainUIController : MonoBehaviour
{
    private Button _btnFox;
    private Button _btnGazelle;
    private Button _btnLemur;
    private Button _btnChameleon;
    private Button _btnBoar;

    private readonly Subject<string> _onClickSource = new Subject<string>();

    void Awake()
    {
        InitUiRef();
        InitUiEvent();
        InitRxEvent();
    }
}

/// <summary>
/// init
/// </summary>
partial class MainUIController
{
    void InitUiRef()
    {
        _btnFox = transform.Find("group/btn_fox").GetComponent<Button>();
        _btnGazelle = transform.Find("group/btn_gazelle").GetComponent<Button>();
        _btnLemur = transform.Find("group/btn_lemur").GetComponent<Button>();
        _btnChameleon = transform.Find("group/btn_chameleon").GetComponent<Button>();
        _btnBoar = transform.Find("group/btn_boar").GetComponent<Button>();
    }

    void InitUiEvent()
    {
        _btnFox.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Fox;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnGazelle.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Gazelle;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnLemur.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Lemur;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnChameleon.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Chameleon;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnBoar.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Boar;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
    }

    private void InitRxEvent()
    {
        _onClickSource
            .ThrottleFirst(TimeSpan.FromMilliseconds(2000))
            .Subscribe(SceneManager.LoadScene);
    }

}
