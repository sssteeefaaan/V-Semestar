#include <stdio.h>
#include <iostream>
#include <list>
#include <string>
#include <vector>
#include <map>
using namespace std;

struct Resource {
	string name;
	int value;
};

struct Process {
	string name;
	map<string, Resource> taken;
	map<string, Resource> needed;
};

void bankarovAlgoritam(int** &C, int** &A, int** &Q, int* &V, int* &R, int n, int m);
void prikaziMatrice(int**& C, int**& A, int**& Q, int*& V, int*& Res, int n, int m);

int main()
{
	map<string, Resource> R;
	map<string, Process> P;

	string input1 = "";
	int input2;

	/*while (true)
	{
		cout << "Unesite ime resursa ili KRAJ: " << endl;
		cin >> input1;

		if (input1 == "KRAJ")
			break;

		cout << "Unesite vrednost resursa: " << endl;
		cin >> input2;

		R.insert(pair<string, Resource> (input1, { input1, input2 }));
	}

	int resVal;
	while (true)
	{
		cout << "Unesite ime procesa ili KRAJ:" << endl;
		cin >> input1;

		if (input1 == "KRAJ")
			break;

		P.insert(pair<string, Process>(input1, { input1 }));

		for (map<string, Resource>::iterator entry = R.begin(); entry != R.end(); ++entry)
		{
			cout << "Unesite maksimalnu potrebnu kolicinu resursa '" << entry->second.name << "' je potreno procesu: " << endl;
			cin >> resVal;
			P[input1].needed.insert({ entry->second.name, { entry->second.name, resVal } });

			cout << "Unesite kolicinu resursa '" << entry->second.name << "' koju drzi proces: " << endl;
			cin >> resVal;
			P[input1].taken.insert({entry->second.name, { entry->second.name, resVal }});
		}
	}*/

	R.insert(pair<string, Resource>("R1", { "R1", 200 }));

	P.insert(pair<string, Process>("P1", {"P1"}));
	P["P1"].needed.insert({ "R1", {"R1", 180} });
	P["P1"].taken.insert({ "R1", {"R1", 40} });

	P.insert(pair<string, Process>("P2", { "P2" }));
	P["P2"].needed.insert({ "R1", {"R1", 130} });
	P["P2"].taken.insert({ "R1", {"R1", 75} });

	P.insert(pair<string, Process>("P3", { "P3" }));
	P["P3"].needed.insert({ "R1", {"R1", 50} });
	P["P3"].taken.insert({ "R1", {"R1", 25} });

	P.insert(pair<string, Process>("P4", { "P4" }));
	P["P4"].needed.insert({ "R1", {"R1", 70} });
	P["P4"].taken.insert({ "R1", {"R1", 35} });

	int n = P.size();
	int m = R.size();

	int** C = new int* [n];
	int** A = new int* [n];
	int** Q = new int* [n];

	int* Res = new int[m];
	int* V = new int[m];

	int i = 0, j;
	for (map<string, Process>::iterator it = P.begin(); it != P.end(); ++it)
	{
		C[i] = new int[m];
		A[i] = new int[m];
		Q[i] = new int[m];

		j = 0;
		for (map<string, Resource>::iterator itR = R.begin(); itR != R.end(); ++itR)
		{
			C[i][j] = it->second.needed[itR->second.name].value;
			A[i][j] = it->second.taken[itR->second.name].value;
			Q[i][j] = C[i][j] - A[i][j];

			j++;
		}

		i++;
	}

	j = 0;
	for (map<string, Resource>::iterator itR = R.begin(); itR != R.end(); ++itR)
	{
		Res[j] = itR->second.value;

		V[j] = Res[j];
		for (int p = 0; p < n; p++)
			V[j] -= A[p][j];

		j++;
	}

	prikaziMatrice(C, A, Q, V, Res, n, m);

	bankarovAlgoritam(C, A, Q, V, Res, n, m);

	cout << "Svi procesi su se zavrsili!" << endl;

	prikaziMatrice(C, A, Q, V, Res, n, m);

	if (V)
		delete[] V;
	if (Res)
		delete[] Res;
	if (C)
	{
		for (int i = 0; i < n; i++)
			delete[] C[i];
		delete[] C;
	}
	if (A)
	{
		for (int i = 0; i < n; i++)
			delete[] A[i];
		delete[] A;
	}
	if (Q)
	{
		for (int i = 0; i < n; i++)
			delete[] Q[i];
		delete[] Q;
	}

	return 0;
}
void prikaziMatrice(int**&C, int**&A, int**&Q, int*&V, int*&Res, int n, int m)
{
	cout << endl << "R vector:" << endl;
	cout << "|\t";
	for (int q = 0; q < m; q++)
		cout << Res[q] << "\t";
	cout << "|" << endl;

	cout << endl << "C matrix:" << endl;
	for (int p = 0; p < n; p++)
	{
		cout << "|\t";
		for (int q = 0; q < m; q++)
			cout << C[p][q] << "\t";
		cout << "|" << endl;
	}

	cout << endl << "A matrix:" << endl;
	for (int p = 0; p < n; p++)
	{
		cout << "|\t";
		for (int q = 0; q < m; q++)
			cout << A[p][q] << "\t";
		cout << "|" << endl;
	}

	cout << endl << "Q matrix:" << endl;
	for (int p = 0; p < n; p++)
	{
		cout << "|\t";
		for (int q = 0; q < m; q++)
			cout << Q[p][q] << "\t";
		cout << "|" << endl;
	}

	cout << endl << "V vector:" << endl;
	cout << "|\t";
	for (int q = 0; q < m; q++)
		cout << V[q] << "\t";
	cout << "|" << endl;
}
bool bezbednoStanje()
{
	return true;
}
bool noBlocked(vector<bool>& temp)
{
	bool ret = true;
	int size = temp.size();

	for (int i = 0; i < size; i++)
		ret &= !temp[i];

	return ret;
}
void bankarovAlgoritam(int** &C, int** &A, int** &Q, int* &V, int* &R, int n, int m)
{
	cout << endl << "------------------Bankarov algoritam----------------------" <<endl<< endl;

	int* _V = new int [m];
	int** _A = new int* [n];

	vector<bool> blocked;
	bool tempBlocked;

	for (int i = 0; i < n; i++)
	{
		blocked.push_back(true);
		_A[i] = new int[m];
		for (int j = 0; j < m; j++)
			_A[i][j] = A[i][j];
	}

	while (!noBlocked(blocked))
	{
		for (int i = 0; i < n; i++)
		{
			if (!blocked[i])
				continue;

			for (int j = 0; j < m; j++)
				if (A[i][j] + Q[i][j] > C[i][j])
					throw exception("Proces trazi vise od maksikuma");

			tempBlocked = false;
			for (int j = 0; j < m && !tempBlocked; j++)
			{
				if (tempBlocked = Q[i][j] > V[j])
					cout << "Proces " << i + 1 << " se blokira jer nema dovoljno resursa!" << endl;
			}

			if (!tempBlocked)
			{
				for (int j = 0; j < m; j++)
				{
					_V[j] = V[j] - Q[i][j];
					_A[i][j] = A[i][j] + Q[i][j];
				}

				if (blocked[i] = !bezbednoStanje())
					cout << "Proces " << i + 1 << " se blokira jer dodela resursa ne dovodi u bezbedno stanje!" << endl;
				else
				{
					for (int j = 0; j < m; j++)
					{
						V[j] = V[j] + A[i][j];
						A[i][j] = Q[i][j] = 0;
					}

					cout << "Proces " << i + 1 << " se izvrsio!" << endl;
				}
			}
		}
	}

	if (_V)
		delete[] _V;

	if (_A)
	{
		for (int i = 0; i < n; i++)
			delete[] _A[i];
		delete[] _A;
	}
}