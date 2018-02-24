using Mordor_Cruel_Plan.Foods;
using Mordor_Cruel_Plan.Moods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_Cruel_Plan.Factory
{
    public class Factory<TFactoryObject> : IFactory<TFactoryObject>
    {
        public TFactoryObject Manufacture(object type)
        {
            if (type is List<Food>)
                return (TFactoryObject)(object)new MoodFactory().Manufacture(type);
            else if (type is string)
                return (TFactoryObject)(object)new FoodFactory().Manufacture(type);

            else return default(TFactoryObject);
        }
    }
}
