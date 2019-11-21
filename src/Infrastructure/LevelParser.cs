using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using thegame.Infrastructure;
using thegame.Models;

namespace thegame.Services
{
    public class LevelParser
    {
        public static Level ParseFromFile(string file)
        {
            var lines = File.ReadAllLines(file);
            List<CellDto> map = new List<CellDto>();
            int x = 0, y = 0, iterator = 1;
            string type = "";
            foreach (var singleLine in lines)
            {

                foreach (var symbol in singleLine.ToCharArray())
                {
                    switch (symbol)
                    {
                        case 'w':
                            type = "wall";
                            break;
                        case 's':
                            type = "space";
                            break;
                        case '*':
                            type = "star";
                            break;
                        case 'P':
                            type = "player";
                            break;
                        case '-':
                            type = "empty";
                            break;
                        case 'B':
                            type = "box";
                            break;

                    }

                    map.Add(
                        new CellDto(iterator.ToString(),
                            new Vec(x, y++),
                            type,
                            "",
                            iterator));


                }

                y = 0;
                x++;

            }

            return new Level(map.ToArray(), 8, 9);
        }
    }
}