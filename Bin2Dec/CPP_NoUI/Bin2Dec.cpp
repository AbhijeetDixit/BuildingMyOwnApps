#include <iostream>
#include <climits>
using namespace std;

bool isBinaryStringValid(string bin){
	for(int i = 0; i < bin.length(); i++){
		if(bin[i] != '1' && bin[i] != '0') return false;
	}
	return true;
}

string getBinFromDecimal(int dec){
	string ret = "";
	while(dec){
		ret += ((dec & 0x01) + '0');
		dec = dec >> 1;
	}
	for(int i = 0; i < ret.length()/2; i++){
		char temp = ret[i];
		ret[i] = ret[ret.length()-i];
		ret[ret.length()-i] = temp;
	}
	return ret;
}

int getDecimalFromBin(string bin){
	int ret = 0;
	for(int i = 0; i < bin.length(); i++){
		ret = (ret * 2) + bin[i]-'0';
	}
	return ret;
}

int main(int argc, char const *argv[])
{
	bool exit = false;
	while(!exit){
		cout << "Enter your choice : "<<endl;
		cout << "1. Convert binary to decimal" << endl;
		cout << "2. Convert decimal to binary" << endl;
		cout << "3. Exit"<<endl;
		int choice;
		cin >> choice;
		string bin;
		long inputDec;
		int dec;
		switch(choice){
		case 1:
			cin >> bin;
			if(bin.length() > 32){
				cout << "String too long. Please try again" << endl;
			}else if(!isBinaryStringValid(bin)){
				cout << "Binary string is invalid" << endl;
			}else{
				cout << "Decimal rep is : " << getDecimalFromBin(bin) << endl;
			}
			break;
		case 2:
			cin >> inputDec;
			if(inputDec >= INT_MAX || inputDec <= INT_MIN){
				cout << "Decimal number is beyond limits. Re-enter the number" << endl;
			}else{
				dec = inputDec;
				cout << "Binary rep is : " << getBinFromDecimal(dec) << endl;	
			}
			break;
		case 3: exit = true;
			break;
		default: cout << "Please enter a valid choice" << endl;
			break;
		}
	}
	return 0;
}