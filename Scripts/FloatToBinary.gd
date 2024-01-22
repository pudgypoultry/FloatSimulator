extends Node

func FloatToBinaryString(initial : float):
	var returnArray = []
	for i in range(32):
		returnArray.append(0)
	
	var byteArray = PackedByteArray()
	for i in range(4):
		byteArray.append(0)
	
	var i = 0
	byteArray.encode_float(0, initial)
	byteArray.reverse()
	
	for item in byteArray:
		var currentBinNumber = bin_string(item)
		
		for char in currentBinNumber:
			returnArray[i] = str_to_var(char)
			i += 1
	
	return returnArray


func IntArrayToFloat(initial):
	var byteArray = PackedByteArray()
	for i in range(4):
		byteArray.append(0)
	
	var i = 0
	
	for k in range(4):
		for j in range(8):
			byteArray[k] = byteArray[k] << 1
			
			if initial[i] == 1:
				byteArray[k] += 1
			
			i += 1
	
	byteArray.reverse()
	return byteArray.decode_float(0)


func bin_string(n):
	var ret_str = ""
	while n > 0 or ret_str.length() < 8:
		ret_str = var_to_str(n&1) + ret_str
		n = n >> 1
	return ret_str
