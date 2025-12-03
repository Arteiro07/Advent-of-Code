using System.Runtime.CompilerServices;
Console.WriteLine("Day 01 - Part 1: " + part1());
Console.WriteLine("Day 02 - Part 2: " + part2());

long part1()
{
    
string projectRootPath = Directory.GetCurrentDirectory();
string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
string[] lines = File.ReadAllLines(inputFilePath);

int state = 50;
int password = 0;
foreach( string line in lines)
{
    if( line.StartsWith("L") )
    {
        state -= int.Parse(line[1..]);
    }
    else if( line.StartsWith("R") )
    {
        state += int.Parse(line[1..]);
    }

    if(state%100 == 0)
    {
        password++;
    }
}
return password;
}

long part2()
{
    
string projectRootPath = Directory.GetCurrentDirectory();
string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
string[] lines = File.ReadAllLines(inputFilePath);

int state = 50;
int prevState = state;
int password = 0;
int overflow = 0;
foreach( string line in lines)
{
    if( line.StartsWith("L") )
    {
        state -= int.Parse(line[1..]);
    }
    else if( line.StartsWith("R") )
    {
        state += int.Parse(line[1..]);
    }

    if( state >= 100 )
    {
        overflow = state%100;
        password+= state/100;
        state = overflow;
    }
    else if( state < 0 )
    {
        password += prevState == 0 ? 0 : 1;
        overflow = state%100;
        password += Math.Abs(state/100);
        state =  overflow == 0? 0: 100 + overflow;
    }
    else if( state == 0 )
    {
        password++;
    }
    
    prevState = state; 
}

return password;
}
