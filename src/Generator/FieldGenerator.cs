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
            var result = new GameEntity[width, height];

            //var field = new CardEntity[width, height];
            //for(var x = 0; x < width; x++)
            //    for(var y = 0; y < height; y++)
            //        ...
            //return field;
        }
    }
}
