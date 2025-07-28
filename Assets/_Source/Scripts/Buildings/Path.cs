using _Source.Scripts.Grid;

namespace _Source.Scripts.Buildings
{
    public class Path : Cell
    {
        public override bool HaveBuilding => false;
        public override bool CanPaceBuilding => false;
    }
}