using System;

namespace _Source.Scripts.Buildings
{
    public class BlockPlacementDto
    {
        public TowerBlockPreset Prefab;
        public Action OnPlacement;
    }
}