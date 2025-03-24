namespace InventoryProject.Util
{
    public static class Extensions
    {
        public static string GetName(this Define.ItemIconMaterial material)
        {
            return material switch
            {
                Define.ItemIconMaterial.None  => "MT UI Icon Outline Trans",
                Define.ItemIconMaterial.Equip => "MT UI Icon Outline Yellow",
                _ => throw new System.ArgumentOutOfRangeException(nameof(material), material, null),
            };
        }
    }
}