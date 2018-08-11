using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class MenuNavigator : Singleton<MenuNavigator>
{
    public string StartMenu = "Main";
    public float TweenInDuration = .3f;
    public float TweenOutDuration = .5f;
    public SceneBinding[] bindings;

    private MenuView[] views;
    private PopUpView popupView;
    private List<MenuView> history = new List<MenuView>();

    public Action<string> OnViewChanged;

    public override void Awake()
    {
        base.Awake();
        views = GetComponentsInChildren<MenuView>(true);
        popupView = GetComponentInChildren<PopUpView>(true);

    }

    void Start()
    {
        SwitchToView(StartMenu);
    }

    #region View Tweening
    public void TweenInView(RectTransform toTween)
    {
        MenuView menuView = toTween.GetComponent<MenuView>();
        history.Add(menuView);

        //set Active
        toTween.gameObject.SetActive(true);

        //scale the view
        toTween.localScale = Vector3.zero;
        toTween.DOScale(Vector3.one, TweenInDuration);

        OnViewChanged?.Invoke(menuView.ViewName);

    }

    private void TweenOutView(MenuView toTween, Action callback = null)
    {
        TweenOutView(toTween.rt, callback);
    }

    private void TweenOutView(RectTransform toTween, Action callback = null)
    {
        toTween.DOScale(Vector3.zero, TweenOutDuration).OnComplete(() => TweenedOut(toTween, callback));
        toTween.DOSizeDelta(new Vector2(1, 0), TweenOutDuration / 2);
    }

    private void TweenedOut(RectTransform toTween, Action callback = null)
    {

        toTween.offsetMax = Vector2.zero;
        toTween.offsetMin = Vector2.zero;

        callback?.Invoke();

        toTween.gameObject.SetActive(false);
    }
    #endregion

    public void SwitchToView(string key)
    {
        key = key.ToLower();

        float delay = 0.1f;
        if (history.Count != 0)
        {
            TweenOutView(history.Last(), () => SceneActionsOnChange(key).ForEach(a => a.Invoke()));
            delay = .5f;
        }
        else
        {
            SceneActionsOnChange(key).ForEach(a => a.Invoke());
        }


        key = CheckSpecialKeys(key);

        foreach (MenuView menuView in views)
        {
            RectTransform rt;
            if (menuView.GetTransformWhenMathing(key, out rt))
            {
                StartCoroutine(DelayedSwitchToView(rt, delay));
            }
        }

    }

    private string CheckSpecialKeys(string key)
    {
        if (key == "back")
            SwitchToPrevious();
        if (key == "exit")
        {
            popupView.SetOptions("Leaving?", "do you realy want to quit?", "Yes", "No", Application.Quit, () => SwitchToView("back"));
            key = "popup";
        }

        return key;
    }

    private List<Action> SceneActionsOnChange(string key)
    {
        List<Action> actions = new List<Action>();
        foreach (SceneBinding sceneBinding in bindings.Where(s => s.buttonSignature.ToLower() == key))
        {

            if (sceneBinding.Unload)
                actions.Add(() => { SceneManager.UnloadSceneAsync(sceneBinding.sceneId); });
            else
                actions.Add(() => { SceneManager.LoadScene(sceneBinding.sceneId, sceneBinding.SceneLoadingMode); });

        }
        return actions;
    }

    private void SwitchToPrevious()
    {
        MenuView view = history[history.Count - 2];
        history.RemoveRange(history.Count - 2, 2);

        StartCoroutine(DelayedSwitchToView(view.rt, .5f));
    }

    public IEnumerator DelayedSwitchToView(RectTransform viewTransform, float delay)
    {
        yield return new WaitForSeconds(delay);
        TweenInView(viewTransform);
    }


    public bool HasView(string key)
    {
        return views.Where(v => v.ViewName.Contains(key)).Count() > 0;
    }

}


