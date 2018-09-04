using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public partial class MainUIController : MonoBehaviour
{
    private Button _btnCrocodile;
    private Button _btnTortoise;
    private Button _btnOtter;
    private Button _btnBird;
    private Button _btnKangaroo;

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
        _btnCrocodile = transform.Find("group/btn_crocodile").GetComponent<Button>();
        _btnTortoise = transform.Find("group/btn_tortoise").GetComponent<Button>();
        _btnOtter = transform.Find("group/btn_otter").GetComponent<Button>();
        _btnBird = transform.Find("group/btn_bird").GetComponent<Button>();
        _btnKangaroo = transform.Find("group/btn_kangaroo").GetComponent<Button>();
    }

    void InitUiEvent()
    {
        _btnCrocodile.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Crocodile;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnTortoise.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Tortoise;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnOtter.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Otter;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnBird.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Bird;
            _onClickSource.OnNext(ConstantValue.Scenes.EBook);
        });
        _btnKangaroo.onClick.AddListener(() =>
        {
            GameController.Instance.CurrentSelectedAnimal = ConstantValue.EBookAnimal.Kangaroo;
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
