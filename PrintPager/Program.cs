using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var blockSize = 6;
var firstPage = 3;
var lastPage = 362;
var blockPages = blockSize * 4;
var totalPages = lastPage - firstPage + 1;
var totalBlocks = (totalPages + blockPages - 1) / blockPages;

for (var b = 0; b < totalBlocks; b++)
{
    var front = new List<int>();
    var back = new List<int>();

    var min = b * blockPages + 1;
    var max = min + blockPages - 1;

    for (var s = 0; s < blockSize; s++)
    {
        Add(front, max);
        Add(front, min);

        Add(back, min + 1);
        Add(back, max - 1);

        min += 2;
        max -= 2;
    }

    Console.WriteLine($"Блок {b + 1}");
    Console.WriteLine($"  Лицевые: {string.Join(",", front)}");
    Console.WriteLine($"  Задние : {string.Join(",", back)}");
}

void Add(List<int> list, int logicalPage)
{
    if (logicalPage < 1 || logicalPage > totalPages)
    {
        return;
    }

    list.Add(firstPage + logicalPage - 1);
}
