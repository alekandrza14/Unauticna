#include <stdio.h>

#include <wchar.h>

#include <stdlib.h>

#include <windows.h>



int main() {

    int s = 1;

    
SetConsoleOutputCP(65001);

    SetConsoleCP(65001);

      FILE *file;

      

    // 

    file = fopen("C:\\data\\solaryAdd", "r");

    

    if (file == NULL) {

        printf("\n");

        return 1;

    }

    

    int number = 0;

    

    //
    fscanf(file, "%d", &number);

    

    fclose(file);
if(s==1)
{
FILE *f = _wfopen(L"C:\\data\\rkn\\EvilFail.BAN", L"w");
if (!f) return 1;
fwprintf(f, L"RF st.#HZ\n");
fclose(f);
 number += 100000;}
if(s==1)
{
FILE *f = _wfopen(L"C:\\data\\rkn\\Cat.BAN", L"w");
if (!f) return 1;
fwprintf(f, L"RF st.#HZ\n");
fclose(f);
 number += 100000;}


    

    file = fopen("C:\\data\\solaryAdd", "w");


    if (file == NULL) {

        printf("\n");

        return 1;

    }


    //
    fprintf(file, "%d", number);


    fclose(file);


    printf("%d\n", number);

    return 0;
}