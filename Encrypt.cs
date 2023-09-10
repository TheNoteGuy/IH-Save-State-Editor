using System.Reflection;

namespace DefaultNamespace
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEditor;
    public class Encrypt
    {
        	private string _saveName;
	static private System.DateTime _lastSaveTime;
	static private string LosslessCompressionEncode;
	static private string _decodedText__91;
	static private bool _IsSaveOnCooldown__172;
	static private string TimeHex;
	static private int _intValue__182;
	static private string ___0_IntToHex2__196;
	static private int _intValue__197;
	static private string SaveNumberToString;
	static private object[] ___0_GetShuffledEncoding__204;
	static private int _seed__205;
	static private string ___0_ReplaceCharacters__207;
	static private string _text__208;
	static private char[] ZeroToFArray2;
	static private char[] AtoZArray2;
	static private string ___0_ReplaceCharacters1To2__213;
	static private string _text__214;
	static private char[] ZeroToZArray2;
	static private object[] shuffledEncoding2;
	static private string ___0_ReverseString__218;
	static private string _str__219;
	static private string FinalSettingsString2;
	static private string EmptySaveString;
	static private string _saveString__229;
	static private string _saveString__231;
	static private string _saveString__233;
	static private System.DateTime @__lcl_now_SystemDateTime_0;
	static private int @__lcl_dateSeed_SystemInt32_0;
	static private string VersionAndTimeString;
	static private int VersionNumber;
	static private int[] playTimeNumber;
	static private object[] idleGameSaveNumbers;
	static private object[] gachaSaveNumbers;
	static private object[] ascendMainSaveNumbers;
	static private object[] upgradesSaveNumbers;
	static private object[] ascendUpgradesSaveNumbers;
	static private object[] gachaItemsSaveNumbers;
	static private object[] equipmentSaveNumbers;
	static private System.DateTime @__lcl_saveDate_SystemDateTime_0;
	static private int @__lcl_checkSum_SystemInt32_0;
	static private int @__lcl_checkSumX_SystemInt32_0;
	static private string TEMPString;
	static private string NullNullAndHexPlayerName;
	static private string @__intnl_SystemString_4;
	static private int copyIndex0;
	static private int TotalLength;
	static private object[] AllsaveNumbersArray;
	static private int[] @__intnl_SystemInt32Array_1;
	static private int[] @__intnl_SystemInt32Array_2;
	static private int TotalIndexLength2;
	static private int[] @__intnl_SystemInt32Array_3;
	static private string[] saveStringsArr;
	static private object[] shuffledEncoding;
	static private char[] ZeroToFArray;
	static private char[] AtoZArray;
	static private char[] ZeroToZArray;
	static private string FirstHalfSaveString;
	static private string FinalSettingsString;
	static private int i7;
	static private int[] num7;
	static private int TotalIndexLength;
	static private int r7;
	static private int TotalLengthMinusi7;
	static private string t7;
	static private char[] chars;
	static private int n;
	static private int setSize;
	static private object[] charSets;
	static private int i2;
	static private int r;
	static private char t;
	static private string @__lcl_replacedText_SystemString_0;
	static private char[] charArr3;
	static private int i3;
	static private int j3;
	static private string encodedText;
	static private char[] decodedArr;
	static private int length;
	static private int i4;
	static private char c4;
	static private int count4;
	static private bool @__intnl_SystemBoolean_111;
	static private string replacedText5;
	static private char[] charArr5;
	static private int i5;
	static private int j5;
	static private char @__intnl_SystemChar_20;
	static private char[] @__lcl_charArr_SystemCharArray_3;
	static private string @__lcl_reverse_SystemString_0;
	static private int @__lcl_i_SystemInt32_13;
	static private int[] AllSaveNumberArrayAti7;
	static private int CheckSumAllIntTogether2;
	static private string PlayerNameLetterChar;
	static string HexConvertedPlayerName;
	static private int posR;
	
	
	//static string EncodedTime = "DC21F8F";
	//private static string SaveFile = "00004E006F00740065004700750079;0327;01DC21F8F;FF835A51E4;05FFFFFFFB;0C8E820E54;061;04895440;151;02229C";

	[MenuItem("IHateThis/Encode")]
	public static string encode(int[] intSave, int ChecksumID2, int ChecksumID255, string nameHex, string[] savefile)
	{
		TEMPString = "";

		intSave[2] = ChecksumID2;
		intSave[255] = ChecksumID255;
		
		Debug.Log("Checksum1 : "+ChecksumID2);
		Debug.Log("Checksum2 : "+ChecksumID255);
		
		saveStringsArr = new string[256];
		saveStringsArr[0] = string.Concat(';', "00" + nameHex);
		
		for (i7 = 1; (i7 < 256); i7 = (i7 + 1))
		{
			num7 = new []{i7, intSave[i7]};
			if ((num7 != null))
			{
				AllSaveNumberArrayAti7 = num7;
				SaveNumberToStringFunc();
				saveStringsArr[i7] = SaveNumberToString;
			}
		}
		i7 = 0;
		for (int i7 = 0; i7 < (256 - 1); i7++)
		{
			posR = Random.Range(i7, (256 - 1));
			t7 = saveStringsArr[posR];
			saveStringsArr[posR] = saveStringsArr[i7];
			
			saveStringsArr[i7] = t7;
		}
		TotalIndexLength = saveStringsArr.Length;
		for (TotalLengthMinusi7 = 0; (TotalLengthMinusi7 < TotalIndexLength); TotalLengthMinusi7 = (TotalLengthMinusi7 + 1))
		{
			TEMPString = (TEMPString + saveStringsArr[TotalLengthMinusi7]);
		}
		TEMPString = TEMPString.Substring(1);
		
		//Debug.Log("TEMPString : " + TEMPString);
		
		
		//EncodedTime = 
		_seed__205 = __lcl_dateSeed_SystemInt32_0;
		GetShuffledEncoding(intSave[1]);
		shuffledEncoding = ___0_GetShuffledEncoding__204;
		ZeroToFArray = "0123456789ABCDEF;".ToCharArray();
		AtoZArray = "ABCDEFGHIJKLMNOPZ".ToCharArray();
		_text__208 = TEMPString;
		ZeroToFArray2 = ZeroToFArray;
		AtoZArray2 = AtoZArray;
		ReplaceSmth();
		TEMPString = ___0_ReplaceCharacters__207;
		_decodedText__91 = TEMPString;
		CompressString();
		TEMPString = LosslessCompressionEncode;
		ZeroToZArray = "0123456789ABCDEFGHIJKLMNOPZ".ToCharArray();
		_text__214 = TEMPString;
		ZeroToZArray2 = ZeroToZArray;
		shuffledEncoding2 = shuffledEncoding;
		ReplaceCharacters1To2Func();
		TEMPString = ___0_ReplaceCharacters1To2__213;
		_str__219 = TEMPString;
		_fixedUpdate_24();
		//Debug.Log(___0_ReverseString__218);

		return (savefile[0] + "-"  + savefile[1] + "-" + ___0_ReverseString__218 + "-" + savefile[3] + "-" + savefile[4] + "---IdleHome");
	}
	static private char @__intnl_SystemChar_1;
	static private string SemiColonAndHexOfSaveNumbere202_0;
	static private void SaveNumberToStringFunc()
	{
		if ((AllSaveNumberArrayAti7[1] == 0))
		{
			SaveNumberToString = "";
			return;
		}
		_intValue__197 = AllSaveNumberArrayAti7[0];
		__intnl_SystemChar_1 = ';';
		_fixedUpdate_9();
		SemiColonAndHexOfSaveNumbere202_0 = string.Concat(__intnl_SystemChar_1, ___0_IntToHex2__196);
		_intValue__182 = AllSaveNumberArrayAti7[1];
		_fixedUpdate_8(); // TimeHex = _saveNumber__202[1]
		SaveNumberToString = (SemiColonAndHexOfSaveNumbere202_0 + TimeHex); 
		return;

	}
	static private void _fixedUpdate_9()
	{
		___0_IntToHex2__196 = _intValue__197.ToString("X2");
		return;

	}
	static private void _fixedUpdate_8()
	{
		TimeHex = _intValue__182.ToString("X");
		return;
	}

        static private void ReplaceSmth()
        {
            if ((ZeroToFArray2.Length != AtoZArray2.Length))
            {
                ___0_ReplaceCharacters__207 = ((string)(null));
                return;
            }
            __lcl_replacedText_SystemString_0 = "";
            charArr3 = _text__208.ToCharArray();
            for (i3 = 0; (i3 < charArr3.Length); i3 = (i3 + 1))
            {
                for (j3 = 0; (j3 < ZeroToFArray2.Length); j3 = (j3 + 1))
                {
                    if (charArr3[i3].Equals(ZeroToFArray2[j3]))
                    {
                        __lcl_replacedText_SystemString_0 = string.Concat(__lcl_replacedText_SystemString_0, AtoZArray2[j3]);
                        break;
                    }
                }
            }
            ___0_ReplaceCharacters__207 = __lcl_replacedText_SystemString_0;
        }
        
        static private void CompressString()
        {
            encodedText = "";
            decodedArr = _decodedText__91.ToCharArray(); // saveString
            length = decodedArr.Length;
            for (i4 = 0; (i4 < length); i4 = (i4 + count4))
            {
                c4 = decodedArr[i4];
                count4 = 1;
                if (((i4 + count4) < length))
                {
                    for (; c4.Equals(decodedArr[(i4 + count4)]);)
                    {
                        count4 = (count4 + 1);
                        if (((i4 + count4) >= length))
                        {
                            break;
                        }
                    }
                }

                if ((count4 >= 2))
                {
                    encodedText = (encodedText + string.Concat(count4.ToString(), c4));
                }
                else
                {
                    encodedText = string.Concat(encodedText, c4);
                }
            }

            LosslessCompressionEncode = encodedText;
            return;

        }
        
        static private string @__lcl_hexValue_SystemString_0;
        static private char[] @__intnl_SystemCharArray_6;
        static private int @__intnl_SystemInt32_123;
        static private int @__intnl_SystemInt32_124;
        static private void PlayerNameStringToHex()
        {
	        __lcl_hexValue_SystemString_0 = "";
	        __intnl_SystemCharArray_6 = PlayerNameLetterChar.ToCharArray();
	        __intnl_SystemInt32_123 = __intnl_SystemCharArray_6.Length;
	        for (__intnl_SystemInt32_124 = 0; (__intnl_SystemInt32_124 < __intnl_SystemInt32_123); __intnl_SystemInt32_124 = (__intnl_SystemInt32_124 + 1))
	        {
		        __lcl_hexValue_SystemString_0 = (__lcl_hexValue_SystemString_0 + System.Convert.ToInt32(__intnl_SystemCharArray_6[__intnl_SystemInt32_124]).ToString("X4"));
	        }
	        HexConvertedPlayerName = __lcl_hexValue_SystemString_0;
	        return;
	        
        }
        
        static private void ReplaceCharacters1To2Func()
        {

            replacedText5 = "";
            charArr5 = _text__214.ToCharArray();
            for (i5 = 0; (i5 < charArr5.Length); i5 = (i5 + 1))
            {
                for (j5 = 0; (j5 < ZeroToZArray2.Length); j5 = (j5 + 1))
                {
                    if (charArr5[i5].Equals(ZeroToZArray2[j5]))
                    {
	                    if (UnityEngine.Random.Range(0F, 1F) < 0.5F)
	                    {
		                    __intnl_SystemChar_20 = ((char[][])shuffledEncoding2)[0][j5];
	                    }
	                    else
	                    {
		                    __intnl_SystemChar_20 = ((char[][])shuffledEncoding2)[1][j5];
	                    }
                        replacedText5 = string.Concat(replacedText5, __intnl_SystemChar_20);
                        break;
                    }
                }
            }
            ___0_ReplaceCharacters1To2__213 = replacedText5;
            return;
            CompressString();
        }
        static private void GetShuffledEncoding(int seed)
        {
	        //int DateSeed = int.Parse(EncodedTime, System.Globalization.NumberStyles.HexNumber);
	        
	        UnityEngine.Random.InitState(seed);
	        chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01".ToCharArray();
	        n = chars.Length;
	        for (i2 = 0; i2 < (n - 1); i2 = (i2 + 1))
	        {
		        r = (i2 + UnityEngine.Random.Range(0, (n - i2)));
		        t = chars[r];
		        chars[r] = chars[i2];
		        chars[i2] = t;
	        }

	        setSize = 27;
	        charSets = new char[2][]; 
	        charSets[0] = new char[setSize];
	        charSets[1] = new char[setSize];

	        for (int i2 = 0; (i2 < setSize); i2 = (i2 + 1))
	        {
		        ((char[])charSets[0])[i2] = chars[i2]; 
	        }
	        for (int i2 = 0; (i2 < setSize); i2 = (i2 + 1))
	        {
		        ((char[])charSets[1])[i2] = chars[(setSize + i2)]; 
	        }

	        ___0_GetShuffledEncoding__204 = charSets; 
	        return;

        }

        static private void _fixedUpdate_24()
        {
	        __lcl_charArr_SystemCharArray_3 = _str__219.ToCharArray();
	        __lcl_reverse_SystemString_0 = "";
	        for (__lcl_i_SystemInt32_13 = (__lcl_charArr_SystemCharArray_3.Length - 1); (__lcl_i_SystemInt32_13 >= 0); __lcl_i_SystemInt32_13 = (__lcl_i_SystemInt32_13 - 1))
	        {
		        __lcl_reverse_SystemString_0 = string.Concat(__lcl_reverse_SystemString_0, __lcl_charArr_SystemCharArray_3[__lcl_i_SystemInt32_13]);
	        }
	        ___0_ReverseString__218 = __lcl_reverse_SystemString_0;
	        return;

        }
        
        
    }
}