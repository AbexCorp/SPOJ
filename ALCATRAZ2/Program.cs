#include <iostream>
#include <vector>
#include <bitset>

using namespace std;

int money[8];
string allPossibilities[256];
int* pairA;
int* pairB;
int maxMoney = 0;

void EveryoneWent() {
    for (int i = 0; i < 8; i++) {
        maxMoney += money[i];
    }
}

void FillPossibilities() {
    for (int i = 0; i <= 255; i++) {
        allPossibilities[i] = bitset<8>(i).to_string();
    }
}

void CheckPossibilities() {
    for (int i = 0; i <= 255; i++) {
        string current = allPossibilities[i];
        bool valid = true;
        for (int j = 0; j < sizeof(pairA); j++) {
            if (current[pairA[j] - 1] == '1' && current[pairB[j] - 1] == '1') {
                valid = false;
                break;
            }
        }
        if (!valid)
            continue;

        int currentMoney = 0;
        for (int j = 0; j < 8; j++) {
            if (current[j] == '1')
                currentMoney += money[j];
        }
        if (currentMoney > maxMoney)
            maxMoney = currentMoney;
    }
}

int main() {
    for (int i = 0; i < 8; i++) {
        cin >> money[i];
    }

    int numberOfPairs;
    cin >> numberOfPairs;

    if (numberOfPairs == 0) {
        EveryoneWent();
        cout << maxMoney << endl;
        return 0;
    }

    pairA = new int[numberOfPairs];
    pairB = new int[numberOfPairs];

    for (int i = 0; i < numberOfPairs; i++) {
        cin >> pairA[i] >> pairB[i];
    }

    FillPossibilities();
    CheckPossibilities();

    cout << maxMoney << endl;

    // Deallocate memory
    delete[] pairA;
    delete[] pairB;

    return 0;
}