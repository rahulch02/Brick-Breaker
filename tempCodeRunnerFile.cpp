#include <iostream>

using namespace std;

int main()
{
    cout<<"[";
    for(int i=0;i<2e4;i++){
        if(i==2e4-1){
            cout<<1;
            continue;
        }
        cout<<1<<",";
    }
    cout<<"]";
    return 0;
}