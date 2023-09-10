using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Globalization;
using System.Text;
using Codice.Client.Common.Connection;
using Codice.CM.WorkspaceServer.DataStore.IncomingChanges;
using DefaultNamespace;
using UnityEngine.UIElements;

public class IdelHomeEditorWindow : EditorWindow
{

    public static string SaveFile;
    public static string EditedSaveFile;

    [MenuItem("NoteGuy/Idle Home Editor Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(IdelHomeEditorWindow));
    }


    public static string[] dataDescriptions = new string[256]
    {
        // Basic info
        "ID0 : Name",
        "ID1 : Time of save",
        "ID2 : CheckSum1",
        "ID3 : Playtime",

        // idleGameSaveNumbers
        "ID4 : Money 7 Digits",
        "ID5 : How many zeros to add to number",
        "ID6 : Stage",
        "ID7 : Enemies hit",
        "ID8 : ???",
        "ID9 : ???",
        "ID10 : ???",

        // gachaSaveNumbers
        "ID11 : Keys",
        "ID12 : Something Gacha seed related?",
        "ID13 : ???",
        "ID14 : ???",
        "ID15 : ???",

        // ascendMainSaveNumbers
        "ID16 : Times Ascended",
        "ID17 : Ascension Points 7 Digits",
        "ID18 : How many zeros to add to number",
        "ID19 : ???",

        // upgradesSaveNumbers
        "ID20 : ???",
        "ID21 : Player",
        "ID22 : Dog",
        "ID23 : Cat",
        "ID24 : Rabbit",
        "ID25 : Crow",
        "ID26 : Hamster",
        "ID27 : Snake",
        "ID28 : Hedgehog",
        "ID29 : Frog",
        "ID30 : Alligator",
        "ID31 : Turtle",
        "ID32 : Wolf",
        "ID33 : Fox",
        "ID34 : Deer",
        "ID35 : Kangaroo",
        "ID36 : Giraffe",
        "ID37 : Alpaca",
        "ID38 : Tiger",
        "ID39 : Bear",
        "ID40 : Moose",
        "ID41 : Red Panda",
        "ID42 : Peacock",
        "ID43 : Goose",
        "ID44 : Dolphin",
        "ID45 : Lion",
        "ID46 : Eagle",
        "ID47 : Octopus",
        "ID48 : Narwhal",
        "ID49 : Piranha",
        "ID50 : Crab",
        "ID51 : Golden Crab",
        "ID52 : Arcane Crab",
        "ID53 : Lunar Crab",
        "ID54 : Solar Crab",
        "ID55 : Void Crab",
        "ID56 : Celestial Crab",
        "ID57 : ???",
        "ID58 : ???",
        "ID59 : ???",
        "ID60 : ???",
        "ID61 : ???",
        "ID62 : ???",
        "ID63 : ???",
        "ID64 : ???",
        "ID65 : ???",
        "ID66 : ???",
        "ID67 : ???",
        "ID68 : ???",
        "ID69 : ???",
        "ID70 : ???",
        "ID71 : ???",
        "ID72 : ???",
        "ID73 : ???",
        "ID74 : ???",
        "ID75 : ???",
        "ID76 : ???",
        "ID77 : ???",
        "ID78 : ???",
        "ID79 : ???",
        "ID80 : ???",

        // ascendUpgradesSaveNumbers
        "ID81 : Gem Damage boost (lvl 20)",
        "ID82 : Gacha Dimensional Storage (lvl 50)",
        "ID83 : Daily Gacha Key (lvl 3)",
        "ID84 : Super Pet (lvl 30)",
        "ID85 : Clunker (lvl 5)",
        "ID86 : Potion Station (lvl 64)",
        "ID87 : ???",
        "ID88 : ???",
        "ID89 : ???",
        "ID90 : ???",
        "ID91 : ???",
        "ID92 : ???",
        "ID93 : ???",
        "ID94 : ???",
        "ID95 : ???",
        "ID96 : ???",
        "ID97 : ???",
        "ID98 : ???",
        "ID99 : ???",
        "ID100 : ???",

        // gachaItemsSaveNumbers
        "ID101 : Blueberry",
        "ID102 : Carrot",
        "ID103 : Apple",
        "ID104 : Pear",
        "ID105 : Orange",
        "ID106 : Potato",
        "ID107 : ???",
        "ID108 : ???",
        "ID109 : ???",
        "ID110 : ???",
        "ID111 : ???",
        "ID112 : ???",
        "ID113 : ???",
        "ID114 : ???",
        "ID115 : ???",
        "ID116 : ???",
        "ID117 : ???",
        "ID118 : ???",
        "ID119 : ???",
        "ID120 : ???",
        "ID121 : Broccoli",
        "ID122 : Cucumber",
        "ID123 : Kiwi",
        "ID124 : Avocado",
        "ID125 : Corn",
        "ID126 : Banana",
        "ID127 : Lime",
        "ID128 : ???",
        "ID129 : ???",
        "ID130 : ???",
        "ID131 : ???",
        "ID132 : ???",
        "ID133 : ???",
        "ID134 : ???",
        "ID135 : ???",
        "ID136 : ???",
        "ID137 : ???",
        "ID138 : ???",
        "ID139 : ???",
        "ID140 : ???",
        "ID141 : Pineapple",
        "ID142 : Eggplant",
        "ID143 : Strawberry",
        "ID144 : Grape",
        "ID145 : Chili Pepper",
        "ID146 : Mango",
        "ID147 : Coconut",
        "ID148 : Lemon",
        "ID149 : Watermelon",
        "ID150 : ???",
        "ID151 : ???",
        "ID152 : ???",
        "ID153 : ???",
        "ID154 : ???",
        "ID155 : ???",
        "ID156 : ???",
        "ID157 : ???",
        "ID158 : ???",
        "ID159 : ???",
        "ID160 : ???",
        "ID161 : Unholy Soulflayer",
        "ID162 : The Godpiercer",
        "ID163 : Malachitic Unmaker",
        "ID164 : Wrathful Soulrender",
        "ID165 : Coremaul",
        "ID166 : Resplendent Bulwark",
        "ID167 : Wyvernsaber",
        "ID168 : ???",
        "ID169 : ???",
        "ID170 : ???",
        "ID171 : ???",
        "ID172 : ???",
        "ID173 : ???",
        "ID174 : ???",
        "ID175 : ???",
        "ID176 : ???",
        "ID177 : ???",
        "ID178 : ???",
        "ID179 : ???",
        "ID180 : ???",
        "ID181 : Thaumaturgus",
        "ID182 : Amthys",
        "ID183 : Ankh'hem",
        "ID184 : Archfiend's Fang",
        "ID185 : ???",
        "ID186 : ???",
        "ID187 : ???",
        "ID188 : ???",
        "ID189 : ???",
        "ID190 : ???",
        "ID191 : ???",
        "ID192 : ???",
        "ID193 : ???",
        "ID194 : ???",
        "ID195 : ???",
        "ID196 : ???",
        "ID197 : ???",
        "ID198 : ???",
        "ID199 : ???",
        "ID200 : ???",
        "ID201 : Sword of Power Cooldown",
        "ID202 : Staff of Greed Cooldown",
        "ID203 : Nebula Blade Cooldown",
        "ID204 : Frosthowl Cooldown",
        "ID205 : Infinity Edge Cooldown",
        "ID206 : Unholy Soulflayer Cooldown (None)",
        "ID207 : The Godpiercer Cooldown",
        "ID208 : Malachitic Unmaker Cooldown",
        "ID209 : Wrathful Soulrender Cooldown",
        "ID210 : Coremaul Cooldown",
        "ID211 : Resplendent Bulwark Cooldown",
        "ID212 : Wyvernsaber Cooldown",
        "ID213 : Thaumaturgus Cooldown",
        "ID214 : Amthys Cooldown",
        "ID215 : Ankh'hem Cooldown",
        "ID216 : Archfiend's Fang Cooldown",
        "ID217 : ???",
        "ID218 : ???",
        "ID219 : ???",
        "ID220 : ???",
        "ID221 : ???",
        "ID222 : ???",
        "ID223 : ???",
        "ID224 : ???",
        "ID225 : ???",
        "ID226 : ???",
        "ID227 : ???",
        "ID228 : ???",
        "ID229 : ???",
        "ID230 : ???",
        "ID231 : ???",
        "ID232 : ???",
        "ID233 : ???",
        "ID234 : ???",
        "ID235 : ???",
        "ID236 : ???",
        "ID237 : ???",
        "ID238 : ???",
        "ID239 : ???",
        "ID240 : ???",
        "ID241 : ???",
        "ID242 : ???",
        "ID243 : ???",
        "ID244 : ???",
        "ID245 : ???",
        "ID246 : ???",
        "ID247 : ???",
        "ID248 : ???",
        "ID249 : ???",
        "ID250 : ???",
        "ID251 : ???",
        "ID252 : ???",
        "ID253 : ???",
        "ID254 : ???",
        "ID255 : Checksum2"
    };


    private int[] IDs;
    private int[] values;
    private string name;
    private bool showSections = false;
    static private string[] resultArrayString = new string[256];
    private string textFieldContent = "Enter text here";
    static int[] newArray = new int[256];
    public static Vector2 scrollPos = Vector2.zero;


    private void OnGUI()
    {

        GUILayout.Label("Idle Home Save State Editor", EditorStyles.boldLabel);
        SaveFile = EditorGUILayout.TextField("Save File : ", SaveFile);
        EditedSaveFile = EditorGUILayout.TextField("Edited Save File : ", EditedSaveFile);

        if (GUILayout.Button("Load"))
        {
            IDs = default;
            values = default;
            name = default;
            resultArrayString = new string[256];
            newArray = new int[256];
            
            (IDs, values, name) = Decrypt.Decode(SaveFile);
            
            
            PopulateResultArray(IDs, values, newArray);
            
            for (var i = 0; i < newArray.Length; i++)
            {

                resultArrayString[i] = Convert.ToString(newArray[i]);

            }
            
            resultArrayString[0] = name;
        }

        if (GUILayout.Button("RESET"))
        {
            for (int i = 0; i <= resultArrayString.Length - 1; i++)
            {
                resultArrayString[i] = "0";
                newArray[i] = 0;
            }
        }


        if (GUILayout.Button("Save"))
        {
            
            //Debug.Log(string.Join(" / ", resultArrayString));
            string playername = (FromHexString(resultArrayString[0])); // resultArrayString[0]
            
            //Debug.Log("NAme : " + playername);
            int version = 6;
            
            
            DateTime time = DateTime.ParseExact(resultArrayString[1], "yyMMddfff", null,DateTimeStyles.None); //call time
            //Debug.Log(time);
            int[] playtimenum = new[] { 3, Convert.ToInt32(resultArrayString[3])}; //second num here
            
            
                int startIndex = 4; 
                int endIndex = 11;  
                int length = endIndex - startIndex - 1; 
                int[][] idlegamesavenum = new int[length][];

                
                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    idlegamesavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        idlegamesavenum[i][1] = parsedValue; 
                        idlegamesavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }

            
            
                startIndex = 11; 
                endIndex = 16;  
                length = endIndex - startIndex - 1;
                int[][] gachasavenum = new int[length][];
            
                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    gachasavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        gachasavenum[i][1] = parsedValue; 
                        gachasavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }
            
                startIndex = 16; 
                endIndex = 20;  
                length = endIndex - startIndex - 1;
                int[][] ascentmainsavenum = new int[length][];


                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    ascentmainsavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        ascentmainsavenum[i][1] = parsedValue; 
                        ascentmainsavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }
            
                startIndex = 20; 
                endIndex = 81;   
                length = endIndex - startIndex - 1;
                int[][] upgradesavenum = new int[length][];


                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    upgradesavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        upgradesavenum[i][1] = parsedValue; 
                        upgradesavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }
            
                startIndex = 81; 
                endIndex = 101;   
                length = endIndex - startIndex - 1;
                int[][] ascendupgradessavenum = new int[length][];


                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    ascendupgradessavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        ascendupgradessavenum[i][1] = parsedValue;
                        ascendupgradessavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }
            
                startIndex = 101; 
                endIndex = 201;   
                length = endIndex - startIndex - 1;
                int[][] gachaitemssavenum = new int[length][];


                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    gachaitemssavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        gachaitemssavenum[i][1] = parsedValue;
                        gachaitemssavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number got " + resultArrayString[startIndex + i]);
                    }
                }
            
                startIndex = 201; 
                endIndex = 255;   
                length = endIndex - startIndex - 1;
                int[][] equipmentsavenum = new int[length][];


                for (int i = 0; i < length; i++)
                {
                    int parsedValue;
                    equipmentsavenum[i] = new int[2];
                    if (int.TryParse(resultArrayString[startIndex + i], out parsedValue))
                    {
                        equipmentsavenum[i][1] = parsedValue; 
                        equipmentsavenum[i][0] = startIndex + i;
                    }
                    else
                    {
                        Debug.Log("Something went wrong, could not parse number at ID " + IDs[startIndex + i] + ", expected number and got " + resultArrayString[startIndex + i]);
                    }
                }
            
            int Checksum1 = CheckSumCalc._Clear_0(playername, version, time, playtimenum, idlegamesavenum, gachasavenum,
                ascentmainsavenum, upgradesavenum, ascendupgradessavenum, gachaitemssavenum, equipmentsavenum);
            int Checksum2 = CheckSumCalc._Clear_1(playername, version, time, playtimenum, idlegamesavenum, gachasavenum,
                ascentmainsavenum, upgradesavenum, ascendupgradessavenum, gachaitemssavenum, equipmentsavenum);
            //Debug.Log("Checksum1 : "+Checksum1);
            //Debug.Log("Checksum2 : "+Checksum2);
            for (var i = 1; i < resultArrayString.Length; i++)
            {
                newArray[i] = Convert.ToInt32(resultArrayString[i]);
            }

            EditedSaveFile = Encrypt.encode(newArray, Checksum1, Checksum2, resultArrayString[0], SaveFile.Split('-'));
            
        }

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);


        EditorGUI.indentLevel++;
        for (int i = 0; i < newArray.Length; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(Convert.ToString(dataDescriptions[i]), GUILayout.Width(250));
            resultArrayString[i] = GUILayout.TextField(resultArrayString[i]);
            GUILayout.EndHorizontal();
        }
        EditorGUI.indentLevel--;
        EditorGUILayout.EndScrollView();
    }

    public static string FromHexString(string hexString)
    {
        var bytes = new byte[hexString.Length / 2];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }

        return Encoding.BigEndianUnicode.GetString(bytes); 
    }

    static private void UpdateActualValues()
    {
        for (int i = 0; i < resultArrayString.Length; i++)
        {
            if (resultArrayString[i] != null)
            {
                resultArrayString[i] = Convert.ToString(newArray[i]);;
            }
            else
            {
                resultArrayString[i] = "0";
            }
            resultArrayString[i] = Convert.ToString(newArray[i]);
        }
    }
    



private int DetermineSectionIndex(int id)
    {
        int sectionIndex = -1; 

        if (id < 4) sectionIndex = 0;
        else if (id < 11) sectionIndex = 1;
        else if (id < 16) sectionIndex = 2;
        else if (id < 20) sectionIndex = 3;
        else if (id < 81) sectionIndex = 4;
        else if (id < 101) sectionIndex = 5;
        else if (id < 135) sectionIndex = 6;
        else if (id == 255) sectionIndex = 7;

        //Debug.Log("ID: " + id + ", Section Index: " + sectionIndex);

        return sectionIndex;
    }


    private string GetSectionName(int sectionIndex)
    {
        string[] sectionNames =
        {
            "Basic info", "idleGameSaveNumbers", "gachaSaveNumbers", "ascendMainSaveNumbers",
            "upgradesSaveNumbers", "ascendUpgradesSaveNumbers", "gachaItemsSaveNumbers", "Checksum"
        };

        return sectionNames[sectionIndex];
    }

    
    void PopulateResultArray(int[] ids, int[] Values, int[] NewAray)
    {

        for (int i = 0; i < ids.Length; i++)
        {
            int id = ids[i];

            if (id >= 0 && id < 256)
            {
                NewAray[id] = Values[i]; 
            }
        }

    }

}
