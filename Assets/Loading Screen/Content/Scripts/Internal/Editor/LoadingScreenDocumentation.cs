using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tutorial.Wizard.LoadingScreen;
using System;

public class LoadingScreenDocumentation : TutorialWizard
{
    //required//////////////////////////////////////////////////////
    public string FolderPath = "loading-screen/editor/";
    public NetworkImages[] ServerImages = new NetworkImages[]
    {
        new NetworkImages{Name = "img-0.jpg", Image = null},
        new NetworkImages{Name = "img-1.png", Image = null},
        new NetworkImages{Name = "img-2.png", Image = null},
        new NetworkImages{Name = "img-3.png", Image = null},
        new NetworkImages{Name = "img-4.png", Image = null},
        new NetworkImages{Name = "img-5.png", Image = null},
        new NetworkImages{Name = "img-6.png", Image = null},
        new NetworkImages{Name = "img-7.png", Image = null},
        new NetworkImages{Name = "img-8.png", Image = null},
        new NetworkImages{Name = "img-9.png", Image = null},
    };
    public Steps[] AllSteps = new Steps[] {
     new Steps { Name = "Get Started", StepsLenght = 0 },
    new Steps { Name = "Load by Button", StepsLenght = 0 },
    new Steps { Name = "Load by Code", StepsLenght = 0 },
    new Steps { Name = "Add new scene", StepsLenght = 0 },
    new Steps { Name = "Load Type", StepsLenght = 0 },
    new Steps { Name = "Edit UI", StepsLenght = 0 },
    new Steps { Name = "Add Tips", StepsLenght = 0 },
    new Steps { Name = "bl_SceneLoader", StepsLenght = 0 },
    };

    public override void OnEnable()
    {
        base.OnEnable();
        base.Initizalized(ServerImages, AllSteps, FolderPath);
    }

    public override void WindowArea(int window)
    {
        if (window == 0) { DrawGetStarted(); }
        else if (window == 1) { LoadByButton(); }
        else if (window == 2) { DrawLoadByCode(); }
        else if (window == 3) { DrawAddNewScene(); }
        else if (window == 4) { DrawLoadType(); }
        else if (window == 5) { DrawEditUI(); }
        else if (window == 6) { DrawAddTips(); }
        else if (window == 7) { DrawblSceneLoader(); }
    }

    //final required////////////////////////////////////////////////

    void DrawGetStarted()
    {
        if (subStep == 0)
        {
            DrawText("<b>Requires:</b>\n\nUnity 2018.4++\n\n- After Import the package in your Unity Project, go to the <i>(Toolbar)</i>Window -> Loading Screen -> (Click) <b>Add Levels</b>.\n\n- Fill all information of your scenes in SceneLoaderManager <i>(check the Add Scene section)</i>.\n\n- Drag one of the <b>SceneLoaders</b> prefabs inside of a Canvas in your scene, the prefabs are located in: <i>Assets->Loading Screen->Content->Prefabs->SceneLoaders->*</i>\n");
            DrawServerImage(0);
            DrawText("Drag one of the prefab inside a Canvas in your scene");
            DrawServerImage(1);
            DrawText("Now you can use modify the design if you want and use it to load your levels asynchronously (see the Usage section)\n");
        }
    }

    void LoadByButton()
    {
        DrawText("For load a scene by a button you have two simple options:\n\n1 - Simple attach the script bl_ButtonSceneLoad.cs to the UI Button and then set the scene name to load in the inspector of the script and that's.\n");
        DrawServerImage(9);
        DownArrow();
        DrawText("2 - Add the <b>bl_SceneLoader</b> script <i>(from the scene)</i> directly in the UI Button -> OnClick list pointing to LoadLevel function.\n\n- After you have the <b>'LoadingScreen'</b> prefab in the canvas of your scene, select the button that you want to use and setup like this:\n");
        DrawServerImage(2);
        DrawText("That's");
    }

    private void DrawLoadByCode()
    {
        DrawText("Load a scene by script is really simple, instead of use the default Unity method:\n");
        DrawCodeText("SceneManager.LoadScene('SCENE_NAME');");
        DrawText("Just replace with:");
        DrawCodeText("bl_SceneLoaderUtils.GetLoader.LoadLevel('SCENE_NAME');");
        DrawText("That's!, is that simple :)");
    }

    private void DrawAddNewScene()
    {
        DrawText("To load scenes you should be added to the list \"SceneList\" of  \"SceneLoaderManager\" to make you simply must:\n\nTo automatically setup all scenes listed in Build Settings, simple click in: Window -> Loading Screen -> <b>Add Levels</b>.\n");
        DrawServerImage(3);
        DrawText("with this all your scenes will added on the list of Loading Screen Manager, then you only need add the Description, Preview Image, Backgrounds,etc.. for add other information see this:\n\nGo to <b>SceneLoaderManager</b> located in:\n");
        DrawServerImage(4);
        DownArrow();
        DrawText("Now foldout the scene or scenes that you have added and fill the required information:\n");
        DrawServerImage(5);
        DrawText("Ready!");
    }

    private void DrawLoadType()
    {
        DrawText("With loading screen you have 2 options for load a level <b>'Async'</b> and <b>'Fake'</b>, both do the same job but with a different process to load the level.\n\n<size=24><b>Async</b>:</size>\nThis is the Unity system for load levels asynchronously in the background, the time it take to load a level depend of the size of level, a level with a lots of models and high resolution textures will take more time to load, there is some cases in which this method will not load smoothly and will make some jumps in the load percentage, unfortunately that is how the internal system <i>(Unity Source side)</i> works.\n\n\n\n<size=24><b>Fake:</b>:</size>\nWith this method as the name say, you simulate the time that take load a level, you can set up how much  in second will take \"load\" the level, this method is useful for small scenes, we not recommend use for large scenes where the time can take much longer depending on each device.\n\n\n\n- So now you know how work each method you decide in witch levels use it, for set up simple go to the scene info in 'SceneLoaderManager' and in the 'LoadType' enum select the option:\n");
        DrawServerImage(6);
    }

    void DrawEditUI()
    {
        DrawText("In order to customize your loading screen design you simple need to take one of the ready made prefabs -> drag inside a Canvas in the hierarchy -> enable the <b>Content</b> game object to preview the UI and start redesign it, we recommend use the prefab: SceneLoader 1 due this have all the requiered components.\n\nYou can delete / modify any UI in the prefab, you can delete any UI without problems due missing it, just setup it as you want, edit sprite, text, size, color,etc...\n");
    }

    void DrawAddTips()
    {
        DrawText("For add / replace 'Tips' text:");
        DrawServerImage(7);
    }

    void DrawblSceneLoader()
    {
        DrawText("The system have alot of customizable variables for you setup the loading screen to your taste, here a brief explanation that each make:");
        DrawServerImage(8);
    }

    [MenuItem("Window/Loading Screen/Documentation")]
    static void Open()
    {
        GetWindow<LoadingScreenDocumentation>();
    }
}