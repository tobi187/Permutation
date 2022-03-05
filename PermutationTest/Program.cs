using System;
using System.Linq;
using PermutationTest.Models;


var file = File.ReadAllLines(@"C:\Users\fisch\Desktop\projects\ebay\Permutation\PermutationTest\testData.txt");

static List<Ebene> convertData(string[] input)
{
    List<Ebene> ebenen = new List<Ebene>();

    int ebenenCounter = 3;

    foreach (var line in input)
    {
        var parts = line.Split(" ");
        var ranNums = parts[0].Split(",").Select(int.Parse).ToArray();
        var vals = parts[1..parts.Length];
        Ebene ebene = new Ebene();
        int tableCounter = 0;
        foreach (var val in vals)
        {
            var values = val.Split(",").Select(int.Parse).ToArray();

            var table = new Table()
            {
                Count = tableCounter,
                InitalOrder = Enumerable.Range(0, values.Length).ToArray(),
                RandomNums = ranNums,
                Values = values
            };
            ebene.Count = ebenenCounter;
            ebene.Tables.Add(table);
            tableCounter++;
        }
        ebenen.Add(ebene);
        ebenenCounter--;
    }

    return ebenen;
}


var ebenen = convertData(file);

var result = new Ebene();

foreach (var ebene in ebenen)
{
    foreach (var table in ebene.Tables)
    {

    }
}