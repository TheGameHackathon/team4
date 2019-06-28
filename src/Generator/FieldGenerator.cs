using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.Generator
{
    public class FieldGenerator
    {
        public CardEntity[,] GenerateField(int width, int height)
        {
            var result = new CardEntity[width, height];
            var id = 0;
            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
            {
                result[x, y] = new CardEntity(id);
                id++;
            }

            return result;
            //var field = new CardEntity[width, height];
            //for(var x = 0; x < width; x++)
            //    for(var y = 0; y < height; y++)
            //        ...
            //return field;
        }
    }
}
