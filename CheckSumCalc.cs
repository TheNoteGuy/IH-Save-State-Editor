using System;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class CheckSumCalc
    {
        static private int ChecksumID2;
        static private int _version__102;
        static private System.DateTime _saveDate__103;
        static private int[] _playTimeNumber__105;
        static private int[][] _idleGameSaveNumbers__106;
        static private int[][] _gachaSaveNumbers__107;
        static private int[][] _ascendMainSaveNumbers__108;
        static private int[][] _ascendUpgradesSaveNumbers__110;
        static private int[][] _gachaItemsSaveNumbers__111;
        static private int[][] _equipmentSaveNumbers__112;
        static private int ___0_HexToInt__114;
        static private string _hexValue__115;
        static private string HexConvertedPlayerName;
        static private string PlayerNameLetterChar;
        static private int ___0_SumOfDigitGroups__120;
        static private int _num__121;
        static private int _divisor__122;
        static private int sumClear0;
        static private char[] PlayerNameCharArray;
        static private int @__intnl_SystemInt32_0;
        static private int i;
        static private int sum2Clear0;
        static private int sum3Clear0;
        static private int sum4Clear0;
        static private int sum5Clear0;
        static private int sum6Clear0;
        static private int sum7Clear0;
        static private int sum8Clear0;
        static private int @__intnl_SystemInt32_10;
        static private int iCheckSum0;
        static private int[] numArray;
        static private object[] _upgradesSaveNumbers__109;
        static private string PlayerName;
        
        
        public static int _Clear_0(string PlayerName,int _version__102, DateTime _saveDate__103, int[] _playTimeNumber__105, int[][] _idleGameSaveNumbers__106,int[][] _gachaSaveNumbers__107, int[][] _ascendMainSaveNumbers__108, int[][] _upgradesSaveNumbers__109, int[][] _ascendUpgradesSaveNumbers__110, int[][] _gachaItemsSaveNumbers__111, int[][] _equipmentSaveNumbers__112)
	{
		sumClear0 = 0;
		PlayerNameCharArray = PlayerName.ToCharArray();
		__intnl_SystemInt32_0 = PlayerNameCharArray.Length;
		for (i = 0; (i < __intnl_SystemInt32_0); i = (i + 1))
		{
			PlayerNameLetterChar = PlayerNameCharArray[i].ToString();
			PlayerNameStringToHex();
			_hexValue__115 = HexConvertedPlayerName;
			_fixedUpdate_10();
			sumClear0 = (sumClear0 + ___0_HexToInt__114);
		}
		__intnl_SystemInt32_0 = _playTimeNumber__105[1];
		_num__121 = __intnl_SystemInt32_0;
		_divisor__122 = 100;
		_Clear_2();
		sumClear0 = (sumClear0 + ___0_SumOfDigitGroups__120);
		sumClear0 = sumClear0
					+ _saveDate__103.Year + _saveDate__103.Month
					+ _saveDate__103.DayOfYear * _saveDate__103.Day
					+ (_version__102 - 1) * 25;
        
		sum2Clear0 = 0;
		__intnl_SystemInt32_10 = _idleGameSaveNumbers__106.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _idleGameSaveNumbers__106[iCheckSum0];
			
			//Debug.Log("NumArray1 : "+numArray[1]);
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum2Clear0 = (sum2Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum2Clear0 = (sum2Clear0 * 2);
		sum3Clear0 = 0;
		__intnl_SystemInt32_10 = _gachaSaveNumbers__107.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _gachaSaveNumbers__107[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum3Clear0 = (sum3Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum3Clear0 = (sum3Clear0 * 3);
		sum4Clear0 = 0;
		__intnl_SystemInt32_10 = _ascendMainSaveNumbers__108.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _ascendMainSaveNumbers__108[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum4Clear0 = (sum4Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum4Clear0 = (sum4Clear0 * 4);
		sum5Clear0 = 0;
		__intnl_SystemInt32_10 = _upgradesSaveNumbers__109.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _upgradesSaveNumbers__109[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum5Clear0 = (sum5Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum5Clear0 = (sum5Clear0 * 5);
		sum6Clear0 = 0;
		__intnl_SystemInt32_10 = _ascendUpgradesSaveNumbers__110.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _ascendUpgradesSaveNumbers__110[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum6Clear0 = (sum6Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum6Clear0 = (sum6Clear0 * 6);
		sum7Clear0 = 0;
		__intnl_SystemInt32_10 = _gachaItemsSaveNumbers__111.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _gachaItemsSaveNumbers__111[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum7Clear0 = (sum7Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum7Clear0 = (sum7Clear0 * 7);
		sum8Clear0 = 0;
		__intnl_SystemInt32_10 = _equipmentSaveNumbers__112.Length;
		for (iCheckSum0 = 0; (iCheckSum0 < __intnl_SystemInt32_10); iCheckSum0 = (iCheckSum0 + 1))
		{
			numArray = _equipmentSaveNumbers__112[iCheckSum0];
			if ((numArray != null))
			{
				_num__121 = numArray[1];
				_divisor__122 = 100;
				_Clear_2();
				sum8Clear0 = (sum8Clear0 + ___0_SumOfDigitGroups__120);
			}
		}
		sum8Clear0 = (sum8Clear0 * 8);
		__intnl_SystemInt32_10 = (sumClear0 + sum2Clear0);
		iCheckSum0 = (__intnl_SystemInt32_10 + sum3Clear0);
		ChecksumID2 = (((((iCheckSum0 + sum4Clear0)
					+ sum5Clear0)
					+ sum6Clear0)
					+ sum7Clear0)
					+ sum8Clear0);
		
		return ChecksumID2;
		
	}
        
        private int ChecksumID255;
	static private int _version__139;
	static private System.DateTime _saveDate__140;
	static private string _saveName__141;
	static private int[] _playTimeNumber__142;
	static private int[][] _idleGameSaveNumbers__143;
	static private int[][] _gachaSaveNumbers__144;
	static private int[][] _ascendMainSaveNumbers__145;
	static private int[][] _upgradesSaveNumbers__146;
	static private int[][] _ascendUpgradesSaveNumbers__147;
	static private int[][] _gachaItemsSaveNumbers__148;
	static private int[][] _equipmentSaveNumbers__149;
	static private int sumInt;
	static private char[] @__lcl_saveNameChar_SystemCharArray_1;
	static private int @__intnl_SystemInt32_16;
	static private int @__intnl_SystemInt32_17;
	static private int sum2Int;
	static private int sum3Int;
	static private int sum4Int;
	static private int sum5Int;
	static private int sum6Int;
	static private int sum7Int;
	static private int sum8Int;
	static private int TempCheckSum;
	static private int iCheckSum;
	static private int[] sumIntArray;
	
	public static int _Clear_1(string _saveName__141,int _version__139, DateTime _saveDate__140, int[] _playTimeNumber__142, int[][] _idleGameSaveNumbers__143,int[][] _gachaSaveNumbers__144, int[][] _ascendMainSaveNumbers__145, int[][] _upgradesSaveNumbers__146, int[][] _ascendUpgradesSaveNumbers__147, int[][] _gachaItemsSaveNumbers__148, int[][] _equipmentSaveNumbers__149)
	{
		sumInt = 0;
		__lcl_saveNameChar_SystemCharArray_1 = _saveName__141.ToCharArray();
		__intnl_SystemInt32_16 = __lcl_saveNameChar_SystemCharArray_1.Length;
		for (__intnl_SystemInt32_17 = 0; (__intnl_SystemInt32_17 < __intnl_SystemInt32_16); __intnl_SystemInt32_17 = (__intnl_SystemInt32_17 + 1))
		{
			PlayerNameLetterChar = __lcl_saveNameChar_SystemCharArray_1[__intnl_SystemInt32_17].ToString();
			PlayerNameStringToHex();
			_hexValue__115 = HexConvertedPlayerName;
			_fixedUpdate_10();
			sumInt = (sumInt + ___0_HexToInt__114);
		}
		__intnl_SystemInt32_16 = __lcl_saveNameChar_SystemCharArray_1.Length;
		sumInt = (sumInt * __intnl_SystemInt32_16);
		__intnl_SystemInt32_17 = _playTimeNumber__142[0];
		sumInt = ((((sumInt
					+ (__intnl_SystemInt32_17 * _playTimeNumber__142[1]))
					+ (((_saveDate__140.Year * _saveDate__140.Month)
					* _saveDate__140.DayOfYear)
					* _saveDate__140.Day))
					+ (_version__139 * 4253))
					* 43);
		sum2Int = 3301;
		TempCheckSum = _idleGameSaveNumbers__143.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _idleGameSaveNumbers__143[iCheckSum];
			if ((sumIntArray != null))
			{
				sum2Int = (sum2Int + (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum2Int = (sum2Int * 37);
		sum3Int = 3637;
		TempCheckSum = _gachaSaveNumbers__144.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _gachaSaveNumbers__144[iCheckSum];
			if ((sumIntArray != null))
			{
				sum3Int = (sum3Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum3Int = (sum3Int * 29);
		sum4Int = 4519;
		TempCheckSum = _ascendMainSaveNumbers__145.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _ascendMainSaveNumbers__145[iCheckSum];
			if ((sumIntArray != null))
			{
				sum4Int = (sum4Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum4Int = (sum4Int * 13);
		sum5Int = 5021;
		TempCheckSum = _upgradesSaveNumbers__146.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _upgradesSaveNumbers__146[iCheckSum];
			if ((sumIntArray != null))
			{
				sum5Int = (sum5Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum5Int = (sum5Int * 97);
		sum6Int = 5867;
		TempCheckSum = _ascendUpgradesSaveNumbers__147.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _ascendUpgradesSaveNumbers__147[iCheckSum];
			if ((sumIntArray != null))
			{
				sum6Int = (sum6Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum6Int = (sum6Int * 79);
		sum7Int = 6947;
		TempCheckSum = _gachaItemsSaveNumbers__148.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _gachaItemsSaveNumbers__148[iCheckSum];
			if ((sumIntArray != null))
			{
				sum7Int = (sum7Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum7Int = (sum7Int * 71);
		sum8Int = 6911;
		TempCheckSum = _equipmentSaveNumbers__149.Length;
		for (iCheckSum = 0; (iCheckSum < TempCheckSum); iCheckSum = (iCheckSum + 1))
		{
			sumIntArray = _equipmentSaveNumbers__149[iCheckSum];
			if ((sumIntArray != null))
			{
				sum8Int = (sum8Int
							+ (sumIntArray[0] * sumIntArray[1]));
			}
		}
		sum8Int = (sum8Int * 53);
		TempCheckSum = (sumInt * sum2Int);
		iCheckSum = (sum3Int * sum4Int);
		ChecksumID2 = (((TempCheckSum + iCheckSum)
					+ (sum5Int * sum6Int))
					+ (sum7Int * sum8Int));
		return ChecksumID2;
		
	}
        
        
        static private void _fixedUpdate_10()
        {
	        ___0_HexToInt__114 = int.Parse(_hexValue__115, System.Globalization.NumberStyles.HexNumber);
	        return;
	        PlayerNameStringToHex();
        }
        
        
        static private int @__lcl_sum_SystemInt32_2;
        static private void _Clear_2()
        {
	        __lcl_sum_SystemInt32_2 = 0;
	        for (; (_num__121 > 0); _num__121 = (_num__121 / _divisor__122))
	        {
		        __lcl_sum_SystemInt32_2 = (__lcl_sum_SystemInt32_2 + (_num__121 % _divisor__122));
	        }
	        ___0_SumOfDigitGroups__120 = __lcl_sum_SystemInt32_2;
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
        
        
    }
}