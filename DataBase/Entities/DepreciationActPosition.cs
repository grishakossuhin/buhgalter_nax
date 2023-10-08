using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class DepreciationActPosition
    {
        public Guid Id { get; set; }
        public DepreciationAct DepreciationAct { get; set; }
        public Os Os { get; set; }
    }
}
