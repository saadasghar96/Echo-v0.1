#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class AnchorSetter : EditorWindow
{
    public GameObject Adsprefab;

    [MenuItem("Salman/Delete All Player Preferences")]
    private static void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        EditorUtility.DisplayDialog("Successful", "The preferences has been deleted successfully", "OK");
    }
    
    [MenuItem("Salman/Ads Initializer")]
    private static void init()
    {
        //GameObject instanceObject;
        //var manager = Resources.Load("Prefabs/_ads_manager");
        //if (GameObject.FindObjectOfType<_ads_manager>())
        //{
        //    EditorUtility.DisplayDialog("Advertisement already added", "The prefab has already been added!", "OK");
        //}
        //else
        //{
        //    if (manager)
        //    {
        //        if (EditorUtility.DisplayDialog("Advertisement Successfully added", "Make sure you are working on the first scene that comes right after splash sceen. \n\nThankyou! \nBy Salman Khan.", "OK", "Cancel"))
        //        {
        //            instanceObject = (GameObject)EditorUtility.InstantiatePrefab(manager);
        //        }
        //    }
        //}
        EditorUtility.DisplayDialog("Rewarded Prefab", "To Edit Rewarded Fail to load Prefab, its located in Resources -> Prefabs.", "OK");
        //		if (EditorUtility.DisplayDialog ("Native Ads Manager", "Are you using native Ads in your project.", "Yes", "No")) {
        //			GameObject instanceObject2;
        //			var _camera = Resources.Load ("Prefabs/camera");
        //			if (GameObject.FindObjectOfType<NativeAdvance_Manager> ()) {
        //				EditorUtility.DisplayDialog ("Native Ads Manager already added", "The prefab has already been added!", "OK");
        //			} else {
        //				if (manager) {
        //						instanceObject = (GameObject)EditorUtility.InstantiatePrefab (_camera);
        //				}
        //
        //			}
        //		}
        //			_ads_maker window = ScriptableObject.CreateInstance<_ads_maker> ();
        //			window.position = new Rect (new Vector2(Screen.width/2, Screen.height/2), new Vector2(500,150));
        //			window.ShowPopup ();
    }
    //		void OnGUI()
    //		{
    //			EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
    //			GUILayout.Space(70);
    //			if (GUILayout.Button("Agree!")) this.Close();
    //		}

    [MenuItem("Helper/Anchor Setter/Set Anchors to Corners for Selected GameObject #Z")]
    static void AnchorsToCorners_per_object()
    {
        if (Selection.activeGameObject.GetComponent<RectTransform>() == null)
            return;
        RectTransform t = Selection.activeTransform as RectTransform;
        RectTransform pt = Selection.activeTransform.parent as RectTransform;

        if (t == null || pt == null)
            return;

        Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                    t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                    t.anchorMax.y + t.offsetMax.y / pt.rect.height);

        t.anchorMin = newAnchorsMin;
        t.anchorMax = newAnchorsMax;
        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("Helper/Anchor Setter/Set Anchors to Corners for Selected GameObjects #X")]
    static void AnchorsToCorners_per_multiple_selected_Objects()
    {
        if (Selection.activeGameObject.GetComponent<RectTransform>() == null)
            return;
        GameObject[] temp = Selection.gameObjects;
        RectTransform[] t = new RectTransform[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            t[i] = temp[i].GetComponent<RectTransform>();
        }

        if (t == null)
            return;

        for (int i = 0; i < t.Length; i++)
        {
            Vector2 newAnchorsMin = new Vector2(t[i].anchorMin.x + t[i].offsetMin.x / t[i].parent.GetComponent<RectTransform>().rect.width,
                                        t[i].anchorMin.y + t[i].offsetMin.y / t[i].parent.GetComponent<RectTransform>().rect.height);
            Vector2 newAnchorsMax = new Vector2(t[i].anchorMax.x + t[i].offsetMax.x / t[i].parent.GetComponent<RectTransform>().rect.width,
                                        t[i].anchorMax.y + t[i].offsetMax.y / t[i].parent.GetComponent<RectTransform>().rect.height);

            t[i].anchorMin = newAnchorsMin;
            t[i].anchorMax = newAnchorsMax;
            t[i].offsetMin = t[i].offsetMax = new Vector2(0, 0);
        }
    }
    //		}
    [MenuItem("Helper/Anchor Setter/Set Anchors to Corners for Whole Canvas % & C")]
    static void AnchorsToCorners_for_all_child_in_canvas()
    {
        if (Selection.activeGameObject.GetComponent<Canvas>())
        {
            if (EditorUtility.DisplayDialog("Set Anchors to Corners", "Set Anchors to Corners of every Child in Canvas. \n\nAre you sure you want to continue?", "OK", "Cancel"))
            {
                GameObject canvas = Selection.activeGameObject as GameObject;
                //		foreach(RectTransform t in canvas){
                //		RectTransform[] t = Selection.activeTransform as RectTransform;
                //		RectTransform[] pt = Selection.activeTransform.parent as RectTransform;

                RectTransform[] t = canvas.GetComponentsInChildren<RectTransform>(true);

                if (t == null)
                    return;

                for (int i = 1; i < t.Length; i++)
                {
                    Vector2 newAnchorsMin = new Vector2(t[i].anchorMin.x + t[i].offsetMin.x / t[i].parent.GetComponent<RectTransform>().rect.width,
                                                t[i].anchorMin.y + t[i].offsetMin.y / t[i].parent.GetComponent<RectTransform>().rect.height);
                    Vector2 newAnchorsMax = new Vector2(t[i].anchorMax.x + t[i].offsetMax.x / t[i].parent.GetComponent<RectTransform>().rect.width,
                                                t[i].anchorMax.y + t[i].offsetMax.y / t[i].parent.GetComponent<RectTransform>().rect.height);

                    t[i].anchorMin = newAnchorsMin;
                    t[i].anchorMax = newAnchorsMax;
                    t[i].offsetMin = t[i].offsetMax = new Vector2(0, 0);
                }
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Canvas Not Selected", "only works if your current selected GameObject is Canvas!", "OK");
        }
    }
}
#endif