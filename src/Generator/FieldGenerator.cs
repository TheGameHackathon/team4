using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;
using thegame.Models.Dto;

namespace thegame.Generator
{
    public class FieldGenerator
    {
        public List<CardEntity> GenerateField(int width, int height)
        {
            var result = new List<CardEntity>();

            var id = 0;
            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
            {
                var cardEntity = new CardEntity(id / 2);
                cardEntity.Position = new PointDto() {X = x, Y = y};
                result.Add(cardEntity);
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