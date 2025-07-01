public static class StarRatingSystem
{
    public static int CalculateStarCount(float timeToWin, float maxTime)
    {
        if (timeToWin <= maxTime / 3f)
            return 1;
        else if (timeToWin <= maxTime * 2f / 3f)
            return 2;
        else
            return 3;
    }
}
