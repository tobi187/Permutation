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
                // ohne array spaß wenn man 1 table ordert ordern die anderen mit vf
                RandomNums = ranNums.ToArray(),
                Values = values.ToArray()
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

Computation c = new Computation(ebenen);

var o = c.RecursivePerm(ebenen.Count - 2, new List<IEnumerable<int>>(), new List<Result>());


static string[] Save(Result res)
{
    var op = new List<string>()
    {
        $"zufällig: {string.Join(", ", res.tables[0].RandomNums)} | {string.Join(", ", res.tables[1].RandomNums)} | {string.Join(", ", res.tables[2].RandomNums)}",
        $"werte:    {string.Join(", ", res.tables[0].Values)} | {string.Join(", ", res.tables[1].Values)} | {string.Join(", ", res.tables[2].Values)}",
        ""
    };

    foreach (var t in res.workFlow)
    {
        foreach (var v in t.Keys)
        {
            op.Add($"Tabelle {v} auf Tabelle {t[v]}");
        }
        op.Add("");
    }

    op.Add("______________________________________________________________________");
    op.Add("");

    return op.ToArray();
}

var w = o.Select(Save);

var weirdShit = new List<string>()
{
    $"Anzahl Ebenen: {ebenen.Count} | Anzahl Tabellen: {ebenen[0].Tables.Count} | Anzahl Ergebnisse: {o.Count}",
    $"_____________________________________________________________________________",
    ""
};

foreach (var d in w)
{
    foreach (var e in d)
    {
        weirdShit.Add(e);
    }
}

File.WriteAllLines(@"C:\Users\fisch\Desktop\testOpFirstTry.txt", weirdShit.ToArray());



var b = o.Select(x => x.workFlow);

var m = b.Distinct();

Console.WriteLine(m.Count());