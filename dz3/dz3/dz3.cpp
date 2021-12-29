#include <iostream>
#include <sstream>
#include <string>
#include <fstream>

using namespace std;

ofstream f("C:/Users/User/Desktop/testik.txt");

void PovtDouble(string t, int l, int n, int k)
{
	int one = 0, two = 0, three = 0, four = 0, five = 0, six = 0, seven = 0;
	if (l > k)
	{

		for (int i = 0; i < k; i++)
		{
			if (t[i] == '1')
				one++;
			if (t[i] == '2')
				two++;;
			if (t[i] == '3')
				three++;
			if (t[i] == '4')
				four++;
			if (t[i] == '5')
				five++;
			if (t[i] == '6')
				six++;
			if (t[i] == '7')
				seven++;


		}
		if((one <= 1 && two <= 1 && three <= 1 && four <= 1 && five <= 1 && six <= 1 && seven == 2) || 
			 (one <= 1 && two <= 1 && three <= 1 && four <= 1 && five <= 1 && six == 2 && seven <= 1) ||
			 (one <= 1 && two <= 1 && three <= 1 && four <= 1 && five == 2 && six <= 1 && seven <= 1) ||
			 (one <= 1 && two <= 1 && three <= 1 && four == 2 && five <= 1 && six <= 1 && seven <= 1) ||
			 (one <= 1 && two <= 1 && three == 2 && four <= 1 && five <= 1 && six <= 1 && seven <= 1) ||
			 (one <= 1 && two == 2 && three <= 1 && four <= 1 && five <= 1 && six <= 1 && seven <= 1) ||
			 (one == 2 && two <= 1 && three <= 1 && four <= 1 && five <= 1 && six <= 1 && seven <= 1))
		{
			for (int i = 0; i < k; i++)
			{
				if (t[i] == '1')
					t[i] = 'a';
				if (t[i] == '2')
					t[i] = 'b';
				if (t[i] == '3')
					t[i] = 'c';
				if (t[i] == '4')
					t[i] = 'd';
				if (t[i] == '5')
					t[i] = 'e';
				if (t[i] == '6')
					t[i] = 'f';
			}
			f << t << endl;
		}
	}
	else {
		for (int i = 0; i < n; i++)
		{
			ostringstream os;
			os << i + 1;
			PovtDouble(t + os.str(), l + 1, n, k);
		}
	}
}

int main()
{

	int n = 6, WordSize = 5;
	f << "Alphabet : {a, b, c, d, e, f}" << endl;
	PovtDouble("", 1, n, WordSize);
	cout << "File 'testik.txt' filled up" << endl;
	return 0;
}
