using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
[CustomEditor(typeof(CustomClass))] //CustomClass는 커스텀 Inspector로 표시할 것
public class CustomInspector : Editor
{
    /* Inspector를 그리는 함수 */
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CustomClass customClass = (CustomClass)target;
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Set"))
        {
            customClass.Sample();
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        string[] Options = new string[] { "Change Mode", "Create Mode" };
        int[] OValues = new int[] { 0, 1 };
        int newIntVar3 = EditorGUILayout.IntPopup("C/C", customClass.Change_Create, Options, OValues);

        

        string[] Options2 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        int[] OValues2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int newIntVar4 = EditorGUILayout.IntPopup("Floor", customClass.Floor_Value, Options2, OValues2);

        string[] displayedOptions = new string[] { "Tile","Left_Wall","Right_Wall","North_Corner_Wall",
                                                   "Left_DoorFrame","Right_DoorFrame","Left_Window","Righ_Window","Left_Door","Right_Door",
                                                   "Left_Wall_Deco", "Right_Wall_Deco", "Left_Direction_Furniture" ,"Right_Direction_Furniture",
                                                   "Left_Down_Fence", "Right_Dwon_Fence", "Tile_Deco", "Fence_Deco"};
        int[] optionValues = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        int Buildin_Type_Value = EditorGUILayout.IntPopup("SetType", customClass.Building_Type_Value, displayedOptions, optionValues);

        EditorGUILayout.Space();


        string[] Choosen_Sprite_Package_Options = new string[] {"Wall_Sprite", "Ground_Sprite", "Roof_Sprite", "Window_Sprite", "Door_Sprite", "Storage_Furniture_Sprite","Bedding_Furniture_Sprite","Sitting_Furniture","Fence_Sprite", "Ground_Deco"};
        int[] Choosen_Sprite_Package_Values = new int[] {0,1,2,3,4,5,6,7,8};
        int Choosen_Sprite_Package = EditorGUILayout.IntPopup("Choose_Sprite_Package", customClass.ChangeAble_Sprite_Package, Choosen_Sprite_Package_Options, Choosen_Sprite_Package_Values);


        /* 가변 sprite 배열 선택및 표시 동기화, 미리보기 시작*/



        if (true) // 패키지 0
        {
            List<string> Choosen_Sprite_list = new List<string>();
            List<int> Choosen_Sprite_list2 = new List<int>();
            for (int i = 0; i < customClass.ChangeAble_Sprite_Arr.Length; ++i)
            {
                Choosen_Sprite_list.Add(customClass.ChangeAble_Sprite_Arr[i].name);
                Choosen_Sprite_list2.Add(i);
            }
            string[] Choosen_Sprite_DO = Choosen_Sprite_list.ToArray();
            int[] Choosen_Sprite_OV = Choosen_Sprite_list2.ToArray();
            int Choosen_Sprite_Num = EditorGUILayout.IntPopup("Choose Sprite", customClass.ChangeAble_Sprite_Num, Choosen_Sprite_DO, Choosen_Sprite_OV);

            if (Choosen_Sprite_Num != customClass.ChangeAble_Sprite_Num)
            {
                customClass.ChangeAble_Sprite_Num = Choosen_Sprite_Num;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
            }

            string[] Furniture_displayedOptions = new string[] {"Water","Heating","Storage","Electricity","Bed","TrashCan","Refrigerator","Sit","Farm"};
            int[] Furniture_optionValues = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8};
            int FurnitureAction_Type_Value = EditorGUILayout.IntPopup("Acting Type Set", customClass.Furniture_ActingType_Value, Furniture_displayedOptions, Furniture_optionValues);

            if (FurnitureAction_Type_Value != customClass.Furniture_ActingType_Value)
            {
                customClass.Furniture_ActingType_Value = FurnitureAction_Type_Value;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
            }

            bool Sel1 = EditorGUILayout.Toggle("Select Size 1", customClass.Furniture_Size_1);
            bool Sel2 = EditorGUILayout.Toggle("Select Size 2", customClass.Furniture_Size_2);
            bool Sel4 = EditorGUILayout.Toggle("Select Size 4", customClass.Furniture_Size_4);

            string NowSetting = "none";
            switch (customClass.Furniture_Direction_Value)
            {
                case 0:
                    NowSetting = "Right Up";
                    break;
                case 1:
                    NowSetting = "Right Down";
                    break;
                case 2:
                    NowSetting = "RU_Cannot_Enter";
                    break;
                case 3:
                    NowSetting = "RD_Cannot_Enter";
                    break;
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Toward Right up"))
            {
                customClass.Furniture_Direction_Value = 0;
                EditorUtility.SetDirty(customClass);
            }
            if(GUILayout.Button("Toward Right down"))
            {
                customClass.Furniture_Direction_Value = 1;
                EditorUtility.SetDirty(customClass);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("RU_Cannot_Enter"))
            {
                customClass.Furniture_Direction_Value = 2;
                EditorUtility.SetDirty(customClass);
            }
            GUILayout.Label(NowSetting);
            if(GUILayout.Button("RD_Cannot_Enter"))
            {
                customClass.Furniture_Direction_Value = 3;
                EditorUtility.SetDirty(customClass);
            }
            GUILayout.EndHorizontal();

            

            if (Sel1 != customClass.Furniture_Size_1)
            {
                customClass.Furniture_Size_1 = Sel1;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
                if (customClass.Furniture_Size_1)
                {
                    customClass.Furniture_Size_2 = false;
                    customClass.Furniture_Size_4 = false;
                    EditorUtility.SetDirty(customClass);
                }
            }
            else if (Sel2 != customClass.Furniture_Size_2)
            {
                customClass.Furniture_Size_2 = Sel2;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
                if (customClass.Furniture_Size_2)
                {
                    customClass.Furniture_Size_1 = false;
                    customClass.Furniture_Size_4 = false;
                    EditorUtility.SetDirty(customClass);
                }
            }
            else if (Sel4 != customClass.Furniture_Size_4)
            {
                customClass.Furniture_Size_4 = Sel4;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
                if (customClass.Furniture_Size_4)
                {
                    customClass.Furniture_Size_2 = false;
                    customClass.Furniture_Size_1 = false;
                    EditorUtility.SetDirty(customClass);
                }
            }
            





            float contentWidth = 512f; // 내용물의 전체 너비
            float scrollViewWidth = EditorGUIUtility.currentViewWidth;
            Vector2 scrollPosition = customClass.scrollPosition; // 스크롤뷰의 가운데 위치 계산

            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(450));
            if (scrollPosition != customClass.scrollPosition)
            {
                customClass.scrollPosition = scrollPosition;
                EditorUtility.SetDirty(customClass); // 변경된 값 저장
            }

            if (customClass.Building_Type_Value == 14 || customClass.Building_Type_Value == 15)
            {
                //boolVar = EditorGUILayout.Toggle("My Bool", boolVar);
            }

            
            //GUILayout.BeginHorizontal();

            //if (Choosen_Sprite_Num != 100 && customClass.ChangeAble_Sprite_Arr.Length > 1)
            //{
            //    if (Choosen_Sprite_Num > 1 && Choosen_Sprite_Num - 2 < customClass.ChangeAble_Sprite_Arr.Length)
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_Before2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_Before2, customClass.ChangeAble_Sprite_Arr[Choosen_Sprite_Num - 2].texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    else
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_Before2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_Before2, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    if (Choosen_Sprite_Num > 0 && Choosen_Sprite_Num - 1 < customClass.ChangeAble_Sprite_Arr.Length)
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_Before1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_Before1, customClass.ChangeAble_Sprite_Arr[Choosen_Sprite_Num - 1].texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    else
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_Before1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_Before1, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    EditorGUILayout.Space();
            //    // Sprite 미리보기 영역 생성
            //    if (Choosen_Sprite_Num < customClass.ChangeAble_Sprite_Arr.Length)
            //    {
            //        Rect CS_Focus = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_Focus, customClass.ChangeAble_Sprite_Arr[Choosen_Sprite_Num].texture, ScaleMode.ScaleToFit);
            //    }
            //    EditorGUILayout.Space();

            //    if (Choosen_Sprite_Num < customClass.ChangeAble_Sprite_Arr.Length - 1 && Choosen_Sprite_Num + 1 < customClass.ChangeAble_Sprite_Arr.Length)
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_After1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_After1, customClass.ChangeAble_Sprite_Arr[Choosen_Sprite_Num + 1].texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    else
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_After1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_After1, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    if (Choosen_Sprite_Num < customClass.ChangeAble_Sprite_Arr.Length - 2 && Choosen_Sprite_Num + 2 < customClass.ChangeAble_Sprite_Arr.Length)
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_After2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_After2, customClass.ChangeAble_Sprite_Arr[Choosen_Sprite_Num + 2].texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }
            //    else
            //    {
            //        EditorGUILayout.Space();
            //        Rect CS_After2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            //        EditorGUI.DrawTextureTransparent(CS_After2, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
            //        EditorGUILayout.Space();
            //    }


            //}

            //GUILayout.EndHorizontal();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            for (int i = 0; i < customClass.ChangeAble_Sprite_Arr.Length/2; i++)
            {
                GUILayout.BeginVertical();
                GUILayout.Box(customClass.ChangeAble_Sprite_Arr[i].texture, GUILayout.Width(96), GUILayout.Height(192));
                if (GUILayout.Button("This"))
                {
                    customClass.ChangeAble_Sprite_Num = i;
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            for (int i = customClass.ChangeAble_Sprite_Arr.Length / 2; i < customClass.ChangeAble_Sprite_Arr.Length; i++)
            {
                GUILayout.BeginVertical();
                GUILayout.Box(customClass.ChangeAble_Sprite_Arr[i].texture, GUILayout.Width(96), GUILayout.Height(192));
                if (GUILayout.Button("This"))
                {
                    customClass.ChangeAble_Sprite_Num = i;
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            EditorGUILayout.EndScrollView();


            GUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("Before"))
            {
                if (Choosen_Sprite_Num > 0)
                {
                    Choosen_Sprite_Num--;
                    customClass.ChangeAble_Sprite_Num = Choosen_Sprite_Num;
                    EditorUtility.SetDirty(customClass);
                }
            }
            if (GUILayout.Button("Next"))
            {
                if (Choosen_Sprite_Num < customClass.ChangeAble_Sprite_Arr.Length - 1)
                {
                    Choosen_Sprite_Num++;
                    customClass.ChangeAble_Sprite_Num = Choosen_Sprite_Num;
                    EditorUtility.SetDirty(customClass);
                }
            }
            EditorGUILayout.Space();
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        


        List<string> list = new List<string>();
        List<int> list2 = new List<int>();
        for (int i = 0; i < customClass.Wall_Sprite_Arr.Length; ++i)
        {
            list.Add(customClass.Wall_Sprite_Arr[i].name);
            list2.Add(i);
        }
        string[] displayedOptions2 = list.ToArray();
        int[] optionValues2 = list2.ToArray();
        int Wall_Sprite_Num = EditorGUILayout.IntPopup("Choose Sprite", customClass.Wall_Sprite_Num, displayedOptions2, optionValues2);

        // customClass의 intVar 값을 변경

        GUILayout.BeginHorizontal();

        if (Wall_Sprite_Num != 100&&customClass.Wall_Sprite_Arr.Length>1)
        {
            if (Wall_Sprite_Num > 1 && Wall_Sprite_Num - 2 < customClass.Wall_Sprite_Arr.Length)
            {
                EditorGUILayout.Space();
                Rect previewRectBefore2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRectBefore2, customClass.Wall_Sprite_Arr[Wall_Sprite_Num - 2].texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRectBefore2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRectBefore2, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            if (Wall_Sprite_Num > 0&& Wall_Sprite_Num -1 < customClass.Wall_Sprite_Arr.Length)
            {
                EditorGUILayout.Space();
                Rect previewRectBefore1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRectBefore1, customClass.Wall_Sprite_Arr[Wall_Sprite_Num - 1].texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRectBefore1 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRectBefore1, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            EditorGUILayout.Space();
            // Sprite 미리보기 영역 생성
            if (Wall_Sprite_Num<customClass.Wall_Sprite_Arr.Length)
            {
                Rect previewRectMain = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRectMain, customClass.Wall_Sprite_Arr[Wall_Sprite_Num].texture, ScaleMode.ScaleToFit);
            }
            EditorGUILayout.Space();

            if (Wall_Sprite_Num < customClass.Wall_Sprite_Arr.Length - 1&& Wall_Sprite_Num + 1 < customClass.Wall_Sprite_Arr.Length)
            {
                EditorGUILayout.Space();
                Rect previewRect2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect2, customClass.Wall_Sprite_Arr[Wall_Sprite_Num + 1].texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRect2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect2, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            if (Wall_Sprite_Num < customClass.Wall_Sprite_Arr.Length - 2 && Wall_Sprite_Num + 2 < customClass.Wall_Sprite_Arr.Length)
            {
                EditorGUILayout.Space();
                Rect previewRect2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect2, customClass.Wall_Sprite_Arr[Wall_Sprite_Num + 2].texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRect2 = GUILayoutUtility.GetRect(96, 192, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect2, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }


        }

        
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.Space();
        if (GUILayout.Button("Before"))
        {
            if (Wall_Sprite_Num > 0)
            {
                Wall_Sprite_Num--;
                customClass.Wall_Sprite_Num = Wall_Sprite_Num;
                EditorUtility.SetDirty(customClass);
            }
        }
        if (GUILayout.Button("Next"))
        {
            if (Wall_Sprite_Num < customClass.Wall_Sprite_Arr.Length - 1)
            {
                Wall_Sprite_Num++;
                customClass.Wall_Sprite_Num = Wall_Sprite_Num;
                EditorUtility.SetDirty(customClass);
            }
        }
        EditorGUILayout.Space();
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        List<string> list3 = new List<string>();
        List<int> list4 = new List<int>();
        for (int i = 0; i < customClass.Ground_Sprite_Arr.Length; ++i)
        {
            list3.Add(customClass.Ground_Sprite_Arr[i].name);
            list4.Add(i);
        }
        string[] GroundOptions = list3.ToArray();
        int[] GroundOptionValues = list4.ToArray();
        int GroundSprite_Num = EditorGUILayout.IntPopup("Choose Ground Sprite", customClass.Ground_Sprite_Num, GroundOptions, GroundOptionValues);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Before"))
        {
            if (GroundSprite_Num > 0)
            {
                GroundSprite_Num--;
                customClass.Ground_Sprite_Num = GroundSprite_Num;
                EditorUtility.SetDirty(customClass);
            }
        }

        if (GroundSprite_Num != 100&& customClass.Ground_Sprite_Arr.Length > 1)
        {

            if (GroundSprite_Num > 0)
            {
                EditorGUILayout.Space();
                Rect previewRect_G1 = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect_G1, customClass.Ground_Sprite_Arr[GroundSprite_Num - 1].texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRect_G1 = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect_G1, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
                EditorGUILayout.Space();
            }

            // Sprite 미리보기 영역 생성
            Rect previewRect_G2 = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            EditorGUI.DrawTextureTransparent(previewRect_G2, customClass.Ground_Sprite_Arr[GroundSprite_Num].texture, ScaleMode.ScaleToFit);

            if (GroundSprite_Num < customClass.Ground_Sprite_Arr.Length - 1)
            {
                EditorGUILayout.Space();
                Rect previewRect_G3 = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect_G3, customClass.Ground_Sprite_Arr[GroundSprite_Num + 1].texture, ScaleMode.ScaleToFit);

            }
            else
            {
                EditorGUILayout.Space();
                Rect previewRect_G3 = GUILayoutUtility.GetRect(128, 256, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                EditorGUI.DrawTextureTransparent(previewRect_G3, customClass.DummySpr.texture, ScaleMode.ScaleToFit);
            }


        }

        if (GUILayout.Button("Next"))
        {
            if (GroundSprite_Num < customClass.Ground_Sprite_Arr.Length - 1)
            {
                GroundSprite_Num++;
                customClass.Ground_Sprite_Num = GroundSprite_Num;
                EditorUtility.SetDirty(customClass);
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();


        if (Buildin_Type_Value != customClass.Building_Type_Value)
        {
            customClass.Building_Type_Value = Buildin_Type_Value;
            EditorUtility.SetDirty(customClass); // 변경된 값 저장
        }
        if (Wall_Sprite_Num != customClass.Wall_Sprite_Num)
        {
            customClass.Wall_Sprite_Num = Wall_Sprite_Num;
            EditorUtility.SetDirty(customClass); // 변경된 값 저장
        }
        if (newIntVar3 != customClass.Change_Create)
        {
            customClass.Change_Create = newIntVar3;
            EditorUtility.SetDirty(customClass); // 변경된 값 저장
        }
        if (newIntVar4 != customClass.Floor_Value)
        {
            customClass.Floor_Value = newIntVar4;
            EditorUtility.SetDirty(customClass); // 변경된 값 저장
        }
        if (GroundSprite_Num != customClass.Ground_Sprite_Num)
        {
            customClass.Ground_Sprite_Num = GroundSprite_Num;
            EditorUtility.SetDirty(customClass); // 변경된 값 저장
        }
        if(Choosen_Sprite_Package != customClass.ChangeAble_Sprite_Package)
        {
            customClass.ChangeAble_Sprite_Package = Choosen_Sprite_Package;
            EditorUtility.SetDirty(customClass);
            switch (customClass.ChangeAble_Sprite_Package)
            {
                case 0:
                    bool TF = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Wall_Sprite_Arr);
                    if (TF)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Wall_Sprite_Arr.Length];
                        customClass.Wall_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 1:
                    bool TF2 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Ground_Sprite_Arr);
                    if (TF2)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Ground_Sprite_Arr.Length];
                        customClass.Ground_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 2:
                    bool TF3 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Roof_Sprite_Arr);
                    if (TF3)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Roof_Sprite_Arr.Length];
                        customClass.Roof_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 3:
                    bool TF4 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Window_Sprite_Arr);
                    if (TF4)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Window_Sprite_Arr.Length];
                        customClass.Window_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 4:
                    bool TF5 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Door_Sprite_Arr);
                    if (TF5)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Door_Sprite_Arr.Length];
                        customClass.Door_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 5:
                    bool TF6 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Furniture_Sprite_Arr);
                    if (TF6)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Furniture_Sprite_Arr.Length];
                        customClass.Furniture_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 6:
                    bool TF7 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Bedding_SP_Arr);
                    if (TF7)
                    {
                        
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Bedding_SP_Arr.Length];
                        customClass.Bedding_SP_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 7:
                    bool TF8 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Sitting_SP_Arr);
                    if (TF8)
                    {

                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Sitting_SP_Arr.Length];
                        customClass.Sitting_SP_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 8:
                    bool TF9 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Fence_Sprite_Arr);
                    if (TF9)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Fence_Sprite_Arr.Length];
                        customClass.Fence_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;
                case 9:
                    bool TF10 = customClass.ChangeAble_Sprite_Arr.SequenceEqual(customClass.Ground_Deco_Huge_Sprite_Arr);
                    if (TF10)
                    {
                    }
                    else
                    {
                        customClass.ChangeAble_Sprite_Arr = new Sprite[customClass.Ground_Deco_Huge_Sprite_Arr.Length];
                        customClass.Ground_Deco_Huge_Sprite_Arr.CopyTo(customClass.ChangeAble_Sprite_Arr, 0);
                    }
                    break;


            }
        }

        
    }
}
#endif