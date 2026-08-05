#include <iostream>
#include <string>
using namespace std;


void Update(const string& cmd);
bool command_is_run;
int main()
{
    std::cout << "READY" << std::endl;


    std::string line;

    while (getline(cin, line))
    {
		
		command_is_run =false;
        Update(line);
    }


    return 0;
}



void Update(const string& cmd)
{
    if (cmd == "FRAME"){
		cout << "No Chageing" << endl;
		command_is_run =true;
        return;
	}
    else if (cmd.rfind("INPUT", 0) == 0)
    {
        if (cmd.find("W=1") != string::npos)
        {
            cout << "MOVE 1 0 0 0,1" << endl;
			command_is_run = true;
        }
		if (cmd.find("D=1") != string::npos)
        {
            cout << "ROT 1 0 1 0" << endl;
			command_is_run = true;
        }
		if (cmd.find("A=1") != string::npos)
        {
            cout << "ROT 1 0 -1 0" << endl;
			command_is_run = true;
        }
		
		

        if (cmd.find("SPACEdw=1") != string::npos)
        {
            cout << "SPAWN AppleJuice 0 2 0" << endl;
			command_is_run =true;
        }
		if (cmd.find(" ") != string::npos) if(!command_is_run)
		{
			cout << "NULL" << endl;
			command_is_run =false;
		}
    }
	else
	{
		cout << "No Chageing maybe you write hui" << endl;
	}
}