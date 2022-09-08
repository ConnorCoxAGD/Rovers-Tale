using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuControl : VisualElement
{
    VisualElement m_home;
    VisualElement m_friends;
    VisualElement m_lore;
    VisualElement m_settings;
    VisualElement s_title;
    VisualElement s_menu;
    bool startClicked = false;

    public new class UxmlFactory : UxmlFactory<MenuControl, UxmlTraits> { } //Allows our visual element to appear as a control in UI Builder
    public MenuControl(){
        RegisterCallback<GeometryChangedEvent>(OnGeometryChanged); //Registers the event GeometryChanged, runs when UI is created or changed.
    }
    //Acts similarly to start in our case. Runs when UI is created or changed. 
    private void OnGeometryChanged(GeometryChangedEvent evt){
        //Find the menus and assign them to variables
        m_home = this.Q("m-home"); //Assigns m_home to the visual element named "m-home"
        m_friends = this.Q("m-friends");
        m_lore = this.Q("m-lore");
        m_settings = this.Q("m-settings");
        this?.Q<Button>().Focus(); //Focuses a button. Useful if you don't have access to pointer controls.
        SetupTopBar();
        SetupHomeMenu();
        if(!startClicked)SetupStartScreen();
    }
    private void SetupStartScreen(){
        s_title = this.Q("s-title");
        s_menu = this.Q("s-menu");
        s_menu.style.display = DisplayStyle.None;
        s_title.style.display = DisplayStyle.Flex; //this means we always start with the title screen on.
        s_title.Focus();


        RegisterCallback<ClickEvent>(ev => StartClicked());
    }
    private void StartClicked(){
        startClicked = true;
        s_title.AddToClassList("opacity-out"); //Add the animation class to fade out.
        UnregisterCallback<ClickEvent>(ev => StartClicked()); //Makes it so that this doesn't run every time we click.
        s_title.RegisterCallback<TransitionEndEvent>(ev => {
            s_title.style.display = DisplayStyle.None;
            s_menu.style.display = DisplayStyle.Flex;
        } );
        
    }
    private void SetupTopBar(){
        this.Q<Button>("b-home").RegisterCallback<ClickEvent>(ev => EnableMenu(m_home));
        this.Q<Button>("b-friends").RegisterCallback<ClickEvent>(ev => EnableMenu(m_friends));
        this.Q<Button>("b-lore").RegisterCallback<ClickEvent>(ev => EnableMenu(m_lore));
        this.Q<Button>("b-settings").RegisterCallback<ClickEvent>(ev => EnableMenu(m_settings));
    }
    private void SetupHomeMenu(){
        m_home?.Q<Button>("b-load").RegisterCallback<ClickEvent>(ev => SceneLoad(1)); //Load button loads scene 1
    }

    private void DisableAllMenus(){
        m_home.style.display = DisplayStyle.None;
        m_friends.style.display = DisplayStyle.None;
        m_lore.style.display = DisplayStyle.None;
        m_settings.style.display = DisplayStyle.None;
    }

    private void EnableMenu(VisualElement menu){
        TimeValue time = new TimeValue(1, TimeUnit.Second);
        DisableAllMenus(); //Disables all menus before enabling the one we'd like to use.
        menu.style.display = DisplayStyle.Flex;
    }

    private void SceneLoad(string scene){
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
    private void SceneLoad(int scene){
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }


}
