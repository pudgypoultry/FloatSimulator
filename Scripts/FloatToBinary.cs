using Godot;
using System;
using System.Collections.Generic;

public partial class FloatToBinary : Node
{

	public int[] FloatToBinaryString(float initial)
	{
		// Need an array of size 32 to return
		int[] returnArray = new int[32];

		// Going to write a foreach loop and use this integer as an iterator that lives outside of the 4 outer iterations
		int i = 0;

		// Use BitConverter class to get the byte representation of the inputted float as 4 ints
		byte[] byteArray = BitConverter.GetBytes(initial);
		// GD.Print("Testing: ", BitConverter.ToSingle(byteArray, 0));
		// Most significant byte is last element of array, need other way around
		Array.Reverse(byteArray);

		// Loop over byteArray...
		foreach (var item in byteArray)
		{
			// Create a string of the binary representation of the integer
			string currentBinNum = Convert.ToString(item, 2);
			// Pad that to be exactly 8 characters, filling in the empty 0's to the left
			string finalBinNum = currentBinNum.PadLeft(8, '0');

			// Go over each of those characters, turn them into int 0's and 1's, and add them to the array
			foreach(char num in finalBinNum)
			{
				returnArray[i] = num - '0';
				i++;
			}
		}

		return returnArray;
	}

	public float IntArrayToFloat(int[] initial)
    {
		// Check for anomalies
		foreach (var item in initial)
        {
			if (item != 0 && item != 1)
            {
				GD.Print("ERROR: Found item that wasn't 0 or 1");
				return 0.0f;
            }
        }

		// Set up the array I'll read into
		byte[] asByteArray = { 0b0, 0b0, 0b0, 0b0 };

		// Set up an iterator to carry through the nested loop
		int i = 0;

		// Loop once for each array of the byte[]
		for (int k = 0; k < 4; k++)
        {
			// Loop once for each bit within the current byte
			for (int j = 0; j < 8; j++)
			{
				// Left-Shift the current byte by one
				asByteArray[k] = (byte)(asByteArray[k] << 0b1);
				
				// If a 1 exists in the current bit, add one to the total byte
				if (initial[i] == 1)
				{
					asByteArray[k] += 0b1;
				}

				// Add one to global iterator
				i++;

				//GD.Print("Current State of byte", k, ": ", asByteArray[k]);
			}
		}

		// BitConverter needs a byte array with the most significant byte as the last index
		Array.Reverse(asByteArray);
		
		// Testing
		/*
		foreach (var item in asByteArray)
        {
			GD.Print(item);
        }
		*/

		return BitConverter.ToSingle(asByteArray, 0);
    }
}
