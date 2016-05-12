using UnityEngine;
using System.Collections;


public class DelegateScript : MonoBehaviour 
{   
	delegate void MyDelegate(int num);
	MyDelegate myDelegate;

	delegate void OtherDelegate(string str);
	OtherDelegate otherDelegate;

	delegate void MultiDelegate(int num);
	MultiDelegate multipleDelegate;

	void Start () 
	{
		myDelegate = PrintNum;
		myDelegate (50);
		
		myDelegate = DoubleNum;
		myDelegate (50);

		otherDelegate = StringTalk;
		otherDelegate ("Work it ?");
	
		multipleDelegate += PrintNum;
		multipleDelegate += DoubleNum;

		if (multipleDelegate != null)
			multipleDelegate (-1);
	}

	void StringTalk( string str)
	{
		print ("Str: " + str);
	}

	void PrintNum(int num)
	{
		print ("Print Num: " + num);
	}
	
	void DoubleNum(int num)
	{
		print ("Double Num: " + num * 2);
	}
}