public static class CastleData
{
    public static int Eat;
    public static int Wood;
    public static int Gold;
    public static int UnitOneLevel;
    public static int UnitEquippedOneLevel;
 

    public static bool CheckValidationRes(TypeResource resource, int countCheckResource)
    {
        bool isValidate = false;
        switch (resource)
        {
            case TypeResource.Eat:
                isValidate = CheckDifference(Eat, countCheckResource);
                break;
            case TypeResource.Wood:
                isValidate = CheckDifference(Wood, countCheckResource);
                break;
            case TypeResource.Gold:
                isValidate = CheckDifference(Gold, countCheckResource);
                break;
        }

        return isValidate;
    }

    public static void RemoveResource(TypeResource resource, int countRemoveResource)
    {
        switch (resource)
        {
            case TypeResource.Eat:
                Eat = Eat - countRemoveResource;
                break;
            case TypeResource.Wood:
                Wood = Wood - countRemoveResource;
                break;
            case TypeResource.Gold:
                Gold = Gold - countRemoveResource;
                break;
        }
    }

    private static bool CheckDifference(int mainRes, int dopRes ) =>
        mainRes - dopRes >= 0 ? true : false;
}


public enum TypeResource
{
    Eat,
    Wood,
    Gold
}